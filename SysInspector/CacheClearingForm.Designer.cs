namespace SysInspector
{
    partial class CacheClearingForm
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
            this.btnClearCache = new System.Windows.Forms.Button();
            this.textBoxCacheResults = new System.Windows.Forms.TextBox();
            this.checkBoxRamCleaning = new System.Windows.Forms.CheckBox();
            this.checkBoxBrowserCleaning = new System.Windows.Forms.CheckBox();
            this.checkBoxOfficeCleaning = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnClearCache
            // 
            this.btnClearCache.Location = new System.Drawing.Point(12, 100);
            this.btnClearCache.Name = "btnClearCache";
            this.btnClearCache.Size = new System.Drawing.Size(100, 23);
            this.btnClearCache.TabIndex = 0;
            this.btnClearCache.Text = "Clear Cache";
            this.btnClearCache.UseVisualStyleBackColor = true;
            this.btnClearCache.Click += new System.EventHandler(this.btnClearCache_Click);
            // 
            // textBoxCacheResults
            // 
            this.textBoxCacheResults.Location = new System.Drawing.Point(12, 129);
            this.textBoxCacheResults.Multiline = true;
            this.textBoxCacheResults.Name = "textBoxCacheResults";
            this.textBoxCacheResults.ReadOnly = true;
            this.textBoxCacheResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCacheResults.Size = new System.Drawing.Size(260, 120);
            this.textBoxCacheResults.TabIndex = 1;
            // 
            // checkBoxRamCleaning
            // 
            this.checkBoxRamCleaning.AutoSize = true;
            this.checkBoxRamCleaning.Location = new System.Drawing.Point(12, 12);
            this.checkBoxRamCleaning.Name = "checkBoxRamCleaning";
            this.checkBoxRamCleaning.Size = new System.Drawing.Size(94, 17);
            this.checkBoxRamCleaning.TabIndex = 2;
            this.checkBoxRamCleaning.Text = "RAM Cleaning";
            this.checkBoxRamCleaning.UseVisualStyleBackColor = true;
            // 
            // checkBoxBrowserCleaning
            // 
            this.checkBoxBrowserCleaning.AutoSize = true;
            this.checkBoxBrowserCleaning.Location = new System.Drawing.Point(12, 35);
            this.checkBoxBrowserCleaning.Name = "checkBoxBrowserCleaning";
            this.checkBoxBrowserCleaning.Size = new System.Drawing.Size(106, 17);
            this.checkBoxBrowserCleaning.TabIndex = 3;
            this.checkBoxBrowserCleaning.Text = "Browser Cleaning";
            this.checkBoxBrowserCleaning.UseVisualStyleBackColor = true;
            // 
            // checkBoxOfficeCleaning
            // 
            this.checkBoxOfficeCleaning.AutoSize = true;
            this.checkBoxOfficeCleaning.Location = new System.Drawing.Point(12, 58);
            this.checkBoxOfficeCleaning.Name = "checkBoxOfficeCleaning";
            this.checkBoxOfficeCleaning.Size = new System.Drawing.Size(102, 17);
            this.checkBoxOfficeCleaning.TabIndex = 4;
            this.checkBoxOfficeCleaning.Text = "Office Cleaning";
            this.checkBoxOfficeCleaning.UseVisualStyleBackColor = true;
            // 
            // CacheClearingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.checkBoxOfficeCleaning);
            this.Controls.Add(this.checkBoxBrowserCleaning);
            this.Controls.Add(this.checkBoxRamCleaning);
            this.Controls.Add(this.textBoxCacheResults);
            this.Controls.Add(this.btnClearCache);
            this.Name = "CacheClearingForm";
            this.Text = "Cache Clearing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClearCache;
        private System.Windows.Forms.TextBox textBoxCacheResults;
        private System.Windows.Forms.CheckBox checkBoxRamCleaning;
        private System.Windows.Forms.CheckBox checkBoxBrowserCleaning;
        private System.Windows.Forms.CheckBox checkBoxOfficeCleaning;
    }
}
