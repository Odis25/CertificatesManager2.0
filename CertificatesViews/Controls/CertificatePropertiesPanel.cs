using CertificatesModel;
using CertificatesModel.Components;
using CertificatesViews.Interfaces;
using System;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using System.Drawing;
using CertificatesModel.Authorization;

namespace CertificatesViews.Controls
{
    public partial class CertificatePropertiesPanel : UserControl, IDetailsView<Certificate, Certificates>
    {
        // Свидетельство
        Certificate _certificate;
        Certificates _certificates;

        // События
        public event EventHandler Changed = delegate { };
        public event EventHandler Edited;
        public event EventHandler Deleted;
        public event EventHandler Search;

        // Конструктор класса
        public CertificatePropertiesPanel()
        {
            InitializeComponent();

            CheckBoxes_CheckedChanged(this, EventArgs.Empty);
            // Событие смены пользователя
            Authorization.UserChanged += delegate { UserChanged(); };

            UserChanged();
        }

        public void Build(Certificate certificate, Certificates certificates)
        {
            if (_certificate != certificate)
                _certificate = certificate;

            if (_certificates != certificates)
            {
                _certificates = certificates;
                CreateAutoCompleteCollection();
            }

            // Заполняем текстбоксы
            if (certificate != null)
                FillTextBoxes(certificate);
        }

        // Состояние кнопок
        private void UserChanged()
        {
            if (Authorization.CurrentUser.UserRights.ToLower() == "user")
            {
                btDelete.Enabled = false;
                btEdit.Enabled = false;
            }
            else
            {
                btDelete.Enabled = true;
                btEdit.Enabled = true;
            }
        }

        // Списки автозаполнения для textbox и combobox
        private void CreateAutoCompleteCollection()
        {
            tbCertificateNumber.AutoCompleteCustomSource.AddRange(_certificates.Select(x => x.CertificateNumber).Distinct().Where(x=> x != null).ToArray());
            tbRegisterNumber.AutoCompleteCustomSource.AddRange(_certificates.Select(x => x.RegisterNumber).Distinct().Where(x => x != null).ToArray());
            tbContractNumber.AutoCompleteCustomSource.AddRange(_certificates.Select(x => x.ContractNumber).Distinct().Where(x => x != null).ToArray());
            tbClientName.AutoCompleteCustomSource.AddRange(_certificates.Select(x => x.ClientName).Distinct().Where(x => x != null).ToArray());
            tbObjectName.AutoCompleteCustomSource.AddRange(_certificates.Select(x => x.ObjectName).Distinct().Where(x => x != null).ToArray());
            tbDeviceType.AutoCompleteCustomSource.AddRange(_certificates.Select(x => x.DeviceType).Distinct().Where(x => x != null).ToArray());
            tbDeviceName.AutoCompleteCustomSource.AddRange(_certificates.Select(x => x.DeviceName).Distinct().Where(x => x != null).ToArray());
            tbSerialNumber.AutoCompleteCustomSource.AddRange(_certificates.Select(x => x.SerialNumber).Distinct().Where(x => x != null).ToArray());
            cbVerificationMethod.Items.AddRange(_certificates.Select(x => x.VerificationMethod).Distinct().Where(x => x != null).ToArray());
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

        // Если все чекбоксы пустые, то отключаем кнопку поиска
        private void CheckBoxes_CheckedChanged(object sender, EventArgs e)
        {
            if (groupBox2.Controls.OfType<CheckBox>().Any(x => x.Checked))
                btSearch.Enabled = true;
            else
                btSearch.Enabled = false;
        }

        // Поиск по шаблону
        private void btSearch_Click(object sender, EventArgs e)
        {
            // передаем событие с аргументами в родительскую форму
            Search(this, MakeSearchPattern());
        }

        // Внести изменения в свидетельство
        private void btEdit_Click(object sender, EventArgs e)
        {
            // Запускаем событие на изменение
            var question = MessageBox.Show("Вы уверены что хотите внести изменения в выбранные свидетельства?", "Внесение изменений", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (question == DialogResult.OK)
                Edited(sender, MakeEditPattern());
        }

        // Удалить выбранные свидетельства
        private void btDelete_Click(object sender, EventArgs e)
        {
            // Запускаем событие на удаление
            var question = MessageBox.Show("Вы уверены что хотите удалить выбранные свидетельства?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (question == DialogResult.OK)
                Deleted(sender, EventArgs.Empty);
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
            pattern.CalibrationDate = dpCalibrationDate.Value.Date;
            pattern.CalibrationExpireDate = dpCalibrationExpireDate.Value.Date;

            // Автоматически формируемые параметры
            var checkedContractNumber = pattern.ContractNumber.Replace('/', '-').Replace('\\', '-');
           
            pattern.CertificatePath = Path.Combine(pattern.Year.ToString(), checkedContractNumber, "Свидетельства", $"{pattern.DeviceType}_{pattern.DeviceName}" + Path.GetExtension(_certificate.CertificatePath));

            // Возвращаем сформированный шаблон
            return pattern;
        }

        // Отрисовка подсказок для списка Item в комбобоксе методик поверки
        private void cbVerificationMethod_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
                return;

            string text = cbVerificationMethod.GetItemText(cbVerificationMethod.Items[e.Index]);
            e.DrawBackground();
            using (SolidBrush br = new SolidBrush(e.ForeColor))
            {
                e.Graphics.DrawString(text, e.Font, br, e.Bounds);
            }

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                tipVerificationMethodItems.Show(text, cbVerificationMethod, e.Bounds.Right, e.Bounds.Bottom);
            }
            else
            {
                tipVerificationMethodItems.Hide(cbVerificationMethod);
            }
            e.DrawFocusRectangle();
        }
        private void cbVerificationMethod_DropDownClosed(object sender, EventArgs e)
        {
            tipVerificationMethodItems.Hide(cbVerificationMethod);
        }
    }
}
