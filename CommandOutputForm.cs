using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysInspector
{
    public partial class CommandOutputForm : Form
    {
        private string command; // Komutun saklandığı değişken

        // Formun constructor'ı, komutu parametre olarak alır
        public CommandOutputForm(string command)
        {
            InitializeComponent();
            this.command = command; // Komutu sınıf değişkenine atar
        }

        // Form yüklendiğinde çalışan event handler
        private void CommandOutputForm_Load(object sender, EventArgs e)
        {
            ExecuteCommandAsync(command); // Komutu asenkron olarak çalıştırır
        }

        // Komutu asenkron olarak çalıştıran metod
        private async void ExecuteCommandAsync(string command)
        {
            await Task.Run(() =>
            {
                try
                {
                    // Komutun cmd.exe ile çalıştırılması için ProcessStartInfo ayarlarını yapar
                    ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe", "/c " + command)
                    {
                        RedirectStandardOutput = true, // Standart çıktıyı yönlendirir
                        UseShellExecute = false, // ShellExecute kullanmaz
                        CreateNoWindow = true // Yeni pencere oluşturmaz
                    };

                    // Process oluşturur ve ayarları uygular
                    using (Process process = new Process())
                    {
                        process.StartInfo = processStartInfo;

                        // Çıktı verilerini aldıkça tetiklenen event handler
                        process.OutputDataReceived += (s, e) =>
                        {
                            if (e.Data != null)
                            {
                                Invoke(new Action(() =>
                                {
                                    textBoxOutput.AppendText(e.Data + Environment.NewLine); // Çıktıyı textBox'a ekler
                                }));
                            }
                        };

                        process.Start(); // Süreci başlatır
                        process.BeginOutputReadLine(); // Çıktı okumayı başlatır
                        process.WaitForExit(); // Sürecin bitmesini bekler
                    }
                }
                catch (Exception ex) // Hata yakalama bloğu
                {
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show("Error executing command: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Hata mesajı gösterir
                    }));
                }
            });
        }
    }
}
