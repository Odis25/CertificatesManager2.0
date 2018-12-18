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
        Control _currentControl;
        Control _previewControl;
        Certificates _certificates;
        IPreview _previewer;
        CancellationTokenSource _cancelationTokenSource, _cts;

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

        public Control CurrentControl
        {
            get { return _currentControl; }
            set
            {
                if (_currentControl != null)
                    _currentControl.Dispose();
                _currentControl = value;
                if (_currentControl != null)
                {
                    value.Dock = DockStyle.Fill;
                    scMainSpliter.SplitterDistance = value.Height;                    

                    value.Parent = scSecondarySpliter.Panel2;
                    value.BringToFront();
                }
            }
        }

        public CertificatesPanel()
        {
            InitializeComponent();
            
            _previewer = AppLocator.ModelFactory.Create<IPreview>();
            lvCertificatesDetails.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        public event EventHandler Changed = delegate { };

        public void Build(Certificates certificates)
        {
            _certificates = certificates;

            tvCertificates.AddCertificates(_certificates);
            tvCertificates.Update();

            BuildProperty();            
        }

        private void BuildProperty()
        {
            Certificate certificate = new Certificate();
            CurrentControl = (Control)AppLocator.GuiFactory.Create<IView<Certificate>>();
            (CurrentControl as IView<Certificate>).Build(certificate);

            ShowOrHidePreviewPanel();                
        }      

        public void ShowOrHidePreviewPanel()
        {
            if (Settings.Instance.AutoPreviewEnabled)
            {
                scPreviewSplitter.Panel2Collapsed = false;
                
                PreviewControl = (Control)AppLocator.GuiFactory.Create<IView<Pages>>();
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
                fileSize = fileInfo.Length.ToString();
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
        async private void lvCertificatesDetails_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var id = e.Item.SubItems[0].Text;

            if (_certificates == null || _certificates.ListOfCertificates.Count == 0)
                return;

            var certificate = _certificates.ListOfCertificates.Where(x => x.ID == int.Parse(id)).ToList()[0];

            if (CurrentControl is CertificatePropertiesPanel)
                (CurrentControl as CertificatePropertiesPanel).Build(certificate);

            // Отменяем исполняемую задачу, если таковая имелась
            if (_cts != null)
                _cts.Cancel();

            // Создаем CancellationTokenSource для текущего метода, и передаем его в переменную класса
            var cts = new CancellationTokenSource();
            _cts = cts;

            // Получаем токен отмены
            var token = _cts.Token;

            // Страницы документа в виде списка изображений
            var images = await _previewer.GetPagesFromPdf(certificate.CertificatePath, token);

            PreviewControl = (Control)AppLocator.GuiFactory.Create<IView<Pages>>();
            (PreviewControl as IView<Pages>).Build(images);

            // Убираем CancellationTokenSource текущего метода из переменной класса
            if (_cts == cts)
                _cts = null;
        }        
    }
}
