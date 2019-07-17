namespace CertificatesViews.NewUI.Forms
{
    partial class StartingForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("ООО \"ГАЗПРОМНЕФТЬ-Хантос\" Южно-Приобская ГТЭС  ");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("2018", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Какой-то договор с очень длинным и стремным названием");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Узел4");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Узел5");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("2019", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4,
            treeNode5});
            this.panTopMenu = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.circularButton1 = new CertificatesViews.CircularButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panTopMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panTopMenu
            // 
            this.panTopMenu.BackColor = System.Drawing.Color.Black;
            this.panTopMenu.Controls.Add(this.circularButton1);
            this.panTopMenu.Controls.Add(this.pictureBox1);
            this.panTopMenu.Controls.Add(this.label1);
            this.panTopMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTopMenu.Location = new System.Drawing.Point(0, 0);
            this.panTopMenu.Name = "panTopMenu";
            this.panTopMenu.Size = new System.Drawing.Size(1280, 73);
            this.panTopMenu.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::CertificatesViews.Properties.Resources.Delicious;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(68, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LemonChiffon;
            this.label1.Location = new System.Drawing.Point(74, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Certificate Manager 2.0";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // circularButton1
            // 
            this.circularButton1.BackColor = System.Drawing.Color.Transparent;
            this.circularButton1.FlatAppearance.BorderSize = 0;
            this.circularButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circularButton1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.circularButton1.ForeColor = System.Drawing.Color.Black;
            this.circularButton1.Image = global::CertificatesViews.Properties.Resources.cross1;
            this.circularButton1.Location = new System.Drawing.Point(1250, 3);
            this.circularButton1.Name = "circularButton1";
            this.circularButton1.Size = new System.Drawing.Size(27, 27);
            this.circularButton1.TabIndex = 1;
            this.circularButton1.UseVisualStyleBackColor = false;
            this.circularButton1.Click += new System.EventHandler(this.circularButton1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 695);
            this.panel1.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.Info;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.CheckBoxes = true;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.treeView1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeView1.ItemHeight = 20;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Узел1";
            treeNode1.Text = "ООО \"ГАЗПРОМНЕФТЬ-Хантос\" Южно-Приобская ГТЭС  ";
            treeNode2.Name = "Узел0";
            treeNode2.Text = "2018";
            treeNode3.Name = "Узел3";
            treeNode3.Text = "Какой-то договор с очень длинным и стремным названием";
            treeNode4.Name = "Узел4";
            treeNode4.Text = "Узел4";
            treeNode5.Name = "Узел5";
            treeNode5.Text = "Узел5";
            treeNode6.Name = "Узел2";
            treeNode6.Text = "2019";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode6});
            this.treeView1.Size = new System.Drawing.Size(394, 336);
            this.treeView1.TabIndex = 0;
            // 
            // StartingForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(1280, 768);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panTopMenu);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "StartingForm";
            this.Text = "Certificate Manager";
            this.panTopMenu.ResumeLayout(false);
            this.panTopMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panTopMenu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private CircularButton circularButton1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView treeView1;
    }
}