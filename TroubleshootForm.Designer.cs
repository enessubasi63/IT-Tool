namespace SysInspector
{
    partial class TroubleshootForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.RadioButton financeRadioButton;
        private System.Windows.Forms.RadioButton nonFinanceRadioButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button logButton;
        private System.Windows.Forms.DataGridView resultsDataGridView;

        private void InitializeComponent()
        {
            this.financeRadioButton = new System.Windows.Forms.RadioButton();
            this.nonFinanceRadioButton = new System.Windows.Forms.RadioButton();
            this.startButton = new System.Windows.Forms.Button();
            this.logButton = new System.Windows.Forms.Button();
            this.resultsDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // financeRadioButton
            // 
            this.financeRadioButton.AutoSize = true;
            this.financeRadioButton.Location = new System.Drawing.Point(238, 27);
            this.financeRadioButton.Name = "financeRadioButton";
            this.financeRadioButton.Size = new System.Drawing.Size(63, 17);
            this.financeRadioButton.TabIndex = 0;
            this.financeRadioButton.TabStop = true;
            this.financeRadioButton.Text = "Finance";
            this.financeRadioButton.UseVisualStyleBackColor = true;
            // 
            // nonFinanceRadioButton
            // 
            this.nonFinanceRadioButton.AutoSize = true;
            this.nonFinanceRadioButton.Location = new System.Drawing.Point(238, 55);
            this.nonFinanceRadioButton.Name = "nonFinanceRadioButton";
            this.nonFinanceRadioButton.Size = new System.Drawing.Size(86, 17);
            this.nonFinanceRadioButton.TabIndex = 1;
            this.nonFinanceRadioButton.TabStop = true;
            this.nonFinanceRadioButton.Text = "Non-Finance";
            this.nonFinanceRadioButton.UseVisualStyleBackColor = true;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(35, 27);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(180, 45);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Start Troubleshoot";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // logButton
            // 
            this.logButton.Location = new System.Drawing.Point(455, 27);
            this.logButton.Name = "logButton";
            this.logButton.Size = new System.Drawing.Size(180, 45);
            this.logButton.TabIndex = 4;
            this.logButton.Text = "Log to File";
            this.logButton.UseVisualStyleBackColor = true;
            this.logButton.Click += new System.EventHandler(this.logButton_Click);
            // 
            // resultsDataGridView
            // 
            this.resultsDataGridView.AllowUserToAddRows = false;
            this.resultsDataGridView.AllowUserToDeleteRows = false;
            this.resultsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultsDataGridView.Location = new System.Drawing.Point(35, 106);
            this.resultsDataGridView.Name = "resultsDataGridView";
            this.resultsDataGridView.ReadOnly = true;
            this.resultsDataGridView.Size = new System.Drawing.Size(600, 254);
            this.resultsDataGridView.TabIndex = 3;
            // 
            // TroubleshootForm
            // 
            this.ClientSize = new System.Drawing.Size(684, 411);
            this.Controls.Add(this.resultsDataGridView);
            this.Controls.Add(this.logButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.nonFinanceRadioButton);
            this.Controls.Add(this.financeRadioButton);
            this.Name = "TroubleshootForm";
            this.Text = "TroubleshootForm";
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
