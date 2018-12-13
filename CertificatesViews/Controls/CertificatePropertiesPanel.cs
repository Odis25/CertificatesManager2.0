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
    }
}
