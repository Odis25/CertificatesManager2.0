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

            cbDocumentType.Enabled = false;
            cbVerifierName.Enabled = false;
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
            //TODO: проверить
            _byteArray = File.ReadAllBytes(ofd.FileName);
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

        // Добавить свидетельство в базу
        private void btAdd_Click(object sender, EventArgs e)
        {
            // Создаем свидетельство и проверяем его
            var certificate = BuildNewCertificate();

            var model = AppLocator.ModelFactory.Create<ICertificatesLoader>();
            model.AddNewCertificate(certificate, (byte[])_byteArray);

            MessageBox.Show("Свидетельство успешно добавлено в базу.", "Результат операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            string result;

            if (cbZipCopyEnabled.Checked)
                result = validator.ValidateDataModelForZip(certificate);
            else
                result = validator.ValidateDataModel(certificate);

            if (!string.IsNullOrEmpty(result))
            {
                MessageBox.Show(result, "Некорректные входные данные", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return null;
            }

            return certificate;
        }

        private void cbZipCopyEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (cbZipCopyEnabled.Checked)
            {
                cbDocumentType.Enabled = true;
                cbVerifierName.Enabled = true;
            }
            else
            {
                cbDocumentType.Enabled = false;
                cbVerifierName.Enabled = false;
            }
        }
    }
}
