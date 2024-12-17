namespace SysInspector
{
    partial class BatchExecutorForm
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
            this.btnMplusLocalOffice = new System.Windows.Forms.Button();
            this.btnMplusMalatya = new System.Windows.Forms.Button();
            this.btnMplusRize = new System.Windows.Forms.Button();
            this.btnMplusUrfa = new System.Windows.Forms.Button();
            this.btnMplusVan = new System.Windows.Forms.Button();
            this.btnSelfService = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMplusLocalOffice
            // 
            this.btnMplusLocalOffice.Location = new System.Drawing.Point(12, 12);
            this.btnMplusLocalOffice.Name = "btnMplusLocalOffice";
            this.btnMplusLocalOffice.Size = new System.Drawing.Size(200, 40);
            this.btnMplusLocalOffice.TabIndex = 0;
            this.btnMplusLocalOffice.Text = "MplusLocalOffice";
            this.btnMplusLocalOffice.UseVisualStyleBackColor = true;
            this.btnMplusLocalOffice.Click += new System.EventHandler(this.btnMplusLocalOffice_Click);
            // 
            // btnMplusMalatya
            // 
            this.btnMplusMalatya.Location = new System.Drawing.Point(12, 58);
            this.btnMplusMalatya.Name = "btnMplusMalatya";
            this.btnMplusMalatya.Size = new System.Drawing.Size(200, 40);
            this.btnMplusMalatya.TabIndex = 1;
            this.btnMplusMalatya.Text = "MplusMalatya";
            this.btnMplusMalatya.UseVisualStyleBackColor = true;
            this.btnMplusMalatya.Click += new System.EventHandler(this.btnMplusMalatya_Click);
            // 
            // btnMplusRize
            // 
            this.btnMplusRize.Location = new System.Drawing.Point(12, 104);
            this.btnMplusRize.Name = "btnMplusRize";
            this.btnMplusRize.Size = new System.Drawing.Size(200, 40);
            this.btnMplusRize.TabIndex = 2;
            this.btnMplusRize.Text = "MplusRize";
            this.btnMplusRize.UseVisualStyleBackColor = true;
            this.btnMplusRize.Click += new System.EventHandler(this.btnMplusRize_Click);
            // 
            // btnMplusUrfa
            // 
            this.btnMplusUrfa.Location = new System.Drawing.Point(12, 150);
            this.btnMplusUrfa.Name = "btnMplusUrfa";
            this.btnMplusUrfa.Size = new System.Drawing.Size(200, 40);
            this.btnMplusUrfa.TabIndex = 3;
            this.btnMplusUrfa.Text = "MplusUrfa";
            this.btnMplusUrfa.UseVisualStyleBackColor = true;
            this.btnMplusUrfa.Click += new System.EventHandler(this.btnMplusUrfa_Click);
            // 
            // btnMplusVan
            // 
            this.btnMplusVan.Location = new System.Drawing.Point(12, 196);
            this.btnMplusVan.Name = "btnMplusVan";
            this.btnMplusVan.Size = new System.Drawing.Size(200, 40);
            this.btnMplusVan.TabIndex = 4;
            this.btnMplusVan.Text = "MplusVan";
            this.btnMplusVan.UseVisualStyleBackColor = true;
            this.btnMplusVan.Click += new System.EventHandler(this.btnMplusVan_Click);
            // 
            // btnSelfService
            // 
            this.btnSelfService.Location = new System.Drawing.Point(12, 196);
            this.btnSelfService.Name = "btnMplusVan";
            this.btnSelfService.Size = new System.Drawing.Size(200, 40);
            this.btnSelfService.TabIndex = 4;
            this.btnSelfService.Text = "MplusVan";
            this.btnSelfService.UseVisualStyleBackColor = true;
            this.btnSelfService.Click += new System.EventHandler(this.btnMplusVan_Click);
            // 
            // BatchExecutorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMplusVan);
            this.Controls.Add(this.btnMplusUrfa);
            this.Controls.Add(this.btnMplusRize);
            this.Controls.Add(this.btnMplusMalatya);
            this.Controls.Add(this.btnMplusLocalOffice);
            this.Controls.Add(this.btnSelfService);
            this.Name = "BatchExecutorForm";
            this.Text = "Batch Executor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMplusLocalOffice;
        private System.Windows.Forms.Button btnMplusMalatya;
        private System.Windows.Forms.Button btnMplusRize;
        private System.Windows.Forms.Button btnMplusUrfa;
        private System.Windows.Forms.Button btnMplusVan;
        private System.Windows.Forms.Button btnSelfService;
    }
}
