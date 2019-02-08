using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WIA;
using System.Windows.Forms;
using CertificatesModel.Interfaces;

namespace CertificatesModel
{
    public struct PageSize
    {
        public double Height;
        public double Width;

        public PageSize(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }
    }

    class WIA_PROPERTIES
    {
        public const uint WIA_RESERVED_FOR_NEW_PROPS = 1024;
        public const uint WIA_DIP_FIRST = 2;
        public const uint WIA_DPA_FIRST = WIA_DIP_FIRST + WIA_RESERVED_FOR_NEW_PROPS;
        public const uint WIA_DPC_FIRST = WIA_DPA_FIRST + WIA_RESERVED_FOR_NEW_PROPS;
        //
        // Scanner only device properties (DPS)
        //
        public const uint WIA_DPS_FIRST = WIA_DPC_FIRST + WIA_RESERVED_FOR_NEW_PROPS;
        public const uint WIA_DPS_DOCUMENT_HANDLING_STATUS = WIA_DPS_FIRST + 13;
        public const uint WIA_DPS_DOCUMENT_HANDLING_SELECT = WIA_DPS_FIRST + 14;
    }

    public class Scanner : IScanner
    {
        ~Scanner()
        {
            GC.Collect();
        }

        //Image Filenames
        const string wiaFormatBMP = "{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}";
        const string wiaFormatPNG = "{B96B3CAF-0728-11D3-9D7B-0000F81EF32E}";
        const string wiaFormatGIF = "{B96B3CB0-0728-11D3-9D7B-0000F81EF32E}";
        const string wiaFormatJPEG = "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}";
        const string wiaFormatTIFF = "{B96B3CB1-0728-11D3-9D7B-0000F81EF32E}";

        //Standard Page Sizes
        public PageSize A3 = new PageSize(16.5, 11.7);
        public PageSize A4 = new PageSize(11.7, 8.3);
        public PageSize A5 = new PageSize(8.3, 5.8);
        public PageSize A6 = new PageSize(5.8, 4.1);

        public string _deviceID;

        #region Setup/select Scanner

