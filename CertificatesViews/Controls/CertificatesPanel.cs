using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CertificatesViews.Interfaces;
using CertificatesModel;
using CertificatesViews.Factories;

namespace CertificatesViews.Controls
{
    public partial class CertificatesPanel : UserControl, IView<Certificates>
    {
        Control _currentControl;
        Certificates _certificates;

        public Control CurrentControl
        {
            get { return _currentControl; }
            set
            {
                if (_currentControl != null)
                    _currentControl.Dispose();
                _currentControl = value;
                if (_currentControl != null)
                {
                    value.Dock = DockStyle.Left;
                    scMainSpliter.SplitterDistance = value.Height;
                    value.Parent = scSecondarySpliter.Panel2;                    
                    value.BringToFront();        
                }
            }
        }

        public CertificatesPanel()
        {
            InitializeComponent();
        }

        public event EventHandler Changed;

        public void Build(Certificates certificates)
        {
            _certificates = certificates;

            tvCertificates.AddCertificates(_certificates);
            tvCertificates.Update();

            BuildProperty();
            //throw new NotImplementedException();
        }

        private void BuildProperty()
        {
            Certificate certificate = new Certificate();
            CurrentControl = (Control)AppLocator.GuiFactory.Create<IView<Certificate>>();
            (CurrentControl as IView<Certificate>).Build(certificate);

        }
    }
}
