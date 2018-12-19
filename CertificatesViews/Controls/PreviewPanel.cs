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
using PdfiumViewer;
using System.IO;

namespace CertificatesViews.Controls
{
    public partial class PreviewPanel : UserControl, IView<string>
    {
        PdfViewer _viewer;
        PdfRenderer _renderer;

        public PreviewPanel()
        {
            InitializeComponent();

            _viewer = new PdfViewer();
            _renderer = new PdfRenderer();
        }

        public event EventHandler Changed;

        public void Build(string obj)
        {
            //_renderer.Load(PdfDocument.Load(obj));
            //_renderer.Dock = DockStyle.Fill;
            //panPages.Controls.Add(_renderer);

            _viewer.Document = PdfDocument.Load(obj);
            _viewer.Dock = DockStyle.Fill;
            panPages.Controls.Add(_viewer);
        }

    }
}
