using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificatesViews.Interfaces
{
    interface ICertificatePropertiesView<T,V>: IView<T,V>
    {
        event EventHandler Search;
        event EventHandler Edited;
        event EventHandler Deleted;
    }
}
