namespace SysInspector
{
    partial class NoIPResolutionForm
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
            this.btnLogNoIPDevices = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.txtHostnamePrefix = new System.Windows.Forms.TextBox();
            this.lblHostnamePrefix = new System.Windows.Forms.Label();
            this.txtDeviceCount = new System.Windows.Forms.TextBox();
            this.lblDeviceCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLogNoIPDevices
            // 
            this.btnLogNoIPDevices.Location = new System.Drawing.Point(12, 70);
            this.btnLogNoIPDevices.Name = "btnLogNoIPDevices";
            this.btnLogNoIPDevices.Size = new System.Drawing.Size(150, 23);
            this.btnLogNoIPDevices.TabIndex = 0;
            this.btnLogNoIPDevices.Text = "Log No IP Devices";
            this.btnLogNoIPDevices.UseVisualStyleBackColor = true;
            this.btnLogNoIPDevices.Click += new System.EventHandler(this.btnLogNoIPDevices_Click);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(12, 100);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(400, 200);
            this.txtLog.TabIndex = 1;
            // 
            // txtHostnamePrefix
            // 
            this.txtHostnamePrefix.Location = new System.Drawing.Point(130, 12);
            this.txtHostnamePrefix.Name = "txtHostnamePrefix";
            this.txtHostnamePrefix.Size = new System.Drawing.Size(100, 20);
            this.txtHostnamePrefix.TabIndex = 2;
            // 
            // lblHostnamePrefix
            // 
            this.lblHostnamePrefix.AutoSize = true;
            this.lblHostnamePrefix.Location = new System.Drawing.Point(12, 15);
            this.lblHostnamePrefix.Name = "lblHostnamePrefix";
            this.lblHostnamePrefix.Size = new System.Drawing.Size(89, 13);
            this.lblHostnamePrefix.TabIndex = 3;
            this.lblHostnamePrefix.Text = "Hostname Prefix:";
            // 
            // txtDeviceCount
            // 
            this.txtDeviceCount.Location = new System.Drawing.Point(130, 38);
            this.txtDeviceCount.Name = "txtDeviceCount";
            this.txtDeviceCount.Size = new System.Drawing.Size(100, 20);
            this.txtDeviceCount.TabIndex = 4;
            // 
            // lblDeviceCount
            // 
            this.lblDeviceCount.AutoSize = true;
            this.lblDeviceCount.Location = new System.Drawing.Point(12, 41);
            this.lblDeviceCount.Name = "lblDeviceCount";
            this.lblDeviceCount.Size = new System.Drawing.Size(76, 13);
            this.lblDeviceCount.TabIndex = 5;
            this.lblDeviceCount.Text = "Device Count:";
            // 
            // NoIPResolutionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 311);
            this.Controls.Add(this.lblDeviceCount);
            this.Controls.Add(this.txtDeviceCount);
            this.Controls.Add(this.lblHostnamePrefix);
            this.Controls.Add(this.txtHostnamePrefix);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnLogNoIPDevices);
            this.Name = "NoIPResolutionForm";
            this.Text = "No IP Resolution";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnLogNoIPDevices;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TextBox txtHostnamePrefix;
        private System.Windows.Forms.Label lblHostnamePrefix;
        private System.Windows.Forms.TextBox txtDeviceCount;
        private System.Windows.Forms.Label lblDeviceCount;
    }
}
