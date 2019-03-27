namespace BuenoBookings
{

    // chsnge me
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnBookings = new System.Windows.Forms.ToolStripButton();
            this.btnGuests = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new MdiTabControl.TabControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssOne = new System.Windows.Forms.ToolStripStatusLabel();
            this.txxTwo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssThree = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssFour = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.maintenanceToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 27);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(41, 23);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // maintenanceToolStripMenuItem
            // 
            this.maintenanceToolStripMenuItem.Name = "maintenanceToolStripMenuItem";
            this.maintenanceToolStripMenuItem.Size = new System.Drawing.Size(100, 23);
            this.maintenanceToolStripMenuItem.Text = "Maintenance";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBookings,
            this.btnGuests});
            this.toolStrip1.Location = new System.Drawing.Point(0, 27);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnBookings
            // 
            this.btnBookings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBookings.Image = global::BuenoBookings.Properties.Resources.iconfinder_37_SEO_Report_1688840;
            this.btnBookings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBookings.Name = "btnBookings";
            this.btnBookings.Size = new System.Drawing.Size(23, 22);
            this.btnBookings.Text = "Bookings";
            this.btnBookings.Click += new System.EventHandler(this.btnBookings_Click);
            // 
            // btnGuests
            // 
            this.btnGuests.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGuests.Image = ((System.Drawing.Image)(resources.GetObject("btnGuests.Image")));
            this.btnGuests.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuests.Name = "btnGuests";
            this.btnGuests.Size = new System.Drawing.Size(23, 22);
            this.btnGuests.Text = "Guests";
            this.btnGuests.Click += new System.EventHandler(this.btnGuests_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 52);
            this.tabControl1.MenuRenderer = null;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Size = new System.Drawing.Size(800, 398);
            this.tabControl1.TabCloseButtonImage = null;
            this.tabControl1.TabCloseButtonImageDisabled = null;
            this.tabControl1.TabCloseButtonImageHot = null;
            this.tabControl1.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssOne,
            this.txxTwo,
            this.tssThree,
            this.tssFour});
            this.statusStrip1.Location = new System.Drawing.Point(0, 426);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 24);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssOne
            // 
            this.tssOne.Name = "tssOne";
            this.tssOne.Size = new System.Drawing.Size(139, 19);
            this.tssOne.Text = "toolStripStatusLabel1";
            // 
            // txxTwo
            // 
            this.txxTwo.Name = "txxTwo";
            this.txxTwo.Size = new System.Drawing.Size(139, 19);
            this.txxTwo.Text = "toolStripStatusLabel2";
            // 
            // tssThree
            // 
            this.tssThree.Name = "tssThree";
            this.tssThree.Size = new System.Drawing.Size(139, 19);
            this.tssThree.Text = "toolStripStatusLabel3";
            // 
            // tssFour
            // 
            this.tssFour.Name = "tssFour";
            this.tssFour.Size = new System.Drawing.Size(139, 19);
            this.tssFour.Text = "toolStripStatusLabel4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnBookings;
        private System.Windows.Forms.ToolStripButton btnGuests;
        private MdiTabControl.TabControl tabControl1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel tssOne;
        public System.Windows.Forms.ToolStripStatusLabel txxTwo;
        public System.Windows.Forms.ToolStripStatusLabel tssThree;
        public System.Windows.Forms.ToolStripStatusLabel tssFour;
    }
}

