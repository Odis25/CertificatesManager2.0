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

namespace CertificatesViews.Controls
{
    public partial class CertificatesPanel : UserControl, IView<Certificates>
    {
        Certificates _certificates;

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
            //throw new NotImplementedException();
        }
    }
}
