using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SysInspector
{
    public partial class BatchExecutorForm : Form
    {
        public BatchExecutorForm()
        {
            InitializeComponent();
        }

        // btnMplusLocalOffice butonuna tıklama event handler'ı
        private void btnMplusLocalOffice_Click(object sender, EventArgs e)
        {
            // MplusLocalOffice.bat dosyasını çalıştırır
            RunBatchFile(@"\\ccdcm\ECM\MplusLocalOffice.bat");
        }

        // btnMplusMalatya butonuna tıklama event handler'ı
        private void btnMplusMalatya_Click(object sender, EventArgs e)
        {
            // MplusMalatya.bat dosyasını çalıştırır
            RunBatchFile(@"\\ccdcm\ECM\MplusMalatya.bat");
        }

        // btnMplusRize butonuna tıklama event handler'ı
        private void btnMplusRize_Click(object sender, EventArgs e)
        {
            // MplusRize.bat dosyasını çalıştırır
            RunBatchFile(@"\\ccdcm\ECM\MplusRize.bat");
        }

        // btnMplusUrfa butonuna tıklama event handler'ı
        private void btnMplusUrfa_Click(object sender, EventArgs e)
        {
            // MplusUrfa.bat dosyasını çalıştırır
            RunBatchFile(@"\\ccdcm\ECM\MplusUrfa.bat");
        }

        // btnMplusVan butonuna tıklama event handler'ı
        private void btnMplusVan_Click(object sender, EventArgs e)
        {
            // MplusVan.bat dosyasını çalıştırır
            RunBatchFile(@"\\ccdcm\ECM\MplusVan.bat");
        }

        // Batch dosyasını çalıştıran metod
        private void RunBatchFile(string filePath)
        {
            try
            {
                // Yeni bir ProcessStartInfo nesnesi oluşturur ve batch dosyasını çalıştırır
                Process.Start(new ProcessStartInfo
                {
                    FileName = filePath, // Çalıştırılacak batch dosyasının yolu
                    UseShellExecute = true // ShellExecute özelliğini kullanarak çalıştırır
                });
            }
            catch (Exception ex) // Hata yakalama bloğu
            {
                // Hata mesajı gösterir
                MessageBox.Show($"Error executing batch file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