        /// <summary>
        /// Select Scanner.
        /// If you need to save the Scanner, Save WiaWrapper.DeviceID
        /// </summary>
        public void SelectScanner()
        {
            WIA.CommonDialog wiaDiag = new WIA.CommonDialog();

            try
            {
                Device d = wiaDiag.ShowSelectDevice(WiaDeviceType.UnspecifiedDeviceType, true, false);
                if (d != null)
                {
                    _deviceID = d.DeviceID;
                    return;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error, Is a scanner chosen?");
            }

            throw new Exception("No Device Selected");
        }

        /// <summary>
        /// Connect to Scanning Device
        /// </summary>
        /// <param name="deviceID"></param>
        /// <returns></returns>

        private Device Connect()
        {
            //Device WiaDev = null;

            DeviceManager manager = new DeviceManager();

            //Iterate through each Device until correct Device found
            foreach (DeviceInfo info in manager.DeviceInfos)
            {
                if (info.DeviceID == _deviceID)
                {
                    Device WiaDev = info.Connect();

                    return WiaDev;
                }
            }

            throw new Exception("Scanner not found - Is it setup in DeviceID?");
        }

        #endregion

        #region Scanning utilities - hasMorePages, SetupPageSize, SetupADF, DeleteFile

        /// <summary>
        /// Check to see if ADF has more pages loaded
        /// </summary>
        /// <param name="wia"></param>
        /// <returns></returns>
        private bool HasMorePages()
        {

            //determine if there are any more pages waiting
            Device wia = Connect();

            var handlingSelect = wia.Properties["Document Handling Select"].get_Value();
            var handlingStatus = wia.Properties["Document Handling Status"].get_Value();

            if ((handlingSelect == 1 & handlingStatus == 3))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Setup Page Size
        /// </summary>
        /// <param name="wia"></param>
        private void SetupPageSize(Device wia, bool rotatePage, PageSize pageSize, int DPI, WIA.Item item)
        {

            item.Properties["6146"].set_Value(0); //4 is Black-white,gray is 2, color 1
            item.Properties["6147"].set_Value(DPI); //dots per inch/horizontal 
            item.Properties["6148"].set_Value(DPI); //dots per inch/vertical 
            item.Properties["6149"].set_Value(0); //x point where to start scan 
            item.Properties["6150"].set_Value(0); //y-point where to start scan 
            item.Properties["6151"].set_Value((int)(8.26 * DPI)); //horizontal exent for A4
            item.Properties["6152"].set_Value((int)(11.69 * DPI)); //vertical extent for A4
        }

        private void SetProperty(Property property, int value)
        {
            IProperty x = (IProperty)property;
            Object val = value;
            x.set_Value(ref val);
        }

        /// <summary>
        /// Setup device to Use ADF if required
        /// </summary>
        private void SetupADF(Device wia, bool duplex)
        {
            string adf = string.Empty;
            //        wia.Properties["Document Handling Select"].set_Value(5);
            foreach (WIA.Property deviceProperty in wia.Properties)
            {
                adf += deviceProperty.Name + "<br>";
                if (deviceProperty.Name == "Document Handling Status") //or PropertyID == 3087
                {
                    int value = duplex ? 0x001 : 0x001;
                    deviceProperty.set_Value(value);
                }
            }
        }

        #endregion

        #region Scan Page - Main Public Method



        /// <summary>
        /// Scan Page,
        /// </summary>
        /// <param name="duplex">Scan both sides of document</param>

        public IEnumerable<Image> Scan(bool duplex)
        {
            return Scan(A4, false, 300, true, duplex);
        }

        /// <summary>
        /// Scan Page,
        /// </summary>
        /// <param name="wia">Connected Device</param>
        /// <param name="pageSize">Page Size. A4, A3, A2 Etc</param>
        /// <param name="rotatePage">Rotation of page while scanning</param>
        public IEnumerable<Image> Scan(PageSize pageSize, bool rotatePage, int DPI, bool useAdf, bool duplex)
        {
            Timer timer = new Timer();
            int pages = 0;
            bool hasMorePages = false;
            IEnumerable<Image> imageList = new List<Image>();
            SortedDictionary<int, Image> imageDict = new SortedDictionary<int, Image>();

            SelectScanner();

            WIA.CommonDialog WiaCommonDialog = new WIA.CommonDialog();

            try
            {
                do
                {
                    //Connect to Device
                    Device wia = Connect();
                    WIA.Item item = wia.Items[1] as WIA.Item;
                    var status = wia.Properties["3087"].get_Value();
                    var select = wia.Properties["3088"].get_Value();
                    if (status == 3)
                        wia.Properties["3088"].set_Value(1);

                    //Setup Page Size
                    SetupPageSize(wia, rotatePage, pageSize, DPI, item);

                    ImageFile imgFile = null;
                    imgFile = ((ImageFile)WiaCommonDialog.ShowTransfer(item, wiaFormatJPEG, false));

                    imageDict.Add(pages, Image.FromStream(new MemoryStream(imgFile.FileData.get_BinaryData())));

                    //Check if duplex
                    if (duplex)
                    {
                        pages += 2;
                    }
                    else
                    {
                        pages++;
                    }

                    System.Threading.Thread.Sleep(2000);
                    hasMorePages = HasMorePages();

                    Device wia2 = Connect();

                    var status2 = wia2.Properties["3087"].get_Value();
                    var select2 = wia2.Properties["3088"].get_Value();

                }
                while (hasMorePages);

                if (duplex)
                {
                    MessageBox.Show("Будет выполнено оставшееся сканирование двухстороннего документа." +
                         Environment.NewLine + "Для сканирования другой стороны:" +
                         Environment.NewLine + "1. Извлеките страницы из выходного лотка. Не меняйте порядок страниц." +
                         Environment.NewLine + "2. Не переворачивая страницы поместите их в устройство АПД тем же передним краем (Верхним краем вперед). Возможно потребуется развернуть страницы." +
                         Environment.NewLine + "3. По окончанию нажмите \"OK\"", "Двухстороннее сканирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pages--;
                    do
                    {
                        //Connect to Device
                        Device wia = Connect();
                        WIA.Item item = wia.Items[1] as WIA.Item;

                        //Setup Page Size
                        SetupPageSize(wia, rotatePage, pageSize, DPI, item);

                        WIA.ImageFile imgFile = null;

                        imgFile = (ImageFile)WiaCommonDialog.ShowTransfer(item, wiaFormatJPEG, false);
                        Image newImage = Image.FromStream(new MemoryStream(imgFile.FileData.get_BinaryData()));
                        newImage.RotateFlip(RotateFlipType.Rotate180FlipNone);

                        imageDict.Add(pages, newImage);

                        pages -= 2;

                        System.Threading.Thread.Sleep(2000);

                        hasMorePages = HasMorePages();
                    }
                    while (hasMorePages);
                }
                imageList = imageDict.Select(x => x.Value).ToList();

                return imageList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
