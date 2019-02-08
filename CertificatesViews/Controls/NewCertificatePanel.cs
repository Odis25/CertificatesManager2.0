using CertificatesModel.ScannerService;
using CertificatesViews.Factories;
using CertificatesViews.Interfaces;
using System;
using System.IO;
using System.Windows.Forms;

namespace CertificatesViews.Controls
{
    public partial class NewCertificatePanel : UserControl, ICreateNewView<string>
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
        public NewCertificatePanel()
        {
            InitializeComponent();
        }

        public event EventHandler Changed = delegate { };

        public void Build(string path)
        {
            var preview = AppLocator.GuiFactory.Create<IView<string>>();
            preview.Build(path);
            PreviewPanel = preview as Control;
        }

        public void Build(MemoryStream stream)
        {
            var preview = AppLocator.GuiFactory.Create<IView<MemoryStream>>();
            preview.Build(stream);
            PreviewPanel = preview as Control;
        }

        private void btScanNewDoc_Click(object sender, EventArgs e)
        {
           // Build(null);
            GC.Collect();
            ScanHelper helper = new ScanHelper();
            MemoryStream stream = helper.ScanNewCertificate(false);

            //var preview = AppLocator.GuiFactory.Create<IView<MemoryStream>>();
            Build(stream);
        }
    }
}
