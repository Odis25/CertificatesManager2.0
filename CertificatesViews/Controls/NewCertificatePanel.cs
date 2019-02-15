using CertificatesModel;
using CertificatesModel.Interfaces;
using CertificatesModel.ScannerService;
using CertificatesViews.Factories;
using CertificatesViews.Interfaces;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
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
            cbDocumentType.SelectedIndex = 0;
            cbVerifierName.SelectedIndex = 0;

            CreateAutoCompleteCollection();
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
            ParentForm.Text = "Добавление новог свидетельства";
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
                Build(ofd.FileName);
                _byteArray = File.ReadAllBytes(ofd.FileName);
                CheckButtonState();
            }
        }

        // Добавление новых страниц к скану
        private void btAddNewPages_Click(object sender, EventArgs e)
        {
            ScanHelper helper = new ScanHelper();
            var result = helper.AddPagesToScannedCertificate((byte[])_byteArray, cbDuplex.Checked);
            _byteArray = result;
            Build(result);
        }

        // Добавить свидетельство в базу
        private void btAdd_Click(object sender, EventArgs e)
        {
            // Формируем свидетельство
            var certificate = BuildNewCertificate();
            if (certificate == null)
                return;

            // Вносим свидетельство в базу
            var model = AppLocator.ModelFactory.Create<ICertificatesLoader>();
            var result = model.AddNewCertificate(certificate, (byte[])_byteArray);
            if (!result)
            {
                MessageBox.Show("Такое свидетельство уже есть в базе.", "Результат операции", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Резервное копирование свидетельства
            if (cbZipCopyEnabled.Checked)
                if (!CreateZipCopy())
                    MessageBox.Show("Не удалось создать резервную копию файла", "Результат операции", MessageBoxButtons.OK, MessageBoxIcon.Error);

            MessageBox.Show("Свидетельство успешно добавлено в базу.", "Результат операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Создать свидетельство и проверить корректность введенных данных
        private Certificate BuildNewCertificate()
        {
            Certificate certificate = new Certificate();
            certificate.Year = (int)numYear.Value;
            certificate.CertificateNumber = tbCertificateNumber.Text.Trim();
            certificate.RegisterNumber = tbRegisterNumber.Text.Trim();
            certificate.VerificationMethod = cbVerificationMethod.Text.Trim();
            certificate.ContractNumber = tbContractNumber.Text.Trim();
            certificate.ClientName = cbClientName.Text.Trim();
            certificate.ObjectName = cbObjectName.Text.Trim();
            certificate.SerialNumber = tbSerialNumber.Text.Trim();
            certificate.DeviceType = cbDeviceType.Text.Trim();
            certificate.DeviceName = cbDeviceName.Text.Trim();
            certificate.CalibrationDate = dpCalibrationDate.Value.Date;
            certificate.CalibrationExpireDate = dpCalibrationExpireDate.Value.Date;

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

        // Создать резервную копию
        private bool CreateZipCopy()
        {
            try
            {
                var halfYear = DateTime.Now.Month > 6 ? "2 полугодие" : "1 полугодие";
                var dir = Path.Combine(Settings.Instance.CertificatesZipFolderPath, numYear.Value.ToString(), halfYear, cbVerifierName.SelectedItem.ToString());
                // Если каталога с таким именем нет - создаем
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                var certNumber = tbCertificateNumber.Text.Split('-').Length > 1 ? tbCertificateNumber.Text.Split('-')[1] : tbCertificateNumber.Text;
                var fileName = $"{cbDocumentType.SelectedItem.ToString()}_№{certNumber}";
                var extension = ".pdf";
                var path = Path.Combine(dir, fileName + extension);

                // Записываем в созданный файл данные в бинарном формате
                using (BinaryWriter writer = new BinaryWriter(File.Create(path)))
                {
                    writer.Write((byte[])_byteArray);
                    writer.Flush();
                    writer.Close();
                }
                // файл создан
                return true;
            }
            catch
            {
                //файл не создан
                return false;
            }
        }

        // Состояние комбобоксов
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

        // Состояние кнопок
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

        // Заполнение AutoCompleteCustomSource для textbox и Items для ComboBox
        private void CreateAutoCompleteCollection()
        {
            var model = AppLocator.ModelFactory.Create<ICertificatesLoader>();
            var certificates = model.GetAllCertificates();
            // textboxes
            tbCertificateNumber.AutoCompleteCustomSource.AddRange(certificates.Select(x => x.CertificateNumber).Distinct().Where(x => x != null).ToArray());
            tbRegisterNumber.AutoCompleteCustomSource.AddRange(certificates.Select(x => x.RegisterNumber).Distinct().Where(x => x != null).ToArray());
            tbContractNumber.AutoCompleteCustomSource.AddRange(certificates.Select(x => x.ContractNumber).Distinct().Where(x => x != null).ToArray());
            tbSerialNumber.AutoCompleteCustomSource.AddRange(certificates.Select(x => x.SerialNumber).Distinct().Where(x => x != null).ToArray());
            // comboboxes
            cbClientName.Items.AddRange(certificates.Select(x => x.ClientName).Distinct().Where(x => x != null).ToArray());
            cbObjectName.Items.AddRange(certificates.Select(x => x.ObjectName).Distinct().Where(x => x != null).ToArray());
            cbVerificationMethod.Items.AddRange(certificates.Select(x => x.VerificationMethod).Distinct().Where(x => x != null).ToArray());
            cbDeviceType.Items.AddRange(certificates.Select(x => x.DeviceType).Distinct().Where(x => x != null).ToArray());
            cbDeviceName.Items.AddRange(certificates.Select(x => x.DeviceType).Distinct().Where(x => x != null).ToArray());
        }

        // Автозаполнение при вводе номера в гос.реестре
        private void tbRegisterNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var text = ((TextBox)sender).Text;

            var model = AppLocator.ModelFactory.Create<ICertificatesLoader>();
            var certificates = model.GetAllCertificates();

            if (!string.IsNullOrWhiteSpace(text))
            {
                // Наименование СИ
                var deviceNamesCollection = certificates.Where(x => x.RegisterNumber == text).Select(x => x.DeviceName).Distinct().ToArray();

                if (deviceNamesCollection.Length == 0)
                {
                    cbDeviceName.Items.Clear();
                    cbDeviceName.Items.AddRange(certificates.Select(x => x.DeviceType).Distinct().Where(x => x != null).ToArray());
                    cbDeviceName.ResetText();
                }
                else if (deviceNamesCollection.Length == 1)
                {
                    cbDeviceName.Items.Clear();
                    cbDeviceName.Items.AddRange(deviceNamesCollection);
                    cbDeviceName.SelectedIndex = 0;
                }
                else
                {
                    cbDeviceName.ResetText();
                    cbDeviceName.Items.Clear();
                    cbDeviceName.Items.AddRange(deviceNamesCollection);
                }

                // Методика поверки
                var verificationMethodCollection = certificates.Where(x => x.RegisterNumber == text && x.VerificationMethod != "").Select(x => x.VerificationMethod).Distinct().ToArray();

                if (verificationMethodCollection.Length == 0)
                {
                    cbVerificationMethod.Items.Clear();
                    cbVerificationMethod.Items.AddRange(certificates.Select(x => x.VerificationMethod).Distinct().Where(x => x != null).ToArray());
                    cbVerificationMethod.ResetText();
                }
                else if (verificationMethodCollection.Length == 1)
                {
                    cbVerificationMethod.Items.Clear();
                    cbVerificationMethod.Items.AddRange(verificationMethodCollection);
                    cbVerificationMethod.SelectedIndex = 0;
                }
                else
                {
                    cbVerificationMethod.ResetText();
                    cbVerificationMethod.Items.Clear();
                    cbVerificationMethod.Items.AddRange(verificationMethodCollection);
                }

                // Группа СИ
                var deviceTypeCollection = certificates.Where(x => x.RegisterNumber == text).Select(x => x.DeviceType).Distinct().ToArray();

                if (deviceTypeCollection.Length == 0)
                {
                    cbDeviceType.Items.Clear();
                    cbDeviceType.Items.AddRange(certificates.Select(x => x.DeviceType).Distinct().Where(x => x != null).ToArray());
                    cbDeviceType.ResetText();
                }
                else if (deviceTypeCollection.Length == 1)
                {
                    cbDeviceType.Items.Clear();
                    cbDeviceType.Items.AddRange(deviceTypeCollection);
                    cbDeviceType.SelectedIndex = 0;
                }
                else
                {
                    cbDeviceType.ResetText();
                    cbDeviceType.Items.Clear();
                    cbDeviceType.Items.AddRange(deviceTypeCollection);
                }
            }
            else
            {
                cbDeviceName.Items.Clear();
                cbDeviceName.Items.AddRange(certificates.Select(x => x.DeviceType).Distinct().Where(x => x != null).ToArray());
                cbVerificationMethod.Items.Clear();
                cbVerificationMethod.Items.AddRange(certificates.Select(x => x.VerificationMethod).Distinct().Where(x => x != null).ToArray());
                cbDeviceType.Items.Clear();
                cbDeviceType.Items.AddRange(certificates.Select(x => x.DeviceType).Distinct().Where(x => x != null).ToArray());
            }
        }

        // Автозаполнение при вводе серийного номера
        private void tbSerialNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var text = ((TextBox)sender).Text;

            var model = AppLocator.ModelFactory.Create<ICertificatesLoader>();
            var certificates = model.GetAllCertificates();

            if (!string.IsNullOrWhiteSpace(text))
            {
                // Наименование объекта
                var objectCollection = certificates.Where(x => x.SerialNumber == text).Select(x => x.ObjectName).Distinct().ToArray();
                // Наименование заказчика
                var clientCollection = certificates.Where(x => x.SerialNumber == text).Select(x => x.ClientName).Distinct().ToArray();

                if (objectCollection.Length == 0)
                {
                    cbObjectName.Items.Clear();
                    cbObjectName.Items.AddRange(certificates.Select(x => x.ObjectName).Distinct().Where(x => x != null).ToArray());
                    cbObjectName.ResetText();

                    cbClientName.Items.Clear();
                    cbClientName.Items.AddRange(certificates.Select(x => x.ClientName).Distinct().Where(x => x != null).ToArray());
                    cbClientName.ResetText();
                }
                else if (objectCollection.Length == 1)
                {
                    cbObjectName.Items.Clear();
                    cbObjectName.Items.AddRange(objectCollection);
                    cbObjectName.SelectedIndex = 0;

                    cbClientName.Items.Clear();
                    cbClientName.Items.AddRange(clientCollection);
                    cbClientName.SelectedIndex = 0;
                }
                else
                {
                    cbObjectName.ResetText();
                    cbObjectName.Items.Clear();
                    cbObjectName.Items.AddRange(objectCollection);

                    cbClientName.ResetText();
                    cbClientName.Items.Clear();
                    cbClientName.Items.AddRange(clientCollection);
                }
            }
            else
            {
                cbObjectName.Items.Clear();
                cbClientName.Items.Clear();
                cbObjectName.Items.AddRange(certificates.Select(x => x.ObjectName).Distinct().Where(x => x != null).ToArray());
                cbClientName.Items.AddRange(certificates.Select(x => x.ClientName).Distinct().Where(x => x != null).ToArray());
            }            
        }

        // Отрисовка подсказки для Items в комбобоксе
        private void combobox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox currentBox = (ComboBox)sender;

            if (e.Index == -1)
                return;

            string text = currentBox.GetItemText(currentBox.Items[e.Index]);
            e.DrawBackground();
            using (SolidBrush br = new SolidBrush(e.ForeColor))
            {
                e.Graphics.DrawString(text, e.Font, br, e.Bounds);
            }

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                tipVerificationMethodItems.Show(text, currentBox, e.Bounds.Right, e.Bounds.Bottom);
            }
            else
            {
                tipVerificationMethodItems.Hide(currentBox);
            }
            e.DrawFocusRectangle();
        }
        // Скрыть подсказку при закрытии комбобокса
        private void combobox_DropDownClosed(object sender, EventArgs e)
        {
            tipVerificationMethodItems.Hide(cbVerificationMethod);
        }
    }
}
