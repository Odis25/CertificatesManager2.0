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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbSize = new System.Windows.Forms.TrackBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSize)).BeginInit();
            this.SuspendLayout();
            // 
            // panPages
            // 
            this.panPages.AutoScroll = true;
            this.panPages.Dock = System.Windows.Forms.DockStyle.Top;
            this.panPages.Location = new System.Drawing.Point(0, 0);
            this.panPages.Name = "panPages";
            this.panPages.Size = new System.Drawing.Size(423, 496);
            this.panPages.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.tbSize);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 496);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(423, 58);
            this.panel1.TabIndex = 3;
            // 
            // tbSize
            // 
            this.tbSize.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSize.Location = new System.Drawing.Point(76, 6);
            this.tbSize.Name = "tbSize";
            this.tbSize.Size = new System.Drawing.Size(243, 45);
            this.tbSize.TabIndex = 0;
            // 
            // PreviewPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panPages);
            this.Name = "PreviewPanel";
            this.Size = new System.Drawing.Size(423, 554);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panPages;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar tbSize;
    }
}
