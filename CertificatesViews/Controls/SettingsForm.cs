using CertificatesModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

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
            tbDataBasePath.Text = Settings.Instance.DataBasePath;
            tbCertificatesFolderPath.Text = Settings.Instance.CertificatesFolderPath;
            tbCertificatesZipFolderPath.Text = Settings.Instance.CertificatesZipFolderPath;
            chbAutoPreviewEnabled.Checked = Settings.Instance.AutoPreviewEnabled;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSaveChanges_Click(object sender, EventArgs e)
        {
            Settings.Instance.DataBasePath = tbDataBasePath.Text;
            Settings.Instance.CertificatesFolderPath = tbCertificatesFolderPath.Text;
            Settings.Instance.CertificatesZipFolderPath = tbCertificatesZipFolderPath.Text;
            Settings.Serialize();
        }
    }
}
