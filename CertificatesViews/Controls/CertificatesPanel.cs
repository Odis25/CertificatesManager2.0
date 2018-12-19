using System;
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

namespace CertificatesViews.Controls
{
    public partial class CertificatesPanel : UserControl, IView<Certificates>
    {
        Control _propertyControl;
        Control _previewControl;
        Certificates _certificates;
        CancellationTokenSource _cancelationTokenSource;

        /// <summary>
        /// Панель предпросмотра 
        /// </summary>
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

        /// <summary>
        /// Панель детализированной информации о свидетельстве
        /// </summary>
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
            
            lvCertificatesDetails.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        // Событие на изменение
        public event EventHandler Changed = delegate { };


        // Передача данных в форму
        public void Build(Certificates certificates)
        {
            _certificates = certificates;

            tvCertificates.AddCertificates(_certificates);
            tvCertificates.Update();

            // Построение панели свойств свидетельства
            BuildProperty();            
        }

        // Построение панели свойств свидетельства
        private void BuildProperty()
        {
            Certificate certificate = new Certificate();
            PropertyControl = (Control)AppLocator.GuiFactory.Create<IView<Certificate>>();
            (PropertyControl as IView<Certificate>).Build(certificate);

            // Показать/скрыть панель предпросмотра
            ShowOrHidePreviewPanel();                
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

        // Асинхронное заполнение ListView результатами выборки
        async private void FillListView(List<Certificate> certificates)
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
                // Датасоздания файла
                fileCreationDate = fileInfo.CreationTime.ToString();
            }
            catch
            {
                fileSize = "---";
                fileCreationDate = "---";
            }

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

            if (token.IsCancellationRequested)
                return null;

            return item;
        }

        // Выбор свидетельства в ListView
        private void lvCertificatesDetails_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var id = e.Item.SubItems[0].Text;

            if (_certificates == null || _certificates.ListOfCertificates.Count == 0)
                return;

            var certificate = _certificates.ListOfCertificates.Where(x => x.ID == int.Parse(id)).ToList()[0];

            // Выводим данные о свидетельстве на панель свойств
            if (PropertyControl is CertificatePropertiesPanel)
                (PropertyControl as CertificatePropertiesPanel).Build(certificate);

            // Выводим страницы документа на панель предпросмотра
            PreviewControl = (Control)AppLocator.GuiFactory.Create<IView<string>>();
            (PreviewControl as IView<string>).Build(certificate.CertificatePath);
        }        
    }
}
