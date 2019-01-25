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
using CertificatesModel.Domain.UsersModel;
using CertificatesModel.Factories;
using CertificatesModel;

namespace CertificatesViews.Controls
{
    public partial class UsersAdministrationPanel : UserControl, IView<Users>
    {
        public UsersAdministrationPanel()
        {
            InitializeComponent();
        }

        public event EventHandler Changed;

        public void Build(Users obj)
        {
            this.Parent.Dock = DockStyle.Left;
            Parent.Width = 455;
            ParentForm.Height = 292;
            Width = 445;
            Height = 272;

            BindingSource data = new BindingSource();

            dgvUsers.DataSource = obj.ToList();
            dgvUsers.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }
    }
}
