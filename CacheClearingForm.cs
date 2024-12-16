using System;
using System.IO;
using System.Windows.Forms;

namespace SysInspector
{
    public partial class CacheClearingForm : Form
    {
        public CacheClearingForm()
        {
            InitializeComponent();
        }

        // btnClearCache butonuna tıklama event handler'ı
        private void btnClearCache_Click(object sender, EventArgs e)
        {
            textBoxCacheResults.Clear(); // Sonuçları gösteren textBox'ı temizler

            // RAM temizleme seçiliyse RAM cache temizleme işlemini başlatır
            if (checkBoxRamCleaning.Checked)
            {
                ClearRamCache();
            }

            // Tarayıcı temizleme seçiliyse tarayıcı cache temizleme işlemini başlatır
            if (checkBoxBrowserCleaning.Checked)
            {
                ClearBrowserCache();
            }

            // Office temizleme seçiliyse Office cache temizleme işlemini başlatır
            if (checkBoxOfficeCleaning.Checked)
            {
                ClearOfficeCache();
            }

            // İşlemin tamamlandığını bildirir
            MessageBox.Show("Selected cache cleared successfully.");
        }

        // RAM cache temizleme işlemini gerçekleştiren metod
        private void ClearRamCache()
        {
            try
            {
                // Kullanıcı profil yolunu alır
                string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                // AppData Local Temp dizin yolunu oluşturur
                string appDataLocalTempPath = Path.Combine(userProfile, "AppData\\Local\\Temp");
                // Windows Temp dizin yolunu oluşturur
                string windowsTempPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Temp");

                // Dizin içeriğini siler
                DeleteDirectoryContents(appDataLocalTempPath);
                DeleteDirectoryContents(windowsTempPath);

                textBoxCacheResults.AppendText("RAM cache cleared.\n"); // Sonuçları textBox'a yazar
            }
            catch (Exception ex) // Hata yakalama bloğu
            {
                textBoxCacheResults.AppendText("Error clearing RAM cache: " + ex.Message + "\n"); // Hata mesajını textBox'a yazar
            }
        }

        // Tarayıcı cache temizleme işlemini gerçekleştiren metod
        private void ClearBrowserCache()
        {
            try
            {
                // Kullanıcı profil yolunu alır
                string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                // Google Cache dizin yolunu oluşturur
                string googleCachePath = Path.Combine(userProfile, "AppData\\Local\\Google");

                // Dizin içeriğini siler
                DeleteDirectoryContents(googleCachePath);

                textBoxCacheResults.AppendText("Browser cache cleared.\n"); // Sonuçları textBox'a yazar
            }
            catch (Exception ex) // Hata yakalama bloğu
            {
                textBoxCacheResults.AppendText("Error clearing browser cache: " + ex.Message + "\n"); // Hata mesajını textBox'a yazar
            }
        }

        // Microsoft Office cache temizleme işlemini gerçekleştiren metod
        private void ClearOfficeCache()
        {
            try
            {
                // Kullanıcı profil yolunu alır
                string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                // Office Cache dizin yolunu oluşturur
                string officeCachePath = Path.Combine(userProfile, "AppData\\Local\\Microsoft\\Office");

                // Dizin içeriğini siler
                DeleteDirectoryContents(officeCachePath);

                textBoxCacheResults.AppendText("Microsoft Office cache cleared.\n"); // Sonuçları textBox'a yazar
            }
            catch (Exception ex) // Hata yakalama bloğu
            {
                textBoxCacheResults.AppendText("Error clearing Microsoft Office cache: " + ex.Message + "\n"); // Hata mesajını textBox'a yazar
            }
        }

        // Belirtilen dizinin içeriğini silen metod
        private void DeleteDirectoryContents(string directoryPath)
        {
            if (Directory.Exists(directoryPath)) // Dizin mevcutsa
            {
                DirectoryInfo dirInfo = new DirectoryInfo(directoryPath);

                // Dizin içindeki dosyaları siler
                foreach (FileInfo file in dirInfo.GetFiles())
                {
                    try
                    {
                        file.Delete();
                    }
                    catch (Exception ex) // Hata yakalama bloğu
                    {
                        textBoxCacheResults.AppendText($"Error deleting file {file.Name}: {ex.Message}\n"); // Hata mesajını textBox'a yazar
                    }
                }

                // Dizin içindeki alt dizinleri siler
                foreach (DirectoryInfo dir in dirInfo.GetDirectories())
                {
                    try
                    {
                        dir.Delete(true);
                    }
                    catch (Exception ex) // Hata yakalama bloğu
                    {
                        textBoxCacheResults.AppendText($"Error deleting directory {dir.Name}: {ex.Message}\n"); // Hata mesajını textBox'a yazar
                    }
                }
            }
        }
    }
}
