using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificatesViews.Interfaces
{
    public interface IView<T>
    {
        event EventHandler Changed;
        void Build(T obj);
    }
}
