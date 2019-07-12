using CertificatesModel;
using CertificatesModel.Authorization;
using CertificatesModel.Domain.UsersModel;
using CertificatesModel.Interfaces;
using CertificatesViews.Components;
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

        // Событие для отслеживания изменения формы
        public event EventHandler Changed = delegate { };

        // Список свидетельств
        private Certificates Certificates
        {
            get { return _certificates; }
            set
            {
                _certificates = value;
                tsCertificatesQuantity.Text = _certificates.Count().ToString();
            }
        }
        // текущий контрол ( TreeView )
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

        // Текущий пользователей
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
                    case "specialist":
                        tsUserRights.Text = "(Специалист)";
                        tsUserLabel.Image = Properties.Resources.user;
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

            var waiting = new PleaseWait();
            Authorization.UserChanged += Authorization_UserChanged;

            BuildCertificatesPanel();
            Authorization_UserChanged(this, EventArgs.Empty);
            waiting.Dispose();
        }

        // Событие смены пользователя
        private void Authorization_UserChanged(object sender, EventArgs e)
        {
            // Устанавливаем текущего пользователя
            CurrentUser = Authorization.CurrentUser;

            switch (Authorization.CurrentUser.UserRights.ToLower())
            {
                case "administrator":
                    btUsersEdit.Enabled = true;
                    btAdd.Enabled = true;
                    break;
                case "metrolog":
                    btAdd.Enabled = true;
                    btUsersEdit.Enabled = false;
                    break;
                default:
                    btUsersEdit.Enabled = false;
                    btAdd.Enabled = false;
                    break;
            }
        }

        // Дерево свидетельств
        private void BuildCertificatesPanel()
        {
            // Получаем список свидетельств
            var loader = AppLocator.ModelFactory.Create<ICertificatesLoader>();
            Certificates = loader.GetAllCertificates();

            // Устанавливаем текущего пользователя
            CurrentUser = Authorization.CurrentUser;

            var view = AppLocator.GuiFactory.Create<ICertificatePanelView<Certificates>>();
            view.Changed += delegate
            {
                _certificates = loader.GetAllCertificates();
                view.Build(_certificates);
            };

            CurrentControl = view as Control;
            view.Build(_certificates);
        }

        // Кнопка "добавить"
        private void btAdd_Click(object sender, EventArgs e)
        {
            OpenAddingNewCertificateForm();
        }

        // Кнопка "настройки"
        private void btSettings_Click(object sender, EventArgs e)
        {
            OpenSettingsForm();
        }

        // Кнопка "сменить пользователя"
        private void btChangeUser_Click(object sender, EventArgs e)
        {
            OpenUserChangingForm();
        }

        // Кнопка "управление акаунтами"
        private void btUsersEdit_Click(object sender, EventArgs e)
        {
            OpenUserAccountsEditForm();
        }

        // Кнопка "О программе"
        private void btAbout_Click(object sender, EventArgs e)
        {
            var form = new AboutForm();
            form.ShowDialog();
        }

        #region Add, Remove, Settings, UserChanging, AccountsEdit
        // Добавление нового свидетельства
        private void OpenAddingNewCertificateForm()
        {
            var form = new ContainerForm<byte[], ICreateNewView<byte[]>>();
            form.Build(null);
            form.Changed += delegate { };
            form.ShowDialog();

            (CurrentControl as IView<Certificates>).Build(_certificates);
        }

        // Настройки
        private void OpenSettingsForm()
        {
            var form = new SettingsForm();
            form.Changed += MainForm_Changed;
            form.ShowDialog();
        }

        private void MainForm_Changed(object sender, EventArgs e)
        {
            (CurrentControl as ICertificatePanelView<Certificates>).ShowOrHidePreviewPanel();
        }

        // Смена пользователя
        private void OpenUserChangingForm()
        {
            var form = new ContainerForm<User, IView<User>>();
            form.Build(CurrentUser);
            form.Changed += delegate { form.DialogResult = DialogResult.OK; CurrentUser = Authorization.CurrentUser; };
            form.ShowDialog();
        }

        // Редактирование пользователей (только для администратора)
        private void OpenUserAccountsEditForm()
        {
            var model = AppLocator.ModelFactory.Create<UsersLoader>();
            var users = model.GetUsersList();
            var form = new ContainerForm<Users, IView<Users>>();
            form.Changed += delegate 
            {
                Authorization.SetNewCurrentUserRights();
                //CurrentUser = Authorization.CurrentUser;
            };
            form.Build(users);
            form.ShowDialog(this);
        }

        #endregion

        
    }
}
