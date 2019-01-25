using CertificatesModel;
using CertificatesModel.Authorization;
using CertificatesModel.Domain.UsersModel;
using CertificatesModel.Interfaces;
using CertificatesViews.Controls;
using CertificatesViews.Factories;
using CertificatesViews.Interfaces;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CertificatesViews
{
    public partial class MainForm : Form
    {
        private Certificates _certificates;
        private Control _currentControl;
        private User _currentUser;

        public event EventHandler Changed = delegate { };

        private Certificates Certificates
        {
            get { return _certificates; }
            set
            {
                _certificates = value;
                tsCertificatesQuantity.Text = _certificates.Count().ToString();
            }
        }
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
        private User CurrentUser
        {
            set
            {
                _currentUser = value;
                tsCurrentUser.Text = _currentUser.Login;

                switch (_currentUser.UserRights.ToLower())
                {
                    case "administrator":
                        tsUserRights.Text = "(Администратор)";
                        tsUserLabel.Image = Properties.Resources.user_suit;
                        break;
                    case "metrolog":
                    case "metrologist":
                        tsUserRights.Text = "(Метролог)";
                        tsUserLabel.Image = Properties.Resources.user_gray;
                        break;
                    default:
                        tsUserRights.Text = "(Пользователь)";
                        tsUserLabel.Image = Properties.Resources.user;
                        break;
                }
            }
            get { return Authorization.CurrentUser; }
        }

        public MainForm()
        {
            InitializeComponent();
            BuildTreeView();
        }

        // Дерево свидетельств
        private void BuildTreeView()
        {
            // Получаем список свидетельств
            var loader = AppLocator.ModelFactory.Create<ICertificatesLoader>();
            Certificates = loader.GetAllCertificates();

            // Устанавливаем текущего пользователя
            CurrentUser = Authorization.CurrentUser;

            var view = AppLocator.GuiFactory.Create<IView<Certificates>>();
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
            var form = new ContainerForm<User>();
            form.Build(CurrentUser);
            form.Changed += delegate { form.DialogResult = DialogResult.OK; CurrentUser = Authorization.CurrentUser; };
            form.ShowDialog();
        }

        private void OpenUserAccountsEditForm()
        {
            var model = AppLocator.ModelFactory.Create<UsersLoader>();
            var users = model.GetUsersList();
            var form = new ContainerForm<Users>();
            form.Build(users);
            // Событие формы
            form.Changed += delegate { };
            form.ShowDialog();
        }

        #endregion
    }
}
