using CertificatesModel.Authorization;
using CertificatesModel.Domain.UsersModel;
using CertificatesModel.Factories;
using CertificatesViews;
using CertificatesViews.Controls;
using CertificatesViews.Factories;
using CertificatesViews.Interfaces;
using System;
using System.Threading;
using System.Windows.Forms;

namespace CertificatesDesktop
{
    static class Program
    {

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (System.Diagnostics.Process.GetProcessesByName(Application.ProductName).Length > 1)
            {
                // Приложение уже запущено
                MessageBox.Show("Приложение уже запущено.", "Certificate Manager", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            // Обработка исключений
            ExceptionHandler.Init();

            // Создаем фабрики
            CertificatesViews.Factories.AppLocator.GuiFactory = new GuiFactory();
            CertificatesViews.Factories.AppLocator.ModelFactory = new ModelFactory();
            CertificatesModel.Factories.AppLocator.ModelFactory = new ModelFactory();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Авторизация пользователя           
            if (!Authorization.UserLogined)
            {
                var loginForm = new ContainerForm<User, IView<User>>();
                loginForm.Build(Authorization.CurrentUser);

                loginForm.Changed += delegate { loginForm.DialogResult = DialogResult.OK; };
                if (loginForm.ShowDialog() == DialogResult.Cancel)
                    Environment.Exit(0);
            }

            Application.Run(new MainForm());
        }
    }
}
