using CertificatesModel;
using CertificatesModel.Interfaces;
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

namespace CertificatesViews
{
    public partial class MainForm : Form
    {
        Certificates _certificates;
        Control _currentControl;

        private Control CurrentControl
        {
            get { return _currentControl; }
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

        public MainForm()
        {
            InitializeComponent();

            CreateNewCertificates();
        }

        private void CreateNewCertificates()
        {
            var loader = AppLocator.ModelFactory.Create<ILoader>();
            _certificates = loader.Load();
            CurrentControl = (Control)AppLocator.GuiFactory.Create<IView<Certificates>>();
            (CurrentControl as IView<Certificates>).Build(_certificates);
        }
    }
}
