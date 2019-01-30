using CertificatesViews.Factories;
using CertificatesViews.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CertificatesViews.Controls
{
    public partial class ContainerForm<T> : Form, IView<T>
    {
        Control _currentControl;

        public ContainerForm()
        {
            InitializeComponent();
        }

        public Control CurrentControl
        {
            get
            {
                return _currentControl;                
            }
            set
            {
                if (_currentControl != null)
                    _currentControl.Dispose();
                _currentControl = value;
                value.Dock = DockStyle.Fill;
                value.Parent = this;
                value.BringToFront();
            }
        }
        public event EventHandler Changed;

        public void Build(T obj)
        {
            //create control to show server
            CurrentControl = (Control)AppLocator.GuiFactory.Create<IView<T>>(); //we need control implements IView<Server>
            //place ctrl
            //ctrl.Parent = this;
            //ctrl.Dock = DockStyle.Fill;
            //build control
            (CurrentControl as IView<T>).Build(obj);
            //route event Changed
            (CurrentControl as IView<T>).Changed += (o, e) => Changed(o, e);
        }
    }


}
