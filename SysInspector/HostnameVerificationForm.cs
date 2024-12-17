using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysInspector
{
    public partial class HostnameVerificationForm : Form
    {
        public HostnameVerificationForm()
        {
            InitializeComponent();
        }

        // btnVerifyHostnames butonuna tıklama event handler'ı
        private async void btnVerifyHostnames_Click(object sender, EventArgs e)
        {
            // Kullanıcı tarafından girilen hostname'leri alır ve boşlukları temizler
            string inputHostnames = txtHostnames.Text.Trim();
            if (string.IsNullOrWhiteSpace(inputHostnames))
            {
                MessageBox.Show("Lütfen geçerli hostname'ler girin."); // Geçersiz giriş için uyarı mesajı gösterir
                return;
            }

            // Hostname'leri ayırır ve bir listeye dönüştürür
            List<string> hostnames = inputHostnames.Split(',').Select(h => h.Trim()).ToList();

            // Sonuç listelerini temizler ve başlangıç mesajını ekler
            listViewNotInDomain.Items.Clear();
            listViewInDomainWithIP.Items.Clear();
            listViewInDomainWithoutIP.Items.Clear();
            listViewNotInDomain.Items.Add(new ListViewItem("Hostname kontrolü başlıyor..."));

            // Progress bar ayarları
            progressBar.Minimum = 0;
            progressBar.Maximum = hostnames.Count;
            progressBar.Value = 0;

            // Hostname'leri asenkron olarak doğrular
            var results = await Task.Run(() => VerifyHostnames(hostnames));

            // Sonuçları ilgili listView'e ekler
            foreach (var result in results.NotInDomain)
            {
                listViewNotInDomain.Items.Add(new ListViewItem(result));
            }

            foreach (var result in results.InDomainWithIP)
            {
                listViewInDomainWithIP.Items.Add(new ListViewItem(result));
            }

            foreach (var result in results.InDomainWithoutIP)
            {
                listViewInDomainWithoutIP.Items.Add(new ListViewItem(result));
            }

            MessageBox.Show("Hostname kontrolü tamamlandı."); // Kontrol tamamlandığında mesaj gösterir
        }

        // Hostname'leri doğrulayan metod
        private (List<string> NotInDomain, List<string> InDomainWithIP, List<string> InDomainWithoutIP) VerifyHostnames(List<string> hostnames)
        {
            List<string> notInDomain = new List<string>();
            List<string> inDomainWithIP = new List<string>();
            List<string> inDomainWithoutIP = new List<string>();
            int i = 1;

            // Her hostname için kontrol yapar
            foreach (var hostname in hostnames)
            {
                string computerName = $"{hostname}";
                if (!IsComputerInDomain(computerName)) // Bilgisayar domain'de değilse
                {
                    notInDomain.Add($"{computerName} zaten domainde değil");
                }
                else if (CanResolveIP($"{computerName}.cmcturkey.com")) // Bilgisayar domain'de ve IP alıyorsa
                {
                    inDomainWithIP.Add($"{computerName} cihaz domainde ve ip alıyor");
                }
                else // Bilgisayar domain'de ama IP almıyorsa
                {
                    inDomainWithoutIP.Add($"{computerName} cihaz domainde ama ip almıyor");
                }

                // Progress bar'ı günceller
                Invoke((Action)(() =>
                {
                    progressBar.Value = i++;
                }));
            }

            // Sonuçları döner
            return (notInDomain, inDomainWithIP, inDomainWithoutIP);
        }

        // Bilgisayarın domain'de olup olmadığını kontrol eden metod
        private bool IsComputerInDomain(string computerName)
        {
            try
            {
                string adPath = "LDAP://DC=cmcturkey,DC=com";
                using (DirectoryEntry entry = new DirectoryEntry(adPath))
                {
                    using (DirectorySearcher searcher = new DirectorySearcher(entry))
                    {
                        searcher.Filter = $"(sAMAccountName={computerName}$)";
                        searcher.PropertiesToLoad.Add("name");

                        SearchResult result = searcher.FindOne();
                        return result != null;
                    }
                }
            }
            catch (Exception ex) // Hata yakalama bloğu
            {
                Invoke((Action)(() =>
                {
                    listViewNotInDomain.Items.Add(new ListViewItem($"Error querying domain for {computerName}: {ex.Message}"));
                }));
                return false;
            }
        }

        // Bilgisayarın IP çözümleyip çözümleyemediğini kontrol eden metod
        private bool CanResolveIP(string fqdn)
        {
            try
            {
                IPHostEntry host = Dns.GetHostEntry(fqdn);
                return host.AddressList.Length > 0;
            }
            catch
            {
                return false;
            }
        }

        // NotInDomain sonuçlarını dışa aktaran butonun tıklama event handler'ı
        private void btnExportNotInDomain_Click(object sender, EventArgs e)
        {
            ExportResults(listViewNotInDomain, "NotInDomain");
        }

        // InDomainWithIP sonuçlarını dışa aktaran butonun tıklama event handler'ı
        private void btnExportInDomainWithIP_Click(object sender, EventArgs e)
        {
            ExportResults(listViewInDomainWithIP, "InDomainWithIP");
        }

        // InDomainWithoutIP sonuçlarını dışa aktaran butonun tıklama event handler'ı
        private void btnExportInDomainWithoutIP_Click(object sender, EventArgs e)
        {
            ExportResults(listViewInDomainWithoutIP, "InDomainWithoutIP");
        }

        // Tüm sonuçları dışa aktaran butonun tıklama event handler'ı
        private void btnExportAll_Click(object sender, EventArgs e)
        {
            string defaultFileName = $"HostnameVerification_All_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.FileName = defaultFileName;
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        writer.WriteLine("Zaten Domainde Değil:");
                        foreach (ListViewItem item in listViewNotInDomain.Items)
                        {
                            writer.WriteLine(item.Text);
                        }

                        writer.WriteLine("\nDomainde ve IP Alıyor:");
                        foreach (ListViewItem item in listViewInDomainWithIP.Items)
                        {
                            writer.WriteLine(item.Text);
                        }

                        writer.WriteLine("\nDomainde Ama IP Almıyor:");
                        foreach (ListViewItem item in listViewInDomainWithoutIP.Items)
                        {
                            writer.WriteLine(item.Text);
                        }
                    }
                    MessageBox.Show("Sonuçlar başarıyla kaydedildi."); // Başarı mesajı gösterir
                }
            }
        }

        // Sonuçları dışa aktaran metod
        private void ExportResults(ListView listView, string resultType)
        {
            string defaultFileName = $"HostnameVerification_{resultType}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.FileName = defaultFileName;
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        foreach (ListViewItem item in listView.Items)
                        {
                            writer.WriteLine(item.Text);
                        }
                    }
                    MessageBox.Show($"{resultType} sonuçları başarıyla kaydedildi."); // Başarı mesajı gösterir
                }
            }
        }
    }
}
