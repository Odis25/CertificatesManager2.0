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
using CertificatesModel;
using System.IO;
using System.Diagnostics;
using CertificatesModel.Authorization;

namespace CertificatesViews.Controls
{
    public partial class TechnicalJournalPanel : UserControl, ITechnicalJournalView<Certificate>
    {
        Certificate _certificate;
        string _technicalJournalDirectory;

        public TechnicalJournalPanel()
        {
            InitializeComponent();
        }

        public event EventHandler Changed = delegate { };

        public void Build(Certificate cert)
        {
            ParentForm.Icon = Properties.Resources.Delicious1;
            ParentForm.Text = "Технические отчеты " + cert.ObjectName;
            ParentForm.FormBorderStyle = FormBorderStyle.FixedSingle;

            var checkedContractNumber = string.Join("-", cert.ContractNumber.Split(Path.GetInvalidFileNameChars()));
            var checkedObjectname = string.Join("'", cert.ObjectName.Split(Path.GetInvalidFileNameChars()));
            var checkedDeviceName = string.Join("-", cert.DeviceName.Split(Path.GetInvalidFileNameChars()));
            _technicalJournalDirectory = Path.Combine(Settings.Instance.CertificatesFolderPath, cert.Year.ToString(), checkedContractNumber, "Технический отчет", checkedObjectname);

            if (Directory.Exists(_technicalJournalDirectory))
                lbFiles.Items.AddRange(Directory.GetFiles(_technicalJournalDirectory));

            CheckUser();
        }

        private void CheckUser()
        {
            switch (Authorization.CurrentUser.UserRights.ToLower())
            {
                case "user":
                    btAttachFile.Enabled = false;
                    break;
                default:
                    btAttachFile.Enabled = true;
                    break;
            }
        }

        // Присоединяем файлы отчетов
        private void btAttachFile_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in ofd.FileNames)
                {
                    if (!File.Exists(Path.Combine(_technicalJournalDirectory, Path.GetFileName(file))) && !lbFiles.Items.Contains(file))
                        lbFiles.Items.Add(file);
                }
            }
        }

        // Применить изменения и закрыть окно формы
        private void btOk_Click(object sender, EventArgs e)
        {
            ApplyChanges();
        }

        // Открыть выбранный файл
        private void btOpen_Click(object sender, EventArgs e)
        {
            var file = lbFiles.SelectedItem?.ToString();
            if (file != null)
                if (File.Exists(file))
                    Process.Start(file);
                else
                    MessageBox.Show("Не удалось открыть выбранный файл.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Открыть папку с тех.отчетами
        private void btOpenFolder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(_technicalJournalDirectory))
                Process.Start(_technicalJournalDirectory);
        }

        // Применить изменения
        private void ApplyChanges()
        {
            // Если директории не существует - создаем
            if (!Directory.Exists(_technicalJournalDirectory))
                Directory.CreateDirectory(_technicalJournalDirectory);

            foreach (var file in lbFiles.Items)
            {
                var newFile = Path.GetFileName(file.ToString());
                if (!File.Exists(Path.Combine(_technicalJournalDirectory, newFile.ToString())))
                    File.Copy(file.ToString(), Path.Combine(_technicalJournalDirectory, newFile));
            }
        }
    }
}
