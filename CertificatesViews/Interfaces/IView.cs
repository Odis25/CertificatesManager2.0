using System;

namespace CertificatesViews.Interfaces
{
    public interface IView<T>
    {
        event EventHandler Changed;
        void Build(T arg1);
    }

    public interface IView<T,V>
    {
        event EventHandler Changed;
        void Build(T arg1, V arg2);
    }
}
