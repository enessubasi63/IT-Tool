using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SysInspector
{
    public partial class AzureCheckForm : Form
    {
        public AzureCheckForm()
        {
            InitializeComponent();
        }

        // btnCheckAzureJoin butonuna tıklama event handler'ı
        private void btnCheckAzureJoin_Click(object sender, EventArgs e)
        {
            string checkScript = @"(dsregcmd /status) -match 'AzureAdJoined\s*:\s*YES'";

            string result = ExecutePowerShellScript(checkScript);
            textBoxResults.Text = result;

            if (result.Trim().Equals("True"))
            {
                btnJoinAzure.Visible = false;
                textBoxResults.AppendText(Environment.NewLine + "Cihaz Azure AD'ye join edilmiş.");
            }
            else
            {
                btnJoinAzure.Visible = true;
                textBoxResults.AppendText(Environment.NewLine + "Cihaz Azure AD'ye join edilmemiş.");
            }
        }


        // PowerShell scriptini çalıştıran metod
        private string ExecutePowerShellScript(string script)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "powershell.exe";
                process.StartInfo.Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{script}\"";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                string result = process.StandardOutput.ReadToEnd();
                result += process.StandardError.ReadToEnd();
                process.WaitForExit();
                return result.Trim();
            }
            catch (Exception ex)
            {
                return "Komut çalıştırılırken bir hata oluştu: " + ex.Message;
            }
        }
    }
}
