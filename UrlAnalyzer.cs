using System;
using System.IO;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace SysInspector
{
    public partial class UrlAnalyzer : Form
    {
        private static readonly HttpClient _client = new HttpClient(); // HttpClient örneği tek seferlik oluşturuldu
        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(5); // Aynı anda en fazla 5 istek

        public UrlAnalyzer()
        {
            InitializeComponent();
            InitializeDataGridViewColumns(); // DataGridView sütunlarını başlat
            _client.Timeout = TimeSpan.FromMinutes(5); // HttpClient zaman aşımı süresi artırıldı
        }

        // DataGridView için gerekli sütunları ekleyen metod
        private void InitializeDataGridViewColumns()
        {
            dgvResults.Columns.Add("Element", "Element");
            dgvResults.Columns.Add("URL", "URL");
            dgvResults.Columns.Add("Status", "Status");
            dgvResults.Columns.Add("Type", "Type");
        }

        // btnAnalyze butonuna tıklama event handler'ı
        private async void btnAnalyze_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text.Trim();
            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("Please enter a valid URL.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute) || !(url.StartsWith("http://") || url.StartsWith("https://")))
            {
                MessageBox.Show("Please enter a valid 'http' or 'https' URL.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                dgvResults.Rows.Clear();
                progressBar.Value = 0;
                await AnalyzeUrl(url);
                progressBar.Value = 100;
            }
            catch (TaskCanceledException ex) when (ex.InnerException is TimeoutException)
            {
                MessageBox.Show("Operation timed out. Please try again with a longer timeout.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (TaskCanceledException ex)
            {
                MessageBox.Show("The operation was canceled. Please try again.", "Operation Canceled", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // URL analizini gerçekleştiren metod
        private async Task AnalyzeUrl(string url)
        {
            HttpResponseMessage response = null;
            string content = null;

            try
            {
                response = await _client.GetAsync(url);
                content = await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                dgvResults.Rows.Add("URL", url, $"Error: {ex.Message}", "N/A");
                return;
            }

            progressBar.Value = 20;

            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(content);

            await AnalyzeNodes(htmlDoc, url);

            progressBar.Value = 80;

            if (response.RequestMessage.RequestUri.ToString() != url)
            {
                dgvResults.Rows.Add("Redirected To", response.RequestMessage.RequestUri.ToString(), "N/A", "Redirection");
            }

            await CheckPortAndLibraries(url);
        }

        // HTML öğelerini ve kaynaklarını analiz eden metod
        private async Task AnalyzeNodes(HtmlAgilityPack.HtmlDocument htmlDoc, string baseUrl)
        {
            var nodes = htmlDoc.DocumentNode.SelectNodes("//a[@href] | //link[@href] | //script[@src] | //img[@src] | //iframe[@src] | //video[@src] | //audio[@src] | //source[@src] | //object[@data]");

            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    await _semaphore.WaitAsync(); // Sınırlayıcıyı bekle
                    try
                    {
                        string attributeValue = "";
                        switch (node.Name)
                        {
                            case "a":
                            case "link":
                                attributeValue = node.GetAttributeValue("href", string.Empty);
                                break;
                            case "script":
                            case "img":
                            case "iframe":
                            case "video":
                            case "audio":
                            case "source":
                                attributeValue = node.GetAttributeValue("src", string.Empty);
                                break;
                            case "object":
                                attributeValue = node.GetAttributeValue("data", string.Empty);
                                break;
                        }

                        if (!string.IsNullOrEmpty(attributeValue))
                        {
                            if (!Uri.IsWellFormedUriString(attributeValue, UriKind.Absolute))
                            {
                                if (Uri.IsWellFormedUriString(baseUrl, UriKind.Absolute))
                                {
                                    var baseUri = new Uri(baseUrl);
                                    attributeValue = new Uri(baseUri, attributeValue).ToString();
                                }
                            }

                            try
                            {
                                await _client.GetAsync(attributeValue);
                                dgvResults.Rows.Add(node.Name, attributeValue, "Accessible", GetElementType(node.Name));
                            }
                            catch (HttpRequestException)
                            {
                                dgvResults.Rows.Add(node.Name, attributeValue, "Inaccessible", GetElementType(node.Name));
                            }
                        }
                        else
                        {
                            dgvResults.Rows.Add(node.Name, "No source found", "Invalid URL", GetElementType(node.Name));
                        }
                    }
                    finally
                    {
                        _semaphore.Release(); // Sınırlayıcıyı serbest bırak
                    }
                }
            }
        }

        // HTML eleman tipini belirleyen metod
        private string GetElementType(string elementName)
        {
            switch (elementName)
            {
                case "a":
                    return "Hyperlink";
                case "link":
                    return "CSS/Link";
                case "script":
                    return "JavaScript";
                case "img":
                    return "Image";
                case "iframe":
                    return "Iframe";
                case "video":
                    return "Video";
                case "audio":
                    return "Audio";
                case "source":
                    return "Media Source";
                case "object":
                    return "Embedded Object";
                default:
                    return "Unknown";
            }
        }

        // Ekstra IP, port ve kütüphane kontrollerini yapan metod
        private async Task CheckPortAndLibraries(string url)
        {
            var uri = new Uri(url);
            await CheckPort(uri.Host, 80);  // HTTP portu
            await CheckPort(uri.Host, 443); // HTTPS portu
        }

        // Belirli bir portu kontrol eden metod
        private async Task CheckPort(string host, int port)
        {
            await Task.Run(() =>
            {
                using (var tcpClient = new TcpClient())
                {
                    try
                    {
                        tcpClient.Connect(host, port);
                        dgvResults.Rows.Add("Port", $"{host}:{port}", "Accessible", "Network Port");
                    }
                    catch (SocketException)
                    {
                        dgvResults.Rows.Add("Port", $"{host}:{port}", "Inaccessible", "Network Port");
                    }
                }
            });
        }

        // btnSaveLog butonuna tıklama event handler'ı
        private void btnSaveLog_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.Title = "Save log as";
                saveFileDialog.FileName = $"UrlAnalysisLog_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                    {
                        foreach (DataGridViewRow row in dgvResults.Rows)
                        {
                            var elements = new[]
                            {
                                row.Cells[0].Value?.ToString(),
                                row.Cells[1].Value?.ToString(),
                                row.Cells[2].Value?.ToString(),
                                row.Cells[3].Value?.ToString()
                            };
                            sw.WriteLine(string.Join("\t", elements));
                        }
                    }
                    MessageBox.Show($"Log saved to {saveFileDialog.FileName}", "Log Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
