using CertificatesViews.Components;

namespace CertificatesViews.Controls
{
    partial class CertificatesPanel2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CertificatesPanel2));
            this.scMainSpliter = new System.Windows.Forms.SplitContainer();
            this.scSecondarySpliter = new System.Windows.Forms.SplitContainer();
            this.dgvCerts = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contractNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.certificateNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registerNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.verificationMethodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.clientNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objectNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deviceTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deviceNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serialNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calibrationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calibrationExpireDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.certificatePathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileCreationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.certificateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panMain = new System.Windows.Forms.Panel();
            this.panPreview = new System.Windows.Forms.Panel();
            this.scPreviewSplitter = new System.Windows.Forms.SplitContainer();
            this.niCertificatesManager = new System.Windows.Forms.NotifyIcon(this.components);
            this.tvCertificates = new CertificatesViews.Components.TreeViewModified();
            ((System.ComponentModel.ISupportInitialize)(this.scMainSpliter)).BeginInit();
            this.scMainSpliter.Panel1.SuspendLayout();
            this.scMainSpliter.Panel2.SuspendLayout();
            this.scMainSpliter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scSecondarySpliter)).BeginInit();
            this.scSecondarySpliter.Panel1.SuspendLayout();
            this.scSecondarySpliter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCerts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.certificateBindingSource)).BeginInit();
            this.panMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scPreviewSplitter)).BeginInit();
            this.scPreviewSplitter.Panel1.SuspendLayout();
            this.scPreviewSplitter.Panel2.SuspendLayout();
            this.scPreviewSplitter.SuspendLayout();
            this.SuspendLayout();
            // 
            // scMainSpliter
            // 
            this.scMainSpliter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMainSpliter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scMainSpliter.Location = new System.Drawing.Point(0, 0);
            this.scMainSpliter.Name = "scMainSpliter";
            this.scMainSpliter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMainSpliter.Panel1
            // 
            this.scMainSpliter.Panel1.Controls.Add(this.scSecondarySpliter);
            // 
            // scMainSpliter.Panel2
            // 
            this.scMainSpliter.Panel2.Controls.Add(this.dgvCerts);
            this.scMainSpliter.Size = new System.Drawing.Size(666, 517);
            this.scMainSpliter.SplitterDistance = 298;
            this.scMainSpliter.TabIndex = 2;
            // 
            // scSecondarySpliter
            // 
            this.scSecondarySpliter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scSecondarySpliter.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scSecondarySpliter.Location = new System.Drawing.Point(0, 0);
            this.scSecondarySpliter.Name = "scSecondarySpliter";
            // 
            // scSecondarySpliter.Panel1
            // 
            this.scSecondarySpliter.Panel1.Controls.Add(this.tvCertificates);
            this.scSecondarySpliter.Panel2MinSize = 441;
            this.scSecondarySpliter.Size = new System.Drawing.Size(666, 298);
            this.scSecondarySpliter.SplitterDistance = 221;
            this.scSecondarySpliter.TabIndex = 0;
            // 
            // dgvCerts
            // 
            this.dgvCerts.AllowUserToAddRows = false;
            this.dgvCerts.AllowUserToDeleteRows = false;
            this.dgvCerts.AllowUserToResizeRows = false;
            this.dgvCerts.AutoGenerateColumns = false;
            this.dgvCerts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCerts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.yearDataGridViewTextBoxColumn,
            this.contractNumberDataGridViewTextBoxColumn,
            this.certificateNumberDataGridViewTextBoxColumn,
            this.registerNumberDataGridViewTextBoxColumn,
            this.verificationMethodDataGridViewTextBoxColumn,
            this.clientNameDataGridViewTextBoxColumn,
            this.objectNameDataGridViewTextBoxColumn,
            this.deviceTypeDataGridViewTextBoxColumn,
            this.deviceNameDataGridViewTextBoxColumn,
            this.serialNumberDataGridViewTextBoxColumn,
            this.calibrationDateDataGridViewTextBoxColumn,
            this.calibrationExpireDateDataGridViewTextBoxColumn,
            this.certificatePathDataGridViewTextBoxColumn,
            this.fileSizeDataGridViewTextBoxColumn,
            this.FileCreationDate});
            this.dgvCerts.DataSource = this.certificateBindingSource;
            this.dgvCerts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCerts.Location = new System.Drawing.Point(0, 0);
            this.dgvCerts.Name = "dgvCerts";
            this.dgvCerts.ReadOnly = true;
            this.dgvCerts.RowHeadersVisible = false;
            this.dgvCerts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCerts.Size = new System.Drawing.Size(666, 215);
            this.dgvCerts.TabIndex = 0;
            this.dgvCerts.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvCerts_RowPrePaint);
            this.dgvCerts.SelectionChanged += new System.EventHandler(this.dgvCerts_SelectionChanged);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "Id";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // yearDataGridViewTextBoxColumn
            // 
            this.yearDataGridViewTextBoxColumn.DataPropertyName = "Year";
            this.yearDataGridViewTextBoxColumn.HeaderText = "Год";
            this.yearDataGridViewTextBoxColumn.Name = "yearDataGridViewTextBoxColumn";
            this.yearDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // contractNumberDataGridViewTextBoxColumn
            // 
            this.contractNumberDataGridViewTextBoxColumn.DataPropertyName = "ContractNumber";
            this.contractNumberDataGridViewTextBoxColumn.HeaderText = "Номер договора";
            this.contractNumberDataGridViewTextBoxColumn.Name = "contractNumberDataGridViewTextBoxColumn";
            this.contractNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // certificateNumberDataGridViewTextBoxColumn
            // 
            this.certificateNumberDataGridViewTextBoxColumn.DataPropertyName = "CertificateNumber";
            this.certificateNumberDataGridViewTextBoxColumn.HeaderText = "Номер свидетельства";
            this.certificateNumberDataGridViewTextBoxColumn.Name = "certificateNumberDataGridViewTextBoxColumn";
            this.certificateNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // registerNumberDataGridViewTextBoxColumn
            // 
            this.registerNumberDataGridViewTextBoxColumn.DataPropertyName = "RegisterNumber";
            this.registerNumberDataGridViewTextBoxColumn.HeaderText = "Номер в гос. реестре";
            this.registerNumberDataGridViewTextBoxColumn.Name = "registerNumberDataGridViewTextBoxColumn";
            this.registerNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // verificationMethodDataGridViewTextBoxColumn
            // 
            this.verificationMethodDataGridViewTextBoxColumn.DataPropertyName = "VerificationMethod";
            this.verificationMethodDataGridViewTextBoxColumn.HeaderText = "Методика поверки";
            this.verificationMethodDataGridViewTextBoxColumn.Name = "verificationMethodDataGridViewTextBoxColumn";
            this.verificationMethodDataGridViewTextBoxColumn.ReadOnly = true;
            this.verificationMethodDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.verificationMethodDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // clientNameDataGridViewTextBoxColumn
            // 
            this.clientNameDataGridViewTextBoxColumn.DataPropertyName = "ClientName";
            this.clientNameDataGridViewTextBoxColumn.HeaderText = "Заказчик";
            this.clientNameDataGridViewTextBoxColumn.Name = "clientNameDataGridViewTextBoxColumn";
            this.clientNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // objectNameDataGridViewTextBoxColumn
            // 
            this.objectNameDataGridViewTextBoxColumn.DataPropertyName = "ObjectName";
            this.objectNameDataGridViewTextBoxColumn.HeaderText = "Объект эксплуатации";
            this.objectNameDataGridViewTextBoxColumn.Name = "objectNameDataGridViewTextBoxColumn";
            this.objectNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // deviceTypeDataGridViewTextBoxColumn
            // 
            this.deviceTypeDataGridViewTextBoxColumn.DataPropertyName = "DeviceType";
            this.deviceTypeDataGridViewTextBoxColumn.HeaderText = "Группа СИ";
            this.deviceTypeDataGridViewTextBoxColumn.Name = "deviceTypeDataGridViewTextBoxColumn";
            this.deviceTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // deviceNameDataGridViewTextBoxColumn
            // 
            this.deviceNameDataGridViewTextBoxColumn.DataPropertyName = "DeviceName";
            this.deviceNameDataGridViewTextBoxColumn.HeaderText = "Наименование СИ";
            this.deviceNameDataGridViewTextBoxColumn.Name = "deviceNameDataGridViewTextBoxColumn";
            this.deviceNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // serialNumberDataGridViewTextBoxColumn
            // 
            this.serialNumberDataGridViewTextBoxColumn.DataPropertyName = "SerialNumber";
            this.serialNumberDataGridViewTextBoxColumn.HeaderText = "Серийный номер";
            this.serialNumberDataGridViewTextBoxColumn.Name = "serialNumberDataGridViewTextBoxColumn";
            this.serialNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // calibrationDateDataGridViewTextBoxColumn
            // 
            this.calibrationDateDataGridViewTextBoxColumn.DataPropertyName = "CalibrationDate";
            this.calibrationDateDataGridViewTextBoxColumn.HeaderText = "Дата поверки";
            this.calibrationDateDataGridViewTextBoxColumn.Name = "calibrationDateDataGridViewTextBoxColumn";
            this.calibrationDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // calibrationExpireDateDataGridViewTextBoxColumn
            // 
            this.calibrationExpireDateDataGridViewTextBoxColumn.DataPropertyName = "CalibrationExpireDate";
            this.calibrationExpireDateDataGridViewTextBoxColumn.HeaderText = "Дата истечения поверки";
            this.calibrationExpireDateDataGridViewTextBoxColumn.Name = "calibrationExpireDateDataGridViewTextBoxColumn";
            this.calibrationExpireDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // certificatePathDataGridViewTextBoxColumn
            // 
            this.certificatePathDataGridViewTextBoxColumn.DataPropertyName = "CertificatePath";
            this.certificatePathDataGridViewTextBoxColumn.HeaderText = "Путь к файлу";
            this.certificatePathDataGridViewTextBoxColumn.Name = "certificatePathDataGridViewTextBoxColumn";
            this.certificatePathDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fileSizeDataGridViewTextBoxColumn
            // 
            this.fileSizeDataGridViewTextBoxColumn.DataPropertyName = "FileSize";
            this.fileSizeDataGridViewTextBoxColumn.HeaderText = "Размер файла";
            this.fileSizeDataGridViewTextBoxColumn.Name = "fileSizeDataGridViewTextBoxColumn";
            this.fileSizeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FileCreationDate
            // 
            this.FileCreationDate.DataPropertyName = "FileCreationDate";
            this.FileCreationDate.HeaderText = "Дата создания файла";
            this.FileCreationDate.Name = "FileCreationDate";
            this.FileCreationDate.ReadOnly = true;
            // 
            // certificateBindingSource
            // 
            this.certificateBindingSource.DataSource = typeof(CertificatesModel.Certificate);
            // 
            // panMain
            // 
            this.panMain.Controls.Add(this.scMainSpliter);
            this.panMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMain.Location = new System.Drawing.Point(0, 0);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(666, 517);
            this.panMain.TabIndex = 1;
            // 
            // panPreview
            // 
            this.panPreview.BackColor = System.Drawing.SystemColors.Control;
            this.panPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panPreview.Location = new System.Drawing.Point(0, 0);
            this.panPreview.Name = "panPreview";
            this.panPreview.Size = new System.Drawing.Size(435, 517);
            this.panPreview.TabIndex = 2;
            // 
            // scPreviewSplitter
            // 
            this.scPreviewSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scPreviewSplitter.Location = new System.Drawing.Point(0, 0);
            this.scPreviewSplitter.Name = "scPreviewSplitter";
            // 
            // scPreviewSplitter.Panel1
            // 
            this.scPreviewSplitter.Panel1.Controls.Add(this.panMain);
            // 
            // scPreviewSplitter.Panel2
            // 
            this.scPreviewSplitter.Panel2.Controls.Add(this.panPreview);
            this.scPreviewSplitter.Panel2MinSize = 423;
            this.scPreviewSplitter.Size = new System.Drawing.Size(1105, 517);
            this.scPreviewSplitter.SplitterDistance = 666;
            this.scPreviewSplitter.TabIndex = 3;
            // 
            // niCertificatesManager
            // 
            this.niCertificatesManager.Icon = ((System.Drawing.Icon)(resources.GetObject("niCertificatesManager.Icon")));
            this.niCertificatesManager.Text = "Certificates Manager 2.0";
            this.niCertificatesManager.Visible = true;
            // 
            // tvCertificates
            // 
            this.tvCertificates.CheckBoxes = true;
            this.tvCertificates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvCertificates.Location = new System.Drawing.Point(0, 0);
            this.tvCertificates.Name = "tvCertificates";
            this.tvCertificates.Size = new System.Drawing.Size(221, 298);
            this.tvCertificates.TabIndex = 0;
            this.tvCertificates.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvCertificates_AfterCheck);
            this.tvCertificates.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvCertificates_AfterSelect);
            // 
            // CertificatesPanel2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.scPreviewSplitter);
            this.Name = "CertificatesPanel2";
            this.Size = new System.Drawing.Size(1105, 517);
            this.scMainSpliter.Panel1.ResumeLayout(false);
            this.scMainSpliter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMainSpliter)).EndInit();
            this.scMainSpliter.ResumeLayout(false);
            this.scSecondarySpliter.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scSecondarySpliter)).EndInit();
            this.scSecondarySpliter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCerts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.certificateBindingSource)).EndInit();
            this.panMain.ResumeLayout(false);
            this.scPreviewSplitter.Panel1.ResumeLayout(false);
            this.scPreviewSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scPreviewSplitter)).EndInit();
            this.scPreviewSplitter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer scMainSpliter;
        private System.Windows.Forms.SplitContainer scSecondarySpliter;
        private TreeViewModified tvCertificates;
        private System.Windows.Forms.Panel panMain;
        private System.Windows.Forms.Panel panPreview;
        private System.Windows.Forms.SplitContainer scPreviewSplitter;
        private System.Windows.Forms.NotifyIcon niCertificatesManager;
        private System.Windows.Forms.DataGridView dgvCerts;
        private System.Windows.Forms.BindingSource certificateBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contractNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn certificateNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn registerNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn verificationMethodDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deviceTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deviceNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn calibrationDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn calibrationExpireDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn certificatePathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileCreationDate;
    }
}
