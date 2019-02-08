using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WIA;

namespace CertificatesModel.ScannerService
{
    internal class Scanner
    {
        //Image Filenames
        const string wiaFormatBMP = "{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}";
        const string wiaFormatPNG = "{B96B3CAF-0728-11D3-9D7B-0000F81EF32E}";
        const string wiaFormatGIF = "{B96B3CB0-0728-11D3-9D7B-0000F81EF32E}";
        const string wiaFormatJPEG = "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}";
        const string wiaFormatTIFF = "{B96B3CB1-0728-11D3-9D7B-0000F81EF32E}";

        //Standard Page Sizes
        PageSize A3 = new PageSize(16.5, 11.7);
        PageSize A4 = new PageSize(11.69, 8.26);
        PageSize A5 = new PageSize(8.3, 5.8);
        PageSize A6 = new PageSize(5.8, 4.1);

        private Device _wiaDevice;

        private bool HasMorePages
        {
            get
            {
                System.Threading.Thread.Sleep(2000);
                _wiaDevice = Connect();

                var handlingSelect = _wiaDevice.Properties["Document Handling Select"].get_Value();
                var handlingStatus = _wiaDevice.Properties["Document Handling Status"].get_Value();

                if ((handlingSelect == 1 & handlingStatus == 3))
                    return true;
                else
                    return false;
            }
        }

        private Device Connect()
        {
            DeviceManager manager = new DeviceManager();

            //Iterate through each Device until correct Device found
            foreach (DeviceInfo info in manager.DeviceInfos)
            {
                if (info.DeviceID == _wiaDevice.DeviceID)
                {
                    return info.Connect();
                }
            }
            throw new Exception("Scanner not found - Is it setup in DeviceID?");
        }

        // Конструктор класса
        public Scanner()
        {
            _wiaDevice = new WIA.CommonDialog().ShowSelectDevice(WiaDeviceType.ScannerDeviceType, true, false);
        }

        public IEnumerable<Image> Scan(bool duplex)
        {
            return Scan(A4, false, 300, duplex);
        }

        private IEnumerable<Image> Scan(PageSize pageSize, bool rotatePage, int DPI, bool duplex)
        {
            int pages = 0;

            SortedDictionary<int, Image> imageDict = new SortedDictionary<int, Image>();

            WIA.CommonDialog WiaCommonDialog = new WIA.CommonDialog();

            try
            {
                do
                {
                    //Connect to Device
                    Item item = _wiaDevice.Items[1] as Item;

                    //Setup Page Size
                    SetupPageSize(_wiaDevice, rotatePage, pageSize, DPI, item);

                    ImageFile imgFile = ((ImageFile)WiaCommonDialog.ShowTransfer(item, wiaFormatJPEG, false));

                    imageDict.Add(pages, Image.FromStream(new MemoryStream(imgFile.FileData.get_BinaryData())));

                    GC.Collect();
                    
                    //Check if duplex
                    if (duplex)
                    {
                        pages += 2;
                    }
                    else
                    {
                        pages++;
                    }
                }
                while (HasMorePages);

                if (duplex)
                {
                    MessageBox.Show(new StringBuilder().AppendLine("Будет выполнено оставшееся сканирование двухстороннего документа.")
                                                       .AppendLine("Для сканирования другой стороны:")
                                                       .AppendLine("1. Извлеките страницы из выходного лотка. Не меняйте порядок страниц.")
                                                       .AppendLine("2. Не переворачивая страницы поместите их в устройство АПД тем же передним краем (Верхним краем вперед). Возможно потребуется развернуть страницы.")
                                                       .Append("3. По окончанию нажмите \"OK\"")
                                                       .ToString(), "Двухстороннее сканирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pages--;

                    if (HasMorePages)
                    {
                        do
                        {
                            //Connect to Device
                            Item item = _wiaDevice.Items[1] as Item;

                            //Setup Page Size
                            SetupPageSize(_wiaDevice, rotatePage, pageSize, DPI, item);

                            ImageFile imgFile = (ImageFile)WiaCommonDialog.ShowTransfer(item, wiaFormatJPEG, false);

                            Image newImage = Image.FromStream(new MemoryStream(imgFile.FileData.get_BinaryData()));
                            // Переворачиваем изображение
                            newImage.RotateFlip(RotateFlipType.Rotate180FlipNone);

                            imageDict.Add(pages, newImage);

                            pages -= 2;
                        }
                        while (HasMorePages);
                    }
                }

                return imageDict.Values;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Параметры сканируемой страницы
        private void SetupPageSize(Device wia, bool rotatePage, PageSize pageSize, int DPI, WIA.Item item)
        {
            item.Properties["6146"].set_Value(0); //4 is Black-white,gray is 2, color 1
            item.Properties["6147"].set_Value(DPI); //dots per inch/horizontal 
            item.Properties["6148"].set_Value(DPI); //dots per inch/vertical 
            item.Properties["6149"].set_Value(0); //x point where to start scan 
            item.Properties["6150"].set_Value(0); //y-point where to start scan 
            item.Properties["6151"].set_Value((int)(pageSize.Width * DPI)); //horizontal exent for A4
            item.Properties["6152"].set_Value((int)(pageSize.Height * DPI)); //vertical extent for A4
        }

        // Вспомогательная структура для задания размеров страниц
        private struct PageSize
        {
            public double Height;
            public double Width;

            public PageSize(double height, double width)
            {
                Height = height;
                Width = width;
            }
        }
    }
}
