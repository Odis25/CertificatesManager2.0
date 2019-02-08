﻿using CertificatesModel;
using CertificatesModel.Authorization;
using CertificatesModel.Domain.UsersModel;
using CertificatesModel.Interfaces;
using CertificatesViews.Controls;
using CertificatesViews.Factories;
using CertificatesViews.Interfaces;
using System;
using System.IO;
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
            Authorization.UserChanged += Authorization_UserChanged;
            BuildTreeView();
            Authorization_UserChanged(this, EventArgs.Empty);
        }

        // Событие смены пользователя
        private void Authorization_UserChanged(object sender, EventArgs e)
        {
            if (Authorization.CurrentUser.UserRights.ToLower() == "administrator")
                btUsersEdit.Enabled = true;
            else
                btUsersEdit.Enabled = false;
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
            var form = new ContainerForm<MemoryStream, ICreateNewView<MemoryStream>>();
            form.Build(null);
            form.Changed += delegate { };
            form.ShowDialog();
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
            form.Changed += delegate { };
            form.Build(users);
            form.ShowDialog(this);
        }

        #endregion
    }
}
