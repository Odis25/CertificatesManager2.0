using CertificatesModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CertificatesViews.Controls
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            // Получаем настройки
            GetSettings();
        }

        private void GetSettings()
        {
            tbDataBasePath.Text = Settings.DataBasePath;
            tbCertificatesFolderPath.Text = Settings.CertificatesFolderPath;
            tbCertificatesZipFolderPath.Text = Settings.CertificatesZipFolderPath;
            chbAutoPreviewEnabled.Checked = Settings.AutoPreviewEnabled;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
