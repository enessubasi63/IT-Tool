using System;
using System.IO;
using System.DirectoryServices;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace SysInspector
{
    public partial class NoIPResolutionForm : Form
    {
        // Uygulamanın log ve çıktı dosyalarının depolandığı dizin ve dosya yolları
        private static readonly string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "NoIPResolution");
        private static readonly string logFilePath = Path.Combine(outputDirectory, "application.log");

        public NoIPResolutionForm()
        {
            InitializeComponent();
        }

        // btnLogNoIPDevices butonuna tıklama event handler'ı
        private void btnLogNoIPDevices_Click(object sender, EventArgs e)
        {
            // Kullanıcı tarafından girilen hostname prefix ve cihaz sayısını alır ve doğrular
            string hostnamePrefix = txtHostnamePrefix.Text.Trim();
            if (string.IsNullOrEmpty(hostnamePrefix) || !int.TryParse(txtDeviceCount.Text.Trim(), out int deviceCount))
            {
                MessageBox.Show("Please enter valid hostname prefix and device count."); // Geçersiz giriş için uyarı mesajı
                return;
            }

            // Log yapılandırmasını başlatır ve log kaydeder
            ConfigureLogging();
            Log("Program started.");
            txtLog.AppendText("Program started.\n");

            // Çıkış dizinini oluşturur ve projeleri işler
            CreateOutputDirectory();
            ProcessProjects(hostnamePrefix, deviceCount);
            Log("All processes are completed.");
            txtLog.AppendText("All processes are completed.\n");
        }

        // Çıkış dizinini oluşturan statik metod
        static void CreateOutputDirectory()
        {
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }
        }

        // Projeleri işleyen metod, hostname'leri kontrol eder ve IP çözümleme durumu ile ilgili verileri toplar
        void ProcessProjects(string projectPrefix, int count)
        {
            // IP almayan cihazları depolamak için ConcurrentBag kullanılır
            ConcurrentBag<string> computersWithoutIp = new ConcurrentBag<string>();

            // Her bir cihaz için paralel olarak işlemler gerçekleştirilir
            Parallel.ForEach(Enumerable.Range(1, count), i =>
            {
                string computerName = $"{projectPrefix}{i:D3}";
                string computerFQDN = $"{computerName}.yourdomain.com";

                // Bilgisayar domain'de ise ve IP alamıyorsa listeye eklenir
                if (IsComputerInDomain(computerName) && !CanResolveIP(computerFQDN))
                {
                    computersWithoutIp.Add(computerName);
                }
            });

            // Sonuçları bir dosyaya kaydeder
            string fileName = $"NoIPResolution_{projectPrefix}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            SaveComputersWithoutIp(fileName, computersWithoutIp);
            Log($"Query completed for {projectPrefix}. {computersWithoutIp.Count} computers without IP resolution were found.");
            txtLog.AppendText($"Query completed for {projectPrefix}. {computersWithoutIp.Count} computers without IP resolution were found.\n");
        }

        // IP almayan cihazları bir dosyaya kaydeden metod
        void SaveComputersWithoutIp(string defaultFileName, ConcurrentBag<string> computers)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.FileName = defaultFileName;
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter file = new StreamWriter(saveFileDialog.FileName))
                    {
                        foreach (var computer in computers)
                        {
                            file.WriteLine(computer);
                        }
                    }
                    MessageBox.Show("Log successfully saved."); // Başarı mesajı gösterir
                }
            }
        }

        // Bilgisayarın domain'de olup olmadığını kontrol eden statik metod
        static bool IsComputerInDomain(string computerName)
        {
            try
            {
                string adPath = "LDAP://DC=yourdomain,DC=com";
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
                Log($"Error querying domain: {ex.Message}"); // Hata logu ekler
                var form = Application.OpenForms.OfType<NoIPResolutionForm>().FirstOrDefault();
                form?.txtLog.AppendText($"Error querying domain: {ex.Message}\n"); // Hata mesajını log ekranına yazar
                return false;
            }
        }

        // Bilgisayarın IP çözümleyip çözümleyemediğini kontrol eden statik metod
        static bool CanResolveIP(string fqdn)
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

        // Log yapılandırmasını yapan statik metod
        static void ConfigureLogging()
        {
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            if (!File.Exists(logFilePath))
            {
                File.Create(logFilePath).Dispose(); // Dosyayı oluşturur ve kapatır
            }
        }

        // Log mesajını log dosyasına yazan statik metod
        static void Log(string message)
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }
    }
}
