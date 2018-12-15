namespace CertificatesViews
{
    partial class MainForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.btAdd = new System.Windows.Forms.ToolStripButton();
            this.btRemove = new System.Windows.Forms.ToolStripButton();
            this.btSettings = new System.Windows.Forms.ToolStripButton();
            this.btChangeUser = new System.Windows.Forms.ToolStripButton();
            this.btUsersEdit = new System.Windows.Forms.ToolStripButton();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btAdd,
            this.btRemove,
            this.btSettings,
            this.btChangeUser,
            this.btUsersEdit});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(869, 25);
            this.tsMain.TabIndex = 0;
            this.tsMain.Text = "tsMain";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 600);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(869, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // btAdd
            // 
            this.btAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btAdd.Image = global::CertificatesViews.Properties.Resources.add;
            this.btAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(23, 22);
            this.btAdd.Text = "toolStripButton1";
            this.btAdd.ToolTipText = "Добавить новое свидетельство";
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btRemove
            // 
            this.btRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btRemove.Image = global::CertificatesViews.Properties.Resources.cross;
            this.btRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(23, 22);
            this.btRemove.Text = "toolStripButton2";
            this.btRemove.ToolTipText = "Удалить выбранные свидетельства";
            this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // btSettings
            // 
            this.btSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btSettings.Image = global::CertificatesViews.Properties.Resources.cog;
            this.btSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btSettings.Name = "btSettings";
            this.btSettings.Size = new System.Drawing.Size(23, 22);
            this.btSettings.Text = "toolStripButton1";
            this.btSettings.ToolTipText = "Настройки приложения";
            this.btSettings.Click += new System.EventHandler(this.btSettings_Click);
            // 
            // btChangeUser
            // 
            this.btChangeUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btChangeUser.Image = global::CertificatesViews.Properties.Resources.key;
            this.btChangeUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btChangeUser.Name = "btChangeUser";
            this.btChangeUser.Size = new System.Drawing.Size(23, 22);
            this.btChangeUser.Text = "toolStripButton1";
            this.btChangeUser.ToolTipText = "Смена пользователя";
            this.btChangeUser.Click += new System.EventHandler(this.btChangeUser_Click);
            // 
            // btUsersEdit
            // 
            this.btUsersEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btUsersEdit.Image = global::CertificatesViews.Properties.Resources.group_edit;
            this.btUsersEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btUsersEdit.Name = "btUsersEdit";
            this.btUsersEdit.Size = new System.Drawing.Size(23, 22);
            this.btUsersEdit.Text = "toolStripButton2";
            this.btUsersEdit.ToolTipText = "Управление правами доступа пользователей";
            this.btUsersEdit.Click += new System.EventHandler(this.btUsersEdit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 622);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tsMain);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Certificates Manager 2.0";
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btAdd;
        private System.Windows.Forms.ToolStripButton btRemove;
        private System.Windows.Forms.ToolStripButton btSettings;
        private System.Windows.Forms.ToolStripButton btChangeUser;
        private System.Windows.Forms.ToolStripButton btUsersEdit;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}

