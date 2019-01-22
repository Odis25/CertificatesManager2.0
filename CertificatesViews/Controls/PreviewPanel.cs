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

    public partial class PreviewPanel : UserControl, IView<string>
    {
        PdfViewer _viewer;
        CancellationTokenSource _cts;

        PdfViewer Viewer
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

        async public void Build(string path)
        {

            // Отменяем предыдущий запрос
            if (_cts != null)
                _cts.Cancel();

            // Создаем CancellationTokenSource для текущего метода, и передаем его в переменную класса
            var cts = new CancellationTokenSource();
            _cts = cts;

            // Получаем токен отмены
            var token = _cts.Token;

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
                    await Task.Delay(100, token);
                    Viewer.Document?.Dispose();
                    Viewer.Document = PdfDocument.Load(path);
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
                //Иначе оставляем панель пустой
                Viewer.Document = null;

            // Убираем CancellationTokenSource текущего метода из переменной класса
            if (_cts == cts)
                _cts = null;
        }
    }
}
