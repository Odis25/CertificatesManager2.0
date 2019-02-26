namespace CertificatesViews.Controls
{
    partial class CreateActPanel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvActSettings = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPresenterName = new System.Windows.Forms.ComboBox();
            this.cbDepType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbOpenBuiltAct = new System.Windows.Forms.CheckBox();
            this.lbAktNumber = new System.Windows.Forms.Label();
            this.lbContractNumber = new System.Windows.Forms.Label();
            this.lbClientName = new System.Windows.Forms.Label();
            this.btOpenActFolder = new System.Windows.Forms.Button();
            this.btBuildAct = new System.Windows.Forms.Button();
            this.dgvId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCertificateNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvIncludeProtocol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPageCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvActSettings
            // 
            this.dgvActSettings.AllowUserToAddRows = false;
            this.dgvActSettings.AllowUserToDeleteRows = false;
            this.dgvActSettings.AllowUserToResizeRows = false;
            this.dgvActSettings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 12);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvActSettings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvActSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActSettings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvId,
            this.dgvDeviceName,
            this.dgvCertificateNumber,
            this.dgvIncludeProtocol,
            this.dgvSerialNumber,
            this.dgvPageCount});
            this.dgvActSettings.Location = new System.Drawing.Point(3, 85);
            this.dgvActSettings.Name = "dgvActSettings";
            this.dgvActSettings.RowHeadersVisible = false;
            this.dgvActSettings.Size = new System.Drawing.Size(784, 352);
            this.dgvActSettings.TabIndex = 0;
            this.dgvActSettings.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvActSettings_EditingControlShowing);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Номер акта:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Номер договора:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Наименование организации заказчика:";
            // 
            // cbPresenterName
            // 
            this.cbPresenterName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbPresenterName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.cbPresenterName.FormattingEnabled = true;
            this.cbPresenterName.Location = new System.Drawing.Point(18, 479);
            this.cbPresenterName.Name = "cbPresenterName";
            this.cbPresenterName.Size = new System.Drawing.Size(266, 21);
            this.cbPresenterName.TabIndex = 4;
            // 
            // cbDepType
            // 
            this.cbDepType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepType.FormattingEnabled = true;
            this.cbDepType.Items.AddRange(new object[] {
            "Метрологическая служба (02)",
            "Отдел ТО (09)"});
            this.cbDepType.Location = new System.Drawing.Point(18, 529);
            this.cbDepType.Name = "cbDepType";
            this.cbDepType.Size = new System.Drawing.Size(266, 21);
            this.cbDepType.TabIndex = 5;
            this.cbDepType.SelectedIndexChanged += new System.EventHandler(this.cbDepType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 463);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(266, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "ФИО представителя ЗАО \"НИЦ ИНКОМСИСТЕМ\":";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 513);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Отдел формирующий акт:";
            // 
            // cbOpenBuiltAct
            // 
            this.cbOpenBuiltAct.AutoSize = true;
            this.cbOpenBuiltAct.Location = new System.Drawing.Point(602, 506);
            this.cbOpenBuiltAct.Name = "cbOpenBuiltAct";
            this.cbOpenBuiltAct.Size = new System.Drawing.Size(183, 17);
            this.cbOpenBuiltAct.TabIndex = 9;
            this.cbOpenBuiltAct.Text = "Открыть сформированный акт";
            this.cbOpenBuiltAct.UseVisualStyleBackColor = true;
            // 
            // lbAktNumber
            // 
            this.lbAktNumber.AutoSize = true;
            this.lbAktNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbAktNumber.Location = new System.Drawing.Point(231, 16);
            this.lbAktNumber.Name = "lbAktNumber";
            this.lbAktNumber.Size = new System.Drawing.Size(35, 13);
            this.lbAktNumber.TabIndex = 11;
            this.lbAktNumber.Text = "label6";
            // 
            // lbContractNumber
            // 
            this.lbContractNumber.AutoSize = true;
            this.lbContractNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbContractNumber.Location = new System.Drawing.Point(231, 38);
            this.lbContractNumber.Name = "lbContractNumber";
            this.lbContractNumber.Size = new System.Drawing.Size(35, 13);
            this.lbContractNumber.TabIndex = 12;
            this.lbContractNumber.Text = "label7";
            // 
            // lbClientName
            // 
            this.lbClientName.AutoSize = true;
            this.lbClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbClientName.Location = new System.Drawing.Point(231, 60);
            this.lbClientName.Name = "lbClientName";
            this.lbClientName.Size = new System.Drawing.Size(35, 13);
            this.lbClientName.TabIndex = 13;
            this.lbClientName.Text = "label8";
            // 
            // btOpenActFolder
            // 
            this.btOpenActFolder.Image = global::CertificatesViews.Properties.Resources.folder;
            this.btOpenActFolder.Location = new System.Drawing.Point(602, 533);
            this.btOpenActFolder.Name = "btOpenActFolder";
            this.btOpenActFolder.Size = new System.Drawing.Size(145, 38);
            this.btOpenActFolder.TabIndex = 10;
            this.btOpenActFolder.Text = "Открыть папку актов";
            this.btOpenActFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btOpenActFolder.UseVisualStyleBackColor = true;
            this.btOpenActFolder.Click += new System.EventHandler(this.btOpenActFolder_Click);
            // 
            // btBuildAct
            // 
            this.btBuildAct.Image = global::CertificatesViews.Properties.Resources.script_add;
            this.btBuildAct.Location = new System.Drawing.Point(602, 462);
            this.btBuildAct.Name = "btBuildAct";
            this.btBuildAct.Size = new System.Drawing.Size(145, 38);
            this.btBuildAct.TabIndex = 8;
            this.btBuildAct.Text = "Сформировать акт";
            this.btBuildAct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btBuildAct.UseVisualStyleBackColor = true;
            this.btBuildAct.Click += new System.EventHandler(this.btBuildAct_Click);
            // 
            // dgvId
            // 
            this.dgvId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvId.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvId.HeaderText = "№ п/п";
            this.dgvId.MinimumWidth = 15;
            this.dgvId.Name = "dgvId";
            this.dgvId.ReadOnly = true;
            this.dgvId.Width = 63;
            // 
            // dgvDeviceName
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvDeviceName.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDeviceName.HeaderText = "Наименование СИ";
            this.dgvDeviceName.Name = "dgvDeviceName";
            this.dgvDeviceName.ReadOnly = true;
            // 
            // dgvCertificateNumber
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvCertificateNumber.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCertificateNumber.HeaderText = "Номер свидетельства";
            this.dgvCertificateNumber.Name = "dgvCertificateNumber";
            this.dgvCertificateNumber.ReadOnly = true;
            // 
            // dgvIncludeProtocol
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.NullValue = false;
            this.dgvIncludeProtocol.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvIncludeProtocol.HeaderText = "С протоколом";
            this.dgvIncludeProtocol.Name = "dgvIncludeProtocol";
            // 
            // dgvSerialNumber
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvSerialNumber.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvSerialNumber.HeaderText = "Серийный номер";
            this.dgvSerialNumber.Name = "dgvSerialNumber";
            this.dgvSerialNumber.ReadOnly = true;
            this.dgvSerialNumber.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSerialNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvPageCount
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvPageCount.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvPageCount.HeaderText = "Количество страниц";
            this.dgvPageCount.Name = "dgvPageCount";
            // 
            // CreateActPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbClientName);
            this.Controls.Add(this.lbContractNumber);
            this.Controls.Add(this.lbAktNumber);
            this.Controls.Add(this.btOpenActFolder);
            this.Controls.Add(this.cbOpenBuiltAct);
            this.Controls.Add(this.btBuildAct);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbDepType);
            this.Controls.Add(this.cbPresenterName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvActSettings);
            this.Name = "CreateActPanel";
            this.Size = new System.Drawing.Size(791, 582);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActSettings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvActSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbPresenterName;
        private System.Windows.Forms.ComboBox cbDepType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btBuildAct;
        private System.Windows.Forms.CheckBox cbOpenBuiltAct;
        private System.Windows.Forms.Button btOpenActFolder;
        private System.Windows.Forms.Label lbAktNumber;
        private System.Windows.Forms.Label lbContractNumber;
        private System.Windows.Forms.Label lbClientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDeviceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCertificateNumber;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvIncludeProtocol;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPageCount;
    }
}
