using CertificatesModel;
using CertificatesModel.Components;
using CertificatesModel.Interfaces;
using CertificatesViews.Factories;
using CertificatesViews.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
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
    }
}
