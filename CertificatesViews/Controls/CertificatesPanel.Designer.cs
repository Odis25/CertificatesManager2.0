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
            this.tvCertificates = new CertificatesViews.TreeViewModified();
            this.SuspendLayout();
            // 
            // tvCertificates
            // 
            this.tvCertificates.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvCertificates.Location = new System.Drawing.Point(0, 0);
            this.tvCertificates.Name = "tvCertificates";
            this.tvCertificates.Size = new System.Drawing.Size(291, 363);
            this.tvCertificates.TabIndex = 0;
            // 
            // CertificatesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvCertificates);
            this.Name = "CertificatesPanel";
            this.Size = new System.Drawing.Size(339, 363);
            this.ResumeLayout(false);

        }

        #endregion

        private TreeViewModified tvCertificates;
    }
}
