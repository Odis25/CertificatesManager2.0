using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificatesViews.Interfaces
{
    interface IViewAndEdit<T>: IView<T>
    {
        event EventHandler Edited;
        event EventHandler Deleted;
    }
}
