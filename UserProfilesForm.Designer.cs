namespace SysInspector
{
    partial class UserProfilesForm
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

        private void InitializeComponent()
        {
            this.dgvUserProfiles = new System.Windows.Forms.DataGridView();
            this.UsernameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserProfiles)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUserProfiles
            // 
            this.dgvUserProfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserProfiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UsernameColumn,
            this.DeleteColumn});
            this.dgvUserProfiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUserProfiles.Location = new System.Drawing.Point(0, 0);
            this.dgvUserProfiles.Name = "dgvUserProfiles";
            this.dgvUserProfiles.Size = new System.Drawing.Size(748, 450);
            this.dgvUserProfiles.TabIndex = 0;
            this.dgvUserProfiles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUserProfiles_CellContentClick);
            // 
            // UsernameColumn
            // 
            this.UsernameColumn.HeaderText = "Username";
            this.UsernameColumn.Name = "UsernameColumn";
            this.UsernameColumn.ReadOnly = true;
            this.UsernameColumn.Width = 400;
            // 
            // DeleteColumn
            // 
            this.DeleteColumn.HeaderText = "Delete";
            this.DeleteColumn.Name = "DeleteColumn";
            this.DeleteColumn.Text = "Delete";
            this.DeleteColumn.UseColumnTextForButtonValue = true;
            // 
            // UserProfilesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 450);
            this.Controls.Add(this.dgvUserProfiles);
            this.Name = "UserProfilesForm";
            this.Text = "User Profiles";
            this.Load += new System.EventHandler(this.UserProfilesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserProfiles)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.DataGridView dgvUserProfiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsernameColumn;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteColumn;
    }
}
