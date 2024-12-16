using System;
using System.Windows.Forms;

namespace SysInspector
{
    public partial class HostnameForm : Form
    {
        public HostnameForm()
        {
            InitializeComponent();
        }

        // menuHostnameController menü öğesine tıklama event handler'ı
        private void menuHostnameController_Click(object sender, EventArgs e)
        {
            ShowForm<HostnameControllerForm>(); // HostnameControllerForm formunu gösterir
        }

        // menuNoIPResolution menü öğesine tıklama event handler'ı
        private void menuNoIPResolution_Click(object sender, EventArgs e)
        {
            ShowForm<NoIPResolutionForm>(); // NoIPResolutionForm formunu gösterir
        }

        // menuHostnameVerification menü öğesine tıklama event handler'ı
        private void menuHostnameVerification_Click(object sender, EventArgs e)
        {
            ShowForm<HostnameVerificationForm>(); // HostnameVerificationForm formunu gösterir
        }

        // Belirtilen form tipini gösteren metod
        private void ShowForm<T>() where T : Form, new()
        {
            panelContent.Controls.Clear(); // Panelin içeriğini temizler
            var form = new T
            {
                TopLevel = false, // Formu üst seviye olmayan bir form olarak ayarlar
                FormBorderStyle = FormBorderStyle.None, // Formun kenarlığını kaldırır
                Dock = DockStyle.Fill // Formu panelin içinde doldurur
            };
            panelContent.Controls.Add(form); // Formu panele ekler
            form.Show(); // Formu gösterir
        }
    }
}
