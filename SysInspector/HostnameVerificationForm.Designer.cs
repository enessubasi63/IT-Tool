namespace SysInspector
{
    partial class HostnameVerificationForm
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
            this.txtHostnames = new System.Windows.Forms.TextBox();
            this.btnVerifyHostnames = new System.Windows.Forms.Button();
            this.listViewNotInDomain = new System.Windows.Forms.ListView();
            this.columnHeaderNotInDomain = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewInDomainWithIP = new System.Windows.Forms.ListView();
            this.columnHeaderInDomainWithIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewInDomainWithoutIP = new System.Windows.Forms.ListView();
            this.columnHeaderInDomainWithoutIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblHostnames = new System.Windows.Forms.Label();
            this.btnExportNotInDomain = new System.Windows.Forms.Button();
            this.btnExportInDomainWithIP = new System.Windows.Forms.Button();
            this.btnExportInDomainWithoutIP = new System.Windows.Forms.Button();
            this.btnExportAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtHostnames
            // 
            this.txtHostnames.Location = new System.Drawing.Point(12, 29);
            this.txtHostnames.Name = "txtHostnames";
            this.txtHostnames.Size = new System.Drawing.Size(537, 20);
            this.txtHostnames.TabIndex = 0;
            // 
            // btnVerifyHostnames
            // 
            this.btnVerifyHostnames.Location = new System.Drawing.Point(12, 55);
            this.btnVerifyHostnames.Name = "btnVerifyHostnames";
            this.btnVerifyHostnames.Size = new System.Drawing.Size(150, 23);
            this.btnVerifyHostnames.TabIndex = 1;
            this.btnVerifyHostnames.Text = "Verify Hostnames";
            this.btnVerifyHostnames.UseVisualStyleBackColor = true;
            this.btnVerifyHostnames.Click += new System.EventHandler(this.btnVerifyHostnames_Click);
            // 
            // listViewNotInDomain
            // 
            this.listViewNotInDomain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNotInDomain});
            this.listViewNotInDomain.HideSelection = false;
            this.listViewNotInDomain.Location = new System.Drawing.Point(12, 84);
            this.listViewNotInDomain.Name = "listViewNotInDomain";
            this.listViewNotInDomain.Size = new System.Drawing.Size(175, 185);
            this.listViewNotInDomain.TabIndex = 2;
            this.listViewNotInDomain.UseCompatibleStateImageBehavior = false;
            this.listViewNotInDomain.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderNotInDomain
            // 
            this.columnHeaderNotInDomain.Text = "Not In Domain";
            this.columnHeaderNotInDomain.Width = 240;
            // 
            // listViewInDomainWithIP
            // 
            this.listViewInDomainWithIP.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderInDomainWithIP});
            this.listViewInDomainWithIP.HideSelection = false;
            this.listViewInDomainWithIP.Location = new System.Drawing.Point(193, 84);
            this.listViewInDomainWithIP.Name = "listViewInDomainWithIP";
            this.listViewInDomainWithIP.Size = new System.Drawing.Size(175, 185);
            this.listViewInDomainWithIP.TabIndex = 3;
            this.listViewInDomainWithIP.UseCompatibleStateImageBehavior = false;
            this.listViewInDomainWithIP.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderInDomainWithIP
            // 
            this.columnHeaderInDomainWithIP.Text = "In Domain with IP";
            this.columnHeaderInDomainWithIP.Width = 240;
            // 
            // listViewInDomainWithoutIP
            // 
            this.listViewInDomainWithoutIP.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderInDomainWithoutIP});
            this.listViewInDomainWithoutIP.HideSelection = false;
            this.listViewInDomainWithoutIP.Location = new System.Drawing.Point(374, 84);
            this.listViewInDomainWithoutIP.Name = "listViewInDomainWithoutIP";
            this.listViewInDomainWithoutIP.Size = new System.Drawing.Size(175, 185);
            this.listViewInDomainWithoutIP.TabIndex = 4;
            this.listViewInDomainWithoutIP.UseCompatibleStateImageBehavior = false;
            this.listViewInDomainWithoutIP.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderInDomainWithoutIP
            // 
            this.columnHeaderInDomainWithoutIP.Text = "In Domain without IP";
            this.columnHeaderInDomainWithoutIP.Width = 240;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(15, 333);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(534, 23);
            this.progressBar.TabIndex = 5;
            // 
            // lblHostnames
            // 
            this.lblHostnames.AutoSize = true;
            this.lblHostnames.Location = new System.Drawing.Point(12, 13);
            this.lblHostnames.Name = "lblHostnames";
            this.lblHostnames.Size = new System.Drawing.Size(156, 13);
            this.lblHostnames.TabIndex = 6;
            this.lblHostnames.Text = "Hostnames (comma-separated):";
            // 
            // btnExportNotInDomain
            // 
            this.btnExportNotInDomain.Location = new System.Drawing.Point(12, 275);
            this.btnExportNotInDomain.Name = "btnExportNotInDomain";
            this.btnExportNotInDomain.Size = new System.Drawing.Size(175, 23);
            this.btnExportNotInDomain.TabIndex = 7;
            this.btnExportNotInDomain.Text = "Export Not In Domain";
            this.btnExportNotInDomain.UseVisualStyleBackColor = true;
            this.btnExportNotInDomain.Click += new System.EventHandler(this.btnExportNotInDomain_Click);
            // 
            // btnExportInDomainWithIP
            // 
            this.btnExportInDomainWithIP.Location = new System.Drawing.Point(193, 275);
            this.btnExportInDomainWithIP.Name = "btnExportInDomainWithIP";
            this.btnExportInDomainWithIP.Size = new System.Drawing.Size(175, 23);
            this.btnExportInDomainWithIP.TabIndex = 8;
            this.btnExportInDomainWithIP.Text = "Export In Domain with IP";
            this.btnExportInDomainWithIP.UseVisualStyleBackColor = true;
            this.btnExportInDomainWithIP.Click += new System.EventHandler(this.btnExportInDomainWithIP_Click);
            // 
            // btnExportInDomainWithoutIP
            // 
            this.btnExportInDomainWithoutIP.Location = new System.Drawing.Point(374, 275);
            this.btnExportInDomainWithoutIP.Name = "btnExportInDomainWithoutIP";
            this.btnExportInDomainWithoutIP.Size = new System.Drawing.Size(175, 23);
            this.btnExportInDomainWithoutIP.TabIndex = 9;
            this.btnExportInDomainWithoutIP.Text = "Export In Domain without IP";
            this.btnExportInDomainWithoutIP.UseVisualStyleBackColor = true;
            this.btnExportInDomainWithoutIP.Click += new System.EventHandler(this.btnExportInDomainWithoutIP_Click);
            // 
            // btnExportAll
            // 
            this.btnExportAll.Location = new System.Drawing.Point(12, 304);
            this.btnExportAll.Name = "btnExportAll";
            this.btnExportAll.Size = new System.Drawing.Size(537, 23);
            this.btnExportAll.TabIndex = 10;
            this.btnExportAll.Text = "Export All";
            this.btnExportAll.UseVisualStyleBackColor = true;
            this.btnExportAll.Click += new System.EventHandler(this.btnExportAll_Click);
            // 
            // HostnameVerificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExportAll);
            this.Controls.Add(this.btnExportInDomainWithoutIP);
            this.Controls.Add(this.btnExportInDomainWithIP);
            this.Controls.Add(this.btnExportNotInDomain);
            this.Controls.Add(this.lblHostnames);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.listViewInDomainWithoutIP);
            this.Controls.Add(this.listViewInDomainWithIP);
            this.Controls.Add(this.listViewNotInDomain);
            this.Controls.Add(this.btnVerifyHostnames);
            this.Controls.Add(this.txtHostnames);
            this.Name = "HostnameVerificationForm";
            this.Text = "Hostname Verification";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHostnames;
        private System.Windows.Forms.Button btnVerifyHostnames;
        private System.Windows.Forms.ListView listViewNotInDomain;
        private System.Windows.Forms.ColumnHeader columnHeaderNotInDomain;
        private System.Windows.Forms.ListView listViewInDomainWithIP;
        private System.Windows.Forms.ColumnHeader columnHeaderInDomainWithIP;
        private System.Windows.Forms.ListView listViewInDomainWithoutIP;
        private System.Windows.Forms.ColumnHeader columnHeaderInDomainWithoutIP;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblHostnames;
        private System.Windows.Forms.Button btnExportNotInDomain;
        private System.Windows.Forms.Button btnExportInDomainWithIP;
        private System.Windows.Forms.Button btnExportInDomainWithoutIP;
        private System.Windows.Forms.Button btnExportAll;
    }
}
