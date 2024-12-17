using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Windows.Forms;

namespace SysInspector
{
    public partial class ADQueryForm : Form
    {
        public ADQueryForm()
        {
            InitializeComponent();
            this.AcceptButton = btnSearch; // Enter tuşuna basıldığında btnSearch butonuna tıklamış gibi yapar
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PerformSearch(); // Arama işlemini gerçekleştirir
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Enter tuşuna basıldıysa
            {
                PerformSearch(); // Arama işlemini gerçekleştirir
                e.Handled = true; // Olayın başka işlemler tarafından işlenmesini engeller
                e.SuppressKeyPress = true; // Enter tuşunun basılma sesini engeller
            }
        }

        private void PerformSearch()
        {
            string username = txtUsername.Text.Trim(); // Kullanıcı adını alır ve baştaki/sondaki boşlukları temizler
            if (string.IsNullOrWhiteSpace(username)) // Kullanıcı adı boşsa
            {
                MessageBox.Show("Please enter a username.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Uyarı mesajı gösterir
                return; // Metottan çık
            }

            dgvResults.Rows.Clear(); // Önceki sonuçları temizler
            var results = SearchUserDescriptions(username); // Kullanıcı açıklamalarını arar

            if (results.Count > 0) // Sonuçlar varsa
            {
                foreach (var result in results) // Her sonuç için
                {
                    // Sonuçları DataGridView'e ekler
                    dgvResults.Rows.Add(result.Name, result.UserLogonName, result.State, result.Description);
                }
            }
            else
            {
                // Kullanıcı bulunamadıysa veya açıklama yoksa bilgi mesajı gösterir
                MessageBox.Show("User not found or no description available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private List<UserInfo> SearchUserDescriptions(string username)
        {
            var userInfos = new List<UserInfo>();
            try
            {
                // Active Directory yolu, kendi AD yolunuza göre güncelleyin
                string adPath = "LDAP://DC=cmcturkey,DC=com";
                using (DirectoryEntry entry = new DirectoryEntry(adPath))
                {
                    using (DirectorySearcher searcher = new DirectorySearcher(entry))
                    {
                        // Arama filtresi, kullanıcı adı içeren nesneleri arar
                        searcher.Filter = $"(&(objectClass=user)(|(cn=*{username}*)(sAMAccountName=*{username}*)))";
                        // Yüklenecek özellikleri belirler
                        searcher.PropertiesToLoad.Add("cn");
                        searcher.PropertiesToLoad.Add("userPrincipalName");
                        searcher.PropertiesToLoad.Add("description");
                        searcher.PropertiesToLoad.Add("st"); 

                        // Arama sonuçlarını işler
                        foreach (SearchResult result in searcher.FindAll())
                        {
                            // Sonuçlardan kullanıcı bilgilerini alır
                            var userInfo = new UserInfo
                            {
                                Name = result.Properties["cn"].Count > 0 ? result.Properties["cn"][0].ToString() : "",
                                UserLogonName = result.Properties["userPrincipalName"].Count > 0 ? result.Properties["userPrincipalName"][0].ToString() : "",
                                State = result.Properties["st"].Count > 0 ? result.Properties["st"][0].ToString() : "",
                                Description = result.Properties["description"].Count > 0 ? result.Properties["description"][0].ToString() : ""
                            };
                            userInfos.Add(userInfo); // Kullanıcı bilgilerini listeye ekler
                        }
                    }
                }
            }
            catch (Exception ex) // Hata yakalama bloğu
            {
                // Hata mesajı gösterir
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return userInfos; // Kullanıcı bilgilerini döner
        }

        private void dgvResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvResults.Columns["Copy"].Index && e.RowIndex >= 0) // Eğer "Copy" sütununa tıklanmışsa
            {
                // Seçili satırdaki kullanıcı adını ve açıklamayı alır
                string userLogonName = dgvResults.Rows[e.RowIndex].Cells["UserLogonNameColumn"].Value.ToString();
                string description = dgvResults.Rows[e.RowIndex].Cells["DescriptionColumn"].Value.ToString();

                // @cmcturkey.com kısmını çıkarır
                string userLogonNameWithoutDomain = userLogonName.Split('@')[0];

                // Kullanıcı adını ve açıklamayı panoya kopyalar
                Clipboard.SetText($"{userLogonNameWithoutDomain} \t {description}");
            }
        }

        // Kullanıcı bilgilerini tutan sınıf
        private class UserInfo
        {
            public string Name { get; set; }
            public string UserLogonName { get; set; }
            public string State { get; set; }
            public string Description { get; set; }
        }
    }
}
