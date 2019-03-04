using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificatesViews.Interfaces
{
    interface ICertificatePanelView<T>: IView<T>
    {
        event EventHandler ShowOrHidePreview;
    }
}
