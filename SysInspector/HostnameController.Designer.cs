namespace SysInspector
{
    partial class HostnameControllerForm
    {
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
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtProjectPrefix = new System.Windows.Forms.TextBox();
            this.txtHostnameCount = new System.Windows.Forms.TextBox();
            this.btnCheckHostname = new System.Windows.Forms.Button();
            this.btnSaveLog = new System.Windows.Forms.Button();
            this.listViewResults = new System.Windows.Forms.ListView();
            this.columnHeaderResults = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblProjectPrefix = new System.Windows.Forms.Label();
            this.lblHostnameCount = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // txtProjectPrefix
            // 
            this.txtProjectPrefix.Location = new System.Drawing.Point(12, 29);
            this.txtProjectPrefix.Name = "txtProjectPrefix";
            this.txtProjectPrefix.Size = new System.Drawing.Size(100, 20);
            this.txtProjectPrefix.TabIndex = 0;
            // 
            // txtHostnameCount
            // 
            this.txtHostnameCount.Location = new System.Drawing.Point(118, 29);
            this.txtHostnameCount.Name = "txtHostnameCount";
            this.txtHostnameCount.Size = new System.Drawing.Size(100, 20);
            this.txtHostnameCount.TabIndex = 1;
            // 
            // btnCheckHostname
            // 
            this.btnCheckHostname.Location = new System.Drawing.Point(224, 26);
            this.btnCheckHostname.Name = "btnCheckHostname";
            this.btnCheckHostname.Size = new System.Drawing.Size(75, 23);
            this.btnCheckHostname.TabIndex = 2;
            this.btnCheckHostname.Text = "Check";
            this.btnCheckHostname.UseVisualStyleBackColor = true;
            this.btnCheckHostname.Click += new System.EventHandler(this.btnCheckHostname_Click);
            // 
            // btnSaveLog
            // 
            this.btnSaveLog.Location = new System.Drawing.Point(305, 26);
            this.btnSaveLog.Name = "btnSaveLog";
            this.btnSaveLog.Size = new System.Drawing.Size(75, 23);
            this.btnSaveLog.TabIndex = 3;
            this.btnSaveLog.Text = "Save Log";
            this.btnSaveLog.UseVisualStyleBackColor = true;
            this.btnSaveLog.Click += new System.EventHandler(this.btnSaveLog_Click);
            // 
            // listViewResults
            // 
            this.listViewResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderResults});
            this.listViewResults.HideSelection = false;
            this.listViewResults.Location = new System.Drawing.Point(12, 55);
            this.listViewResults.Name = "listViewResults";
            this.listViewResults.Size = new System.Drawing.Size(538, 268);
            this.listViewResults.TabIndex = 4;
            this.listViewResults.UseCompatibleStateImageBehavior = false;
            this.listViewResults.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderResults
            // 
            this.columnHeaderResults.Text = "Results";
            this.columnHeaderResults.Width = 750;
            // 
            // lblProjectPrefix
            // 
            this.lblProjectPrefix.AutoSize = true;
            this.lblProjectPrefix.Location = new System.Drawing.Point(12, 13);
            this.lblProjectPrefix.Name = "lblProjectPrefix";
            this.lblProjectPrefix.Size = new System.Drawing.Size(72, 13);
            this.lblProjectPrefix.TabIndex = 5;
            this.lblProjectPrefix.Text = "Project Prefix:";
            // 
            // lblHostnameCount
            // 
            this.lblHostnameCount.AutoSize = true;
            this.lblHostnameCount.Location = new System.Drawing.Point(118, 13);
            this.lblHostnameCount.Name = "lblHostnameCount";
            this.lblHostnameCount.Size = new System.Drawing.Size(89, 13);
            this.lblHostnameCount.TabIndex = 6;
            this.lblHostnameCount.Text = "Hostname Count:";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 329);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(538, 23);
            this.progressBar.TabIndex = 7;
            // 
            // HostnameControllerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 399);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblHostnameCount);
            this.Controls.Add(this.lblProjectPrefix);
            this.Controls.Add(this.listViewResults);
            this.Controls.Add(this.btnSaveLog);
            this.Controls.Add(this.btnCheckHostname);
            this.Controls.Add(this.txtHostnameCount);
            this.Controls.Add(this.txtProjectPrefix);
            this.Name = "HostnameControllerForm";
            this.Text = "Hostname Controller";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProjectPrefix;
        private System.Windows.Forms.TextBox txtHostnameCount;
        private System.Windows.Forms.Button btnCheckHostname;
        private System.Windows.Forms.Button btnSaveLog;
        private System.Windows.Forms.ListView listViewResults;
        private System.Windows.Forms.ColumnHeader columnHeaderResults;
        private System.Windows.Forms.Label lblProjectPrefix;
        private System.Windows.Forms.Label lblHostnameCount;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}