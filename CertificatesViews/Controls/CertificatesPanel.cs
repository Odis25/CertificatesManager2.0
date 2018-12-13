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
using CertificatesViews.Factories;
using System.IO;

namespace CertificatesViews.Controls
{
    public partial class CertificatesPanel : UserControl, IView<Certificates>
    {
        Control _currentControl;
        Certificates _certificates;

        public Control CurrentControl
        {
            get { return _currentControl; }
            set
            {
                if (_currentControl != null)
                    _currentControl.Dispose();
                _currentControl = value;
                if (_currentControl != null)
                {
                    value.Dock = DockStyle.Left;
                    scMainSpliter.SplitterDistance = value.Height;
                    value.Parent = scSecondarySpliter.Panel2;
                    value.BringToFront();
                }
            }
        }

        public CertificatesPanel()
        {
            InitializeComponent();
        }

        public event EventHandler Changed;

        public void Build(Certificates certificates)
        {
            _certificates = certificates;

            tvCertificates.AddCertificates(_certificates);
            tvCertificates.Update();

            BuildProperty();
        }

        private void BuildProperty()
        {
            Certificate certificate = new Certificate();
            CurrentControl = (Control)AppLocator.GuiFactory.Create<IView<Certificate>>();
            (CurrentControl as IView<Certificate>).Build(certificate);

        }

        // Выбираем узел в TreeView
        private void tvCertificates_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Получаем контекст выбранного узла
            var content = e.Node.Tag;
            var type = content.GetType();

            // Заполняем ListView результатами выборки
            if (type == typeof(Certificates))
                FillListView((content as Certificates).ListOfCertificates);
            else if (type == typeof(Year))
                FillListView((content as Year).ListOfCertificates);
            else if (type == typeof(Contract))
                FillListView(content as Contract);

        }

        // Заполнение ListView результатами выборки
        private void FillListView(List<Certificate> certificates)
        {
            // Очищаем ListView перед заполнением результатом выборки
            lvCertificatesDetails.Items.Clear();            

            // Заполняем ListView
            foreach (var cert in certificates)
            {
                FileInfo fileInfo = new FileInfo(cert.CertificatePath);
                string fileSize, fileCreationDate;
                try
                {
                    fileSize = fileInfo.Length.ToString();
                    fileCreationDate = fileInfo.CreationTime.ToString();
                }
                catch
                {
                    fileSize = "---";
                    fileCreationDate = "---";
                }
                lvCertificatesDetails.Items.Add(
                    new ListViewItem(new string[]
                    {
                    cert.ID.ToString(),
                    cert.ContractNumber,
                    cert.CertificateNumber,
                    cert.RegisterNumber,
                    cert.VerificationMethod,
                    cert.ClientName,
                    cert.ObjectName,
                    cert.DeviceType,
                    cert.DeviceName,
                    cert.SerialNumber,
                    cert.CalibrationDate.ToShortDateString(),
                    cert.CalibrationExpireDate.ToShortDateString(),
                    cert.CertificatePath,
                    fileSize,
                    fileCreationDate
                    // TODO: добавить размер файла
                    // TODO: добавить дату создания файла
                    }));
            }
        }

        // Выбор свидетельства в ListView
        private void lvCertificatesDetails_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var id = e.Item.SubItems[0].Text;
            var certificate = _certificates.ListOfCertificates.Where(x => x.ID == int.Parse(id)).ToList()[0];
            if (CurrentControl is CertificatePropertiesPanel)
                (CurrentControl as CertificatePropertiesPanel).Build(certificate);
        }
    }
}
