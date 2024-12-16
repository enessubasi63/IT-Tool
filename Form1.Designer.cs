namespace SysInspector
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageTroubleshoot = new System.Windows.Forms.TabPage();
            this.tabPageServiceManager = new System.Windows.Forms.TabPage();
            this.tabPageUrlAnalyzer = new System.Windows.Forms.TabPage();
            this.tabPageOtherTools = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageTroubleshoot);
            this.tabControl1.Controls.Add(this.tabPageUrlAnalyzer);
            this.tabControl1.Controls.Add(this.tabPageServiceManager);
            this.tabControl1.Controls.Add(this.tabPageOtherTools);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 426);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageTroubleshoot
            // 
            this.tabPageTroubleshoot.Location = new System.Drawing.Point(4, 22);
            this.tabPageTroubleshoot.Name = "tabPageTroubleshoot";
            this.tabPageTroubleshoot.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTroubleshoot.Size = new System.Drawing.Size(768, 400);
            this.tabPageTroubleshoot.TabIndex = 0;
            this.tabPageTroubleshoot.Text = "Troubleshoot";
            this.tabPageTroubleshoot.UseVisualStyleBackColor = true;
            // 
            // tabPageServiceManager
            // 
            this.tabPageServiceManager.Location = new System.Drawing.Point(4, 22);
            this.tabPageServiceManager.Name = "tabPageServiceManager";
            this.tabPageServiceManager.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageServiceManager.Size = new System.Drawing.Size(768, 400);
            this.tabPageServiceManager.TabIndex = 2;
            this.tabPageServiceManager.Text = "Service Manager";
            this.tabPageServiceManager.UseVisualStyleBackColor = true;
            // 
            // tabPageUrlAnalyzer
            // 
            this.tabPageUrlAnalyzer.Location = new System.Drawing.Point(4, 22);
            this.tabPageUrlAnalyzer.Name = "tabPageUrlAnalyzer";
            this.tabPageUrlAnalyzer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUrlAnalyzer.Size = new System.Drawing.Size(768, 400);
            this.tabPageUrlAnalyzer.TabIndex = 3;
            this.tabPageUrlAnalyzer.Text = "URL Analyzer";
            this.tabPageUrlAnalyzer.UseVisualStyleBackColor = true;
            // 
            // tabPageOtherTools
            // 
            this.tabPageOtherTools.Location = new System.Drawing.Point(4, 22);
            this.tabPageOtherTools.Name = "tabPageOtherTools";
            this.tabPageOtherTools.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOtherTools.Size = new System.Drawing.Size(768, 400);
            this.tabPageOtherTools.TabIndex = 5;
            this.tabPageOtherTools.Text = "Other Tools";
            this.tabPageOtherTools.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Mplus IT Tools";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageTroubleshoot;
        private System.Windows.Forms.TabPage tabPageUrlAnalyzer;
        private System.Windows.Forms.TabPage tabPageServiceManager;
        private System.Windows.Forms.TabPage tabPageOtherTools;
    }
}
