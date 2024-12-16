namespace SysInspector
{
    partial class AzureCheckForm
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
            this.btnCheckAzureJoin = new System.Windows.Forms.Button();
            this.textBoxResults = new System.Windows.Forms.TextBox();
            this.btnJoinAzure = new System.Windows.Forms.Button();
            this.panelNote = new System.Windows.Forms.Panel();
            this.labelNote = new System.Windows.Forms.Label();
            this.panelNote.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCheckAzureJoin
            // 
            this.btnCheckAzureJoin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckAzureJoin.Location = new System.Drawing.Point(12, 12);
            this.btnCheckAzureJoin.Name = "btnCheckAzureJoin";
            this.btnCheckAzureJoin.Size = new System.Drawing.Size(150, 30);
            this.btnCheckAzureJoin.TabIndex = 0;
            this.btnCheckAzureJoin.Text = "Check Azure Join";
            this.btnCheckAzureJoin.UseVisualStyleBackColor = true;
            this.btnCheckAzureJoin.Click += new System.EventHandler(this.btnCheckAzureJoin_Click);
            // 
            // textBoxResults
            // 
            this.textBoxResults.Location = new System.Drawing.Point(12, 48);
            this.textBoxResults.Multiline = true;
            this.textBoxResults.Name = "textBoxResults";
            this.textBoxResults.ReadOnly = true;
            this.textBoxResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxResults.Size = new System.Drawing.Size(400, 300);
            this.textBoxResults.TabIndex = 1;
            // 
            // btnJoinAzure
            // 
            this.btnJoinAzure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJoinAzure.Location = new System.Drawing.Point(12, 354);
            this.btnJoinAzure.Name = "btnJoinAzure";
            this.btnJoinAzure.Size = new System.Drawing.Size(150, 30);
            this.btnJoinAzure.TabIndex = 2;
            this.btnJoinAzure.Text = "Join Azure";
            this.btnJoinAzure.UseVisualStyleBackColor = true;
            this.btnJoinAzure.Visible = false;

            // 
            // panelNote
            // 
            this.panelNote.BackColor = System.Drawing.Color.LightCoral;
            this.panelNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNote.Controls.Add(this.labelNote);
            this.panelNote.Location = new System.Drawing.Point(418, 48);
            this.panelNote.Name = "panelNote";
            this.panelNote.Size = new System.Drawing.Size(149, 150);
            this.panelNote.TabIndex = 3;
            // 
            // labelNote
            // 
            this.labelNote.AutoSize = true;
            this.labelNote.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelNote.Location = new System.Drawing.Point(10, 10);
            this.labelNote.Name = "labelNote";
            this.labelNote.Size = new System.Drawing.Size(127, 133);
            this.labelNote.TabIndex = 0;
            this.labelNote.Text = "Dikkat!: \r\nCihazın OU\'sunu \r\nkontrol edin.\r\n\r\nOffice 365 lisansını \r\nkontrol edin" +
    ".\r\n\r\n";

            // 
            // AzureCheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 400);
            this.Controls.Add(this.panelNote);
            this.Controls.Add(this.btnJoinAzure);
            this.Controls.Add(this.textBoxResults);
            this.Controls.Add(this.btnCheckAzureJoin);
            this.Name = "AzureCheckForm";
            this.Text = "Azure Join Check";
            this.panelNote.ResumeLayout(false);
            this.panelNote.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCheckAzureJoin;
        private System.Windows.Forms.TextBox textBoxResults;
        private System.Windows.Forms.Button btnJoinAzure;
        private System.Windows.Forms.Panel panelNote;
        private System.Windows.Forms.Label labelNote;
    }
}
