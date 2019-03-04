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
using CertificatesViews.Components;
using System.Text.RegularExpressions;
using System.IO;
using CertificatesModel.Components;
using System.Diagnostics;
using CertificatesModel.ExcelService;

namespace CertificatesViews.Controls
{

    public partial class CreateActPanel : UserControl, ICreateNewActView<Certificates>
    {
        // Свидетельства по которым формируется акт
        private Certificates _certificates;
        
        // Номер Акта
        private int ActNumber
        {
            get
            {
                Regex reg = new Regex(@"№\d{1,}");
                var reg2 = new Regex(@"\d{1,}");
                string path;
                var aktNumbers = new List<int>();

                if (cbDepType.SelectedIndex == 1)
                    path = Path.Combine(Settings.Instance.CertificatesFolderPath, "АКТЫ", DateTime.Now.Year.ToString(),"ТОиС");
                else
                    path = Path.Combine(Settings.Instance.CertificatesFolderPath, "АКТЫ",  DateTime.Now.Year.ToString(), "МС");

                // Если директория уже существует получаем номер
                if (Directory.Exists(path))
                {
                    var files = Directory.GetFiles(path);
                    foreach (var file in files)
                    {
                        Match aktNumber = reg2.Match(reg.Match(file).Value);
                        aktNumbers.Add(Convert.ToInt32(aktNumber.Value));
                    }

                    return aktNumbers.Count > 0 ? aktNumbers.Max() + 1 : 1;
                }
                else
                    return 1;
            }
        }

        // Конструктор
        public CreateActPanel()
        {
            InitializeComponent();

            // создаем заголовок с checkbox для DataGridView
            CheckBoxHeaderCell checkheader = new CheckBoxHeaderCell();
            checkheader.Value = "С протоколом";

            checkheader.OnCheckBoxHeaderClick += Checkheader_OnCheckBoxHeaderClick;
            dgvActSettings.Columns[3].HeaderCell = checkheader;
        }

        // Событие изменения формы
        public event EventHandler Changed = delegate { };

        // Передача параметров в класс
        public void Build(Certificates selectedCertificates)
        {
            _certificates = selectedCertificates;
            FillDataGridView(selectedCertificates);
            cbDepType.SelectedIndex = 0;            
        }

        // Заполняем DataGridView результатами
        private void FillDataGridView(Certificates certificates)
        {
            for (int i = 0; i < certificates.Count; i++)
                dgvActSettings.Rows.Add(i + 1, certificates[i].DeviceName, certificates[i].CertificateNumber, false, certificates[i].SerialNumber, 0);

            lbClientName.Text = certificates[0].ClientName;
            lbContractNumber.Text = certificates[0].ContractNumber;
            lbAktNumber.Text = ActNumber.ToString();
        }

        private void dgvActSettings_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (((DataGridView)sender).CurrentCell.OwningColumn.Index == 5)
            {
                e.Control.KeyPress -= new KeyPressEventHandler(Control_KeyPress);
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
            }
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        // Создать акт передачи
        private void btBuildAct_Click(object sender, EventArgs e)
        {
            int[] pageCount = new int[_certificates.Count];
            Dictionary<int, string> flags = new Dictionary<int, string>();
            AdditionalData args = new AdditionalData();

            // Определяем для каких свидетельств надо сформировать акт с протоколом
            for (int i = 0; i < _certificates.Count; i++)
            {
                flags.Add(i, dgvActSettings[3, i].Value.ToString());
                pageCount[i] = Convert.ToInt32(dgvActSettings[5, i].Value);
            }

            args.Pages = pageCount;
            args.Name = cbPresenterName.Text;
            args.Flags = flags;

            if (cbDepType.SelectedIndex == 1)
                args.AktFolderPath = Path.Combine(Settings.Instance.CertificatesFolderPath, "АКТЫ",  DateTime.Now.Year.ToString(), "ТОиС");
            if (cbDepType.SelectedIndex == 0)
                args.AktFolderPath = Path.Combine(Settings.Instance.CertificatesFolderPath, "АКТЫ", DateTime.Now.Year.ToString(), "МС");

            args.AktNumber = ActNumber;
            args.OpenAkt = cbOpenBuiltAct.Checked;

            // Путь к сформированному акту
            var filename = Excel.MakeNewAct(_certificates.ToArray(), args);

            // Событие изменения формы
            MessageBox.Show("Акт приема/передачи успешно сформирован.");

            // Открываем сформированный акт
            if (cbOpenBuiltAct.Checked)
                Process.Start(filename);

            Changed(sender, e);
        }

        // Открываем папку где хранятся акты
        private void btOpenActFolder_Click(object sender, EventArgs e)
        {
            Process.Start(Path.Combine(Settings.Instance.CertificatesFolderPath, "АКТЫ"));
        }

        // Получаем номер акта для отдела формирующего акт
        private void cbDepType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbAktNumber.Text = ActNumber.ToString();
        }

        // Меняем состояние CheckBox в заголовке столбца
        private void Checkheader_OnCheckBoxHeaderClick(CheckBoxHeaderCellEventArgs e)
        {
            dgvActSettings.BeginEdit(true);
            foreach (DataGridViewRow item in dgvActSettings.Rows)
            {
                item.Cells[3].Value = e.IsChecked;
            }
            dgvActSettings.EndEdit();
        }
    }
}
