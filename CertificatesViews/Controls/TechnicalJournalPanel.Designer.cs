namespace CertificatesViews.Controls
{
    partial class TechnicalJournalPanel
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
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.btAttachFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbFiles = new System.Windows.Forms.ListBox();
            this.btOpen = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btOpenFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btOk
            // 
            this.btOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOk.Image = global::CertificatesViews.Properties.Resources.check;
            this.btOk.Location = new System.Drawing.Point(15, 331);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 35);
            this.btOk.TabIndex = 1;
            this.btOk.Text = "ОК";
            this.btOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Image = global::CertificatesViews.Properties.Resources.cross;
            this.btCancel.Location = new System.Drawing.Point(243, 331);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 35);
            this.btCancel.TabIndex = 1;
            this.btCancel.Text = "Отмена";
            this.btCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // btAttachFile
            // 
            this.btAttachFile.Image = global::CertificatesViews.Properties.Resources.attach;
            this.btAttachFile.Location = new System.Drawing.Point(96, 235);
            this.btAttachFile.Name = "btAttachFile";
            this.btAttachFile.Size = new System.Drawing.Size(138, 35);
            this.btAttachFile.TabIndex = 1;
            this.btAttachFile.Text = "Присоединить файл технического отчета";
            this.btAttachFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btAttachFile.UseVisualStyleBackColor = true;
            this.btAttachFile.Click += new System.EventHandler(this.btAttachFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(417, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Краткое описание:";
            // 
            // lbFiles
            // 
            this.lbFiles.FormattingEnabled = true;
            this.lbFiles.HorizontalScrollbar = true;
            this.lbFiles.Location = new System.Drawing.Point(15, 43);
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.Size = new System.Drawing.Size(303, 186);
            this.lbFiles.TabIndex = 3;
            // 
            // btOpen
            // 
            this.btOpen.Location = new System.Drawing.Point(96, 331);
            this.btOpen.Name = "btOpen";
            this.btOpen.Size = new System.Drawing.Size(138, 35);
            this.btOpen.TabIndex = 1;
            this.btOpen.Text = "Открыть выбранный файл";
            this.btOpen.UseVisualStyleBackColor = true;
            this.btOpen.Click += new System.EventHandler(this.btOpen_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Файлы технических отчетов:";
            // 
            // btOpenFolder
            // 
            this.btOpenFolder.Image = global::CertificatesViews.Properties.Resources.folder;
            this.btOpenFolder.Location = new System.Drawing.Point(96, 290);
            this.btOpenFolder.Name = "btOpenFolder";
            this.btOpenFolder.Size = new System.Drawing.Size(138, 35);
            this.btOpenFolder.TabIndex = 1;
            this.btOpenFolder.Text = "Открыть папку с отчетами";
            this.btOpenFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btOpenFolder.UseVisualStyleBackColor = true;
            this.btOpenFolder.Click += new System.EventHandler(this.btOpenFolder_Click);
            // 
            // TechnicalJournalPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbFiles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btAttachFile);
            this.Controls.Add(this.btOpenFolder);
            this.Controls.Add(this.btOpen);
            this.Controls.Add(this.btOk);
            this.Name = "TechnicalJournalPanel";
            this.Size = new System.Drawing.Size(338, 381);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btAttachFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbFiles;
        private System.Windows.Forms.Button btOpen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btOpenFolder;
    }
}
