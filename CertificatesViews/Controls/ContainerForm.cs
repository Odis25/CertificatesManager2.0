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
        public ContainerForm()
        {
            InitializeComponent();
        }

        public event EventHandler Changed;

        public void Build(T obj)
        {
            throw new NotImplementedException();
        }
    }


}
