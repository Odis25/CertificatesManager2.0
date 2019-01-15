using CertificatesViews.Interfaces;
using PdfiumViewer;
using System;
using System.IO;
using System.Net;
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

        public event EventHandler Changed;

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

            // Если файл доступен, то асинхронно загружаем его в панель предпросмотра
            if (File.Exists(path))
            {
                if (Viewer.Document != null)
                    Viewer.Document.Dispose();
                // Viewer.Document = await Task.Run(() => { return PdfDocument.Load(path); }, token);
                Viewer.Document = PdfDocument.Load(path);
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
