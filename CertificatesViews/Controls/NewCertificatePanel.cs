using CertificatesModel;
using CertificatesModel.Authorization;
using CertificatesModel.Components;
using CertificatesModel.Interfaces;
using CertificatesModel.LoggingService;
using CertificatesModel.ScannerService;
using CertificatesViews.Factories;
using CertificatesViews.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CertificatesViews.Controls
{
    public partial class NewCertificatePanel : UserControl, INewCertificateView<byte[]>
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
        // Тип файла
        FileType _type;

        object[] _verificationMethodsCollection;

        public event EventHandler Changed = delegate { };

        // Конструктор
        public NewCertificatePanel()
        {
            InitializeComponent();

            cbVerifierName.Enabled = false;
            cbDocumentType.SelectedIndex = 0;
            cbVerifierName.SelectedIndex = 0;

            CreateAutoCompleteCollection();
        }

        // Загрузка превью из файла
        public void Build(string path)
        {
            var preview = AppLocator.GuiFactory.Create<IPreviewView<string>>();
            preview.Build(path);
            PreviewPanel = preview as Control;
            _byteArray = null;
            _type = FileType.pdf;
            CheckButtonState();
        }

        // Загрузка превью из массива байт(скана)
        public void Build(byte[] byteArray)
        {
            ParentForm.Text = "Добавление нового свидетельства";
            var preview = AppLocator.GuiFactory.Create<IPreviewView<byte[]>>();
            preview.Build(byteArray);
            PreviewPanel = preview as Control;
            CheckButtonState();
        }

        // Сканируем новый документ
        private void btScanNewDoc_Click(object sender, EventArgs e)
        {
            _type = FileType.pdf;
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
            ofd.Filter = "Документы PDF(*.pdf)|*.pdf|Изображения JPEG(*.jpg)|*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                labSourceFilePath.Text = ofd.FileName;
                Build(ofd.FileName);
                _byteArray = File.ReadAllBytes(ofd.FileName);

                if (ofd.FileName.ToLower().EndsWith(".jpg"))
                    _type = FileType.jpg;
                else
                    _type = FileType.pdf;

                CheckButtonState();
            }
        }

        // Добавление новых страниц к скану
        private void btAddNewPages_Click(object sender, EventArgs e)
        {
            _type = FileType.pdf;
            ScanHelper helper = new ScanHelper();
            var result = helper.AddPagesToScannedCertificate((byte[])_byteArray, cbDuplex.Checked);
            _byteArray = result;
            Build(result);
        }

        // Добавить свидетельство в базу
        private void btAdd_Click(object sender, EventArgs e)
        {
            // Формируем свидетельство
            var document = BuildNewDocument();

            if (document == null)
                return;

            // Проверяем выбран ли документ
            if (_byteArray == null)
            {
                MessageBox.Show("Отсканируйте новый документ, или выберите существующий.", "Некорректные входные данные", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            // Вносим свидетельство в базу
            var model = AppLocator.ModelFactory.Create<ICertificatesLoader>();
            var result = model.Create(document, (byte[])_byteArray, _type);

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

            // Логирование
            var message = new StringBuilder().AppendLine($"Пользователь {Authorization.CurrentUser.Login} ДОБАВИЛ в БД запись:");
            if (document.ContractNumber.Length > 0)
                message.Append(new string(' ', 31)).Append($"Номер договора: {document.ContractNumber}").AppendLine();
            if (document.RegisterNumber.Length > 0)
                message.Append(new string(' ', 31)).Append($"Номер в гос.реестре: {document.RegisterNumber}").AppendLine();
            if (document.VerificationMethod.Length > 0)
                message.Append(new string(' ', 31)).Append($"Методика поверки: {document.VerificationMethod}").AppendLine();
            if (document.ClientName.Length > 0)
                message.Append(new string(' ', 31)).Append($"Наименование заказчика: {document.ClientName}").AppendLine();
            if (document.ObjectName.Length > 0)
                message.Append(new string(' ', 31)).Append($"Наименование объекта эксплуатации: {document.ObjectName}").AppendLine();
            if (document.DeviceType.Length > 0)
                message.Append(new string(' ', 31)).Append($"Тип средства измерения: {document.DeviceType}").AppendLine();
            if (document.DeviceName.Length > 0)
                message.Append(new string(' ', 31)).Append($"Наименование средства измерения: {document.DeviceName}").AppendLine();
            if (document.SerialNumber.Length > 0)
                message.Append(new string(' ', 31)).Append($"Серийный номер: {document.SerialNumber}").AppendLine();
            if (document.CertificatePath.Length > 0)
                message.Append(new string(' ', 31)).Append($"Путь к файлу: {document.FullCertificatePath}").AppendLine();
            LoggingService.LogEvent(message.ToString());
            // ClearTextBoxes();
        }

        // очистка текстбоксов
        private void ClearTextBoxes()
        {
            tbCertificateNumber.Clear();
            tbContractNumber.Clear();
            tbRegisterNumber.Clear();
            tbSerialNumber.Clear();
            cbClientName.ResetText();
            cbDeviceName.ResetText();
            cbDeviceType.ResetText();
            cbObjectName.ResetText();
            cbVerificationMethod.ResetText();

            CreateAutoCompleteCollection();
        }

        // Создать свидетельство и проверить корректность введенных данных
        private Certificate BuildNewDocument()
        {
            Certificate document = new Certificate();
            document.Year = (int)numYear.Value;
            document.DocumentType = (DocumentType)cbDocumentType.SelectedIndex;
            document.CertificateNumber = tbCertificateNumber.Text.Trim();
            document.RegisterNumber = tbRegisterNumber.Text.Trim();
            document.VerificationMethod = cbVerificationMethod.Text.Trim();
            document.ContractNumber = tbContractNumber.Text.Trim();
            document.ClientName = cbClientName.Text.Trim();
            document.ObjectName = cbObjectName.Text.Trim();
            document.SerialNumber = tbSerialNumber.Text.Trim();
            document.DeviceType = cbDeviceType.Text.Trim();
            document.DeviceName = cbDeviceName.Text.Trim();
            document.CalibrationDate = dpCalibrationDate.Value.Date;
            if (cbDocumentType.SelectedIndex != 2)
                document.CalibrationExpireDate = dpCalibrationExpireDate.Value.Date;

            var validator = AppLocator.ModelFactory.Create<IValidationModel>();

            string result;

            if (cbDocumentType.SelectedIndex != 2)
                result = validator.ValidateDataModel(document);
            else
                result = validator.ValidateDataModelForFaultNotification(document);

            if (!string.IsNullOrEmpty(result))
            {
                MessageBox.Show(result, "Некорректные входные данные", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return null;
            }

            return document;
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
                //cbDocumentType.Enabled = true;
                cbVerifierName.Enabled = true;
            }
            else
            {
                //cbDocumentType.Enabled = false;
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
            var certificates = model.Read();
            // textboxes
            tbCertificateNumber.AutoCompleteCustomSource.AddRange(certificates.Select(x => x.CertificateNumber).Distinct().Where(x => x != null).ToArray());
            tbRegisterNumber.AutoCompleteCustomSource.AddRange(certificates.Select(x => x.RegisterNumber).Distinct().Where(x => x != null).ToArray());
            tbContractNumber.AutoCompleteCustomSource.AddRange(certificates.Select(x => x.ContractNumber).Distinct().Where(x => x != null).ToArray());
            tbSerialNumber.AutoCompleteCustomSource.AddRange(certificates.Select(x => x.SerialNumber).Distinct().Where(x => x != null).ToArray());
            // comboboxes
            cbClientName.Items.AddRange(certificates.Select(x => x.ClientName).Distinct().Where(x => x != null).ToArray());
            cbObjectName.Items.AddRange(certificates.Select(x => x.ObjectName).Distinct().Where(x => x != null).ToArray());
            cbDeviceType.Items.AddRange(certificates.Select(x => x.DeviceType).Distinct().Where(x => x != null).ToArray());
            cbDeviceName.Items.AddRange(certificates.Select(x => x.DeviceType).Distinct().Where(x => x != null).ToArray());

            if (!Directory.Exists(Settings.Instance.VerificateionMethodFolderPath))
                return;

            var filePaths = Directory.GetFiles(Settings.Instance.VerificateionMethodFolderPath);
            var verificationMethods = new List<string>();
            verificationMethods.Add("");

            foreach (var filePath in filePaths)
            {
                verificationMethods.Add(Path.GetFileNameWithoutExtension(filePath).ToLower());
            }

            _verificationMethodsCollection = verificationMethods.ToArray();
            cbVerificationMethod.Items.Clear();
            cbVerificationMethod.Items.AddRange(_verificationMethodsCollection);
        }

        // Автозаполнение при вводе номера в гос.реестре
        private void tbRegisterNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var text = ((TextBox)sender).Text;

            var model = AppLocator.ModelFactory.Create<ICertificatesLoader>();
            var certificates = model.Read();

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
                    cbVerificationMethod.Items.AddRange(_verificationMethodsCollection);
                    cbVerificationMethod.ResetText();
                }
                else if (verificationMethodCollection.Length == 1)
                {
                    cbVerificationMethod.Items.Clear();
                    cbVerificationMethod.Items.Add("");
                    cbVerificationMethod.Items.AddRange(verificationMethodCollection);
                    cbVerificationMethod.SelectedIndex = 1;
                }
                else
                {
                    cbVerificationMethod.ResetText();
                    cbVerificationMethod.Items.Clear();
                    cbVerificationMethod.Items.Add("");
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
            var certificates = model.Read();

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
                    //cbObjectName.ResetText();

                    cbClientName.Items.Clear();
                    cbClientName.Items.AddRange(certificates.Select(x => x.ClientName).Distinct().Where(x => x != null).ToArray());
                    //cbClientName.ResetText();
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

        // Выбор типа документа
        private void cbDocumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbDocumentType.SelectedIndex)
            {         
                case 2:
                    lbCalibrationExpireDate.Visible = false;
                    dpCalibrationExpireDate.Visible = false;
                    lbCertificateNumber.Text = "Номер извещения";
                    lbCalibrationDate.Text = "Дата оформления";
                    break;
                case 0:
                case 1:
                    lbCalibrationExpireDate.Visible = true;
                    dpCalibrationExpireDate.Visible = true;
                    lbCertificateNumber.Text = "Номер свидетельства";
                    lbCalibrationDate.Text = "Дата поверки";
                    break;
                default:
                    break;
            }
        }
    }
}
