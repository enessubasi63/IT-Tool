using System;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Linq;

namespace SysInspector
{
    public partial class TelnetToolForm : Form
    {
        public TelnetToolForm()
        {
            InitializeComponent();
        }

        // btnTelnet butonuna tıklama event handler'ı
        private async void btnTelnet_Click(object sender, EventArgs e)
        {
            // IP adreslerini virgülle ayırarak alır
            string[] ips = txtIPs.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (!int.TryParse(txtPort.Text, out int port)) // Port numarasını doğrular
            {
                MessageBox.Show("Please enter a valid port number.");
                return;
            }

            listViewLogTelnet.Items.Clear(); // ListView öğelerini temizler
            foreach (string ip in ips)
            {
                string trimmedIp = ip.Trim();
                var listViewItem = new ListViewItem(new[] { trimmedIp, port.ToString(), "Attempting to connect..." });
                listViewLogTelnet.Items.Add(listViewItem); // ListView'e yeni öğe ekler
                string result = await TelnetAsync(trimmedIp, port); // Telnet işlemini asenkron olarak yapar
                listViewItem.SubItems[2].Text = result; // Sonucu günceller
            }
        }

        // Telnet bağlantısını asenkron olarak gerçekleştiren metod
        private Task<string> TelnetAsync(string ip, int port)
        {
            return Task.Run(() =>
            {
                try
                {
                    using (TcpClient client = new TcpClient())
                    {
                        client.Connect(ip, port); // Bağlantıyı gerçekleştirir
                        return $"Successfully connected to {ip} on port {port}."; // Başarılı mesajı döner
                    }
                }
                catch (Exception ex) // Hata yakalama bloğu
                {
                    return $"Failed to connect to {ip} on port {port}: {ex.Message}"; // Hata mesajı döner
                }
            });
        }

        // btnEnableTelnet butonuna tıklama event handler'ı
        private void btnEnableTelnet_Click(object sender, EventArgs e)
        {
            EnableTelnet(); // Telnet'i etkinleştirir
        }

        // Telnet'i etkinleştiren metod
        private void EnableTelnet()
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "powershell.exe";
                process.StartInfo.Arguments = "-NoProfile -ExecutionPolicy Bypass -Command \"Enable-WindowsOptionalFeature -Online -FeatureName TelnetClient -All\"";
                process.StartInfo.Verb = "runas"; // Admin yetkisiyle çalıştırır
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (process.ExitCode == 0) // Başarılıysa mesaj gösterir
                {
                    MessageBox.Show("Telnet Client successfully enabled.");
                }
                else // Hatalıysa hata mesajı gösterir
                {
                    MessageBox.Show($"Failed to enable Telnet Client. Error: {error}");
                }
            }
            catch (Exception ex) // Hata yakalama bloğu
            {
                MessageBox.Show($"Exception occurred: {ex.Message}");
            }
        }

        // btnAssignIP butonuna tıklama event handler'ı
        private async void btnAssignIP_Click(object sender, EventArgs e)
        {
            // IP adreslerini virgülle ayırarak alır
            string[] ips = txtIPAssignments.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            listViewLogIP.Items.Clear(); // ListView öğelerini temizler
            foreach (string ip in ips)
            {
                string trimmedIp = ip.Trim();
                var listViewItem = new ListViewItem(new[] { trimmedIp, "Pinging..." });
                listViewLogIP.Items.Add(listViewItem); // ListView'e yeni öğe ekler
                string result = await PingAsync(trimmedIp); // Ping işlemini asenkron olarak yapar
                listViewItem.SubItems[1].Text = result; // Sonucu günceller
            }
        }

        // Ping işlemini asenkron olarak gerçekleştiren metod
        private Task<string> PingAsync(string ip)
        {
            return Task.Run(() =>
            {
                try
                {
                    using (Ping ping = new Ping())
                    {
                        PingReply reply = ping.Send(ip, 1000); // Sadece 1 paket gönderir
                        if (reply.Status == IPStatus.Success) // Başarılıysa mesaj döner
                        {
                            return $"Ping to {ip} successful.";
                        }
                        else // Başarısızsa hata mesajı döner
                        {
                            return $"Ping to {ip} failed: {reply.Status}.";
                        }
                    }
                }
                catch (Exception ex) // Hata yakalama bloğu
                {
                    return $"Ping to {ip} failed: {ex.Message}.";
                }
            });
        }

        // Telnet logunu kaydeden butonun tıklama event handler'ı
        private void btnSaveLogTelnet_Click(object sender, EventArgs e)
        {
            SaveLog(listViewLogTelnet, "Telnet_Log.txt"); // Log kaydeder
        }

        // IP atama logunu kaydeden butonun tıklama event handler'ı
        private void btnSaveLogIP_Click(object sender, EventArgs e)
        {
            SaveLog(listViewLogIP, "IPAssignment_Log.txt"); // Log kaydeder
        }

        // Log kaydeden metod
        private void SaveLog(ListView listView, string defaultFileName)
        {
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
                            writer.WriteLine(string.Join(", ", item.SubItems.Cast<ListViewItem.ListViewSubItem>().Select(subItem => subItem.Text))); // Log verisini yazar
                        }
                    }
                    MessageBox.Show("Log saved successfully."); // Başarılı mesajı gösterir
                }
            }
        }
    }
}
