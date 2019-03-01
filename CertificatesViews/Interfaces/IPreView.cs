using PdfiumViewer;

namespace CertificatesViews.Interfaces
{
    interface IPreView<T>: IView<T>
    {
        PdfViewer Viewer { get; }
    }
}
