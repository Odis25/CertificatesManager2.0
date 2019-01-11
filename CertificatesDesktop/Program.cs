using CertificatesModel.Factories;
using CertificatesViews.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CertificatesModel.Authorization;
using CertificatesViews.Interfaces;
using CertificatesViews;
using CertificatesViews.Controls;
using CertificatesModel.UsersModel;

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
                var loginForm = new ContainerForm<User>();
                loginForm.Build(Authorization.CurrentUser);

                loginForm.Changed += delegate { loginForm.DialogResult = DialogResult.OK; };
                if (loginForm.ShowDialog() == DialogResult.Cancel)
                    Environment.Exit(0);
            }

            Application.Run(new MainForm());
        }
    }
}
