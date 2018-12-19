namespace CertificatesViews.Controls
{
    partial class PreviewPanel
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
            this.panPages = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panPages
            // 
            this.panPages.AutoScroll = true;
            this.panPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panPages.Location = new System.Drawing.Point(0, 0);
            this.panPages.Name = "panPages";
            this.panPages.Size = new System.Drawing.Size(423, 554);
            this.panPages.TabIndex = 4;
            // 
            // PreviewPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panPages);
            this.Name = "PreviewPanel";
            this.Size = new System.Drawing.Size(423, 554);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panPages;
    }
}
