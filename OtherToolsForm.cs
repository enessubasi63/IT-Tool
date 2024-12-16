using System;
using System.Windows.Forms;

namespace SysInspector
{
    public partial class OtherToolsForm : Form
    {
        public OtherToolsForm()
        {
            InitializeComponent();
        }

        // Butona tıklama event handler'ı
        private void btnTool_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                switch (button.Name)
                {
                    case "btnTool1":
                        ShowForm<AzureCheckForm>();
                        break;
                    case "btnTool2":
                        ShowForm<HostnameForm>(); 
                        break;
                    case "btnNoIPResolution":
                        ShowForm<NoIPResolutionForm>();
                        break;
                    case "btnTelnetTool":
                        ShowForm<TelnetToolForm>();
                        break;
                    case "btnBatchExecutor":
                        ShowForm<BatchExecutorForm>();
                        break;
                    case "btnCacheClearing":
                        ShowForm<CacheClearingForm>();
                        break;
                    case "btnSystemInformation":
                        ShowForm<SystemInformationForm>();
                        break;
                    case "btnADQuery":
                        ShowForm<ADQueryForm>();
                        break;
                    case "btnGroupPolicyUpdater":
                        ShowForm<GroupPolicyUpdaterForm>();
                        break;
                    case "btnUserProfiles":
                        ShowForm<UserProfilesForm>();
                        break;
                }
            }
        }

        // Generic metod, belirli bir form tipini gösterir
        private void ShowForm<T>() where T : Form, new()
        {
            panelContent.Controls.Clear(); // Panel içeriğini temizler
            var form = new T // Yeni form oluşturur
            {
                TopLevel = false, // Formun en üst seviyede olmamasını sağlar
                FormBorderStyle = FormBorderStyle.None, // Formun kenarlığını kaldırır
                Dock = DockStyle.Fill // Formu panelin içinde doldurur
            };
            panelContent.Controls.Add(form); // Formu panele ekler
            form.Show(); // Formu gösterir
        }

        // Form yüklendiğinde çalışan event handler
        private void OtherToolsForm_Load(object sender, EventArgs e)
        {
            // Scroll ayarlarını başlatır
            flowLayoutPanelButtons.WrapContents = false; // İçeriğin sarmalanmasını engeller
            flowLayoutPanelButtons.AutoScroll = false; // Otomatik kaydırmayı kapatır
            flowLayoutPanelButtons.HorizontalScroll.Enabled = false; // Yatay kaydırmayı kapatır
            flowLayoutPanelButtons.HorizontalScroll.Visible = false; // Yatay kaydırmayı görünmez yapar
            flowLayoutPanelButtons.HorizontalScroll.Maximum = 0; // Yatay kaydırmanın maksimum değerini sıfırlar
            flowLayoutPanelButtons.AutoScroll = true; // Otomatik kaydırmayı açar
        }
    }
}
