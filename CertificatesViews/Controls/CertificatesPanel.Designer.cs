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
            this.scMainSpliter = new System.Windows.Forms.SplitContainer();
            this.scSecondarySpliter = new System.Windows.Forms.SplitContainer();
            this.tvCertificates = new CertificatesViews.TreeViewModified();
            this.lvCertificatesDetails = new CertificatesViews.Components.ListViewModified();
            this.headerId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerContractNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerCertificateNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerRegisterNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerVerificationMethod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerClientName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerObjectName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerDeviceType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerDeviceName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerSerialNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerCalibrationDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerCalibrationExpireDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerCertificatePath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerFileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerFileCreationDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panMain = new System.Windows.Forms.Panel();
            this.panPreview = new System.Windows.Forms.Panel();
            this.scPreviewSplitter = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.scMainSpliter)).BeginInit();
            this.scMainSpliter.Panel1.SuspendLayout();
            this.scMainSpliter.Panel2.SuspendLayout();
            this.scMainSpliter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scSecondarySpliter)).BeginInit();
            this.scSecondarySpliter.Panel1.SuspendLayout();
            this.scSecondarySpliter.SuspendLayout();
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
            this.scMainSpliter.Panel2.Controls.Add(this.lvCertificatesDetails);
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
            this.tvCertificates.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvCertificates_AfterSelect);
            // 
            // lvCertificatesDetails
            // 
            this.lvCertificatesDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.headerId,
            this.headerContractNumber,
            this.headerCertificateNumber,
            this.headerRegisterNumber,
            this.headerVerificationMethod,
            this.headerClientName,
            this.headerObjectName,
            this.headerDeviceType,
            this.headerDeviceName,
            this.headerSerialNumber,
            this.headerCalibrationDate,
            this.headerCalibrationExpireDate,
            this.headerCertificatePath,
            this.headerFileSize,
            this.headerFileCreationDate});
            this.lvCertificatesDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCertificatesDetails.FullRowSelect = true;
            this.lvCertificatesDetails.GridLines = true;
            this.lvCertificatesDetails.HeaderContextMenu = null;
            this.lvCertificatesDetails.Location = new System.Drawing.Point(0, 0);
            this.lvCertificatesDetails.Name = "lvCertificatesDetails";
            this.lvCertificatesDetails.Size = new System.Drawing.Size(666, 215);
            this.lvCertificatesDetails.TabIndex = 0;
            this.lvCertificatesDetails.UseCompatibleStateImageBehavior = false;
            this.lvCertificatesDetails.View = System.Windows.Forms.View.Details;
            this.lvCertificatesDetails.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvCertificatesDetails_ItemSelectionChanged);
            // 
            // headerId
            // 
            this.headerId.Text = "Id";
            this.headerId.Width = 49;
            // 
            // headerContractNumber
            // 
            this.headerContractNumber.Text = "Номер договора";
            this.headerContractNumber.Width = 103;
            // 
            // headerCertificateNumber
            // 
            this.headerCertificateNumber.Text = "Номер свидетельства";
            this.headerCertificateNumber.Width = 131;
            // 
            // headerRegisterNumber
            // 
            this.headerRegisterNumber.Text = "Номер в гос. реестре";
            this.headerRegisterNumber.Width = 127;
            // 
            // headerVerificationMethod
            // 
            this.headerVerificationMethod.Text = "Методика поверки";
            // 
            // headerClientName
            // 
            this.headerClientName.Text = "Заказчик";
            // 
            // headerObjectName
            // 
            this.headerObjectName.Text = "Объект эксплуатации";
            // 
            // headerDeviceType
            // 
            this.headerDeviceType.Text = "Группа СИ";
            // 
            // headerDeviceName
            // 
            this.headerDeviceName.Text = "Наименование СИ";
            // 
            // headerSerialNumber
            // 
            this.headerSerialNumber.Text = "Заводской номер";
            // 
            // headerCalibrationDate
            // 
            this.headerCalibrationDate.Text = "Дата поверки";
            // 
            // headerCalibrationExpireDate
            // 
            this.headerCalibrationExpireDate.Text = "Дата окончания срока поверки";
            // 
            // headerCertificatePath
            // 
            this.headerCertificatePath.Text = "Путь к файлу";
            // 
            // headerFileSize
            // 
            this.headerFileSize.Text = "Размер файла";
            // 
            // headerFileCreationDate
            // 
            this.headerFileCreationDate.Text = "Дата создания файла";
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
        private Components.ListViewModified lvCertificatesDetails;
        private System.Windows.Forms.ColumnHeader headerId;
        private System.Windows.Forms.ColumnHeader headerContractNumber;
        private System.Windows.Forms.ColumnHeader headerCertificateNumber;
        private System.Windows.Forms.ColumnHeader headerRegisterNumber;
        private System.Windows.Forms.ColumnHeader headerVerificationMethod;
        private System.Windows.Forms.ColumnHeader headerClientName;
        private System.Windows.Forms.ColumnHeader headerObjectName;
        private System.Windows.Forms.ColumnHeader headerDeviceType;
        private System.Windows.Forms.ColumnHeader headerDeviceName;
        private System.Windows.Forms.ColumnHeader headerSerialNumber;
        private System.Windows.Forms.ColumnHeader headerCalibrationDate;
        private System.Windows.Forms.ColumnHeader headerCalibrationExpireDate;
        private System.Windows.Forms.ColumnHeader headerCertificatePath;
        private System.Windows.Forms.ColumnHeader headerFileSize;
        private System.Windows.Forms.ColumnHeader headerFileCreationDate;
        private System.Windows.Forms.Panel panMain;
        private System.Windows.Forms.Panel panPreview;
        private System.Windows.Forms.SplitContainer scPreviewSplitter;
    }
}
