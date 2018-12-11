using CertificatesModel.Factories;
using CertificatesViews.Factories;
using CertificatesViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            // Создаем фабрики
            AppLocator.GuiFactory = new GuiFactory();
            AppLocator.ModelFactory = new ModelFactory();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
