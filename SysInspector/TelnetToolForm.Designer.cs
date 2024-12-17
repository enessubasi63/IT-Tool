namespace SysInspector
{
    partial class TelnetToolForm
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
            this.tabControlTelnetTool = new System.Windows.Forms.TabControl();
            this.tabPageTelnet = new System.Windows.Forms.TabPage();
            this.tabPageIPAssignment = new System.Windows.Forms.TabPage();
            this.txtIPs = new System.Windows.Forms.TextBox();
            this.lblIPs = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.btnTelnet = new System.Windows.Forms.Button();
            this.btnEnableTelnet = new System.Windows.Forms.Button();
            this.btnSaveLogTelnet = new System.Windows.Forms.Button(); // Yeni buton
            this.listViewLogTelnet = new System.Windows.Forms.ListView();
            this.columnHeaderIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderResult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtIPAssignments = new System.Windows.Forms.TextBox();
            this.lblIPAssignments = new System.Windows.Forms.Label();
            this.btnAssignIP = new System.Windows.Forms.Button();
            this.btnSaveLogIP = new System.Windows.Forms.Button(); // Yeni buton
            this.listViewLogIP = new System.Windows.Forms.ListView();
            this.columnHeaderAssignedIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAssignedResult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControlTelnetTool.SuspendLayout();
            this.tabPageTelnet.SuspendLayout();
            this.tabPageIPAssignment.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlTelnetTool
            // 
            this.tabControlTelnetTool.Controls.Add(this.tabPageTelnet);
            this.tabControlTelnetTool.Controls.Add(this.tabPageIPAssignment);
            this.tabControlTelnetTool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlTelnetTool.Location = new System.Drawing.Point(0, 0);
            this.tabControlTelnetTool.Name = "tabControlTelnetTool";
            this.tabControlTelnetTool.SelectedIndex = 0;
            this.tabControlTelnetTool.Size = new System.Drawing.Size(600, 400);
            this.tabControlTelnetTool.TabIndex = 0;
            // 
            // tabPageTelnet
            // 
            this.tabPageTelnet.Controls.Add(this.txtIPs);
            this.tabPageTelnet.Controls.Add(this.lblIPs);
            this.tabPageTelnet.Controls.Add(this.txtPort);
            this.tabPageTelnet.Controls.Add(this.lblPort);
            this.tabPageTelnet.Controls.Add(this.btnTelnet);
            this.tabPageTelnet.Controls.Add(this.btnEnableTelnet);
            this.tabPageTelnet.Controls.Add(this.btnSaveLogTelnet);
            this.tabPageTelnet.Controls.Add(this.listViewLogTelnet);
            this.tabPageTelnet.Location = new System.Drawing.Point(4, 22);
            this.tabPageTelnet.Name = "tabPageTelnet";
            this.tabPageTelnet.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTelnet.Size = new System.Drawing.Size(592, 374);
            this.tabPageTelnet.TabIndex = 0;
            this.tabPageTelnet.Text = "Telnet";
            this.tabPageTelnet.UseVisualStyleBackColor = true;
            // 
            // tabPageIPAssignment
            // 
            this.tabPageIPAssignment.Controls.Add(this.txtIPAssignments);
            this.tabPageIPAssignment.Controls.Add(this.lblIPAssignments);
            this.tabPageIPAssignment.Controls.Add(this.btnAssignIP);
            this.tabPageIPAssignment.Controls.Add(this.btnSaveLogIP);
            this.tabPageIPAssignment.Controls.Add(this.listViewLogIP);
            this.tabPageIPAssignment.Location = new System.Drawing.Point(4, 22);
            this.tabPageIPAssignment.Name = "tabPageIPAssignment";
            this.tabPageIPAssignment.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIPAssignment.Size = new System.Drawing.Size(592, 374);
            this.tabPageIPAssignment.TabIndex = 1;
            this.tabPageIPAssignment.Text = "IP Assignment";
            this.tabPageIPAssignment.UseVisualStyleBackColor = true;
            // 
            // txtIPs
            // 
            this.txtIPs.Location = new System.Drawing.Point(10, 30);
            this.txtIPs.Name = "txtIPs";
            this.txtIPs.Size = new System.Drawing.Size(570, 20);
            this.txtIPs.TabIndex = 0;
            // 
            // lblIPs
            // 
            this.lblIPs.AutoSize = true;
            this.lblIPs.Location = new System.Drawing.Point(10, 10);
            this.lblIPs.Name = "lblIPs";
            this.lblIPs.Size = new System.Drawing.Size(149, 13);
            this.lblIPs.TabIndex = 1;
            this.lblIPs.Text = "Enter IPs (comma separated):";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(10, 70);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 20);
            this.txtPort.TabIndex = 2;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(10, 50);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(29, 13);
            this.lblPort.TabIndex = 3;
            this.lblPort.Text = "Port:";
            // 
            // btnTelnet
            // 
            this.btnTelnet.Location = new System.Drawing.Point(10, 100);
            this.btnTelnet.Name = "btnTelnet";
            this.btnTelnet.Size = new System.Drawing.Size(100, 30);
            this.btnTelnet.TabIndex = 4;
            this.btnTelnet.Text = "Telnet";
            this.btnTelnet.UseVisualStyleBackColor = true;
            this.btnTelnet.Click += new System.EventHandler(this.btnTelnet_Click);
            // 
            // btnEnableTelnet
            // 
            this.btnEnableTelnet.Location = new System.Drawing.Point(120, 100);
            this.btnEnableTelnet.Name = "btnEnableTelnet";
            this.btnEnableTelnet.Size = new System.Drawing.Size(100, 30);
            this.btnEnableTelnet.TabIndex = 5;
            this.btnEnableTelnet.Text = "Enable Telnet";
            this.btnEnableTelnet.UseVisualStyleBackColor = true;
            this.btnEnableTelnet.Click += new System.EventHandler(this.btnEnableTelnet_Click);
            // 
            // btnSaveLogTelnet
            // 
            this.btnSaveLogTelnet.Location = new System.Drawing.Point(230, 100);
            this.btnSaveLogTelnet.Name = "btnSaveLogTelnet";
            this.btnSaveLogTelnet.Size = new System.Drawing.Size(100, 30);
            this.btnSaveLogTelnet.TabIndex = 6;
            this.btnSaveLogTelnet.Text = "Save Log";
            this.btnSaveLogTelnet.UseVisualStyleBackColor = true;
            this.btnSaveLogTelnet.Click += new System.EventHandler(this.btnSaveLogTelnet_Click);
            // 
            // listViewLogTelnet
            // 
            this.listViewLogTelnet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderIP,
            this.columnHeaderPort,
            this.columnHeaderResult});
            this.listViewLogTelnet.FullRowSelect = true;
            this.listViewLogTelnet.GridLines = true;
            this.listViewLogTelnet.Location = new System.Drawing.Point(10, 140);
            this.listViewLogTelnet.Name = "listViewLogTelnet";
            this.listViewLogTelnet.Size = new System.Drawing.Size(570, 220);
            this.listViewLogTelnet.TabIndex = 7;
            this.listViewLogTelnet.UseCompatibleStateImageBehavior = false;
            this.listViewLogTelnet.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderIP
            // 
            this.columnHeaderIP.Text = "IP Address";
            this.columnHeaderIP.Width = 120;
            // 
            // columnHeaderPort
            // 
            this.columnHeaderPort.Text = "Port";
            this.columnHeaderPort.Width = 50;
            // 
            // columnHeaderResult
            // 
            this.columnHeaderResult.Text = "Result";
            this.columnHeaderResult.Width = 400;
            // 
            // txtIPAssignments
            // 
            this.txtIPAssignments.Location = new System.Drawing.Point(10, 30);
            this.txtIPAssignments.Name = "txtIPAssignments";
            this.txtIPAssignments.Size = new System.Drawing.Size(570, 20);
            this.txtIPAssignments.TabIndex = 0;
            // 
            // lblIPAssignments
            // 
            this.lblIPAssignments.AutoSize = true;
            this.lblIPAssignments.Location = new System.Drawing.Point(10, 10);
            this.lblIPAssignments.Name = "lblIPAssignments";
            this.lblIPAssignments.Size = new System.Drawing.Size(149, 13);
            this.lblIPAssignments.TabIndex = 1;
            this.lblIPAssignments.Text = "Enter IPs (comma separated):";
            // 
            // btnAssignIP
            // 
            this.btnAssignIP.Location = new System.Drawing.Point(10, 60);
            this.btnAssignIP.Name = "btnAssignIP";
            this.btnAssignIP.Size = new System.Drawing.Size(100, 30);
            this.btnAssignIP.TabIndex = 2;
            this.btnAssignIP.Text = "Ping IPs";
            this.btnAssignIP.UseVisualStyleBackColor = true;
            this.btnAssignIP.Click += new System.EventHandler(this.btnAssignIP_Click);
            // 
            // btnSaveLogIP
            // 
            this.btnSaveLogIP.Location = new System.Drawing.Point(120, 60);
            this.btnSaveLogIP.Name = "btnSaveLogIP";
            this.btnSaveLogIP.Size = new System.Drawing.Size(100, 30);
            this.btnSaveLogIP.TabIndex = 3;
            this.btnSaveLogIP.Text = "Save Log";
            this.btnSaveLogIP.UseVisualStyleBackColor = true;
            this.btnSaveLogIP.Click += new System.EventHandler(this.btnSaveLogIP_Click);
            // 
            // listViewLogIP
            // 
            this.listViewLogIP.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderAssignedIP,
            this.columnHeaderAssignedResult});
            this.listViewLogIP.FullRowSelect = true;
            this.listViewLogIP.GridLines = true;
            this.listViewLogIP.Location = new System.Drawing.Point(10, 100);
            this.listViewLogIP.Name = "listViewLogIP";
            this.listViewLogIP.Size = new System.Drawing.Size(570, 260);
            this.listViewLogIP.TabIndex = 4;
            this.listViewLogIP.UseCompatibleStateImageBehavior = false;
            this.listViewLogIP.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderAssignedIP
            // 
            this.columnHeaderAssignedIP.Text = "IP Address";
            this.columnHeaderAssignedIP.Width = 200;
            // 
            // columnHeaderAssignedResult
            // 
            this.columnHeaderAssignedResult.Text = "Result";
            this.columnHeaderAssignedResult.Width = 370;
            // 
            // TelnetToolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.tabControlTelnetTool);
            this.Name = "TelnetToolForm";
            this.Text = "Telnet Tool";
            this.tabControlTelnetTool.ResumeLayout(false);
            this.tabPageTelnet.ResumeLayout(false);
            this.tabPageTelnet.PerformLayout();
            this.tabPageIPAssignment.ResumeLayout(false);
            this.tabPageIPAssignment.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControlTelnetTool;
        private System.Windows.Forms.TabPage tabPageTelnet;
        private System.Windows.Forms.TabPage tabPageIPAssignment;
        private System.Windows.Forms.TextBox txtIPs;
        private System.Windows.Forms.Label lblIPs;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Button btnTelnet;
        private System.Windows.Forms.Button btnEnableTelnet;
        private System.Windows.Forms.Button btnSaveLogTelnet;
        private System.Windows.Forms.ListView listViewLogTelnet;
        private System.Windows.Forms.ColumnHeader columnHeaderIP;
        private System.Windows.Forms.ColumnHeader columnHeaderPort;
        private System.Windows.Forms.ColumnHeader columnHeaderResult;
        private System.Windows.Forms.TextBox txtIPAssignments;
        private System.Windows.Forms.Label lblIPAssignments;
        private System.Windows.Forms.Button btnAssignIP;
        private System.Windows.Forms.Button btnSaveLogIP;
        private System.Windows.Forms.ListView listViewLogIP;
        private System.Windows.Forms.ColumnHeader columnHeaderAssignedIP;
        private System.Windows.Forms.ColumnHeader columnHeaderAssignedResult;
    }
}
