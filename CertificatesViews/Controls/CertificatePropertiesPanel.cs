using CertificatesModel;
using CertificatesModel.Components;
using CertificatesViews.Interfaces;
using System;
using System.Windows.Forms;
using System.Linq;
using System.IO;

namespace CertificatesViews.Controls
{
    public partial class CertificatePropertiesPanel : UserControl, IView<Certificate>
    {
        // Свидетельство
        Certificate _certificate;

        // Событие изменения формы
        public event EventHandler Changed = delegate { };

        // Конструктор класса
        public CertificatePropertiesPanel()
        {
            InitializeComponent();

            CheckBoxes_CheckedChanged(this, EventArgs.Empty);
        }

        public void Build(Certificate certificate)
        {
            if (_certificate != certificate)
                _certificate = certificate;

            // Заполняем текстбоксы
            if (certificate != null)
                FillTextBoxes(certificate);
        }

        // Заполняем форму данными
        private void FillTextBoxes(Certificate certificate)
        {
            numId.Value = certificate.ID;
            numYear.Value = certificate.Year;
            tbCertificateNumber.Text = certificate.CertificateNumber;
            tbRegisterNumber.Text = certificate.RegisterNumber;
            cbVerificationMethod.Text = certificate.VerificationMethod;
            tbContractNumber.Text = certificate.ContractNumber;
            tbClientName.Text = certificate.ClientName;
            tbObjectName.Text = certificate.ObjectName;
            tbDeviceType.Text = certificate.DeviceType;
            tbDeviceName.Text = certificate.DeviceName;
            tbSerialNumber.Text = certificate.SerialNumber;
            try
            {
                dpCalibrationDate.Value = certificate.CalibrationDate;
                dpCalibrationExpireDate.Value = certificate.CalibrationExpireDate;
            }
            catch
            {
                dpCalibrationDate.Value = dpCalibrationDate.MinDate;
                dpCalibrationExpireDate.Value = dpCalibrationExpireDate.MinDate;
            }
        }

        // Поиск по шаблону
        private void btSearch_Click(object sender, EventArgs e)
        {
            // передаем событие с аргументами в родительскую форму
            Changed(this, MakeSearchPattern());
        }

        // Если все чекбоксы пустые, то отключаем кнопку поиска
        private void CheckBoxes_CheckedChanged(object sender, EventArgs e)
        {
            if (groupBox2.Controls.OfType<CheckBox>().Any(x => x.Checked))
                btSearch.Enabled = true;
            else
                btSearch.Enabled = false;
        }

        // Внести изменения в свидетельство
        private void btEdit_Click(object sender, EventArgs e)
        {
            Changed(sender, MakeEditPattern());
        }

        // Создаем аргументы событию поиска
        private CertificateEventArgs MakeSearchPattern()
        {
            CertificateEventArgs pattern = new CertificateEventArgs();
            pattern.ID = chbId.Checked ? (int?)numId.Value : null;
            pattern.Year = chbYear.Checked ? (int?)numYear.Value : null;
            pattern.CertificateNumber = chbCertificateNumber.Checked ? tbCertificateNumber.Text : null;
            pattern.RegisterNumber = chbRegisterNumber.Checked ? tbRegisterNumber.Text : null;
            pattern.VerificationMethod = chbVerificationMethod.Checked ? cbVerificationMethod.Text : null;
            pattern.ContractNumber = chbContractNumber.Checked ? tbContractNumber.Text : null;
            pattern.ClientName = chbClientName.Checked ? tbClientName.Text : null;
            pattern.ObjectName = chbObjectName.Checked ? tbObjectName.Text : null;
            pattern.DeviceType = chbDeviceType.Checked ? tbDeviceType.Text : null;
            pattern.DeviceName = chbDeviceName.Checked ? tbDeviceName.Text : null;
            pattern.SerialNumber = chbSerialNumber.Checked ? tbSerialNumber.Text : null;
            pattern.CalibrationDate = chbCalibrationDate.Checked ? dpCalibrationDate?.Value : null;
            pattern.CalibrationExpireDate = chbCalibrationExpireDate.Checked ? dpCalibrationExpireDate?.Value : null;

            return pattern;
        }

        // Создаем аргументы событию изменения
        private CertificateEventArgs MakeEditPattern()
        {
            CertificateEventArgs pattern = new CertificateEventArgs();
            
            // Немодифицируемые параметры
            pattern.ID = (int)numId.Value;

            // Модифицируемые параметры
            pattern.Year = (int)numYear.Value;
            pattern.CertificateNumber = tbCertificateNumber.Text;
            pattern.RegisterNumber = tbRegisterNumber.Text;
            pattern.VerificationMethod = cbVerificationMethod.Text;
            pattern.ContractNumber = tbContractNumber.Text;
            pattern.ClientName = tbClientName.Text;
            pattern.ObjectName = tbObjectName.Text;
            pattern.DeviceType = tbDeviceType.Text;
            pattern.DeviceName = tbDeviceName.Text;
            pattern.SerialNumber = tbSerialNumber.Text;
            pattern.CalibrationDate = dpCalibrationDate.Value;
            pattern.CalibrationExpireDate = dpCalibrationExpireDate?.Value;

            // Автоматически формируемые параметры
            var checkedContractNumber = pattern.ContractNumber.Replace('/', '-').Replace('\\', '-');
            pattern.CertificatePath = $"{Settings.Instance.CertificatesFolderPath}\\{pattern.Year}\\{checkedContractNumber}\\Свидетельства\\{pattern.DeviceType}_{pattern.DeviceName + Path.GetExtension(_certificate.CertificatePath)}";

            // Возвращаем сформированный шаблон
            return pattern;
        }
    }
}
