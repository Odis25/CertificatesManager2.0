using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificatesViews.Interfaces
{
    interface IView<T>
    {
        event EventHandler Changed;
        void Build(T arg1);
    }

    interface IView<T,V>
    {
        event EventHandler Changed;
        void Build(T arg1, V arg2);
    }
}
