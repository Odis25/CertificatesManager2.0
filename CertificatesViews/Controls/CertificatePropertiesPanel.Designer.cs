namespace CertificatesViews.Controls
{
    partial class CertificatePropertiesPanel
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chbCalibrationExpireDate = new System.Windows.Forms.CheckBox();
            this.chbCalibrationDate = new System.Windows.Forms.CheckBox();
            this.chbSerialNumber = new System.Windows.Forms.CheckBox();
            this.chbDeviceName = new System.Windows.Forms.CheckBox();
            this.chbDeviceType = new System.Windows.Forms.CheckBox();
            this.chbObjectName = new System.Windows.Forms.CheckBox();
            this.chbClientName = new System.Windows.Forms.CheckBox();
            this.chbContractNumber = new System.Windows.Forms.CheckBox();
            this.chbVerificationMethod = new System.Windows.Forms.CheckBox();
            this.chbRegisterNumber = new System.Windows.Forms.CheckBox();
            this.chbCertificateNumber = new System.Windows.Forms.CheckBox();
            this.chbYear = new System.Windows.Forms.CheckBox();
            this.chbId = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btDelete = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.btSearch = new System.Windows.Forms.Button();
            this.dpCalibrationExpireDate = new System.Windows.Forms.DateTimePicker();
            this.dpCalibrationDate = new System.Windows.Forms.DateTimePicker();
            this.cbVerificationMethod = new System.Windows.Forms.ComboBox();
            this.tbSerialNumber = new System.Windows.Forms.TextBox();
            this.lbCalibrationExpireDate = new System.Windows.Forms.Label();
            this.tbDeviceName = new System.Windows.Forms.TextBox();
            this.lbCalibrationDate = new System.Windows.Forms.Label();
            this.tbDeviceType = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbObjectName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbClientName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbContractNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbRegisterNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCertificateNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numId = new System.Windows.Forms.NumericUpDown();
            this.lbCertificateNumber = new System.Windows.Forms.Label();
            this.lbYear = new System.Windows.Forms.Label();
            this.lbId = new System.Windows.Forms.Label();
            this.tipVerificationMethodItems = new System.Windows.Forms.ToolTip(this.components);
            this.cbDocumentType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chbDocumentType = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numId)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chbCalibrationExpireDate);
            this.groupBox2.Controls.Add(this.chbCalibrationDate);
            this.groupBox2.Controls.Add(this.chbSerialNumber);
            this.groupBox2.Controls.Add(this.chbDeviceName);
            this.groupBox2.Controls.Add(this.chbDeviceType);
            this.groupBox2.Controls.Add(this.chbObjectName);
            this.groupBox2.Controls.Add(this.chbClientName);
            this.groupBox2.Controls.Add(this.chbContractNumber);
            this.groupBox2.Controls.Add(this.chbVerificationMethod);
            this.groupBox2.Controls.Add(this.chbRegisterNumber);
            this.groupBox2.Controls.Add(this.chbCertificateNumber);
            this.groupBox2.Controls.Add(this.chbDocumentType);
            this.groupBox2.Controls.Add(this.chbYear);
            this.groupBox2.Controls.Add(this.chbId);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(386, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(55, 410);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Поиск";
            // 
            // chbCalibrationExpireDate
            // 
            this.chbCalibrationExpireDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chbCalibrationExpireDate.AutoSize = true;
            this.chbCalibrationExpireDate.Location = new System.Drawing.Point(19, 338);
            this.chbCalibrationExpireDate.Name = "chbCalibrationExpireDate";
            this.chbCalibrationExpireDate.Size = new System.Drawing.Size(15, 14);
            this.chbCalibrationExpireDate.TabIndex = 0;
            this.chbCalibrationExpireDate.UseVisualStyleBackColor = true;
            this.chbCalibrationExpireDate.CheckedChanged += new System.EventHandler(this.CheckBoxes_CheckedChanged);
            // 
            // chbCalibrationDate
            // 
            this.chbCalibrationDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chbCalibrationDate.AutoSize = true;
            this.chbCalibrationDate.Location = new System.Drawing.Point(19, 314);
            this.chbCalibrationDate.Name = "chbCalibrationDate";
            this.chbCalibrationDate.Size = new System.Drawing.Size(15, 14);
            this.chbCalibrationDate.TabIndex = 0;
            this.chbCalibrationDate.UseVisualStyleBackColor = true;
            this.chbCalibrationDate.CheckedChanged += new System.EventHandler(this.CheckBoxes_CheckedChanged);
            // 
            // chbSerialNumber
            // 
            this.chbSerialNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chbSerialNumber.AutoSize = true;
            this.chbSerialNumber.Location = new System.Drawing.Point(19, 290);
            this.chbSerialNumber.Name = "chbSerialNumber";
            this.chbSerialNumber.Size = new System.Drawing.Size(15, 14);
            this.chbSerialNumber.TabIndex = 0;
            this.chbSerialNumber.UseVisualStyleBackColor = true;
            this.chbSerialNumber.CheckedChanged += new System.EventHandler(this.CheckBoxes_CheckedChanged);
            // 
            // chbDeviceName
            // 
            this.chbDeviceName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chbDeviceName.AutoSize = true;
            this.chbDeviceName.Location = new System.Drawing.Point(19, 266);
            this.chbDeviceName.Name = "chbDeviceName";
            this.chbDeviceName.Size = new System.Drawing.Size(15, 14);
            this.chbDeviceName.TabIndex = 0;
            this.chbDeviceName.UseVisualStyleBackColor = true;
            this.chbDeviceName.CheckedChanged += new System.EventHandler(this.CheckBoxes_CheckedChanged);
            // 
            // chbDeviceType
            // 
            this.chbDeviceType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chbDeviceType.AutoSize = true;
            this.chbDeviceType.Location = new System.Drawing.Point(19, 242);
            this.chbDeviceType.Name = "chbDeviceType";
            this.chbDeviceType.Size = new System.Drawing.Size(15, 14);
            this.chbDeviceType.TabIndex = 0;
            this.chbDeviceType.UseVisualStyleBackColor = true;
            this.chbDeviceType.CheckedChanged += new System.EventHandler(this.CheckBoxes_CheckedChanged);
            // 
            // chbObjectName
            // 
            this.chbObjectName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chbObjectName.AutoSize = true;
            this.chbObjectName.Location = new System.Drawing.Point(19, 218);
            this.chbObjectName.Name = "chbObjectName";
            this.chbObjectName.Size = new System.Drawing.Size(15, 14);
            this.chbObjectName.TabIndex = 0;
            this.chbObjectName.UseVisualStyleBackColor = true;
            this.chbObjectName.CheckedChanged += new System.EventHandler(this.CheckBoxes_CheckedChanged);
            // 
            // chbClientName
            // 
            this.chbClientName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chbClientName.AutoSize = true;
            this.chbClientName.Location = new System.Drawing.Point(19, 194);
            this.chbClientName.Name = "chbClientName";
            this.chbClientName.Size = new System.Drawing.Size(15, 14);
            this.chbClientName.TabIndex = 0;
            this.chbClientName.UseVisualStyleBackColor = true;
            this.chbClientName.CheckedChanged += new System.EventHandler(this.CheckBoxes_CheckedChanged);
            // 
            // chbContractNumber
            // 
            this.chbContractNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chbContractNumber.AutoSize = true;
            this.chbContractNumber.Location = new System.Drawing.Point(19, 170);
            this.chbContractNumber.Name = "chbContractNumber";
            this.chbContractNumber.Size = new System.Drawing.Size(15, 14);
            this.chbContractNumber.TabIndex = 0;
            this.chbContractNumber.UseVisualStyleBackColor = true;
            this.chbContractNumber.CheckedChanged += new System.EventHandler(this.CheckBoxes_CheckedChanged);
            // 
            // chbVerificationMethod
            // 
            this.chbVerificationMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chbVerificationMethod.AutoSize = true;
            this.chbVerificationMethod.Location = new System.Drawing.Point(19, 146);
            this.chbVerificationMethod.Name = "chbVerificationMethod";
            this.chbVerificationMethod.Size = new System.Drawing.Size(15, 14);
            this.chbVerificationMethod.TabIndex = 0;
            this.chbVerificationMethod.UseVisualStyleBackColor = true;
            this.chbVerificationMethod.CheckedChanged += new System.EventHandler(this.CheckBoxes_CheckedChanged);
            // 
            // chbRegisterNumber
            // 
            this.chbRegisterNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chbRegisterNumber.AutoSize = true;
            this.chbRegisterNumber.Location = new System.Drawing.Point(19, 122);
            this.chbRegisterNumber.Name = "chbRegisterNumber";
            this.chbRegisterNumber.Size = new System.Drawing.Size(15, 14);
            this.chbRegisterNumber.TabIndex = 0;
            this.chbRegisterNumber.UseVisualStyleBackColor = true;
            this.chbRegisterNumber.CheckedChanged += new System.EventHandler(this.CheckBoxes_CheckedChanged);
            // 
            // chbCertificateNumber
            // 
            this.chbCertificateNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chbCertificateNumber.AutoSize = true;
            this.chbCertificateNumber.Location = new System.Drawing.Point(19, 98);
            this.chbCertificateNumber.Name = "chbCertificateNumber";
            this.chbCertificateNumber.Size = new System.Drawing.Size(15, 14);
            this.chbCertificateNumber.TabIndex = 0;
            this.chbCertificateNumber.UseVisualStyleBackColor = true;
            this.chbCertificateNumber.CheckedChanged += new System.EventHandler(this.CheckBoxes_CheckedChanged);
            // 
            // chbYear
            // 
            this.chbYear.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chbYear.AutoSize = true;
            this.chbYear.Location = new System.Drawing.Point(19, 50);
            this.chbYear.Name = "chbYear";
            this.chbYear.Size = new System.Drawing.Size(15, 14);
            this.chbYear.TabIndex = 0;
            this.chbYear.UseVisualStyleBackColor = true;
            this.chbYear.CheckedChanged += new System.EventHandler(this.CheckBoxes_CheckedChanged);
            // 
            // chbId
            // 
            this.chbId.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chbId.AutoSize = true;
            this.chbId.Location = new System.Drawing.Point(19, 26);
            this.chbId.Name = "chbId";
            this.chbId.Size = new System.Drawing.Size(15, 14);
            this.chbId.TabIndex = 0;
            this.chbId.UseVisualStyleBackColor = true;
            this.chbId.CheckedChanged += new System.EventHandler(this.CheckBoxes_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbDocumentType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btDelete);
            this.groupBox1.Controls.Add(this.btEdit);
            this.groupBox1.Controls.Add(this.btSearch);
            this.groupBox1.Controls.Add(this.dpCalibrationExpireDate);
            this.groupBox1.Controls.Add(this.dpCalibrationDate);
            this.groupBox1.Controls.Add(this.cbVerificationMethod);
            this.groupBox1.Controls.Add(this.tbSerialNumber);
            this.groupBox1.Controls.Add(this.lbCalibrationExpireDate);
            this.groupBox1.Controls.Add(this.tbDeviceName);
            this.groupBox1.Controls.Add(this.lbCalibrationDate);
            this.groupBox1.Controls.Add(this.tbDeviceType);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.tbObjectName);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.tbClientName);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tbContractNumber);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbRegisterNumber);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbCertificateNumber);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numYear);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numId);
            this.groupBox1.Controls.Add(this.lbCertificateNumber);
            this.groupBox1.Controls.Add(this.lbYear);
            this.groupBox1.Controls.Add(this.lbId);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 410);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Инфо";
            // 
            // btDelete
            // 
            this.btDelete.Image = global::CertificatesViews.Properties.Resources.cross1;
            this.btDelete.Location = new System.Drawing.Point(250, 369);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(84, 29);
            this.btDelete.TabIndex = 14;
            this.btDelete.Text = "Удалить";
            this.btDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btEdit
            // 
            this.btEdit.Image = global::CertificatesViews.Properties.Resources.page_edit;
            this.btEdit.Location = new System.Drawing.Point(150, 369);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(84, 29);
            this.btEdit.TabIndex = 14;
            this.btEdit.Text = "Изменить";
            this.btEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btSearch
            // 
            this.btSearch.Image = global::CertificatesViews.Properties.Resources.zoom;
            this.btSearch.Location = new System.Drawing.Point(50, 369);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(84, 29);
            this.btSearch.TabIndex = 14;
            this.btSearch.Text = "Найти";
            this.btSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // dpCalibrationExpireDate
            // 
            this.dpCalibrationExpireDate.Location = new System.Drawing.Point(178, 336);
            this.dpCalibrationExpireDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dpCalibrationExpireDate.Name = "dpCalibrationExpireDate";
            this.dpCalibrationExpireDate.Size = new System.Drawing.Size(200, 20);
            this.dpCalibrationExpireDate.TabIndex = 13;
            // 
            // dpCalibrationDate
            // 
            this.dpCalibrationDate.Location = new System.Drawing.Point(178, 312);
            this.dpCalibrationDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dpCalibrationDate.Name = "dpCalibrationDate";
            this.dpCalibrationDate.Size = new System.Drawing.Size(200, 20);
            this.dpCalibrationDate.TabIndex = 12;
            // 
            // cbVerificationMethod
            // 
            this.cbVerificationMethod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbVerificationMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbVerificationMethod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVerificationMethod.FormattingEnabled = true;
            this.cbVerificationMethod.Location = new System.Drawing.Point(178, 143);
            this.cbVerificationMethod.Name = "cbVerificationMethod";
            this.cbVerificationMethod.Size = new System.Drawing.Size(200, 21);
            this.cbVerificationMethod.Sorted = true;
            this.cbVerificationMethod.TabIndex = 5;
            this.cbVerificationMethod.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbVerificationMethod_DrawItem);
            this.cbVerificationMethod.DropDownClosed += new System.EventHandler(this.cbVerificationMethod_DropDownClosed);
            // 
            // tbSerialNumber
            // 
            this.tbSerialNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbSerialNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbSerialNumber.Location = new System.Drawing.Point(178, 288);
            this.tbSerialNumber.Name = "tbSerialNumber";
            this.tbSerialNumber.Size = new System.Drawing.Size(200, 20);
            this.tbSerialNumber.TabIndex = 11;
            // 
            // lbCalibrationExpireDate
            // 
            this.lbCalibrationExpireDate.AutoSize = true;
            this.lbCalibrationExpireDate.Location = new System.Drawing.Point(6, 338);
            this.lbCalibrationExpireDate.Name = "lbCalibrationExpireDate";
            this.lbCalibrationExpireDate.Size = new System.Drawing.Size(167, 13);
            this.lbCalibrationExpireDate.TabIndex = 0;
            this.lbCalibrationExpireDate.Text = "Дата окончания срока поверки";
            // 
            // tbDeviceName
            // 
            this.tbDeviceName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbDeviceName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbDeviceName.Location = new System.Drawing.Point(178, 264);
            this.tbDeviceName.Name = "tbDeviceName";
            this.tbDeviceName.Size = new System.Drawing.Size(200, 20);
            this.tbDeviceName.TabIndex = 10;
            // 
            // lbCalibrationDate
            // 
            this.lbCalibrationDate.AutoSize = true;
            this.lbCalibrationDate.Location = new System.Drawing.Point(6, 314);
            this.lbCalibrationDate.Name = "lbCalibrationDate";
            this.lbCalibrationDate.Size = new System.Drawing.Size(78, 13);
            this.lbCalibrationDate.TabIndex = 0;
            this.lbCalibrationDate.Text = "Дата поверки";
            // 
            // tbDeviceType
            // 
            this.tbDeviceType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbDeviceType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbDeviceType.Location = new System.Drawing.Point(178, 240);
            this.tbDeviceType.Name = "tbDeviceType";
            this.tbDeviceType.Size = new System.Drawing.Size(200, 20);
            this.tbDeviceType.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 290);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Заводской номер СИ";
            // 
            // tbObjectName
            // 
            this.tbObjectName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbObjectName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbObjectName.Location = new System.Drawing.Point(178, 216);
            this.tbObjectName.Name = "tbObjectName";
            this.tbObjectName.Size = new System.Drawing.Size(200, 20);
            this.tbObjectName.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 266);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Наименование СИ";
            // 
            // tbClientName
            // 
            this.tbClientName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbClientName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbClientName.Location = new System.Drawing.Point(178, 192);
            this.tbClientName.Name = "tbClientName";
            this.tbClientName.Size = new System.Drawing.Size(200, 20);
            this.tbClientName.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 242);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Группа СИ";
            // 
            // tbContractNumber
            // 
            this.tbContractNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbContractNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbContractNumber.Location = new System.Drawing.Point(178, 168);
            this.tbContractNumber.Name = "tbContractNumber";
            this.tbContractNumber.Size = new System.Drawing.Size(200, 20);
            this.tbContractNumber.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 218);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Объект эксплуатации";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Заказчик";
            // 
            // tbRegisterNumber
            // 
            this.tbRegisterNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbRegisterNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbRegisterNumber.Location = new System.Drawing.Point(178, 119);
            this.tbRegisterNumber.Name = "tbRegisterNumber";
            this.tbRegisterNumber.Size = new System.Drawing.Size(200, 20);
            this.tbRegisterNumber.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Номер договора";
            // 
            // tbCertificateNumber
            // 
            this.tbCertificateNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbCertificateNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbCertificateNumber.Location = new System.Drawing.Point(178, 95);
            this.tbCertificateNumber.Name = "tbCertificateNumber";
            this.tbCertificateNumber.Size = new System.Drawing.Size(200, 20);
            this.tbCertificateNumber.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Методика поверки";
            // 
            // numYear
            // 
            this.numYear.Location = new System.Drawing.Point(178, 46);
            this.numYear.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(200, 20);
            this.numYear.TabIndex = 2;
            this.numYear.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Номер в Гос. Реестре";
            // 
            // numId
            // 
            this.numId.Location = new System.Drawing.Point(178, 22);
            this.numId.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numId.Name = "numId";
            this.numId.Size = new System.Drawing.Size(200, 20);
            this.numId.TabIndex = 1;
            // 
            // lbCertificateNumber
            // 
            this.lbCertificateNumber.AutoSize = true;
            this.lbCertificateNumber.Location = new System.Drawing.Point(6, 98);
            this.lbCertificateNumber.Name = "lbCertificateNumber";
            this.lbCertificateNumber.Size = new System.Drawing.Size(120, 13);
            this.lbCertificateNumber.TabIndex = 0;
            this.lbCertificateNumber.Text = "Номер свидетельства";
            // 
            // lbYear
            // 
            this.lbYear.AutoSize = true;
            this.lbYear.Location = new System.Drawing.Point(6, 50);
            this.lbYear.Name = "lbYear";
            this.lbYear.Size = new System.Drawing.Size(25, 13);
            this.lbYear.TabIndex = 0;
            this.lbYear.Text = "Год";
            // 
            // lbId
            // 
            this.lbId.AutoSize = true;
            this.lbId.Location = new System.Drawing.Point(6, 26);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(18, 13);
            this.lbId.TabIndex = 0;
            this.lbId.Text = "ID";
            // 
            // cbDocumentType
            // 
            this.cbDocumentType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbDocumentType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbDocumentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDocumentType.FormattingEnabled = true;
            this.cbDocumentType.Items.AddRange(new object[] {
            "Свидетельство",
            "Свидетельство+Протокол",
            "Извещение о непригодности"});
            this.cbDocumentType.Location = new System.Drawing.Point(178, 70);
            this.cbDocumentType.Name = "cbDocumentType";
            this.cbDocumentType.Size = new System.Drawing.Size(200, 21);
            this.cbDocumentType.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Тип документа";
            // 
            // chbDocumentType
            // 
            this.chbDocumentType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chbDocumentType.AutoSize = true;
            this.chbDocumentType.Location = new System.Drawing.Point(19, 74);
            this.chbDocumentType.Name = "chbDocumentType";
            this.chbDocumentType.Size = new System.Drawing.Size(15, 14);
            this.chbDocumentType.TabIndex = 0;
            this.chbDocumentType.UseVisualStyleBackColor = true;
            this.chbDocumentType.CheckedChanged += new System.EventHandler(this.CheckBoxes_CheckedChanged);
            // 
            // CertificatePropertiesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.MaximumSize = new System.Drawing.Size(441, 410);
            this.MinimumSize = new System.Drawing.Size(441, 410);
            this.Name = "CertificatePropertiesPanel";
            this.Size = new System.Drawing.Size(441, 410);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numId)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chbCalibrationExpireDate;
        private System.Windows.Forms.CheckBox chbCalibrationDate;
        private System.Windows.Forms.CheckBox chbSerialNumber;
        private System.Windows.Forms.CheckBox chbDeviceName;
        private System.Windows.Forms.CheckBox chbDeviceType;
        private System.Windows.Forms.CheckBox chbObjectName;
        private System.Windows.Forms.CheckBox chbClientName;
        private System.Windows.Forms.CheckBox chbContractNumber;
        private System.Windows.Forms.CheckBox chbVerificationMethod;
        private System.Windows.Forms.CheckBox chbRegisterNumber;
        private System.Windows.Forms.CheckBox chbCertificateNumber;
        private System.Windows.Forms.CheckBox chbYear;
        private System.Windows.Forms.CheckBox chbId;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.DateTimePicker dpCalibrationExpireDate;
        private System.Windows.Forms.DateTimePicker dpCalibrationDate;
        private System.Windows.Forms.ComboBox cbVerificationMethod;
        private System.Windows.Forms.TextBox tbSerialNumber;
        private System.Windows.Forms.Label lbCalibrationExpireDate;
        private System.Windows.Forms.TextBox tbDeviceName;
        private System.Windows.Forms.Label lbCalibrationDate;
        private System.Windows.Forms.TextBox tbDeviceType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbObjectName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbClientName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbContractNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbRegisterNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbCertificateNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numId;
        private System.Windows.Forms.Label lbCertificateNumber;
        private System.Windows.Forms.Label lbYear;
        private System.Windows.Forms.Label lbId;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.ToolTip tipVerificationMethodItems;
        private System.Windows.Forms.CheckBox chbDocumentType;
        private System.Windows.Forms.ComboBox cbDocumentType;
        private System.Windows.Forms.Label label1;
    }
}
