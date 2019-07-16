using PdfiumViewer;

namespace CertificatesViews.Interfaces
{
    interface IPreviewPanel<T>: IView<T>
    {
        PdfViewer Viewer { get; }
    }
}
