using CertificatesModel;
using CertificatesModel.Components;
using CertificatesModel.Interfaces;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CertificatesViews.Controls
{
    public partial class CertificatesPanel : UserControl, IView<Certificates>
    {
        Control _propertyControl;
        Control _previewControl;
        Certificates _certificates;
        Certificates _selectedCertificates;

        // Список отслеживаемых свидетельств 
        private HashSet<Certificate> _tracedCertificates;

        // Событие на изменение
        public event EventHandler Changed = delegate { };

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
        }

        // Передача данных в форму
        public void Build(Certificates certificates)
        {
            // TODO: Допилить загрузку формы
            _certificates = certificates;

            dgvCerts.DataSource = _certificates;

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
            var view = AppLocator.GuiFactory.Create<IDetailsView<Certificate, Certificates>>();
            view.Build(new Certificate(), _certificates);
            view.Changed += CertificatesPanel_Changed;
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
            model.EditCertificate(editPattern);

            dgvCerts.Refresh();
            BuildTreeView();

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
            model.DeleteCertificates(id.ToArray());

            // Убираем удаленные элементы из выборки
            for (int i = 0; i < id.Count; i++)
            {
                var cert = _selectedCertificates.FirstOrDefault(x => x.ID == id[i]);
                _selectedCertificates.Remove(cert);
            }

            BuildTreeView();

            MessageBox.Show("Указанные свидетельства были успешно удалены из базы данных", "Операция удаления", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Поиск свидетельств по шаблону
        private void CertificatesPanel_Changed(object sender, EventArgs e)
        {
            var model = AppLocator.ModelFactory.Create<ICertificatesLoader>();
            var searchPattern = e as CertificateEventArgs;
            var result = model.GetCertificatesBySearchPattern(searchPattern);
            FillDataGridView(result);
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
                (PreviewControl as IView<string>).Build(certificate.CertificatePath);
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
        internal void ShowOrHidePreviewPanel()
        {
            if (Settings.Instance.AutoPreviewEnabled)
            {
                scPreviewSplitter.Panel2Collapsed = false;
                PreviewControl = (Control)AppLocator.GuiFactory.Create<IView<string>>();
            }
            else
            {
                scPreviewSplitter.Panel2Collapsed = true;
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

        // Контекстное меню для заголовков DataGridView
        private void dgvCerts_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dgvHeaderMenuStrip.Show(MousePosition);
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

        // Контекстное меню для итемов DataGridView
        private void dgvCerts_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex != -1)
            {
                if (ModifierKeys != Keys.Control)
                    dgvCerts.ClearSelection();
                dgvCerts.Rows[e.RowIndex].Selected = true;
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
                    SendByEmail(pathsArray);
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
                    BuildTransferDocument();
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

            for (int i = 1; i < 12; i++)
            {
                foreach (DataGridViewRow row in selectedRows)
                {
                    if (row.Cells[i].Value?.ToString().Length > maxLenghtArray[i])
                        maxLenghtArray[i] = row.Cells[i].Value.ToString().Length;
                }
            }

            foreach (DataGridViewRow row in selectedRows)
            {
                textArray.Add(j.ToString() + new string(' ', 3));
                j++;
                for (int i = 1; i < 12; i++)
                {
                    if (row.Cells[i].Value?.ToString().Length < maxLenghtArray[i])
                        textArray.Add(row.Cells[i].Value.ToString() + new string(' ', maxLenghtArray[i] - row.Cells[i].Value.ToString().Length + 3));
                    else if (maxLenghtArray[i] == 0)
                    { }
                    else
                        textArray.Add(row.Cells[i].Value.ToString() + new string(' ', 3));
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
        private void SendByEmail(string[] pathsArray)
        {
            Task.Run(() => MailService.SendFilesByEmail(pathsArray.Distinct().ToArray()));
        }

        // Изменить путь файла свидетельства
        private void ChangeFilePath()
        {
            var idList = new List<int>();
            foreach (DataGridViewRow row in dgvCerts.SelectedRows)
            {
                idList.Add((int)row.Cells["iDDataGridViewTextBoxColumn"].Value);
            }

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Укажите путь к новому файлу свидетельства";
            ofd.Filter = "Документы PDF|*.pdf";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var model = AppLocator.ModelFactory.Create<ICertificatesLoader>();
                model.ModifyFilePath(idList.ToArray(), ofd.FileName);

                MessageBox.Show("Путь к файлам был успешно изменен.", "Результат операции", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
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
        private void BuildTransferDocument()
        {
            var idList = new List<int>();
            foreach (DataGridViewRow row in dgvCerts.SelectedRows)
            {
                idList.Add((int)row.Cells["iDDataGridViewTextBoxColumn"].Value);
            }

            var selectedCertificates = new Certificates(_certificates.Where(x => idList.Contains(x.ID)).ToList());

            var form = new ContainerForm<Certificates, ICreateNewTransferDocumentView<Certificates>>();
            form.Build(selectedCertificates);
            form.Changed += delegate { form.DialogResult = DialogResult.OK; };
            form.ShowDialog();
        }

        #endregion
    }
}
