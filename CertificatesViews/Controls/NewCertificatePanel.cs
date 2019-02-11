using CertificatesModel;
using CertificatesModel.Interfaces;
using CertificatesModel.ScannerService;
using CertificatesViews.Factories;
using CertificatesViews.Interfaces;
using System;
using System.IO;
using System.Windows.Forms;

namespace CertificatesViews.Controls
{
    public partial class NewCertificatePanel : UserControl, ICreateNewView<byte[]>
    {
        Control _previewPanel;
        Control PreviewPanel
        {
            get
            {
                return _previewPanel;
            }
            set
            {
                if (_previewPanel != null)
                    _previewPanel.Dispose();

                _previewPanel = value;
                if (_previewPanel != null)
                {
                    value.Dock = DockStyle.Fill;
                    value.Parent = panPreview;
                    value.BringToFront();
                }
            }
        }

        // Объект для хранения pdf документа
        object _byteArray;

        public event EventHandler Changed = delegate { };

        // Конструктор
        public NewCertificatePanel()
        {
            InitializeComponent();
        }

        // Загрузка превью из файла
        public void Build(string path)
        {
            var preview = AppLocator.GuiFactory.Create<IView<string>>();
            preview.Build(path);
            PreviewPanel = preview as Control;
            _byteArray = null;
            CheckButtonState();
        }

        // Загрузка превью из массива байт(скана)
        public void Build(byte[] byteArray)
        {
            var preview = AppLocator.GuiFactory.Create<IView<byte[]>>();
            preview.Build(byteArray);
            PreviewPanel = preview as Control;
            CheckButtonState();
        }

        // Сканируем новый документ
        private void btScanNewDoc_Click(object sender, EventArgs e)
        {
            ScanHelper helper = new ScanHelper();
            var byteArray = helper.ScanNewCertificate(cbDuplex.Checked);
            _byteArray = byteArray;
            Build(byteArray);
            CheckButtonState();
        }

        // Выбираем существующее свидетельство
        private void btSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Title = "Выберите файл свидетельства о поверке:";
            ofd.Filter = "Документы PDF(*.pdf)|*.pdf";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                labSourceFilePath.Text = ofd.FileName;
            }
            Build(ofd.FileName);
            CheckButtonState();
        }

        // Добавление новых страниц к скану
        private void btAddNewPages_Click(object sender, EventArgs e)
        {
            ScanHelper helper = new ScanHelper();
            var result = helper.AddPagesToScannedCertificate((byte[])_byteArray, cbDuplex.Checked);
            _byteArray = result;
            Build(result);
        }

        private void CheckButtonState()
        {
            if (_byteArray == null)
            {
                btAddNewPages.Enabled = false;
            }
            else
            {
                btAddNewPages.Enabled = true;
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            // Создаем свидетельство и проверяем его
            var certificate = BuildNewCertificate();
            // Проверить правильность введенных данных
            // Сформировать путь к файлу
            // Проверить нужно ли делать резервное копирование
            // Если да:
            // // Проверить правильность данных для резервной копии
            // // Сформировать путь к новому файлу в резервной папке
            // // Внести свидетельство в 
            // Если нет:
            // // Внести свидетельство в базу 
        }

        private Certificate BuildNewCertificate()
        {
            Certificate certificate = new Certificate();
            certificate.Year = (int)numYear.Value;
            certificate.CertificateNumber = tbCertificateNumber.Text;
            certificate.RegisterNumber = tbRegisterNumber.Text;
            certificate.VerificationMethod = cbVerificationMethod.Text;
            certificate.ContractNumber = tbContractNumber.Text;
            certificate.ClientName = tbClientName.Text;
            certificate.ObjectName = tbObjectName.Text;
            certificate.SerialNumber = tbSerialNumber.Text;
            certificate.DeviceType = tbDeviceType.Text;
            certificate.DeviceName = tbDeviceName.Text;
            certificate.CalibrationDate = dpCalibrationDate.Value;
            certificate.CalibrationExpireDate = dpCalibrationExpireDate.Value;

            var validator = AppLocator.ModelFactory.Create<IValidationModel>();
            var result = validator.ValidateDataModel(certificate);
            if (!string.IsNullOrEmpty(result))
            {
                MessageBox.Show(result, "Некорректные входные данные", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return null;
            }

            var illegalChars = Path.GetInvalidFileNameChars();

            return certificate;
        }
    }
}
