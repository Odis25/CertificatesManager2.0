﻿namespace CertificatesViews
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
            this.btAdd = new System.Windows.Forms.ToolStripButton();
            this.btSettings = new System.Windows.Forms.ToolStripButton();
            this.btChangeUser = new System.Windows.Forms.ToolStripButton();
            this.btUsersEdit = new System.Windows.Forms.ToolStripButton();
            this.stMain = new System.Windows.Forms.StatusStrip();
            this.tsUserRights = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsCurrentUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsUserLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsMain.SuspendLayout();
            this.stMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btAdd,
            this.btSettings,
            this.btChangeUser,
            this.btUsersEdit});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1034, 25);
            this.tsMain.TabIndex = 0;
            this.tsMain.Text = "tsMain";
            // 
            // btAdd
            // 
            this.btAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btAdd.Image = global::CertificatesViews.Properties.Resources.add;
            this.btAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(23, 22);
            this.btAdd.Text = "AddNewCertificate";
            this.btAdd.ToolTipText = "Добавить новое свидетельство";
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btSettings
            // 
            this.btSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btSettings.Image = global::CertificatesViews.Properties.Resources.cog;
            this.btSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btSettings.Name = "btSettings";
            this.btSettings.Size = new System.Drawing.Size(23, 22);
            this.btSettings.Text = "Settings";
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
            this.btChangeUser.Text = "ChangeUser";
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
            this.btUsersEdit.Text = "UsersEdit";
            this.btUsersEdit.ToolTipText = "Управление правами доступа пользователей";
            this.btUsersEdit.Click += new System.EventHandler(this.btUsersEdit_Click);
            // 
            // stMain
            // 
            this.stMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsUserRights,
            this.toolStripStatusLabel1,
            this.tsCurrentUser,
            this.tsUserLabel});
            this.stMain.Location = new System.Drawing.Point(0, 600);
            this.stMain.Name = "stMain";
            this.stMain.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.stMain.Size = new System.Drawing.Size(1034, 22);
            this.stMain.TabIndex = 1;
            this.stMain.Text = "sbMain";
            // 
            // tsUserRights
            // 
            this.tsUserRights.Name = "tsUserRights";
            this.tsUserRights.Size = new System.Drawing.Size(84, 17);
            this.tsUserRights.Text = "Пользователь";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(46, 17);
            this.toolStripStatusLabel1.Text = "Статус:";
            // 
            // tsCurrentUser
            // 
            this.tsCurrentUser.Name = "tsCurrentUser";
            this.tsCurrentUser.Size = new System.Drawing.Size(32, 17);
            this.tsCurrentUser.Text = "Вася";
            // 
            // tsUserLabel
            // 
            this.tsUserLabel.Image = global::CertificatesViews.Properties.Resources.user;
            this.tsUserLabel.Name = "tsUserLabel";
            this.tsUserLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsUserLabel.Size = new System.Drawing.Size(154, 17);
            this.tsUserLabel.Text = "Текущий пользователь:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 622);
            this.Controls.Add(this.stMain);
            this.Controls.Add(this.tsMain);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Certificates Manager 2.0";
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.stMain.ResumeLayout(false);
            this.stMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btAdd;
        private System.Windows.Forms.ToolStripButton btSettings;
        private System.Windows.Forms.ToolStripButton btChangeUser;
        private System.Windows.Forms.ToolStripButton btUsersEdit;
        private System.Windows.Forms.StatusStrip stMain;
        private System.Windows.Forms.ToolStripStatusLabel tsCurrentUser;
        private System.Windows.Forms.ToolStripStatusLabel tsUserLabel;
        private System.Windows.Forms.ToolStripStatusLabel tsUserRights;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

