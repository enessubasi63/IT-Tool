using System;
using System.Windows.Forms;
using System.Management;
using System.Management.Automation;

namespace SysInspector
{
    public partial class UserProfilesForm : Form
    {
        public UserProfilesForm()
        {
            InitializeComponent();
        }

        // Form yüklendiğinde çalışan event handler
        private void UserProfilesForm_Load(object sender, EventArgs e)
        {
            LoadUserProfiles(); // Kullanıcı profillerini yükler
        }

        // Kullanıcı profillerini yükleyen metod
        private void LoadUserProfiles()
        {
            dgvUserProfiles.Rows.Clear(); // DataGridView satırlarını temizler

            // Kullanıcı profillerini sorgulayan WMI sorgusu
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_UserProfile WHERE Special != True AND LocalPath IS NOT NULL");
            foreach (ManagementObject profile in searcher.Get())
            {
                // Kullanıcı adı 'LocalPath' içinde yer alan dizin adından elde edilir
                string username = profile["LocalPath"].ToString().Split('\\')[2];
                dgvUserProfiles.Rows.Add(username); // Kullanıcı adını DataGridView'e ekler
            }
        }

        // DataGridView'de bir hücreye tıklandığında çalışan event handler
        private void dgvUserProfiles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Eğer tıklanan hücre 'DeleteColumn' ise
            if (e.ColumnIndex == dgvUserProfiles.Columns["DeleteColumn"].Index && e.RowIndex >= 0)
            {
                // Kullanıcı adını elde eder
                string username = dgvUserProfiles.Rows[e.RowIndex].Cells["UsernameColumn"].Value.ToString();

                // Kullanıcıya silme işlemini onaylatan bir mesaj kutusu gösterir
                var result = MessageBox.Show($"Are you sure you want to delete the profile for {username}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteUserProfile(username); // Kullanıcı profilini siler
                    LoadUserProfiles(); // Silme işleminden sonra listeyi yeniler
                }
            }
        }

        // Kullanıcı profilini silen metod
        private void DeleteUserProfile(string username)
        {
            try
            {
                // Kullanıcı profilini ve ilgili işlemleri sonlandıran PowerShell betiği
                string script = $@"
$User = '{username}'
# Kullanıcıya ait çalışan işlemleri durdurur
$Processes = Get-WmiObject Win32_Process -Filter ""Name='explorer.exe'""
foreach ($Process in $Processes) {{
    $Owner = $Process.GetOwner()
    if ($Owner.User -eq $User) {{
        $Process.Terminate()
    }}
}}
# Kullanıcı profilini kaldırır
$profiles = Get-WmiObject -Query ""SELECT * FROM Win32_UserProfile WHERE LocalPath LIKE '%\\$User\\%'"" -ErrorAction Stop
foreach ($profile in $profiles) {{
    $profile.Delete()
}}
# Kullanıcıyı sistemden kaldırır
$user = Get-WmiObject -Class Win32_UserAccount -Filter ""Name='$User'""
if ($user) {{
    $user.Delete()
}}
";

                ExecutePowerShellScript(script); // PowerShell betiğini çalıştırır

                // Başarılı işlem mesajı gösterir
                MessageBox.Show($"Profile for {username} deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) // Hata yakalama bloğu
            {
                // Hata mesajı gösterir
                MessageBox.Show($"Error deleting profile for {username}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // PowerShell betiğini çalıştıran metod
        private void ExecutePowerShellScript(string script)
        {
            using (PowerShell powerShell = PowerShell.Create())
            {
                powerShell.AddScript(script); // Betiği ekler
                powerShell.Invoke(); // Betiği çalıştırır

                // Eğer betikte hata varsa, bir exception fırlatır
                if (powerShell.Streams.Error.Count > 0)
                {
                    throw new Exception(string.Join(Environment.NewLine, powerShell.Streams.Error));
                }
            }
        }
    }
}
