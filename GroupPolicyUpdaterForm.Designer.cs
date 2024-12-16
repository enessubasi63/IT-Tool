namespace SysInspector
{
    partial class GroupPolicyUpdaterForm
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
            this.btnGpupdate = new System.Windows.Forms.Button();
            this.btnGpupdateForce = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGpupdate
            // 
            this.btnGpupdate.Location = new System.Drawing.Point(50, 30);
            this.btnGpupdate.Name = "btnGpupdate";
            this.btnGpupdate.Size = new System.Drawing.Size(150, 40);
            this.btnGpupdate.TabIndex = 0;
            this.btnGpupdate.Text = "gpupdate";
            this.btnGpupdate.UseVisualStyleBackColor = true;
            this.btnGpupdate.Click += new System.EventHandler(this.btnGpupdate_Click);
            // 
            // btnGpupdateForce
            // 
            this.btnGpupdateForce.Location = new System.Drawing.Point(50, 90);
            this.btnGpupdateForce.Name = "btnGpupdateForce";
            this.btnGpupdateForce.Size = new System.Drawing.Size(150, 40);
            this.btnGpupdateForce.TabIndex = 1;
            this.btnGpupdateForce.Text = "gpupdate /force";
            this.btnGpupdateForce.UseVisualStyleBackColor = true;
            this.btnGpupdateForce.Click += new System.EventHandler(this.btnGpupdateForce_Click);
            // 
            // GroupPolicyUpdaterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 160);
            this.Controls.Add(this.btnGpupdateForce);
            this.Controls.Add(this.btnGpupdate);
            this.Name = "GroupPolicyUpdaterForm";
            this.Text = "Group Policy Updater";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGpupdate;
        private System.Windows.Forms.Button btnGpupdateForce;
    }
}
