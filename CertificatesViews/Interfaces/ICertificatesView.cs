using CertificatesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificatesViews.Interfaces
{
    interface ICertificatesView<T>: IView<T>
    {
        void ShowOrHidePreviewPanel();
        void Refresh(Certificates certificates);
    }
}
