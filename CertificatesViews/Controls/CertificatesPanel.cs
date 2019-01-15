﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CertificatesViews.Interfaces;
using CertificatesModel;
using CertificatesViews.Factories;
using System.IO;
using System.Threading;
using CertificatesModel.Interfaces;
using CertificatesModel.Components;
using static CertificatesViews.TreeNodeCollectionExtensions;

namespace CertificatesViews.Controls
{
    public partial class CertificatesPanel : UserControl, IView<Certificates>
    {
        Control _propertyControl;
        Control _previewControl;
        Certificates _certificates;
        CancellationTokenSource _cancelationTokenSource;

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

            // Подгоняем размер столбцов ListView под размер содержимого заголовков
            lvCertificatesDetails.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        // Передача данных в форму
        public void Build(Certificates certificates)
        {
            // TODO: Допилить загрузку формы
            TreeNodeList state = new TreeNodeList();
            if (tvCertificates.Nodes.Count != 0)
            {
                state = tvCertificates.Nodes.getNodeCollectionState();
            }

            _certificates = certificates;

            tvCertificates.BeginUpdate();

            tvCertificates.Nodes.Clear();
            tvCertificates.AddCertificates(_certificates);
            tvCertificates.DeserializeNodeState();

            tvCertificates.EndUpdate();

            // Построение панели свойств свидетельства
            BuildProperty();
        }

        // Построение панели свойств свидетельства
        private void BuildProperty()
        {
            Certificate certificate = new Certificate();
            var view = AppLocator.GuiFactory.Create<IViewAndEdit<Certificate>>();
            view.Build(certificate);
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

            Changed(this, EventArgs.Empty);
            MessageBox.Show("Изменения в свидетельство успешно внесены.", "Операция изменения", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Удаление выбранных свидетельств
        private void CertificatesPanel_Deleted(object sender, EventArgs e)
        {
            // Выбранные свидетельства
            var selectedItems = lvCertificatesDetails.SelectedItems;

            // Проверяем выбраны ли какие то свидетельства
            if (selectedItems.Count == 0)
                return;

            // Создаем и заполняем массив Id 
            var id = new int[selectedItems.Count];

            for (int i = 0; i < id.Length; i++)
            {
                id[i] = Convert.ToInt32(selectedItems[i].SubItems[0].Text);
            }

            // Передаем массив Id в модель
            var model = AppLocator.ModelFactory.Create<ICertificatesLoader>();
            model.DeleteCertificates(id);

            Changed(this, EventArgs.Empty);
            MessageBox.Show("Указанные свидетельства были успешно удалены из базы данных", "Операция удаления", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Поиск свидетельств по шаблону
        private void CertificatesPanel_Changed(object sender, EventArgs e)
        {
            var model = AppLocator.ModelFactory.Create<ICertificatesLoader>();
            var searchPattern = e as CertificateEventArgs;
            var result = model.GetCertificatesBySearchPattern(searchPattern).ListOfCertificates;
            FillListView(result);
        }

        // Выбираем узел в TreeView
        private void tvCertificates_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Получаем контекст выбранного узла
            var content = e.Node.Tag;
            var type = content.GetType();

            // Заполняем ListView результатами выборки
            if (type == typeof(Certificates))
                FillListView((content as Certificates).ListOfCertificates);
            else if (type == typeof(Year))
                FillListView((content as Year).ListOfCertificates);
            else if (type == typeof(Contract))
                FillListView(content as Contract);
        }

        // Выбор свидетельства в ListView
        private void lvCertificatesDetails_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                // Если список свидетельств пуст, выходим из метода
                if (_certificates == null || _certificates.ListOfCertificates.Count == 0)
                    return;

                // ID выбранного свидетельства
                var id = int.Parse(e.Item.SubItems[0].Text);

                // Выбираем свидетельство
                var certificate = _certificates.ListOfCertificates.Where(x => x.ID == id).ToList()[0];

                // Панель свойств
                var view = PropertyControl as IView<Certificate>;

                // Выводим данные о свидетельстве на панель свойств
                view.Build(certificate);

                // Выводим страницы документа на панель предпросмотра
                if (Settings.Instance.AutoPreviewEnabled)
                    (PreviewControl as IView<string>).Build(certificate.CertificatePath);
            }
        }

        // Меняем состояние CheckBox у TreeView
        private void tvCertificates_AfterCheck(object sender, TreeViewEventArgs e)
        {     
            // The code only executes if the user caused the checked state to change.
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    /* Calls the CheckAllChildNodes method, passing in the current 
                    Checked value of the TreeNode whose checked state changed. */
                    this.CheckAllChildNodes(e.Node, e.Node.Checked);
                }
                tvCertificates.SerializeNodeState();
            }
            
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
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

        // Показать/скрыть панель предпросмотра
        public void ShowOrHidePreviewPanel()
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

        // Асинхронное заполнение ListView результатами выборки
        private async void FillListView(List<Certificate> certificates)
        {
            // Отменяем исполняемую задачу, если таковая имелась
            if (_cancelationTokenSource != null)
                _cancelationTokenSource.Cancel();

            // Создаем CancellationTokenSource для текущего метода, и передаем его в переменную класса
            var cts = new CancellationTokenSource();
            _cancelationTokenSource = cts;

            // Получаем токен отмены
            var token = _cancelationTokenSource.Token;

            // Очищаем ListView перед заполнением результатом выборки
            lvCertificatesDetails.Items.Clear();

            // Асинхронно заполняем ListView результатами выборки
            foreach (var cert in certificates)
            {
                var item = await Task<ListViewItem>.Factory.StartNew(() => GetCertificateDetails(cert, token), token);
                if (item != null)
                    lvCertificatesDetails.Items.Add(item);
            }

            // Убираем CancellationTokenSource текущего метода из переменной класса
            if (_cancelationTokenSource == cts)
                _cancelationTokenSource = null;
        }

        // Получение ListViewItem с детализированной информацией о свидетельстве 
        private ListViewItem GetCertificateDetails(Certificate cert, CancellationToken token)
        {
            string fileSize, fileCreationDate;
            FileInfo fileInfo = new FileInfo(cert.CertificatePath);

            try
            {
                // Размер файла
                fileSize = fileInfo.Length.ToString();
                // Дата создания файла
                fileCreationDate = fileInfo.CreationTime.ToString();
            }
            catch
            {
                // Если файл не доступен, то заполняем поля заглушками
                fileSize = "---";
                fileCreationDate = "---";
            }

            // Формируем ListViewItem и заполняем результатами выборки
            var item = new ListViewItem(new string[]
                    {
                    cert.ID.ToString(),
                    cert.ContractNumber,
                    cert.CertificateNumber,
                    cert.RegisterNumber,
                    cert.VerificationMethod,
                    cert.ClientName,
                    cert.ObjectName,
                    cert.DeviceType,
                    cert.DeviceName,
                    cert.SerialNumber,
                    cert.CalibrationDate.ToShortDateString(),
                    cert.CalibrationExpireDate.ToShortDateString(),
                    cert.CertificatePath,
                    fileSize,
                    fileCreationDate
                    });

            // Если пришел запрос отмены выполнения операции, то прекращаем выполнение
            if (token.IsCancellationRequested)
                token.ThrowIfCancellationRequested();

            // Возвращаем результат
            return item;
        }
    }
}
