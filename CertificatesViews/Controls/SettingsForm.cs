using CertificatesModel;
using System;
using System.Windows.Forms;

namespace CertificatesViews.Controls
{

    public partial class SettingsForm : Form
    {
        public event EventHandler Changed = delegate { }; 

        public SettingsForm()
        {
            InitializeComponent();
            
            // Получаем настройки
            GetSettings();
        }

        // Получение настроек приложения
        private void GetSettings()
        {
            tbDataBasePath.Text = Settings.Instance.DataBasePath;
            tbCertificatesFolderPath.Text = Settings.Instance.CertificatesFolderPath;
            tbCertificatesZipFolderPath.Text = Settings.Instance.CertificatesZipFolderPath;
            chbAutoPreviewEnabled.Checked = Settings.Instance.AutoPreviewEnabled;
            // Отключаем кнопку сохранения
            btSaveChanges.Enabled = false;
        }

        //Закрытие окна
        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Сохраняем изменения настроек
        private void btSaveChanges_Click(object sender, EventArgs e)
        {
            Settings.Instance.DataBasePath = tbDataBasePath.Text;
            Settings.Instance.CertificatesFolderPath = tbCertificatesFolderPath.Text;
            Settings.Instance.CertificatesZipFolderPath = tbCertificatesZipFolderPath.Text;
            Settings.Instance.AutoPreviewEnabled = chbAutoPreviewEnabled.Checked;

            // Сериализуем класс настроек
            Settings.Serialize();
            btSaveChanges.Enabled = false;

            Changed(this, EventArgs.Empty); // сработка события на главной форме
        }

        // Событие изменения настроек
        private void SettingsChanged(object sender, EventArgs e)
        {
            // включаем кнопку сохранения
            btSaveChanges.Enabled = true;
        }

        // Выбрать файл БД
        private void btChangeDataBasePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Файл БД SQL COmpact(*.sdf)|*.sdf";
            ofd.InitialDirectory = tbDataBasePath.Text;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tbDataBasePath.Text = ofd.FileName;
            }
        }

        // Выбрать каталог хранения свидетельств
        private void btChangeCertificatesFolderPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = tbCertificatesFolderPath.Text;
            fbd.Description = "Выберите папку для хранения свидетельств поверки";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tbCertificatesFolderPath.Text = fbd.SelectedPath;
            }
        }

        // Выбрать каталог резервного хранения свидетельств
        private void btChangeCertificatesZipFolderPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = tbCertificatesZipFolderPath.Text;
            fbd.Description = "Выберите папку для резервного хранения свидетельств поверки";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tbCertificatesZipFolderPath.Text = fbd.SelectedPath;
            }
        }
    }
}
