using CertificatesModel;
using CertificatesModel.Authorization;
using CertificatesModel.Components;
using CertificatesModel.Interfaces;
using CertificatesModel.LoggingService;
using CertificatesModel.MailService;
using CertificatesViews.Factories;
using CertificatesViews.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CertificatesViews.Controls
{
    public partial class CertificatesPanel : UserControl, ICertificatePanelView<Certificates>
    {
        Control _propertyControl;
        Control _previewControl;
        Certificates _certificates;
        Certificates _selectedCertificates;

        // Список отслеживаемых свидетельств 
        private HashSet<Certificate> _tracedCertificates;

        // Событие на изменение
        public event EventHandler Changed = delegate { };
        public event EventHandler ShowOrHidePreview = delegate { };

        // Панель предпросмотра 
        public Control PreviewControl
        {
            get { return _previewControl; }
            set
            {
                if (_previewControl != null)
                    _previewControl.Dispose();
                _previewControl = value;
                if (_previewControl != null)
                {
                    value.Dock = DockStyle.Fill;
                    value.Parent = panPreview;
                    value.BringToFront();
                }
            }
        }

        // Панель детализированной информации о свидетельстве
        public Control PropertyControl
        {
            get { return _propertyControl; }
            set
            {
                if (_propertyControl != null)
                    _propertyControl.Dispose();
                _propertyControl = value;
                if (_propertyControl != null)
                {
                    value.Dock = DockStyle.Fill;
                    scMainSpliter.SplitterDistance = value.Height;

                    value.Parent = scSecondarySpliter.Panel2;
                    value.BringToFront();
                }
            }
        }

        // Конструктор
        public CertificatesPanel()
        {
            InitializeComponent();

            SetUserRights();

            Authorization.UserChanged += (s, e) => SetUserRights();
        }

        public void Refresh(Certificates certificates)
        {
            _certificates = certificates;
        }

        // Передача данных в форму
        public void Build(Certificates certificates)
        {
            Refresh(certificates);

            // Заполняем узлами TreeView
            BuildTreeView();

            // Построение панели свойств свидетельства
            BuildProperty();

            // Показать всплывающую подсказку в трее
            ShowTrayToolTip();
        }

        // Заполняем узлами TreeView
        private void BuildTreeView()
        {
            tvCertificates.BeginUpdate();
            tvCertificates.Nodes.Clear();
            tvCertificates.AddCertificates(_certificates);
            tvCertificates.DeserializeNodeState();
            tvCertificates.EndUpdate();
            // Формируем список отслеживаемых свидетельств 
            SetTracedCertificates();
        }

        // Построение панели свойств свидетельства
        private void BuildProperty()
        {
            var view = AppLocator.GuiFactory.Create<ICertificatePropertiesPanelView<Certificate, Certificates>>();
            view.Build(new Certificate(), _certificates);
            view.Search += CertificatesPanel_Search;
            view.Deleted += CertificatesPanel_Deleted;
            view.Edited += CertificatesPanel_Edited;
            PropertyControl = view as Control;

            // Показать/скрыть панель предпросмотра
            ShowOrHidePreviewPanel();
        }

        // Внесение изменений в свидетельство
        private void CertificatesPanel_Edited(object sender, EventArgs e)
        {
            var model = AppLocator.ModelFactory.Create<ICertificatesLoader>();
            var editPattern = e as CertificateEventArgs;
            var unmodifiedCertificate = model.Update(editPattern);

            BuildTreeView();
            Changed(this, EventArgs.Empty);
            dgvCerts.Refresh();

            // Логирование
            var message = new StringBuilder().AppendLine($"Пользователь {Authorization.CurrentUser.Login} ВНЕС ИЗМЕНЕНИЯ в БД для записи ID = {editPattern.ID}:");
            if (editPattern.Year != unmodifiedCertificate.Year)
                message.Append(new string(' ', 31)).Append($"Год был изменен с '{unmodifiedCertificate.Year}' на '{editPattern.Year}'").AppendLine();
            if (editPattern.DocumentType != unmodifiedCertificate.DocumentType)
                message.Append(new string(' ', 31)).Append($"Тип документа был изменен с '{unmodifiedCertificate.DocumentTypeString}' на '{editPattern.DocumentTypeString}'").AppendLine();
            if (editPattern.ContractNumber != unmodifiedCertificate.ContractNumber)
                message.Append(new string(' ', 31)).Append($"Номер договора был изменен с '{unmodifiedCertificate.ContractNumber}' на '{editPattern.ContractNumber}'").AppendLine();
            if (editPattern.CertificateNumber != unmodifiedCertificate.CertificateNumber)
                message.Append(new string(' ', 31)).Append($"Номер свидетельства был изменен с '{unmodifiedCertificate.CertificateNumber}' на '{editPattern.CertificateNumber}'").AppendLine();
            if (editPattern.RegisterNumber != unmodifiedCertificate.RegisterNumber)
                message.Append(new string(' ', 31)).Append($"Номер в Гос.реестре был изменен с '{unmodifiedCertificate.RegisterNumber}' на '{editPattern.RegisterNumber}'").AppendLine();
            if (editPattern.VerificationMethod != unmodifiedCertificate.VerificationMethod)
                message.Append(new string(' ', 31)).Append($"Методика поверки была изменена с '{unmodifiedCertificate.VerificationMethod}' на '{editPattern.VerificationMethod}'").AppendLine();
            if (editPattern.ClientName != unmodifiedCertificate.ClientName)
                message.Append(new string(' ', 31)).Append($"Наименование заказчика было изменено с '{unmodifiedCertificate.ClientName}' на '{editPattern.ClientName}'").AppendLine();
            if (editPattern.ObjectName != unmodifiedCertificate.ObjectName)
                message.Append(new string(' ', 31)).Append($"Наименование объекта эксплуатации было изменено с '{unmodifiedCertificate.ObjectName}' на '{editPattern.ObjectName}'").AppendLine();
            if (editPattern.DeviceType != unmodifiedCertificate.DeviceType)
                message.Append(new string(' ', 31)).Append($"Группа СИ была изменена с '{unmodifiedCertificate.DeviceType}' на '{editPattern.DeviceType}'").AppendLine();
            if (editPattern.DeviceName != unmodifiedCertificate.DeviceName)
                message.Append(new string(' ', 31)).Append($"Наименование СИ было изменено с '{unmodifiedCertificate.DeviceName}' на '{editPattern.DeviceName}'").AppendLine();
            if (editPattern.SerialNumber != unmodifiedCertificate.SerialNumber)
                message.Append(new string(' ', 31)).Append($"Сенийный номер был изменен с '{unmodifiedCertificate.SerialNumber}' на '{editPattern.SerialNumber}'").AppendLine();
            if (editPattern.CalibrationDate != unmodifiedCertificate.CalibrationDate)
                message.Append(new string(' ', 31)).Append($"Дата поверки был изменена с '{unmodifiedCertificate.CalibrationDate}' на '{editPattern.CalibrationDate}'").AppendLine();
            if (editPattern.CalibrationExpireDate != unmodifiedCertificate.CalibrationExpireDate)
                message.Append(new string(' ', 31)).Append($"Дата окончания срока поверки была изменена с '{unmodifiedCertificate.CalibrationExpireDate}' на '{editPattern.CalibrationExpireDate}'").AppendLine();
            if (editPattern.CertificatePath != unmodifiedCertificate.CertificatePath)
                message.Append(new string(' ', 31)).Append($"Путь к файлу был изменен с '{unmodifiedCertificate.CertificatePath}' на '{editPattern.CertificatePath}'").AppendLine();
            LoggingService.LogEvent(message.ToString());
            MessageBox.Show("Изменения в свидетельство успешно внесены.", "Операция изменения", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Удаление выбранных свидетельств
        private void CertificatesPanel_Deleted(object sender, EventArgs e)
        {
            // Проверяем есть ли какие то свидетельства
            if (dgvCerts.RowCount == 0)
                return;

            // Создаем и заполняем массив Id 
            var id = new List<int>();

            foreach (DataGridViewRow row in dgvCerts.SelectedRows)
            {
                id.Add((int)row.Cells[0].Value);
            }

            // Передаем массив Id в модель
            var model = AppLocator.ModelFactory.Create<ICertificatesLoader>();
            model.Delete(id.ToArray());

            // Убираем удаленные элементы из выборки
            for (int i = 0; i < id.Count; i++)
            {
                var cert = _selectedCertificates.FirstOrDefault(x => x.ID == id[i]);
                _selectedCertificates.Remove(cert);                
                // Логирование
                var message = new StringBuilder().AppendLine($"Пользователь {Authorization.CurrentUser.Login} УДАЛИЛ из БД запись:");
                message.Append(new string(' ', 31)).Append($"ID: {cert.ID}").AppendLine();
                message.Append(new string(' ', 31)).Append($"Год: {cert.Year}").AppendLine();
                message.Append(new string(' ', 31)).Append($"Тип документа: {cert.DocumentTypeString}").AppendLine();
                if (cert.ContractNumber?.Length > 0)
                    message.Append(new string(' ', 31)).Append($"Номер договора: {cert.ContractNumber}").AppendLine();
                if (cert.CertificateNumber?.Length > 0)
                    message.Append(new string(' ', 31)).Append($"Номер свидетельства: {cert.CertificateNumber}").AppendLine();
                if (cert.RegisterNumber?.Length > 0)
                    message.Append(new string(' ', 31)).Append($"Номер в гос.реестре: {cert.RegisterNumber}").AppendLine();
                if (cert.VerificationMethod?.Length > 0)
                    message.Append(new string(' ', 31)).Append($"Методика поверки: {cert.VerificationMethod}").AppendLine();
                if (cert.ClientName?.Length > 0)
                    message.Append(new string(' ', 31)).Append($"Наименование заказчика: {cert.ClientName}").AppendLine();
                if (cert.ObjectName?.Length > 0)
                    message.Append(new string(' ', 31)).Append($"Наименование объекта эксплуатации: {cert.ObjectName}").AppendLine();
                if (cert.DeviceType?.Length > 0)
                    message.Append(new string(' ', 31)).Append($"Группа СИ: {cert.DeviceType}").AppendLine();
                if (cert.DeviceName?.Length > 0)
                    message.Append(new string(' ', 31)).Append($"Наименование СИ: {cert.DeviceName}").AppendLine();
                if (cert.SerialNumber?.Length > 0)
                    message.Append(new string(' ', 31)).Append($"Серийный номер: {cert.SerialNumber}").AppendLine();
                message.Append(new string(' ', 31)).Append($"Дата поверки: {cert.CalibrationDate}").AppendLine();
                message.Append(new string(' ', 31)).Append($"Дата окончания срока поверки: {cert.CalibrationExpireDate}").AppendLine();
                if (cert.CertificatePath?.Length > 0)
                    message.Append(new string(' ', 31)).Append($"Путь к файлу: {cert.FullCertificatePath}").AppendLine();

                LoggingService.LogEvent(message.ToString());
            }

            BuildTreeView();
            Changed(this, EventArgs.Empty);

            MessageBox.Show("Указанные свидетельства были успешно удалены из базы данных", "Операция удаления", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Поиск свидетельств по шаблону
        private void CertificatesPanel_Search(object sender, EventArgs e)
        {
            var model = AppLocator.ModelFactory.Create<ICertificatesLoader>();
            var searchPattern = e as CertificateEventArgs;
            _selectedCertificates = model.Read(searchPattern);
            FillDataGridView(_selectedCertificates);
        }

        // Выбираем узел в TreeView
        private void tvCertificates_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Получаем контекст выбранного узла
            var content = e.Node.Tag.ToString().ToLower();
            var type = content.GetType();
            IEnumerable<Certificate> certificates = new Certificates();

            if (content == "year")
            {
                certificates = _certificates.Where(x => x.Year == int.Parse(e.Node.Name));
            }
            else if (content == "contract")
            {
                certificates = _certificates.Where(x => x.Year == int.Parse(e.Node.Parent.Name) && x.ContractNumber == e.Node.Name);
            }

            _selectedCertificates = new Certificates(certificates.ToList());
            // Заполняем DataGridView результатами выборки
            FillDataGridView(_selectedCertificates);
        }

        // Меняем состояние CheckBox у TreeView
        private void tvCertificates_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // Код выполняется, только если статус чекбокса был изменен пользователем
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    /* Устанавливаем значение Checkbox'а узла всем дочерним узлам */
                    CheckAllChildNodes(e.Node, e.Node.Checked);
                }
                // Сохраняем состояние узлов
                tvCertificates.SerializeNodeState();

                // Формируем список отслеживаемых свидетельств
                SetTracedCertificates();

                // Обновление DataGridView
                dgvCerts.Refresh();
                // Отображение всплывающей подсказки
                ShowTrayToolTip();
            }
        }

        // Выбираем свидетельство в DataGridView
        private void dgvCerts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCerts.SelectedRows.Count == 0)
                return;

            int id = (int)dgvCerts.SelectedRows[0].Cells[0].Value;
            // Выбираем свидетельство
            var certificate = _certificates.Where(x => x.ID == id).FirstOrDefault();

            // Выводим данные о свидетельстве на панель свойств
            var view = PropertyControl as IView<Certificate, Certificates>;
            view.Build(certificate, _certificates);

            // Выводим страницы документа на панель предпросмотра
            if (Settings.Instance.AutoPreviewEnabled && certificate != null)
                (PreviewControl as IPreviewPanel<string>).Build(certificate.FullCertificatePath);
        }

        // Рекурсивное обновление дочерних узлов
        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    // If the current node has child nodes, call the CheckAllChildsNodes method recursively.
                    CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

        // Показать/скрыть панель предпросмотра
        public void ShowOrHidePreviewPanel()
        {
            if (Settings.Instance.AutoPreviewEnabled)
            {
                scPreviewSplitter.Panel2Collapsed = false;
                PreviewControl = (Control)AppLocator.GuiFactory.Create<IPreviewPanel<string>>();
            }
            else
            {
                scPreviewSplitter.Panel2Collapsed = true;
            }
        }

        // Определить права пользователя
        private void SetUserRights()
        {
            switch (Authorization.CurrentUser.UserRights.ToLower())
            {
                case "user":
                    tsmChangeFilePath.Enabled = false;
                    tsmTransferDocument.Enabled = false;
                    break;
                case "specialist":
                    tsmChangeFilePath.Enabled = false;
                    tsmTransferDocument.Enabled = false;
                    break;
                case "metrolog":
                case "metrologist":
                case "administrator":
                    tsmChangeFilePath.Enabled = true;
                    tsmTransferDocument.Enabled = true;
                    break;
                default:
                    tsmChangeFilePath.Enabled = true;
                    break;
            }
        }

        // Заполняем DataGridView результатами выборки
        private void FillDataGridView(Certificates certificates)
        {
            dgvCerts.DataSource = certificates;
        }

        // Отобразить всплывающее оповещение в трее
        private void ShowTrayToolTip()
        {
            var expiredCertificateCount = _tracedCertificates.Where(x => x.CalibrationExpireDate < DateTime.Now).Count();
            var almostExpiredCertificateCount = _tracedCertificates.Where(x => x.CalibrationExpireDate >= DateTime.Now && x.CalibrationExpireDate < DateTime.Now.AddDays(30)).Count();

            niCertificatesManager.BalloonTipIcon = ToolTipIcon.Info;
            niCertificatesManager.BalloonTipTitle = "Внимание!";
            niCertificatesManager.BalloonTipText = $"У {expiredCertificateCount} свидетельств истек срок поверки."
                                                    + Environment.NewLine
                                                    + $"У {almostExpiredCertificateCount} свидетельств срок закончится втечении 30 дней.";
            niCertificatesManager.ShowBalloonTip(10000);
        }

        // Меняем цвет для просроченных свидетельств в DataGridView
        private void dgvCerts_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var itemId = (int)dgvCerts.Rows[e.RowIndex].Cells[0].Value;
            var certificate = _certificates.Where(x => x.ID == itemId).FirstOrDefault();

            if (_tracedCertificates.Contains(certificate))
            {
                if (certificate.CalibrationExpireDate <= DateTime.Now)
                {
                    dgvCerts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                    dgvCerts.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Yellow;
                }
                else if (certificate.CalibrationExpireDate <= DateTime.Now.AddDays(30))
                {
                    dgvCerts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                    dgvCerts.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
            else
            {
                dgvCerts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                dgvCerts.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        // Выбираем отслеживаемые свидетельства
        private void SetTracedCertificates()
        {
            var checkedNodes = tvCertificates.Nodes.Descendants().Where(x => x.Checked);
            _tracedCertificates = new HashSet<Certificate>
                (from node in checkedNodes
                 from cert in _certificates
                 where node.Text == cert.ContractNumber && node.Parent.Name == cert.Year.ToString()
                 select cert);
        }

        // Вызов контекстного меню для заголовков DataGridView
        private void dgvCerts_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dgvHeaderMenuStrip.Show(MousePosition);
            }
        }

        // Открытие файла свидетельства двойным кликом
        private void dgvCerts_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.RowIndex != -1)
            {
                dgvCerts.Rows[e.RowIndex].Selected = true;
                var file = dgvCerts.SelectedRows[0].Cells["certificatePathDataGridViewTextBoxColumn"].Value.ToString();
                if (File.Exists(file))
                {
                    Process.Start(file);
                }
                else
                    MessageBox.Show("Файл по указанному пути не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Видимость столбцов datagridview
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            int num = Convert.ToInt32(item.Tag);

            if (dgvCerts.Columns[num].Visible != false)
            {
                dgvCerts.Columns[num].Visible = false;
                item.Checked = false;
            }
            else
            {
                dgvCerts.Columns[num].Visible = true;
                item.Checked = true;
            }
        }

        // Открыть методику поверки
        private void dgvCerts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if (!Directory.Exists(Settings.Instance.VerificateionMethodFolderPath))
                return;

            var filePaths = Directory.GetFiles(Settings.Instance.VerificateionMethodFolderPath);
            var verificationMethods = new Dictionary<string, string>();

            foreach (var filePath in filePaths)
            {
                verificationMethods.Add(Path.GetFileNameWithoutExtension(filePath).ToLower(), filePath.ToLower());
            }

            if (dgvCerts.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewLinkCell)
            {
                var file = verificationMethods[dgvCerts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString().ToLower()];
                Process.Start(file);
            }
        }

        // Вызов контекстного меню для итемов DataGridView
        private void dgvCerts_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex != -1)
            {
                dgvCerts.Focus();
                dgvItemMenuStrip.Show(MousePosition);
            }
        }

        // Контекстное меню для Items DataGridView
        private void dgvItemMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var paths = new List<string>();
            for (int i = 0; i < dgvCerts.SelectedRows.Count; i++)
            {
                paths.Add(dgvCerts.SelectedRows[i].Cells["certificatePathDataGridViewTextBoxColumn"].Value.ToString());
            }
            var pathsArray = paths.Distinct().ToArray();

            switch (e.ClickedItem.Name)
            {
                case "tsmOpen":
                    OpenFile(pathsArray);
                    break;
                case "tsmOpenFolder":
                    OpenFolder(pathsArray);
                    break;
                case "tsmCopyInfo":
                    CopyInfo();
                    break;
                case "tsmCopy":
                    dgvItemMenuStrip.Hide();
                    Copy(pathsArray);
                    break;
                case "tsmSaveFile":
                    dgvItemMenuStrip.Hide();
                    SaveFile(pathsArray);
                    break;
                case "tsmSendByEmail":
                    dgvItemMenuStrip.Hide();
                    SendByEmailAsync(pathsArray);
                    break;
                case "tsmChangeFilePath":
                    dgvItemMenuStrip.Hide();
                    ChangeFilePath();
                    break;
                case "tsmOpenVerificationMethod":
                    dgvItemMenuStrip.Hide();
                    OpenVerificationMethod();
                    break;
                case "tsmTransferDocument":
                    dgvItemMenuStrip.Hide();
                    BuildActDocument();
                    break;
                case "tsmCreateTechnicalJournal":
                    OpenTechnicalJournalForm();
                    break;
            }
        }

        #region Методы для dgvContextStripMenu

        // Открыть файл
        private void OpenFile(string[] paths)
        {
            var file = paths.Last();

            if (File.Exists(file))
            {
                Process.Start(file);
            }
            else
                MessageBox.Show("Файл по указанному пути не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Открыть папку с файлом
        private void OpenFolder(string[] pathsArray)
        {
            var item = Path.GetDirectoryName(pathsArray.Last());
            Process.Start(item);
        }

        // Копировать информацию о свидетельствах в буфер обмена
        private void CopyInfo()
        {
            string text = "";
            var textArray = new List<string>();
            var maxLenghtArray = new int[12];

            var selectedRows = dgvCerts.SelectedRows;
            int j = 1;

            for (int i = 0; i < 12; i++)
            {
                foreach (DataGridViewRow row in selectedRows)
                {
                    if (row.Cells[i + 1].Value?.ToString().Length > maxLenghtArray[i])
                        maxLenghtArray[i] = row.Cells[i + 1].Value.ToString().Length;
                }
            }

            foreach (DataGridViewRow row in selectedRows)
            {
                textArray.Add(j.ToString() + new string(' ', 3));
                j++;
                for (int i = 0; i < 12; i++)
                {
                    if (row.Cells[i + 1].Value?.ToString().Length < maxLenghtArray[i])
                        textArray.Add(row.Cells[i + 1].Value.ToString() + new string(' ', maxLenghtArray[i] - row.Cells[i + 1].Value.ToString().Length + 3));
                    else if (maxLenghtArray[i] == 0)
                    { }
                    else
                        textArray.Add(row.Cells[i + 1].Value.ToString() + new string(' ', 3));
                }
                textArray.Add(Environment.NewLine);
            }

            text = string.Join(null, textArray);
            Clipboard.SetText(text);
        }

        // Копировать файл
        private void Copy(string[] pathsArray)
        {
            System.Collections.Specialized.StringCollection stringCollection = new System.Collections.Specialized.StringCollection();
            stringCollection.AddRange(pathsArray);
            Clipboard.SetFileDropList(stringCollection);
        }

        // Сохранить файл по заданному пути
        private void SaveFile(string[] pathsArray)
        {
            if (pathsArray.Length > 1)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "Выберите место сохранения выбранных свидетельств";
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    foreach (var path in pathsArray)
                    {
                        var newPath = Path.Combine(fbd.SelectedPath, Path.GetFileName(path));
                        File.Copy(path, newPath, true);
                    }
                }
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.FileName = Path.GetFileName(pathsArray[0]);
                sfd.Filter = "Все типы файлов (*.*)|(*.*)";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(pathsArray[0], sfd.FileName, true);
                }
            }
        }

        // Отправить выбранные файлы по Email
        private async void SendByEmailAsync(string[] pathsArray)
        {
            await Task.Run(() => MailService.SendFilesByEmail(pathsArray.Distinct().ToArray()));
        }

        // Изменить путь файла свидетельства
        private void ChangeFilePath()
        {
            var idList = new List<int>();
            foreach (DataGridViewRow row in dgvCerts.SelectedRows)
            {
                idList.Add((int)row.Cells["iDDataGridViewTextBoxColumn"].Value);
            }

            // Старый путь
            var oldPath = _certificates.FirstOrDefault(x => x.ID == idList.FirstOrDefault()).FullCertificatePath;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Укажите путь к новому файлу свидетельства";
            ofd.Filter = "Документы PDF|*.pdf";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var model = AppLocator.ModelFactory.Create<ICertificatesLoader>();

                var path = Directory.GetParent(ofd.FileName).Parent.Parent.Parent.FullName;
                var modifiedPath = ofd.FileName.Remove(0, path.Length + 1);

                model.UpdatePaths(idList.ToArray(), modifiedPath);

                MessageBox.Show("Путь к файлам был успешно изменен.", "Результат операции", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            // Новый путь
            var newPath = _certificates.FirstOrDefault(x => x.ID == idList.FirstOrDefault()).FullCertificatePath;

            // Логирование
            var message = new StringBuilder().AppendLine($"Пользователь {Authorization.CurrentUser.Login} ИЗМЕНИЛ ПУТЬ К ФАЙЛУ СВИДЕТЕЛЬСТВА для записи ID = {idList.FirstOrDefault()}:");
            message.Append(new string(' ', 31)).Append($"Старый путь: {oldPath}").AppendLine();
            message.Append(new string(' ', 31)).Append($"Новый путь: {newPath}").AppendLine();
            LoggingService.LogEvent(message.ToString());
        }

        // Открыть методику поверки
        private void OpenVerificationMethod()
        {
            if (!Directory.Exists(Settings.Instance.VerificateionMethodFolderPath))
                return;

            var filePaths = Directory.GetFiles(Settings.Instance.VerificateionMethodFolderPath);
            var verificationMethods = new Dictionary<string, string>();

            foreach (var filePath in filePaths)
            {
                verificationMethods.Add(Path.GetFileNameWithoutExtension(filePath).ToLower(), filePath.ToLower());
            }

            if (string.IsNullOrWhiteSpace(dgvCerts.SelectedRows[0].Cells["verificationMethodDataGridViewLinkColumn"].Value?.ToString()))
                return;

            var file = verificationMethods[dgvCerts.SelectedRows[0].Cells["verificationMethodDataGridViewLinkColumn"].Value?.ToString().ToLower()];

            Process.Start(file);
        }

        // Сформировать акт передачи документов
        private void BuildActDocument()
        {
            var idList = new List<int>();
            foreach (DataGridViewRow row in dgvCerts.SelectedRows)
            {
                idList.Add((int)row.Cells["iDDataGridViewTextBoxColumn"].Value);
            }

            var selectedCertificates = new Certificates(_certificates.Where(x => idList.Contains(x.ID)).ToList());

            var form = new ContainerForm<Certificates, ICreateNewActView<Certificates>>();
            form.Build(selectedCertificates);
            form.Changed += delegate { form.DialogResult = DialogResult.OK; };
            form.ShowDialog();
        }

        // Сформировать технический отчет
        private void OpenTechnicalJournalForm()
        {
            var form = new ContainerForm<Certificate, ITechnicalJournalPanelView<Certificate>>();
            var cert = _certificates.Where(x => x.ID == (int)dgvCerts.SelectedRows[0].Cells["iDDataGridViewTextBoxColumn"].Value).Last();
            form.Build(cert);
            form.ShowDialog();
        }


        #endregion

    }
}
