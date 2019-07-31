using CertificatesModel;
using CertificatesModel.Authorization;
using CertificatesModel.Domain.UsersModel;
using CertificatesViews.Interfaces;
using System;
using System.Windows.Forms;

namespace CertificatesViews.Controls
{
    public partial class AuthorizationPanel : UserControl, IAuthorizationView<User>
    {
        public AuthorizationPanel()
        {
            InitializeComponent();
        }

        public event EventHandler Changed;

        public void Build(User obj)
        {
            var parent = Parent as Form;
            parent.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            parent.Text = "Авторизация";
            parent.AcceptButton = btLogin;
            parent.CancelButton = btCancel;

            chbSaveCredentials.Checked = Settings.Instance.SaveUserCredential;
            tbDomain.Text = obj.Domain;
            tbLogin.Text = obj.Login;
            tbPassword.Text = obj.Password;
        }

        // Попытка авторизации пользователя
        private void btLogin_Click(object sender, EventArgs e)
        {
            var user = new User() { Login = tbLogin.Text, Password = tbPassword.Text };

            // Попытка авторизации
            TryToAuthorizate(user);
        }

        // Выход из приложения
        private void btCancel_Click(object sender, EventArgs e)
        {
            var parent = Parent as Form;
            parent.Close();
        }

        // Попытка авторизации
        private void TryToAuthorizate(User user)
        {
            Settings.Instance.SaveUserCredential = chbSaveCredentials.Checked;
            Authorization.LogIn(user);
            if (!Authorization.UserLogined)
                return;
            Settings.Serialize();
            Changed(this, EventArgs.Empty);
        }
    }
}
