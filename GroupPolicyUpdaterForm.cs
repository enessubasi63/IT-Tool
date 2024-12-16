using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysInspector
{
    public partial class GroupPolicyUpdaterForm : Form
    {
        public GroupPolicyUpdaterForm()
        {
            InitializeComponent();
        }

        // btnGpupdate butonuna tıklama event handler'ı
        private void btnGpupdate_Click(object sender, EventArgs e)
        {
            // "gpupdate" komutunu yeni bir pencerede çalıştırır
            ExecuteCommandInNewWindow("gpupdate");
        }

        // btnGpupdateForce butonuna tıklama event handler'ı
        private void btnGpupdateForce_Click(object sender, EventArgs e)
        {
            // "gpupdate /force" komutunu yeni bir pencerede çalıştırır
            ExecuteCommandInNewWindow("gpupdate /force");
        }

        // Belirtilen komutu yeni bir pencerede çalıştıran metod
        private void ExecuteCommandInNewWindow(string command)
        {
            CommandOutputForm outputForm = new CommandOutputForm(command); // Komutla yeni bir CommandOutputForm oluşturur
            outputForm.Show(); // Formu gösterir
        }
    }
}
