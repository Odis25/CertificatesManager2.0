using CertificatesViews.Interfaces;
using PdfiumViewer;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CertificatesViews.Controls
{

    public partial class PreviewPanel : UserControl, IPreviewView<string>, IPreviewView<byte[]>
    {
        PdfViewer _viewer;

        public PdfViewer Viewer
        {
            get
            {
                if (_viewer == null)
                    _viewer = new PdfViewer();

                return _viewer;
            }
        }

        public PreviewPanel()
        {
            InitializeComponent();
            panPages.Controls.Add(Viewer);
            Viewer.Dock = DockStyle.Fill;
        }

        public event EventHandler Changed = delegate { };

        public void Build(string path)
        {
            // Удаляем picturebox с предыдущего вызова и очищаем память
            foreach (PictureBox c in panPages.Controls.OfType<PictureBox>())
            { c.Dispose(); GC.Collect(); }

            // Если файл доступен, то асинхронно загружаем его в панель предпросмотра
            if (File.Exists(path))
            {
                // Если свидетельство в формате pdf-документа
                if (path.EndsWith(".pdf", true, null))
                {
                    Viewer.Visible = true;
                    //TODO: Разобраться с утечкой памяти и асинхронностью
                    if (Viewer.Document != null)
                    {
                        Viewer.Document.Dispose();
                        Viewer.Renderer.Document.Dispose();
                        Viewer.Document = null;
                    }

                    //Viewer.Document = PdfDocument.Load(path);
                    if (Viewer.Document == null)
                        Viewer.Document = PdfDocument.Load(new MemoryStream(File.ReadAllBytes(path)));
                    GC.Collect();
                }
                // Если свидетельство в формате изображения
                else
                {
                    Viewer.Visible = false;
                    // Создаем новый picturebox и загружаем туда изображение 
                    var pb = new PictureBox();
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                    pb.Load(path);
                    panPages.Controls.Add(pb);
                    pb.Dock = DockStyle.Fill;
                    }
                }
            else
                // Иначе оставляем панель пустой
                Viewer.Document = null;
        }

        public void Build(byte[] byteArray)
        {
            // Удаляем picturebox с предыдущего вызова и очищаем память
            foreach (PictureBox c in panPages.Controls.OfType<PictureBox>())
            { c.Dispose(); GC.Collect(); }

            // Если файл доступен, то асинхронно загружаем его в панель предпросмотра
            if (byteArray != null)
            {
                Viewer.Visible = true;

                Viewer.Document?.Dispose();
                Viewer.Document = PdfDocument.Load(new MemoryStream(byteArray));
            }
            else
                //Иначе оставляем панель пустой
                Viewer.Document = null;
        }
    }
}
