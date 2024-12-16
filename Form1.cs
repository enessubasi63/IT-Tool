using System;
using System.Windows.Forms;

namespace SysInspector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Form yüklendiğinde çalışan event handler
        private void Form1_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde ilk sekmeyi kontrol eder ve ilgili formu gösterir
            if (tabControl1.SelectedTab == tabPageTroubleshoot)
            {
                ShowTroubleshootForm();
            }
            else if (tabControl1.SelectedTab == tabPageServiceManager)
            {
                ShowServiceManagerForm();
            }
            else if (tabControl1.SelectedTab == tabPageUrlAnalyzer)
            {
                ShowUrlAnalyzerForm();
            }
            else if (tabControl1.SelectedTab == tabPageOtherTools)
            {
                ShowOtherToolsForm();
            }
        }

        // TabControl'deki seçili sekme değiştiğinde çalışan event handler
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Yeni seçilen sekmeyi kontrol eder ve ilgili formu gösterir
            if (tabControl1.SelectedTab == tabPageTroubleshoot)
            {
                ShowTroubleshootForm();
            }
            else if (tabControl1.SelectedTab == tabPageServiceManager)
            {
                ShowServiceManagerForm();
            }
            else if (tabControl1.SelectedTab == tabPageUrlAnalyzer)
            {
                ShowUrlAnalyzerForm();
            }
            else if (tabControl1.SelectedTab == tabPageOtherTools)
            {
                ShowOtherToolsForm();
            }
        }

        // Troubleshoot formunu gösteren metod
        private void ShowTroubleshootForm()
        {
            TroubleshootForm troubleshootForm = new TroubleshootForm();
            troubleshootForm.TopLevel = false; // Formun parent formu içinde yer almasını sağlar
            troubleshootForm.FormBorderStyle = FormBorderStyle.None; // Formun kenarlığını kaldırır
            troubleshootForm.Dock = DockStyle.Fill; // Formun parent container içinde doldurulmasını sağlar
            tabPageTroubleshoot.Controls.Add(troubleshootForm); // Formu ilgili tabPage'e ekler
            tabPageTroubleshoot.Tag = troubleshootForm; // Formu tabPage'in Tag propertysine atar
            troubleshootForm.Show(); // Formu gösterir
        }

        // Service Manager formunu gösteren metod
        private void ShowServiceManagerForm()
        {
            ServiceManagerForm serviceManagerForm = new ServiceManagerForm();
            serviceManagerForm.TopLevel = false; // Formun parent formu içinde yer almasını sağlar
            serviceManagerForm.FormBorderStyle = FormBorderStyle.None; // Formun kenarlığını kaldırır
            serviceManagerForm.Dock = DockStyle.Fill; // Formun parent container içinde doldurulmasını sağlar
            tabPageServiceManager.Controls.Add(serviceManagerForm); // Formu ilgili tabPage'e ekler
            tabPageServiceManager.Tag = serviceManagerForm; // Formu tabPage'in Tag propertysine atar
            serviceManagerForm.Show(); // Formu gösterir
        }

        // URL Analyzer formunu gösteren metod
        private void ShowUrlAnalyzerForm()
        {
            UrlAnalyzer urlAnalyzerForm = new UrlAnalyzer();
            urlAnalyzerForm.TopLevel = false; // Formun parent formu içinde yer almasını sağlar
            urlAnalyzerForm.FormBorderStyle = FormBorderStyle.None; // Formun kenarlığını kaldırır
            urlAnalyzerForm.Dock = DockStyle.Fill; // Formun parent container içinde doldurulmasını sağlar
            tabPageUrlAnalyzer.Controls.Add(urlAnalyzerForm); // Formu ilgili tabPage'e ekler
            tabPageUrlAnalyzer.Tag = urlAnalyzerForm; // Formu tabPage'in Tag propertysine atar
            urlAnalyzerForm.Show(); // Formu gösterir
        }


        // Other Tools formunu gösteren metod
        private void ShowOtherToolsForm()
        {
            OtherToolsForm otherToolsForm = new OtherToolsForm();
            otherToolsForm.TopLevel = false; // Formun parent formu içinde yer almasını sağlar
            otherToolsForm.FormBorderStyle = FormBorderStyle.None; // Formun kenarlığını kaldırır
            otherToolsForm.Dock = DockStyle.Fill; // Formun parent container içinde doldurulmasını sağlar
            tabPageOtherTools.Controls.Add(otherToolsForm); // Formu ilgili tabPage'e ekler
            tabPageOtherTools.Tag = otherToolsForm; // Formu tabPage'in Tag propertysine atar
            otherToolsForm.Show(); // Formu gösterir
        }
    }
}
