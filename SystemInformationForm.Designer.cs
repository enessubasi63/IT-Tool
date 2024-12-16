namespace SysInspector
{
    partial class SystemInformationForm
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
            this.btnGetSystemInfo = new System.Windows.Forms.Button();
            this.textBoxSystemInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGetSystemInfo
            // 
            this.btnGetSystemInfo.Location = new System.Drawing.Point(12, 12);
            this.btnGetSystemInfo.Name = "btnGetSystemInfo";
            this.btnGetSystemInfo.Size = new System.Drawing.Size(100, 23);
            this.btnGetSystemInfo.TabIndex = 0;
            this.btnGetSystemInfo.Text = "Get System Info";
            this.btnGetSystemInfo.UseVisualStyleBackColor = true;
            this.btnGetSystemInfo.Click += new System.EventHandler(this.btnGetSystemInfo_Click);
            // 
            // textBoxSystemInfo
            // 
            this.textBoxSystemInfo.Location = new System.Drawing.Point(12, 41);
            this.textBoxSystemInfo.Multiline = true;
            this.textBoxSystemInfo.Name = "textBoxSystemInfo";
            this.textBoxSystemInfo.ReadOnly = true;
            this.textBoxSystemInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSystemInfo.Size = new System.Drawing.Size(260, 208);
            this.textBoxSystemInfo.TabIndex = 1;
            // 
            // SystemInformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.textBoxSystemInfo);
            this.Controls.Add(this.btnGetSystemInfo);
            this.Name = "SystemInformationForm";
            this.Text = "System Information";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetSystemInfo;
        private System.Windows.Forms.TextBox textBoxSystemInfo;
    }
}
