using CertificatesViews.Components;

namespace CertificatesViews.Controls
{
    partial class CertificatesPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CertificatesPanel));
            this.scMainSpliter = new System.Windows.Forms.SplitContainer();
            this.scSecondarySpliter = new System.Windows.Forms.SplitContainer();
            this.tvCertificates = new CertificatesViews.Components.TreeViewModified();
            this.dgvCerts = new System.Windows.Forms.DataGridView();
            this.certificateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panMain = new System.Windows.Forms.Panel();
            this.panPreview = new System.Windows.Forms.Panel();
            this.scPreviewSplitter = new System.Windows.Forms.SplitContainer();
            this.dgvHeaderMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Id = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiYear = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiContractNumber = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCertificateNumber = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRegisterNumber = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVerificationMethod = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClientName = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiObjectName = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeviceType = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeviceName = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSerialNumber = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCalibrationDate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCalibrationExpireDate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCertificatePath = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFileSize = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFileCreationDate = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvItemMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCopyInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSendByEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmChangeFilePath = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOpenVerificationMethod = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTransferDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.niCertificatesManager = new System.Windows.Forms.NotifyIcon(this.components);
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contractNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.certificateNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registerNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.verificationMethodDataGridViewLinkColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.clientNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objectNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deviceTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deviceNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serialNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calibrationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calibrationExpireDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.certificatePathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileCreationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.dgvHeaderMenuStrip.SuspendLayout();
            this.dgvItemMenuStrip.SuspendLayout();
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
            this.verificationMethodDataGridViewLinkColumn,
            this.clientNameDataGridViewTextBoxColumn,
            this.objectNameDataGridViewTextBoxColumn,
            this.deviceTypeDataGridViewTextBoxColumn,
            this.deviceNameDataGridViewTextBoxColumn,
            this.serialNumberDataGridViewTextBoxColumn,
            this.calibrationDateDataGridViewTextBoxColumn,
            this.calibrationExpireDateDataGridViewTextBoxColumn,
            this.certificatePathDataGridViewTextBoxColumn,
            this.fileSizeDataGridViewTextBoxColumn,
            this.fileCreationDateDataGridViewTextBoxColumn});
            this.dgvCerts.DataSource = this.certificateBindingSource;
            this.dgvCerts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCerts.Location = new System.Drawing.Point(0, 0);
            this.dgvCerts.Name = "dgvCerts";
            this.dgvCerts.ReadOnly = true;
            this.dgvCerts.RowHeadersVisible = false;
            this.dgvCerts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCerts.Size = new System.Drawing.Size(666, 215);
            this.dgvCerts.TabIndex = 0;
            this.dgvCerts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCerts_CellContentClick);
            this.dgvCerts.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCerts_CellMouseClick);
            this.dgvCerts.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCerts_ColumnHeaderMouseClick);
            this.dgvCerts.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvCerts_RowPrePaint);
            this.dgvCerts.SelectionChanged += new System.EventHandler(this.dgvCerts_SelectionChanged);
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
            // dgvHeaderMenuStrip
            // 
            this.dgvHeaderMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Id,
            this.tsmiYear,
            this.tsmiContractNumber,
            this.tsmiCertificateNumber,
            this.tsmiRegisterNumber,
            this.tsmiVerificationMethod,
            this.tsmiClientName,
            this.tsmiObjectName,
            this.tsmiDeviceType,
            this.tsmiDeviceName,
            this.tsmiSerialNumber,
            this.tsmiCalibrationDate,
            this.tsmiCalibrationExpireDate,
            this.tsmiCertificatePath,
            this.tsmiFileSize,
            this.tsmiFileCreationDate});
            this.dgvHeaderMenuStrip.Name = "dgvHeaderMenuStrip";
            this.dgvHeaderMenuStrip.Size = new System.Drawing.Size(209, 356);
            // 
            // Id
            // 
            this.Id.Checked = true;
            this.Id.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Id.Name = "Id";
            this.Id.Size = new System.Drawing.Size(208, 22);
            this.Id.Tag = "0";
            this.Id.Text = "Id";
            this.Id.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // tsmiYear
            // 
            this.tsmiYear.Checked = true;
            this.tsmiYear.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiYear.Name = "tsmiYear";
            this.tsmiYear.Size = new System.Drawing.Size(208, 22);
            this.tsmiYear.Tag = "1";
            this.tsmiYear.Text = "Год";
            this.tsmiYear.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // tsmiContractNumber
            // 
            this.tsmiContractNumber.Checked = true;
            this.tsmiContractNumber.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiContractNumber.Name = "tsmiContractNumber";
            this.tsmiContractNumber.Size = new System.Drawing.Size(208, 22);
            this.tsmiContractNumber.Tag = "2";
            this.tsmiContractNumber.Text = "Номер договора";
            this.tsmiContractNumber.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // tsmiCertificateNumber
            // 
            this.tsmiCertificateNumber.Checked = true;
            this.tsmiCertificateNumber.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiCertificateNumber.Name = "tsmiCertificateNumber";
            this.tsmiCertificateNumber.Size = new System.Drawing.Size(208, 22);
            this.tsmiCertificateNumber.Tag = "3";
            this.tsmiCertificateNumber.Text = "Номер свидетельства";
            this.tsmiCertificateNumber.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // tsmiRegisterNumber
            // 
            this.tsmiRegisterNumber.Checked = true;
            this.tsmiRegisterNumber.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiRegisterNumber.Name = "tsmiRegisterNumber";
            this.tsmiRegisterNumber.Size = new System.Drawing.Size(208, 22);
            this.tsmiRegisterNumber.Tag = "4";
            this.tsmiRegisterNumber.Text = "Номер в гос. реестре";
            this.tsmiRegisterNumber.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // tsmiVerificationMethod
            // 
            this.tsmiVerificationMethod.Checked = true;
            this.tsmiVerificationMethod.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiVerificationMethod.Name = "tsmiVerificationMethod";
            this.tsmiVerificationMethod.Size = new System.Drawing.Size(208, 22);
            this.tsmiVerificationMethod.Tag = "5";
            this.tsmiVerificationMethod.Text = "Методика поверки";
            this.tsmiVerificationMethod.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // tsmiClientName
            // 
            this.tsmiClientName.Checked = true;
            this.tsmiClientName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiClientName.Name = "tsmiClientName";
            this.tsmiClientName.Size = new System.Drawing.Size(208, 22);
            this.tsmiClientName.Tag = "6";
            this.tsmiClientName.Text = "Заказчик";
            this.tsmiClientName.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // tsmiObjectName
            // 
            this.tsmiObjectName.Checked = true;
            this.tsmiObjectName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiObjectName.Name = "tsmiObjectName";
            this.tsmiObjectName.Size = new System.Drawing.Size(208, 22);
            this.tsmiObjectName.Tag = "7";
            this.tsmiObjectName.Text = "Объект эксплуатации";
            this.tsmiObjectName.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // tsmiDeviceType
            // 
            this.tsmiDeviceType.Checked = true;
            this.tsmiDeviceType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiDeviceType.Name = "tsmiDeviceType";
            this.tsmiDeviceType.Size = new System.Drawing.Size(208, 22);
            this.tsmiDeviceType.Tag = "8";
            this.tsmiDeviceType.Text = "Группа СИ";
            this.tsmiDeviceType.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // tsmiDeviceName
            // 
            this.tsmiDeviceName.Checked = true;
            this.tsmiDeviceName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiDeviceName.Name = "tsmiDeviceName";
            this.tsmiDeviceName.Size = new System.Drawing.Size(208, 22);
            this.tsmiDeviceName.Tag = "9";
            this.tsmiDeviceName.Text = "Наименование СИ";
            this.tsmiDeviceName.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // tsmiSerialNumber
            // 
            this.tsmiSerialNumber.Checked = true;
            this.tsmiSerialNumber.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiSerialNumber.Name = "tsmiSerialNumber";
            this.tsmiSerialNumber.Size = new System.Drawing.Size(208, 22);
            this.tsmiSerialNumber.Tag = "10";
            this.tsmiSerialNumber.Text = "Заводской номер";
            this.tsmiSerialNumber.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // tsmiCalibrationDate
            // 
            this.tsmiCalibrationDate.Checked = true;
            this.tsmiCalibrationDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiCalibrationDate.Name = "tsmiCalibrationDate";
            this.tsmiCalibrationDate.Size = new System.Drawing.Size(208, 22);
            this.tsmiCalibrationDate.Tag = "11";
            this.tsmiCalibrationDate.Text = "Дата поверки";
            this.tsmiCalibrationDate.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // tsmiCalibrationExpireDate
            // 
            this.tsmiCalibrationExpireDate.Checked = true;
            this.tsmiCalibrationExpireDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiCalibrationExpireDate.Name = "tsmiCalibrationExpireDate";
            this.tsmiCalibrationExpireDate.Size = new System.Drawing.Size(208, 22);
            this.tsmiCalibrationExpireDate.Tag = "12";
            this.tsmiCalibrationExpireDate.Text = "Дата истечения поверки";
            this.tsmiCalibrationExpireDate.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // tsmiCertificatePath
            // 
            this.tsmiCertificatePath.Checked = true;
            this.tsmiCertificatePath.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiCertificatePath.Name = "tsmiCertificatePath";
            this.tsmiCertificatePath.Size = new System.Drawing.Size(208, 22);
            this.tsmiCertificatePath.Tag = "13";
            this.tsmiCertificatePath.Text = "Путь к файлу";
            this.tsmiCertificatePath.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // tsmiFileSize
            // 
            this.tsmiFileSize.Checked = true;
            this.tsmiFileSize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiFileSize.Name = "tsmiFileSize";
            this.tsmiFileSize.Size = new System.Drawing.Size(208, 22);
            this.tsmiFileSize.Tag = "14";
            this.tsmiFileSize.Text = "Размер файла";
            this.tsmiFileSize.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // tsmiFileCreationDate
            // 
            this.tsmiFileCreationDate.Checked = true;
            this.tsmiFileCreationDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiFileCreationDate.Name = "tsmiFileCreationDate";
            this.tsmiFileCreationDate.Size = new System.Drawing.Size(208, 22);
            this.tsmiFileCreationDate.Tag = "15";
            this.tsmiFileCreationDate.Text = "Дата создания файла";
            this.tsmiFileCreationDate.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // dgvItemMenuStrip
            // 
            this.dgvItemMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmOpen,
            this.tsmOpenFolder,
            this.tsmCopyInfo,
            this.tsmCopy,
            this.tsmSaveFile,
            this.tsmSendByEmail,
            this.tsmChangeFilePath,
            this.tsmOpenVerificationMethod,
            this.tsmTransferDocument});
            this.dgvItemMenuStrip.Name = "dgvItemMenuStrip";
            this.dgvItemMenuStrip.Size = new System.Drawing.Size(302, 202);
            this.dgvItemMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.dgvItemMenuStrip_ItemClicked);
            // 
            // tsmOpen
            // 
            this.tsmOpen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tsmOpen.Name = "tsmOpen";
            this.tsmOpen.Size = new System.Drawing.Size(301, 22);
            this.tsmOpen.Text = "&Открыть";
            // 
            // tsmOpenFolder
            // 
            this.tsmOpenFolder.Image = global::CertificatesViews.Properties.Resources.folder;
            this.tsmOpenFolder.Name = "tsmOpenFolder";
            this.tsmOpenFolder.Size = new System.Drawing.Size(301, 22);
            this.tsmOpenFolder.Text = "О&ткрыть папку свидетельств";
            // 
            // tsmCopyInfo
            // 
            this.tsmCopyInfo.Name = "tsmCopyInfo";
            this.tsmCopyInfo.Size = new System.Drawing.Size(301, 22);
            this.tsmCopyInfo.Text = "Копировать &инфо";
            // 
            // tsmCopy
            // 
            this.tsmCopy.Image = global::CertificatesViews.Properties.Resources.page_copy;
            this.tsmCopy.Name = "tsmCopy";
            this.tsmCopy.Size = new System.Drawing.Size(301, 22);
            this.tsmCopy.Text = "&Копировать свидетельство";
            // 
            // tsmSaveFile
            // 
            this.tsmSaveFile.Image = global::CertificatesViews.Properties.Resources.disk;
            this.tsmSaveFile.Name = "tsmSaveFile";
            this.tsmSaveFile.Size = new System.Drawing.Size(301, 22);
            this.tsmSaveFile.Text = "&Сохранить свидетельство в...";
            // 
            // tsmSendByEmail
            // 
            this.tsmSendByEmail.Image = global::CertificatesViews.Properties.Resources.email_go;
            this.tsmSendByEmail.Name = "tsmSendByEmail";
            this.tsmSendByEmail.Size = new System.Drawing.Size(301, 22);
            this.tsmSendByEmail.Text = "Отправить по &e-mail";
            // 
            // tsmChangeFilePath
            // 
            this.tsmChangeFilePath.Image = global::CertificatesViews.Properties.Resources.link_edit;
            this.tsmChangeFilePath.Name = "tsmChangeFilePath";
            this.tsmChangeFilePath.Size = new System.Drawing.Size(301, 22);
            this.tsmChangeFilePath.Text = "Изменить путь к файлу";
            // 
            // tsmOpenVerificationMethod
            // 
            this.tsmOpenVerificationMethod.Name = "tsmOpenVerificationMethod";
            this.tsmOpenVerificationMethod.Size = new System.Drawing.Size(301, 22);
            this.tsmOpenVerificationMethod.Text = "Открыть &методику поверки";
            // 
            // tsmTransferDocument
            // 
            this.tsmTransferDocument.Image = global::CertificatesViews.Properties.Resources.page_white_excel;
            this.tsmTransferDocument.Name = "tsmTransferDocument";
            this.tsmTransferDocument.Size = new System.Drawing.Size(301, 22);
            this.tsmTransferDocument.Text = "Сформировать &акт передачи документов";
            // 
            // niCertificatesManager
            // 
            this.niCertificatesManager.Icon = ((System.Drawing.Icon)(resources.GetObject("niCertificatesManager.Icon")));
            this.niCertificatesManager.Text = "Certificates Manager 2.0";
            this.niCertificatesManager.Visible = true;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "Id";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Width = 41;
            // 
            // yearDataGridViewTextBoxColumn
            // 
            this.yearDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.yearDataGridViewTextBoxColumn.DataPropertyName = "Year";
            this.yearDataGridViewTextBoxColumn.HeaderText = "Год";
            this.yearDataGridViewTextBoxColumn.Name = "yearDataGridViewTextBoxColumn";
            this.yearDataGridViewTextBoxColumn.ReadOnly = true;
            this.yearDataGridViewTextBoxColumn.Width = 50;
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
            // verificationMethodDataGridViewLinkColumn
            // 
            this.verificationMethodDataGridViewLinkColumn.DataPropertyName = "VerificationMethod";
            this.verificationMethodDataGridViewLinkColumn.HeaderText = "Методика поверки";
            this.verificationMethodDataGridViewLinkColumn.Name = "verificationMethodDataGridViewLinkColumn";
            this.verificationMethodDataGridViewLinkColumn.ReadOnly = true;
            this.verificationMethodDataGridViewLinkColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.verificationMethodDataGridViewLinkColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.verificationMethodDataGridViewLinkColumn.TrackVisitedState = false;
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
            this.certificatePathDataGridViewTextBoxColumn.DataPropertyName = "FullCertificatePath";
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
            // fileCreationDateDataGridViewTextBoxColumn
            // 
            this.fileCreationDateDataGridViewTextBoxColumn.DataPropertyName = "FileCreationDate";
            this.fileCreationDateDataGridViewTextBoxColumn.HeaderText = "Дата создания файла";
            this.fileCreationDateDataGridViewTextBoxColumn.Name = "fileCreationDateDataGridViewTextBoxColumn";
            this.fileCreationDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // CertificatesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.scPreviewSplitter);
            this.Name = "CertificatesPanel";
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
            this.dgvHeaderMenuStrip.ResumeLayout(false);
            this.dgvItemMenuStrip.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip dgvHeaderMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem Id;
        private System.Windows.Forms.ToolStripMenuItem tsmiYear;
        private System.Windows.Forms.ToolStripMenuItem tsmiContractNumber;
        private System.Windows.Forms.ToolStripMenuItem tsmiCertificateNumber;
        private System.Windows.Forms.ToolStripMenuItem tsmiRegisterNumber;
        private System.Windows.Forms.ToolStripMenuItem tsmiVerificationMethod;
        private System.Windows.Forms.ToolStripMenuItem tsmiClientName;
        private System.Windows.Forms.ToolStripMenuItem tsmiObjectName;
        private System.Windows.Forms.ToolStripMenuItem tsmiSerialNumber;
        private System.Windows.Forms.ToolStripMenuItem tsmiCalibrationDate;
        private System.Windows.Forms.ToolStripMenuItem tsmiCalibrationExpireDate;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeviceType;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeviceName;
        private System.Windows.Forms.ToolStripMenuItem tsmiCertificatePath;
        private System.Windows.Forms.ToolStripMenuItem tsmiFileSize;
        private System.Windows.Forms.ToolStripMenuItem tsmiFileCreationDate;
        private System.Windows.Forms.ContextMenuStrip dgvItemMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmOpen;
        private System.Windows.Forms.ToolStripMenuItem tsmOpenFolder;
        private System.Windows.Forms.ToolStripMenuItem tsmCopyInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmSaveFile;
        private System.Windows.Forms.ToolStripMenuItem tsmSendByEmail;
        private System.Windows.Forms.ToolStripMenuItem tsmChangeFilePath;
        private System.Windows.Forms.ToolStripMenuItem tsmOpenVerificationMethod;
        private System.Windows.Forms.ToolStripMenuItem tsmTransferDocument;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contractNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn certificateNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn registerNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn verificationMethodDataGridViewLinkColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deviceTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deviceNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn calibrationDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn calibrationExpireDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn certificatePathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileCreationDateDataGridViewTextBoxColumn;
    }
}
