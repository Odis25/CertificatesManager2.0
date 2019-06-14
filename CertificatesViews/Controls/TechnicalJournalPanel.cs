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

namespace CertificatesViews.Controls
{
    public partial class TechnicalJournalPanel : UserControl, IView<Certificate>
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
            var checkedContractNumber = string.Join("-", cert.ContractNumber.Split(Path.GetInvalidFileNameChars()));
            var checkedObjectname = string.Join("'", cert.ObjectName.Split(Path.GetInvalidFileNameChars()));
            var checkedDeviceName = string.Join("-", cert.DeviceName.Split(Path.GetInvalidFileNameChars()));
            _technicalJournalDirectory = Path.Combine(Settings.Instance.CertificatesFolderPath, cert.Year.ToString(), checkedContractNumber, "Технический отчет", checkedObjectname);

            if (Directory.Exists(_technicalJournalDirectory))
                lbFiles.Items.AddRange(Directory.GetFiles(_technicalJournalDirectory));
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
       
        private void btOk_Click(object sender, EventArgs e)
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
