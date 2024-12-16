using System;
using System.IO;
using System.Management.Automation;
using System.Management;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.ServiceProcess;
using System.Windows.Forms;

namespace SysInspector
{
    public partial class TroubleshootForm : Form
    {
        public TroubleshootForm()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            resultsDataGridView.ColumnCount = 2;
            resultsDataGridView.Columns[0].Name = "Kontrol";
            resultsDataGridView.Columns[1].Name = "Sonuç";
            resultsDataGridView.Columns[0].Width = 300;
            resultsDataGridView.Columns[1].Width = 300;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            string selectedOption = financeRadioButton.Checked ? "Finance" : "Non-Finance";
            PerformTroubleshoot(selectedOption);
        }

        private void PerformTroubleshoot(string option)
        {
            resultsDataGridView.Rows.Clear();

            AddResult("Genel Troubleshoot Başlatılıyor...", "");
            AddResult("mail.mplusgroup.com.tr:443", CheckTelnet("mail.mplusgroup.com.tr", 443));
            AddResult("10.90.200.113:8383", CheckTelnet("10.90.200.113", 8383));
            AddResult("10.90.200.113:8027", CheckTelnet("10.90.200.113", 8027));
            AddResult("10.90.200.113:8443", CheckTelnet("10.90.200.113", 8443));
            AddResult("10.90.154.14:8080", CheckTelnet("10.90.154.14", 8080));
            AddResult("box:445", CheckTelnet("box", 445));
            AddResult("Windows Time Servisi", CheckWindowsTimeService());
            AddResult("NetBIOS", CheckNetBIOS());
            AddResult("IPv6", CheckIPv6());

            if (option == "Finance")
            {
                AddResult("Finance Troubleshoot Başlatılıyor...", "");
                AddResult("10.90.154.57:8014", CheckTelnet("10.90.154.57", 8014));
                AddResult("securitycloud.symantec.com:443", CheckTelnet("securitycloud.symantec.com", 443));
            }
            else if (option == "Non-Finance")
            {
                AddResult("Non-Finance Troubleshoot Başlatılıyor...", "");
                PerformNonFinanceChecks();
            }
        }

        private void PerformNonFinanceChecks()
        {
            string[,] ipAddresses = new string[,]
            {
                {"172.64.149.23", "80"},
                {"104.18.38.233", "80"},
                {"152.199.19.74", "80"},
                {"192.229.221.95", "80"},
                {"23.52.120.96", "80"},
                {"204.79.197.203", "80"},
                {"23.50.131.76", "80"},
                {"2.17.222.14", "80"},
                {"52.219.46.92", "80"},
                {"18.195.202.253", "443"},
                {"3.124.180.157", "443"},
                {"18.196.241.73", "443"},
                {"20.190.181.3", "443"},
                {"51.105.216.71", "443"},
                {"3.126.19.109", "443"},
                {"40.115.3.253", "443"},
                {"172.64.149.23", "443"},
                {"104.18.38.233", "443"},
                {"152.199.19.74", "443"},
                {"d3loxeqnrcs4xe.cloudfront.net", "443"},
                {"securitycloud.symantec.com", "443"},
                {"192.229.221.95", "443"}
            };

            for (int i = 0; i < ipAddresses.GetLength(0); i++)
            {
                string ip = ipAddresses[i, 0];
                string port = ipAddresses[i, 1];
                string result = CheckTelnet(ip, int.Parse(port));
                AddResult($"{ip}:{port}", result);
            }
        }

        private void AddResult(string check, string result)
        {
            resultsDataGridView.Rows.Add(check, result);
        }

        private string CheckTelnet(string host, int port)
        {
            try
            {
                using (var client = new TcpClient())
                {
                    var result = client.BeginConnect(host, port, null, null);
                    var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(5));

                    if (!success)
                    {
                        return "Başarısız";
                    }

                    client.EndConnect(result);
                    return "Başarılı";
                }
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }

        private string CheckPing(string host)
        {
            try
            {
                using (var ping = new Ping())
                {
                    var reply = ping.Send(host, 5000);
                    if (reply.Status == IPStatus.Success)
                    {
                        return "Başarılı";
                    }
                    else
                    {
                        return $"Başarısız: {reply.Status}";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }

        private string CheckWindowsTimeService()
        {
            try
            {
                ServiceController sc = new ServiceController("W32Time");
                if (sc.Status == ServiceControllerStatus.Running)
                {
                    return "Çalışıyor";
                }
                else
                {
                    return "Çalışmıyor";
                }
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }

        private string CheckNetBIOS()
        {
            try
            {
                string netBiosStatus = "Kapalı";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = True");
                foreach (ManagementObject mo in searcher.Get())
                {
                    if (mo["TcpipNetbiosOptions"] != null && mo["TcpipNetbiosOptions"].ToString() == "1")
                    {
                        netBiosStatus = "Açık";
                    }
                }
                return netBiosStatus;
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }

        private string CheckIPv6()
        {
            try
            {
                using (PowerShell powerShell = PowerShell.Create())
                {
                    powerShell.AddScript("Get-NetAdapterBinding -ComponentID ms_tcpip6 | Where-Object {$_.Enabled -eq $true}");

                    var results = powerShell.Invoke();

                    if (powerShell.Streams.Error.Count > 0)
                    {
                        throw new Exception(string.Join(Environment.NewLine, powerShell.Streams.Error));
                    }

                    // Eğer sonuçlar varsa, IPv6 aktiftir
                    if (results.Count > 0)
                    {
                        return "Aktif";
                    }
                    else
                    {
                        return "Kapalı";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }

        private void logButton_Click(object sender, EventArgs e)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string defaultFileName = $"TroubleshootLog_{timestamp}.txt";

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt",
                Title = "Log Dosyasını Kaydet",
                FileName = defaultFileName,
                DefaultExt = "txt",
                AddExtension = true
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLine("Kontrol\tSonuç");
                    foreach (DataGridViewRow row in resultsDataGridView.Rows)
                    {
                        sw.WriteLine($"{row.Cells[0].Value}\t{row.Cells[1].Value}");
                    }
                }
                MessageBox.Show("Log dosyası başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
