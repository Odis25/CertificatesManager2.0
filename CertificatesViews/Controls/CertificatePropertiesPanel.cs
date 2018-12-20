using CertificatesModel;
using CertificatesModel.Components;
using CertificatesViews.Interfaces;
using System;
using System.Windows.Forms;

namespace CertificatesViews.Controls
{
    public partial class CertificatePropertiesPanel : UserControl, IView<Certificate>
    {
        Control _currentControl;
        Certificate _certificate;

        public event EventHandler Changed;

        public Control CurrentControl
        {
            get { return _currentControl; }
            set
            {
                if (_currentControl != null)
                    _currentControl.Dispose();
                _currentControl = value;
                value.Dock = DockStyle.Fill;
                value.Parent = this;
                value.BringToFront();
            }
        }

        public CertificatePropertiesPanel()
        {
            InitializeComponent();
        }


        public void Build(Certificate certificate)
        {
            if (_certificate != certificate)
            {
                _certificate = certificate;

                if (_certificate != null)
                    FillTextBoxes();
            }

        }

        // Заполняем форму данными
        private void FillTextBoxes()
        {
            numId.Value = _certificate.ID;
            numYear.Value = _certificate.Year;
            tbCertificateNumber.Text = _certificate.CertificateNumber;
            tbRegisterNumber.Text = _certificate.RegisterNumber;
            cbVerificationMethod.Text = _certificate.VerificationMethod;
            tbContractNumber.Text = _certificate.ContractNumber;
            tbClientName.Text = _certificate.ClientName;
            tbObjectName.Text = _certificate.ObjectName;
            tbDeviceType.Text = _certificate.DeviceType;
            tbDeviceName.Text = _certificate.DeviceName;
            tbSerialNumber.Text = _certificate.SerialNumber;
            try
            {
                dpCalibrationDate.Value = _certificate.CalibrationDate;
                dpCalibrationExpireDate.Value = _certificate.CalibrationExpireDate;
            }
            catch
            {
                dpCalibrationDate.Value = dpCalibrationDate.MinDate;
                dpCalibrationExpireDate.Value = dpCalibrationExpireDate.MinDate;
            }

        }

        private void btSearch_Click(object sender, EventArgs e)
        {      
            Changed(this, MakeSearchPattern());
        }

        private CertificateEventArgs MakeSearchPattern()
        {
            CertificateEventArgs temp = new CertificateEventArgs();
            temp.ID = chbId.Checked ? (int?)numId.Value : null;
            temp.Year = chbYear.Checked ? (int?)numYear.Value : null;
            temp.CertificateNumber = chbCertificateNumber.Checked ? tbCertificateNumber.Text : null;
            temp.RegisterNumber = chbRegisterNumber.Checked ? tbRegisterNumber.Text : null;
            temp.VerificationMethod = chbVerificationMethod.Checked ? cbVerificationMethod.Text : null;
            temp.ContractNumber = chbContractNumber.Checked ? tbContractNumber.Text : null;
            temp.ClientName = chbClientName.Checked ? tbClientName.Text : null;
            temp.ObjectName = chbObjectName.Checked ? tbObjectName.Text : null;
            temp.DeviceType = chbDeviceType.Checked ? tbDeviceType.Text : null;
            temp.DeviceName = chbDeviceName.Checked ? tbDeviceName.Text : null;
            temp.SerialNumber = chbSerialNumber.Checked ? tbSerialNumber.Text : null;
            temp.CalibrationDate = chbCalibrationDate.Checked ? dpCalibrationDate?.Value : null;
            temp.CalibrationExpireDate = chbCalibrationExpireDate.Checked ? dpCalibrationExpireDate?.Value : null;

            return temp;
        }
    }
}
