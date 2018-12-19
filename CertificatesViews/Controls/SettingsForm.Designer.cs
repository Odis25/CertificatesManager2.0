namespace CertificatesViews.Controls
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbPaths = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tbCertificatesZipFolderPath = new System.Windows.Forms.TextBox();
            this.tbCertificatesFolderPath = new System.Windows.Forms.TextBox();
            this.tbDataBasePath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbAutoPreviewEnabled = new System.Windows.Forms.CheckBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.btSaveChanges = new System.Windows.Forms.Button();
            this.btChangeCertificatesZipFolderPath = new System.Windows.Forms.Button();
            this.btChangeCertificatesFolderPath = new System.Windows.Forms.Button();
            this.btChangeDataBasePath = new System.Windows.Forms.Button();
            this.gbPaths.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPaths
            // 
            this.gbPaths.Controls.Add(this.btChangeCertificatesZipFolderPath);
            this.gbPaths.Controls.Add(this.button3);
            this.gbPaths.Controls.Add(this.btChangeCertificatesFolderPath);
            this.gbPaths.Controls.Add(this.button2);
            this.gbPaths.Controls.Add(this.btChangeDataBasePath);
            this.gbPaths.Controls.Add(this.tbCertificatesZipFolderPath);
            this.gbPaths.Controls.Add(this.tbCertificatesFolderPath);
            this.gbPaths.Controls.Add(this.tbDataBasePath);
            this.gbPaths.Controls.Add(this.label3);
            this.gbPaths.Controls.Add(this.label2);
            this.gbPaths.Controls.Add(this.label1);
            this.gbPaths.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbPaths.Location = new System.Drawing.Point(0, 0);
            this.gbPaths.Name = "gbPaths";
            this.gbPaths.Size = new System.Drawing.Size(582, 129);
            this.gbPaths.TabIndex = 0;
            this.gbPaths.TabStop = false;
            this.gbPaths.Text = "Пути";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(537, 87);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(33, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(537, 59);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(33, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // tbCertificatesZipFolderPath
            // 
            this.tbCertificatesZipFolderPath.Location = new System.Drawing.Point(252, 89);
            this.tbCertificatesZipFolderPath.Name = "tbCertificatesZipFolderPath";
            this.tbCertificatesZipFolderPath.Size = new System.Drawing.Size(287, 20);
            this.tbCertificatesZipFolderPath.TabIndex = 1;
            this.tbCertificatesZipFolderPath.TextChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // tbCertificatesFolderPath
            // 
            this.tbCertificatesFolderPath.Location = new System.Drawing.Point(252, 61);
            this.tbCertificatesFolderPath.Name = "tbCertificatesFolderPath";
            this.tbCertificatesFolderPath.Size = new System.Drawing.Size(287, 20);
            this.tbCertificatesFolderPath.TabIndex = 1;
            this.tbCertificatesFolderPath.TextChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // tbDataBasePath
            // 
            this.tbDataBasePath.Location = new System.Drawing.Point(252, 33);
            this.tbDataBasePath.Name = "tbDataBasePath";
            this.tbDataBasePath.Size = new System.Drawing.Size(287, 20);
            this.tbDataBasePath.TabIndex = 1;
            this.tbDataBasePath.TextChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(236, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Каталог резервного хранения свидетельств:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Каталог хранения свидетельств:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "База данных:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbAutoPreviewEnabled);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 129);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(582, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Другие настройки";
            // 
            // chbAutoPreviewEnabled
            // 
            this.chbAutoPreviewEnabled.AutoSize = true;
            this.chbAutoPreviewEnabled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbAutoPreviewEnabled.Location = new System.Drawing.Point(16, 45);
            this.chbAutoPreviewEnabled.Name = "chbAutoPreviewEnabled";
            this.chbAutoPreviewEnabled.Size = new System.Drawing.Size(262, 17);
            this.chbAutoPreviewEnabled.TabIndex = 1;
            this.chbAutoPreviewEnabled.Text = "Автоматический предпросмотр свидетельств:";
            this.chbAutoPreviewEnabled.UseVisualStyleBackColor = true;
            this.chbAutoPreviewEnabled.CheckedChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // btCancel
            // 
            this.btCancel.Image = global::CertificatesViews.Properties.Resources.cross;
            this.btCancel.Location = new System.Drawing.Point(319, 241);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(77, 28);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "Отмена";
            this.btCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btSaveChanges
            // 
            this.btSaveChanges.Image = global::CertificatesViews.Properties.Resources.disk;
            this.btSaveChanges.Location = new System.Drawing.Point(175, 241);
            this.btSaveChanges.Name = "btSaveChanges";
            this.btSaveChanges.Size = new System.Drawing.Size(86, 28);
            this.btSaveChanges.TabIndex = 1;
            this.btSaveChanges.Text = "Сохранить";
            this.btSaveChanges.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btSaveChanges.UseVisualStyleBackColor = true;
            this.btSaveChanges.Click += new System.EventHandler(this.btSaveChanges_Click);
            // 
            // btChangeCertificatesZipFolderPath
            // 
            this.btChangeCertificatesZipFolderPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btChangeCertificatesZipFolderPath.Image = global::CertificatesViews.Properties.Resources.folder_explore;
            this.btChangeCertificatesZipFolderPath.Location = new System.Drawing.Point(537, 88);
            this.btChangeCertificatesZipFolderPath.Name = "btChangeCertificatesZipFolderPath";
            this.btChangeCertificatesZipFolderPath.Size = new System.Drawing.Size(33, 23);
            this.btChangeCertificatesZipFolderPath.TabIndex = 2;
            this.btChangeCertificatesZipFolderPath.UseVisualStyleBackColor = true;
            this.btChangeCertificatesZipFolderPath.Click += new System.EventHandler(this.btChangeCertificatesZipFolderPath_Click);
            // 
            // btChangeCertificatesFolderPath
            // 
            this.btChangeCertificatesFolderPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btChangeCertificatesFolderPath.Image = global::CertificatesViews.Properties.Resources.folder_explore;
            this.btChangeCertificatesFolderPath.Location = new System.Drawing.Point(537, 60);
            this.btChangeCertificatesFolderPath.Name = "btChangeCertificatesFolderPath";
            this.btChangeCertificatesFolderPath.Size = new System.Drawing.Size(33, 23);
            this.btChangeCertificatesFolderPath.TabIndex = 2;
            this.btChangeCertificatesFolderPath.UseVisualStyleBackColor = true;
            this.btChangeCertificatesFolderPath.Click += new System.EventHandler(this.btChangeCertificatesFolderPath_Click);
            // 
            // btChangeDataBasePath
            // 
            this.btChangeDataBasePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btChangeDataBasePath.Image = global::CertificatesViews.Properties.Resources.folder_explore;
            this.btChangeDataBasePath.Location = new System.Drawing.Point(537, 32);
            this.btChangeDataBasePath.Name = "btChangeDataBasePath";
            this.btChangeDataBasePath.Size = new System.Drawing.Size(33, 23);
            this.btChangeDataBasePath.TabIndex = 2;
            this.btChangeDataBasePath.UseVisualStyleBackColor = true;
            this.btChangeDataBasePath.Click += new System.EventHandler(this.btChangeDataBasePath_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 281);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSaveChanges);
            this.Controls.Add(this.gbPaths);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки приложения";
            this.gbPaths.ResumeLayout(false);
            this.gbPaths.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPaths;
        private System.Windows.Forms.Button btChangeCertificatesZipFolderPath;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btChangeCertificatesFolderPath;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btChangeDataBasePath;
        private System.Windows.Forms.TextBox tbCertificatesZipFolderPath;
        private System.Windows.Forms.TextBox tbCertificatesFolderPath;
        private System.Windows.Forms.TextBox tbDataBasePath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btSaveChanges;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chbAutoPreviewEnabled;
    }
}