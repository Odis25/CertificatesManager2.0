using CertificatesViews.Factories;
using CertificatesViews.Interfaces;
using System;
using System.Windows.Forms;

namespace CertificatesViews.Controls
{
    public partial class ContainerForm<T, V> : Form where V : IView<T>
    {
        public ContainerForm()
        {
            InitializeComponent();
        }

        public event EventHandler Changed;

        public void Build(T obj)
        {
            //create control to show server
            var ctrl = AppLocator.GuiFactory.Create<V>();
            (ctrl as Control).Dock = DockStyle.None;
            (ctrl as Control).Parent = this;
            //build control
            ctrl.Build(obj);
            //route event Changed
            ctrl.Changed += (o, e) => Changed(o, e);
        }
    }
}
