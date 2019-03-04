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
            this.btChangeVerificationMethodPath = new System.Windows.Forms.Button();
            this.btChangeCertificatesZipFolderPath = new System.Windows.Forms.Button();
            this.btChangeCertificatesFolderPath = new System.Windows.Forms.Button();
            this.btChangeDataBasePath = new System.Windows.Forms.Button();
            this.tbVerificationMethodFolderPath = new System.Windows.Forms.TextBox();
            this.tbCertificatesZipFolderPath = new System.Windows.Forms.TextBox();
            this.tbCertificatesFolderPath = new System.Windows.Forms.TextBox();
            this.tbDataBasePath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbSaveUserCredential = new System.Windows.Forms.CheckBox();
            this.chbAutoPreviewEnabled = new System.Windows.Forms.CheckBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.btSaveChanges = new System.Windows.Forms.Button();
            this.btOk = new System.Windows.Forms.Button();
            this.gbPaths.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPaths
            // 
            this.gbPaths.Controls.Add(this.btChangeVerificationMethodPath);
            this.gbPaths.Controls.Add(this.btChangeCertificatesZipFolderPath);
            this.gbPaths.Controls.Add(this.btChangeCertificatesFolderPath);
            this.gbPaths.Controls.Add(this.btChangeDataBasePath);
            this.gbPaths.Controls.Add(this.tbVerificationMethodFolderPath);
            this.gbPaths.Controls.Add(this.tbCertificatesZipFolderPath);
            this.gbPaths.Controls.Add(this.tbCertificatesFolderPath);
            this.gbPaths.Controls.Add(this.tbDataBasePath);
            this.gbPaths.Controls.Add(this.label4);
            this.gbPaths.Controls.Add(this.label3);
            this.gbPaths.Controls.Add(this.label2);
            this.gbPaths.Controls.Add(this.label1);
            this.gbPaths.Location = new System.Drawing.Point(6, 0);
            this.gbPaths.Name = "gbPaths";
            this.gbPaths.Size = new System.Drawing.Size(578, 173);
            this.gbPaths.TabIndex = 0;
            this.gbPaths.TabStop = false;
            this.gbPaths.Text = "Пути";
            // 
            // btChangeVerificationMethodPath
            // 
            this.btChangeVerificationMethodPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btChangeVerificationMethodPath.Image = global::CertificatesViews.Properties.Resources.folder_explore;
            this.btChangeVerificationMethodPath.Location = new System.Drawing.Point(537, 137);
            this.btChangeVerificationMethodPath.Name = "btChangeVerificationMethodPath";
            this.btChangeVerificationMethodPath.Size = new System.Drawing.Size(33, 23);
            this.btChangeVerificationMethodPath.TabIndex = 14;
            this.btChangeVerificationMethodPath.UseVisualStyleBackColor = true;
            this.btChangeVerificationMethodPath.Click += new System.EventHandler(this.btChangeVerificationMethodPath_Click);
            // 
            // btChangeCertificatesZipFolderPath
            // 
            this.btChangeCertificatesZipFolderPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btChangeCertificatesZipFolderPath.Image = global::CertificatesViews.Properties.Resources.folder_explore;
            this.btChangeCertificatesZipFolderPath.Location = new System.Drawing.Point(537, 109);
            this.btChangeCertificatesZipFolderPath.Name = "btChangeCertificatesZipFolderPath";
            this.btChangeCertificatesZipFolderPath.Size = new System.Drawing.Size(33, 23);
            this.btChangeCertificatesZipFolderPath.TabIndex = 13;
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
            this.btChangeCertificatesFolderPath.TabIndex = 12;
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
            this.btChangeDataBasePath.TabIndex = 10;
            this.btChangeDataBasePath.UseVisualStyleBackColor = true;
            this.btChangeDataBasePath.Click += new System.EventHandler(this.btChangeDataBasePath_Click);
            // 
            // tbVerificationMethodFolderPath
            // 
            this.tbVerificationMethodFolderPath.Location = new System.Drawing.Point(252, 138);
            this.tbVerificationMethodFolderPath.Name = "tbVerificationMethodFolderPath";
            this.tbVerificationMethodFolderPath.Size = new System.Drawing.Size(287, 20);
            this.tbVerificationMethodFolderPath.TabIndex = 4;
            this.tbVerificationMethodFolderPath.TextChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // tbCertificatesZipFolderPath
            // 
            this.tbCertificatesZipFolderPath.Location = new System.Drawing.Point(252, 110);
            this.tbCertificatesZipFolderPath.Name = "tbCertificatesZipFolderPath";
            this.tbCertificatesZipFolderPath.Size = new System.Drawing.Size(287, 20);
            this.tbCertificatesZipFolderPath.TabIndex = 3;
            this.tbCertificatesZipFolderPath.TextChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // tbCertificatesFolderPath
            // 
            this.tbCertificatesFolderPath.Location = new System.Drawing.Point(252, 61);
            this.tbCertificatesFolderPath.Name = "tbCertificatesFolderPath";
            this.tbCertificatesFolderPath.Size = new System.Drawing.Size(287, 20);
            this.tbCertificatesFolderPath.TabIndex = 2;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Каталог хранения методик поверки:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 114);
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
            this.groupBox1.Controls.Add(this.chbSaveUserCredential);
            this.groupBox1.Controls.Add(this.chbAutoPreviewEnabled);
            this.groupBox1.Location = new System.Drawing.Point(6, 179);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(578, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Другие настройки";
            // 
            // chbSaveUserCredential
            // 
            this.chbSaveUserCredential.AutoSize = true;
            this.chbSaveUserCredential.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbSaveUserCredential.Location = new System.Drawing.Point(16, 53);
            this.chbSaveUserCredential.Name = "chbSaveUserCredential";
            this.chbSaveUserCredential.Size = new System.Drawing.Size(231, 17);
            this.chbSaveUserCredential.TabIndex = 6;
            this.chbSaveUserCredential.Text = "Автоматическая авторизация при входе";
            this.chbSaveUserCredential.UseVisualStyleBackColor = true;
            this.chbSaveUserCredential.CheckedChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // chbAutoPreviewEnabled
            // 
            this.chbAutoPreviewEnabled.AutoSize = true;
            this.chbAutoPreviewEnabled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbAutoPreviewEnabled.Location = new System.Drawing.Point(16, 30);
            this.chbAutoPreviewEnabled.Name = "chbAutoPreviewEnabled";
            this.chbAutoPreviewEnabled.Size = new System.Drawing.Size(262, 17);
            this.chbAutoPreviewEnabled.TabIndex = 5;
            this.chbAutoPreviewEnabled.Text = "Автоматический предпросмотр свидетельств:";
            this.chbAutoPreviewEnabled.UseVisualStyleBackColor = true;
            this.chbAutoPreviewEnabled.CheckedChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // btCancel
            // 
            this.btCancel.Image = global::CertificatesViews.Properties.Resources.door_in;
            this.btCancel.Location = new System.Drawing.Point(362, 291);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(77, 28);
            this.btCancel.TabIndex = 9;
            this.btCancel.Text = "Закрыть";
            this.btCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btSaveChanges
            // 
            this.btSaveChanges.Image = global::CertificatesViews.Properties.Resources.disk;
            this.btSaveChanges.Location = new System.Drawing.Point(258, 291);
            this.btSaveChanges.Name = "btSaveChanges";
            this.btSaveChanges.Size = new System.Drawing.Size(86, 28);
            this.btSaveChanges.TabIndex = 8;
            this.btSaveChanges.Text = "Сохранить";
            this.btSaveChanges.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btSaveChanges.UseVisualStyleBackColor = true;
            this.btSaveChanges.Click += new System.EventHandler(this.btSaveChanges_Click);
            // 
            // btOk
            // 
            this.btOk.Image = global::CertificatesViews.Properties.Resources.check;
            this.btOk.Location = new System.Drawing.Point(154, 291);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(86, 28);
            this.btOk.TabIndex = 7;
            this.btOk.Text = "ОК";
            this.btOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 331);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
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
        private System.Windows.Forms.Button btChangeCertificatesFolderPath;
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
        private System.Windows.Forms.CheckBox chbSaveUserCredential;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btChangeVerificationMethodPath;
        private System.Windows.Forms.TextBox tbVerificationMethodFolderPath;
        private System.Windows.Forms.Label label4;
    }
}