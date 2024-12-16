using System.Windows.Forms;

namespace SysInspector
{
    partial class OtherToolsForm
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.flowLayoutPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.flowLayoutPanelButtons);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 450);
            this.panelMenu.TabIndex = 0;
            // 
            // flowLayoutPanelButtons
            // 
            this.flowLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelButtons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelButtons.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            this.flowLayoutPanelButtons.Size = new System.Drawing.Size(200, 450);
            this.flowLayoutPanelButtons.TabIndex = 0;
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(200, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(600, 450);
            this.panelContent.TabIndex = 1;
            // 
            // OtherToolsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelMenu);
            this.Name = "OtherToolsForm";
            this.Text = "Other Tools";
            this.Load += new System.EventHandler(this.OtherToolsForm_Load);
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

            AddMenuButtons();
        }

        private void AddMenuButtons()
        {
            AddMenuButton("Azure Check", "btnTool1");
            AddMenuButton("Hostname Check", "btnTool2"); // HostnameController yerine Hostname kullanılıyor
            AddMenuButton("Telnet and Ping Tool", "btnTelnetTool");
            AddMenuButton("DCM Agents", "btnBatchExecutor");
            AddMenuButton("Cache Clearing", "btnCacheClearing");
            AddMenuButton("System Information", "btnSystemInformation");
            AddMenuButton("AD Description", "btnADQuery");
            AddMenuButton("Group Policy Updater", "btnGroupPolicyUpdater");
            AddMenuButton("User Profiles", "btnUserProfiles");
        }

        private void AddMenuButton(string text, string name)
        {
            var button = new Button
            {
                Text = text,
                Name = name,
                FlatStyle = FlatStyle.Flat,
                Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular),
                Width = 180,
                Height = 50
            };
            button.Click += btnTool_Click;
            flowLayoutPanelButtons.Controls.Add(button);
        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;
        private System.Windows.Forms.Panel panelContent;
    }
}
