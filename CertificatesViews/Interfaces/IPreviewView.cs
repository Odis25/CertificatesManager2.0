using PdfiumViewer;

namespace CertificatesViews.Interfaces
{
    interface IPreviewView<T>: IView<T>
    {
        PdfViewer Viewer { get; }
    }
}
