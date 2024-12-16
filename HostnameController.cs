using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysInspector
{
    public partial class HostnameControllerForm : Form

    {
        public HostnameControllerForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Check Hostname button click event.
        /// Initiates the hostname checking process.
        /// </summary>
        private async void btnCheckHostname_Click(object sender, EventArgs e)
        {
            string projectPrefix = txtProjectPrefix.Text.Trim(); // Proje prefix'ini alır ve boşlukları temizler

            // Kullanıcı girişini doğrular
            if (string.IsNullOrWhiteSpace(projectPrefix) || !int.TryParse(txtHostnameCount.Text, out int count) || count <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir proje prefix'i ve hostname sayısı girin."); // Hatalı giriş için uyarı mesajı
                return;
            }

            // Önceki sonuçları temizler ve başlangıç mesajlarını gösterir
            listViewResults.Items.Clear();
            listViewResults.Items.Add(new ListViewItem($"Proje prefix'i: {projectPrefix}"));
            listViewResults.Items.Add(new ListViewItem("Hostname kontrolü başlıyor..."));

            progressBar.Minimum = 0;
            progressBar.Maximum = count;
            progressBar.Value = 0;

            // Hostname'leri asenkron olarak kontrol eder
            var availableHostnames = await Task.Run(() => CheckHostnames(projectPrefix, count));

            // Mevcut hostname'leri gösterir
            foreach (var hostname in availableHostnames)
            {
                listViewResults.Items.Add(new ListViewItem($"{hostname}"));
            }

            MessageBox.Show("Hostname kontrolü tamamlandı."); // Kontrol tamamlandığında mesaj gösterir
        }

        /// <summary>
        /// Handles the Save Log button click event.
        /// Saves the current log to a text file.
        /// </summary>
        private void btnSaveLog_Click(object sender, EventArgs e)
        {
            string fileName = $"HostnameCheckLog_{DateTime.Now:yyyyMMdd_HHmmss}.txt"; // Kaydedilecek dosya adı

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.FileName = fileName;
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                // Dosya kaydetme dialogunu gösterir ve kullanıcı onaylarsa log'u kaydeder
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        foreach (ListViewItem item in listViewResults.Items)
                        {
                            writer.WriteLine(item.Text); // Her bir sonucu dosyaya yazar
                        }
                    }
                    MessageBox.Show("Log başarıyla kaydedildi."); // Kaydetme başarılı olduğunda mesaj gösterir
                }
            }
        }

        /// <summary>
        /// Checks for available hostnames with the specified project prefix.
        /// </summary>
        /// <param name="projectPrefix">The project prefix for hostnames.</param>
        /// <param name="count">The number of hostnames to check.</param>
        /// <returns>A list of available hostnames.</returns>
        private List<string> CheckHostnames(string projectPrefix, int count)
        {
            List<string> availableHostnames = new List<string>();
            int i = 1;

            // Gerekli sayıda mevcut hostname bulunana kadar kontrol etmeye devam eder
            while (availableHostnames.Count < count)
            {
                string computerName = $"{projectPrefix}{i:D3}"; // Bilgisayar adını oluşturur
                if (!IsComputerInDomain(computerName))
                {
                    availableHostnames.Add(computerName); // Domain'de olmayan hostname'leri ekler
                }

                // Her kontrol sonrası progress bar'ı günceller
                Invoke((Action)(() =>
                {
                    progressBar.Value = availableHostnames.Count;
                }));

                i++;
            }

            return availableHostnames; // Mevcut hostname'leri döner
        }

        /// <summary>
        /// Checks if a computer is in the domain.
        /// </summary>
        /// <param name="computerName">The name of the computer to check.</param>
        /// <returns>True if the computer is in the domain, otherwise false.</returns>
        private bool IsComputerInDomain(string computerName)
        {
            try
            {
                string adPath = "LDAP://DC=yourdomain,DC=com"; // Domain yolunu belirtir
                using (DirectoryEntry entry = new DirectoryEntry(adPath))
                {
                    using (DirectorySearcher searcher = new DirectorySearcher(entry))
                    {
                        searcher.Filter = $"(sAMAccountName={computerName}$)"; // Bilgisayar adını filtreler
                        searcher.PropertiesToLoad.Add("name");

                        SearchResult result = searcher.FindOne(); // Arama sonucunu alır
                        return result != null; // Sonuç varsa true, yoksa false döner
                    }
                }
            }
            catch (Exception ex) // Hata yakalama bloğu
            {
                // Arka plandaki thread'den UI güncellemek için Invoke kullanılır
                Invoke((Action)(() =>
                {
                    listViewResults.Items.Add(new ListViewItem($"Error querying domain for {computerName}: {ex.Message}")); // Hata mesajını ekler
                }));
                return false;
            }
        }
    }
}
