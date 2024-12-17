namespace SysInspector
{
    partial class HostnameForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuHostnameController = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNoIPResolution = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHostnameVerification = new System.Windows.Forms.ToolStripMenuItem();
            this.panelContent = new System.Windows.Forms.Panel();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHostnameController,
            this.menuNoIPResolution,
            this.menuHostnameVerification});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // menuHostnameController
            // 
            this.menuHostnameController.Name = "menuHostnameController";
            this.menuHostnameController.Size = new System.Drawing.Size(128, 20);
            this.menuHostnameController.Text = "HostnameController";
            this.menuHostnameController.Click += new System.EventHandler(this.menuHostnameController_Click);
            // 
            // menuNoIPResolution
            // 
            this.menuNoIPResolution.Name = "menuNoIPResolution";
            this.menuNoIPResolution.Size = new System.Drawing.Size(107, 20);
            this.menuNoIPResolution.Text = "NoIPResolution";
            this.menuNoIPResolution.Click += new System.EventHandler(this.menuNoIPResolution_Click);
            // 
            // menuHostnameVerification
            // 
            this.menuHostnameVerification.Name = "menuHostnameVerification";
            this.menuHostnameVerification.Size = new System.Drawing.Size(138, 20);
            this.menuHostnameVerification.Text = "HostnameVerification";
            this.menuHostnameVerification.Click += new System.EventHandler(this.menuHostnameVerification_Click);
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 24);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(800, 426);
            this.panelContent.TabIndex = 1;
            // 
            // HostnameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "HostnameForm";
            this.Text = "Hostname";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuHostnameController;
        private System.Windows.Forms.ToolStripMenuItem menuNoIPResolution;
        private System.Windows.Forms.ToolStripMenuItem menuHostnameVerification;
        private System.Windows.Forms.Panel panelContent;
    }
}
