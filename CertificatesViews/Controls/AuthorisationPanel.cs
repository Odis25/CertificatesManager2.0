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
using CertificatesModel.Authorization;
using CertificatesModel;
using CertificatesModel.UsersModel;

namespace CertificatesViews.Controls
{
    public partial class AuthorisationPanel : UserControl, IView<User>
    {
        public AuthorisationPanel()
        {
            InitializeComponent();
        }

        public event EventHandler Changed;

        public void Build(User obj)
        {
            var parent = Parent as Form;
            parent.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            parent.Dock = DockStyle.Fill;
            parent.Text = "Авторизация";
            parent.Height = 210;
            parent.Width = 310;

            chbSaveCredentials.Checked = Settings.Instance.SaveUserCredential;
        }

        // Попытка авторизации пользователя
        private void btOk_Click(object sender, EventArgs e)
        {
            var user = new User()
            {
                Login = tbLogin.Text,
                Password = tbPassword.Text
            };

            // Попытка авторизации
            TryToAuthorisate(user);
        }

        // Выход из приложения
        private void btCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Попытка авторизации
        private void TryToAuthorisate(User user)
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
