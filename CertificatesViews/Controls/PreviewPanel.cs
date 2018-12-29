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

        async public void Build(string obj)
        {
            // Отменяем предыдущий запрос
            if (_cts != null)
                _cts.Cancel();

            // Создаем CancellationTokenSource для текущего метода, и передаем его в переменную класса
            var cts = new CancellationTokenSource();
            _cts = cts;

            // Получаем токен отмены
            var token = _cts.Token;

            var path = CheckPath(obj);

            // Если файл доступен, то асинхронно загружаем его в панель предпросмотра
            if (File.Exists(path))
                Viewer.Document = await Task.Run(() => { return PdfDocument.Load(path); }, token);
            else
                //Иначе оставляем панель пустой
                Viewer.Document = null;

            // Убираем CancellationTokenSource текущего метода из переменной класса
            if (_cts == cts)
                _cts = null;
        }

        // Если путь содержит IP Address, то заменяем его на UNC
        private string CheckPath(string path)
        {
            // Если путь сетевой
            if (path.StartsWith(@"\\"))
            {
                // Получаем имя или IP адресс хоста
                var nameOrIP = path.TrimStart('\\').Split('\\')[0];
                // Получение имя удаленного компьютера
                var hostName = Dns.GetHostEntry(nameOrIP).HostName.Split('.')[0];
                // Формируем новый путь к файлу
                var newPath = path.Replace(nameOrIP, hostName);

                return newPath;
            }

            return path;
        }
    }
}
