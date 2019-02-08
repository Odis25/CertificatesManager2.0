using System.Collections.Generic;
using System.Drawing;

namespace CertificatesModel.Interfaces
{
    public interface IScanner
    {
        IEnumerable<Image> Scan(bool duplex);
        IEnumerable<Image> Scan(PageSize pageSize, bool rotatePage, int DPI, bool useAdf, bool duplex);
        void SelectScanner();
    }
}