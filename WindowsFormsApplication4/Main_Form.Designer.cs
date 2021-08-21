namespace WindowsFormsApplication4
{
    partial class Main_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.createUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sUPPLIERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pRODUCTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOSTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pURCHASEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sALESREPORTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eXITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Castellar", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createUserToolStripMenuItem,
            this.sUPPLIERToolStripMenuItem,
            this.pRODUCTToolStripMenuItem,
            this.cOSTToolStripMenuItem,
            this.pURCHASEToolStripMenuItem,
            this.sALESREPORTToolStripMenuItem,
            this.eXITToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(693, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // createUserToolStripMenuItem
            // 
            this.createUserToolStripMenuItem.Name = "createUserToolStripMenuItem";
            this.createUserToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.createUserToolStripMenuItem.Text = "CREATE USER";
            this.createUserToolStripMenuItem.Click += new System.EventHandler(this.createUserToolStripMenuItem_Click);
            // 
            // sUPPLIERToolStripMenuItem
            // 
            this.sUPPLIERToolStripMenuItem.Name = "sUPPLIERToolStripMenuItem";
            this.sUPPLIERToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.sUPPLIERToolStripMenuItem.Text = "SUPPLIER";
            this.sUPPLIERToolStripMenuItem.Click += new System.EventHandler(this.sUPPLIERToolStripMenuItem_Click);
            // 
            // pRODUCTToolStripMenuItem
            // 
            this.pRODUCTToolStripMenuItem.Name = "pRODUCTToolStripMenuItem";
            this.pRODUCTToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.pRODUCTToolStripMenuItem.Text = "PRODUCT";
            this.pRODUCTToolStripMenuItem.Click += new System.EventHandler(this.pRODUCTToolStripMenuItem_Click);
            // 
            // cOSTToolStripMenuItem
            // 
            this.cOSTToolStripMenuItem.Name = "cOSTToolStripMenuItem";
            this.cOSTToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.cOSTToolStripMenuItem.Text = "CUSTOMER";
            this.cOSTToolStripMenuItem.Click += new System.EventHandler(this.cOSTToolStripMenuItem_Click);
            // 
            // pURCHASEToolStripMenuItem
            // 
            this.pURCHASEToolStripMenuItem.Name = "pURCHASEToolStripMenuItem";
            this.pURCHASEToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.pURCHASEToolStripMenuItem.Text = "PURCHASE";
            this.pURCHASEToolStripMenuItem.Click += new System.EventHandler(this.pURCHASEToolStripMenuItem_Click);
            // 
            // sALESREPORTToolStripMenuItem
            // 
            this.sALESREPORTToolStripMenuItem.Name = "sALESREPORTToolStripMenuItem";
            this.sALESREPORTToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.sALESREPORTToolStripMenuItem.Text = "SALES REPORT";
            this.sALESREPORTToolStripMenuItem.Click += new System.EventHandler(this.sALESREPORTToolStripMenuItem_Click);
            // 
            // eXITToolStripMenuItem
            // 
            this.eXITToolStripMenuItem.Name = "eXITToolStripMenuItem";
            this.eXITToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.eXITToolStripMenuItem.Text = "EXIT";
            this.eXITToolStripMenuItem.Click += new System.EventHandler(this.eXITToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(693, 72);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(693, 431);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main_Form";
            this.Text = "Main_Form";
            this.Load += new System.EventHandler(this.Main_Form_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem createUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sUPPLIERToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pRODUCTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOSTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pURCHASEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sALESREPORTToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem eXITToolStripMenuItem;
    }
}