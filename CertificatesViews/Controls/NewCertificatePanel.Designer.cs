namespace CertificatesViews.Controls
{
    partial class NewCertificatePanel
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
            this.panMain = new System.Windows.Forms.Panel();
            this.tcFileSource = new System.Windows.Forms.TabControl();
            this.tabFile = new System.Windows.Forms.TabPage();
            this.btSelectFile = new System.Windows.Forms.Button();
            this.tabScanner = new System.Windows.Forms.TabPage();
            this.btAddNewPages = new System.Windows.Forms.Button();
            this.btScanNewDoc = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dpCalibrationExpireDate = new System.Windows.Forms.DateTimePicker();
            this.dpCalibrationDate = new System.Windows.Forms.DateTimePicker();
            this.cbVerificationMethod = new System.Windows.Forms.ComboBox();
            this.tbSerialNumber = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbDeviceName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panPreview = new System.Windows.Forms.Panel();
            this.panMain.SuspendLayout();
            this.tcFileSource.SuspendLayout();
            this.tabFile.SuspendLayout();
            this.tabScanner.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numId)).BeginInit();
            this.SuspendLayout();
            // 
            // panMain
            // 
            this.panMain.Controls.Add(this.tcFileSource);
            this.panMain.Controls.Add(this.groupBox1);
            this.panMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.panMain.Location = new System.Drawing.Point(0, 0);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(482, 662);
            this.panMain.TabIndex = 0;
            // 
            // tcFileSource
            // 
            this.tcFileSource.Controls.Add(this.tabFile);
            this.tcFileSource.Controls.Add(this.tabScanner);
            this.tcFileSource.Location = new System.Drawing.Point(14, 391);
            this.tcFileSource.Name = "tcFileSource";
            this.tcFileSource.SelectedIndex = 0;
            this.tcFileSource.Size = new System.Drawing.Size(451, 162);
            this.tcFileSource.TabIndex = 0;
            // 
            // tabFile
            // 
            this.tabFile.BackColor = System.Drawing.Color.Transparent;
            this.tabFile.Controls.Add(this.btSelectFile);
            this.tabFile.Location = new System.Drawing.Point(4, 22);
            this.tabFile.Name = "tabFile";
            this.tabFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabFile.Size = new System.Drawing.Size(443, 136);
            this.tabFile.TabIndex = 0;
            this.tabFile.Text = "Существующий файл";
            // 
            // btSelectFile
            // 
            this.btSelectFile.Image = global::CertificatesViews.Properties.Resources.folder_explore;
            this.btSelectFile.Location = new System.Drawing.Point(17, 28);
            this.btSelectFile.Name = "btSelectFile";
            this.btSelectFile.Size = new System.Drawing.Size(184, 40);
            this.btSelectFile.TabIndex = 0;
            this.btSelectFile.Text = "Выбрать файл свидетельства";
            this.btSelectFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btSelectFile.UseVisualStyleBackColor = true;
            // 
            // tabScanner
            // 
            this.tabScanner.BackColor = System.Drawing.Color.Transparent;
            this.tabScanner.Controls.Add(this.btAddNewPages);
            this.tabScanner.Controls.Add(this.btScanNewDoc);
            this.tabScanner.Location = new System.Drawing.Point(4, 22);
            this.tabScanner.Name = "tabScanner";
            this.tabScanner.Padding = new System.Windows.Forms.Padding(3);
            this.tabScanner.Size = new System.Drawing.Size(443, 136);
            this.tabScanner.TabIndex = 1;
            this.tabScanner.Text = "Сканнер";
            // 
            // btAddNewPages
            // 
            this.btAddNewPages.Image = global::CertificatesViews.Properties.Resources.image_add;
            this.btAddNewPages.Location = new System.Drawing.Point(17, 74);
            this.btAddNewPages.Name = "btAddNewPages";
            this.btAddNewPages.Size = new System.Drawing.Size(185, 40);
            this.btAddNewPages.TabIndex = 1;
            this.btAddNewPages.Text = "Добавить страницы к скану";
            this.btAddNewPages.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btAddNewPages.UseVisualStyleBackColor = true;
            // 
            // btScanNewDoc
            // 
            this.btScanNewDoc.Image = global::CertificatesViews.Properties.Resources.image;
            this.btScanNewDoc.Location = new System.Drawing.Point(17, 28);
            this.btScanNewDoc.Name = "btScanNewDoc";
            this.btScanNewDoc.Size = new System.Drawing.Size(185, 40);
            this.btScanNewDoc.TabIndex = 0;
            this.btScanNewDoc.Text = "Сканировать новый документ";
            this.btScanNewDoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btScanNewDoc.UseVisualStyleBackColor = true;
            this.btScanNewDoc.Click += new System.EventHandler(this.btScanNewDoc_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dpCalibrationExpireDate);
            this.groupBox1.Controls.Add(this.dpCalibrationDate);
            this.groupBox1.Controls.Add(this.cbVerificationMethod);
            this.groupBox1.Controls.Add(this.tbSerialNumber);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.tbDeviceName);
            this.groupBox1.Controls.Add(this.label12);
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
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(451, 380);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Свидетельство";
            // 
            // dpCalibrationExpireDate
            // 
            this.dpCalibrationExpireDate.Location = new System.Drawing.Point(201, 343);
            this.dpCalibrationExpireDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dpCalibrationExpireDate.Name = "dpCalibrationExpireDate";
            this.dpCalibrationExpireDate.Size = new System.Drawing.Size(200, 20);
            this.dpCalibrationExpireDate.TabIndex = 39;
            // 
            // dpCalibrationDate
            // 
            this.dpCalibrationDate.Location = new System.Drawing.Point(201, 317);
            this.dpCalibrationDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dpCalibrationDate.Name = "dpCalibrationDate";
            this.dpCalibrationDate.Size = new System.Drawing.Size(200, 20);
            this.dpCalibrationDate.TabIndex = 38;
            // 
            // cbVerificationMethod
            // 
            this.cbVerificationMethod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbVerificationMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbVerificationMethod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVerificationMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVerificationMethod.FormattingEnabled = true;
            this.cbVerificationMethod.Location = new System.Drawing.Point(201, 134);
            this.cbVerificationMethod.Name = "cbVerificationMethod";
            this.cbVerificationMethod.Size = new System.Drawing.Size(200, 21);
            this.cbVerificationMethod.Sorted = true;
            this.cbVerificationMethod.TabIndex = 31;
            // 
            // tbSerialNumber
            // 
            this.tbSerialNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbSerialNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbSerialNumber.Location = new System.Drawing.Point(201, 291);
            this.tbSerialNumber.Name = "tbSerialNumber";
            this.tbSerialNumber.Size = new System.Drawing.Size(200, 20);
            this.tbSerialNumber.TabIndex = 37;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(29, 346);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(167, 13);
            this.label13.TabIndex = 26;
            this.label13.Text = "Дата окончания срока поверки";
            // 
            // tbDeviceName
            // 
            this.tbDeviceName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbDeviceName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbDeviceName.Location = new System.Drawing.Point(201, 265);
            this.tbDeviceName.Name = "tbDeviceName";
            this.tbDeviceName.Size = new System.Drawing.Size(200, 20);
            this.tbDeviceName.TabIndex = 36;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(29, 320);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Дата поверки";
            // 
            // tbDeviceType
            // 
            this.tbDeviceType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbDeviceType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbDeviceType.Location = new System.Drawing.Point(201, 239);
            this.tbDeviceType.Name = "tbDeviceType";
            this.tbDeviceType.Size = new System.Drawing.Size(200, 20);
            this.tbDeviceType.TabIndex = 35;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(29, 294);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Заводской номер СИ";
            // 
            // tbObjectName
            // 
            this.tbObjectName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbObjectName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbObjectName.Location = new System.Drawing.Point(201, 213);
            this.tbObjectName.Name = "tbObjectName";
            this.tbObjectName.Size = new System.Drawing.Size(200, 20);
            this.tbObjectName.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 268);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Наименование СИ";
            // 
            // tbClientName
            // 
            this.tbClientName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbClientName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbClientName.Location = new System.Drawing.Point(201, 187);
            this.tbClientName.Name = "tbClientName";
            this.tbClientName.Size = new System.Drawing.Size(200, 20);
            this.tbClientName.TabIndex = 33;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 242);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Группа СИ";
            // 
            // tbContractNumber
            // 
            this.tbContractNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbContractNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbContractNumber.Location = new System.Drawing.Point(201, 161);
            this.tbContractNumber.Name = "tbContractNumber";
            this.tbContractNumber.Size = new System.Drawing.Size(200, 20);
            this.tbContractNumber.TabIndex = 32;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Объект эксплуатации";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Заказчик";
            // 
            // tbRegisterNumber
            // 
            this.tbRegisterNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbRegisterNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbRegisterNumber.Location = new System.Drawing.Point(201, 109);
            this.tbRegisterNumber.Name = "tbRegisterNumber";
            this.tbRegisterNumber.Size = new System.Drawing.Size(200, 20);
            this.tbRegisterNumber.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Номер договора";
            // 
            // tbCertificateNumber
            // 
            this.tbCertificateNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbCertificateNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbCertificateNumber.Location = new System.Drawing.Point(201, 83);
            this.tbCertificateNumber.Name = "tbCertificateNumber";
            this.tbCertificateNumber.Size = new System.Drawing.Size(200, 20);
            this.tbCertificateNumber.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Методика поверки";
            // 
            // numYear
            // 
            this.numYear.Location = new System.Drawing.Point(201, 55);
            this.numYear.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(200, 20);
            this.numYear.TabIndex = 28;
            this.numYear.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Номер в Гос. Реестре";
            // 
            // numId
            // 
            this.numId.Location = new System.Drawing.Point(201, 26);
            this.numId.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numId.Name = "numId";
            this.numId.Size = new System.Drawing.Size(200, 20);
            this.numId.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Номер свидетельства";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Год";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "ID";
            // 
            // panPreview
            // 
            this.panPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panPreview.Location = new System.Drawing.Point(482, 0);
            this.panPreview.Name = "panPreview";
            this.panPreview.Size = new System.Drawing.Size(485, 662);
            this.panPreview.TabIndex = 1;
            // 
            // NewCertificatePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panPreview);
            this.Controls.Add(this.panMain);
            this.Name = "NewCertificatePanel";
            this.Size = new System.Drawing.Size(967, 662);
            this.panMain.ResumeLayout(false);
            this.tcFileSource.ResumeLayout(false);
            this.tabFile.ResumeLayout(false);
            this.tabScanner.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numId)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panPreview;
        private System.Windows.Forms.TabControl tcFileSource;
        private System.Windows.Forms.TabPage tabFile;
        private System.Windows.Forms.TabPage tabScanner;
        private System.Windows.Forms.Button btAddNewPages;
        private System.Windows.Forms.Button btScanNewDoc;
        private System.Windows.Forms.DateTimePicker dpCalibrationExpireDate;
        private System.Windows.Forms.DateTimePicker dpCalibrationDate;
        private System.Windows.Forms.ComboBox cbVerificationMethod;
        private System.Windows.Forms.TextBox tbSerialNumber;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbDeviceName;
        private System.Windows.Forms.Label label12;
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btSelectFile;
    }
}
