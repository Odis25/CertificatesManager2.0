using CertificatesModel;
using CertificatesModel.Interfaces;
using CertificatesViews.Controls;
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

        public event EventHandler Changed = delegate { };

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

            BuildTreeView();
        }

        // Дерево свидетельств
        private void BuildTreeView()
        {
            var loader = AppLocator.ModelFactory.Create<ILoader>();
            _certificates = loader.GetAllCertificates();
            var view= AppLocator.GuiFactory.Create<IView<Certificates>>();
            view.Changed += delegate 
            {
                _certificates = loader.GetAllCertificates();
                view.Build(_certificates);
            };
            CurrentControl = view as Control;
            view.Build(_certificates);
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            OpenAddingNewCertificateForm();
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            RemoveCertificateFromDataBase();
        }

        private void btSettings_Click(object sender, EventArgs e)
        {
            OpenSettingsForm();
        }

        private void btChangeUser_Click(object sender, EventArgs e)
        {
            OpenUserChangingForm();
        }

        private void btUsersEdit_Click(object sender, EventArgs e)
        {
            OpenUserAccountsEditForm();
        }

        #region Add, Remove, Settings, UserChanging, AccountsEdit
        private void OpenAddingNewCertificateForm()
        {

        }

        private void RemoveCertificateFromDataBase()
        {

        }

        private void OpenSettingsForm()
        {
            var form = new SettingsForm();
            form.Changed += MainForm_Changed;
            form.ShowDialog();
        }

        private void MainForm_Changed(object sender, EventArgs e)
        {
            //TODO: Антипаттерн. Переделать
            (CurrentControl as CertificatesPanel).ShowOrHidePreviewPanel();
        }

        private void OpenUserChangingForm()
        {

        }

        private void OpenUserAccountsEditForm()
        {

        }

        #endregion
    }
}
