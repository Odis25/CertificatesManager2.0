using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificatesViews.Interfaces
{
    interface IViewAndEdit<T,V>: IView<T,V>
    {
        event EventHandler Edited;
        event EventHandler Deleted;
    }
}
