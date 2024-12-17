using System;
using System.ServiceProcess;
using System.Windows.Forms;

namespace SysInspector
{
    public partial class ServiceManagerForm : Form
    {
        public ServiceManagerForm()
        {
            InitializeComponent();
            LoadServices(); // Servisleri yükler
        }

        // Servisleri listeye yükleyen metod
        private void LoadServices()
        {
            listViewServices.Items.Clear(); // Listeyi temizler
            ServiceController[] services = ServiceController.GetServices(); // Tüm servisleri alır

            foreach (ServiceController service in services)
            {
                ListViewItem item = new ListViewItem(service.ServiceName); // Servis adını ekler
                item.SubItems.Add(service.DisplayName); // Servis görüntü adını ekler
                item.SubItems.Add(service.Status.ToString()); // Servis durumunu ekler
                item.SubItems.Add(service.StartType.ToString()); // Servis başlangıç tipini ekler
                listViewServices.Items.Add(item); // Liste öğesini ekler
            }
        }

        // Servisi başlatan butonun tıklama event handler'ı
        private void btnStartService_Click(object sender, EventArgs e)
        {
            if (listViewServices.SelectedItems.Count > 0) // Seçili öğe varsa
            {
                string serviceName = listViewServices.SelectedItems[0].SubItems[0].Text; // Servis adını alır
                ServiceController service = new ServiceController(serviceName); // Servis kontrolcüsü oluşturur
                try
                {
                    service.Start(); // Servisi başlatır
                    service.WaitForStatus(ServiceControllerStatus.Running); // Servisin çalıştığını bekler
                    LoadServices(); // Servisleri yeniden yükler
                    MessageBox.Show($"Service {serviceName} started successfully."); // Başarı mesajı gösterir
                }
                catch (Exception ex) // Hata yakalama bloğu
                {
                    MessageBox.Show($"Failed to start service {serviceName}: {ex.Message}"); // Hata mesajı gösterir
                }
            }
        }

        // Servisi durduran butonun tıklama event handler'ı
        private void btnStopService_Click(object sender, EventArgs e)
        {
            if (listViewServices.SelectedItems.Count > 0) // Seçili öğe varsa
            {
                string serviceName = listViewServices.SelectedItems[0].SubItems[0].Text; // Servis adını alır
                ServiceController service = new ServiceController(serviceName); // Servis kontrolcüsü oluşturur
                try
                {
                    service.Stop(); // Servisi durdurur
                    service.WaitForStatus(ServiceControllerStatus.Stopped); // Servisin durduğunu bekler
                    LoadServices(); // Servisleri yeniden yükler
                    MessageBox.Show($"Service {serviceName} stopped successfully."); // Başarı mesajı gösterir
                }
                catch (Exception ex) // Hata yakalama bloğu
                {
                    MessageBox.Show($"Failed to stop service {serviceName}: {ex.Message}"); // Hata mesajı gösterir
                }
            }
        }

        // Servisi yeniden başlatan butonun tıklama event handler'ı
        private void btnRestartService_Click(object sender, EventArgs e)
        {
            if (listViewServices.SelectedItems.Count > 0) // Seçili öğe varsa
            {
                string serviceName = listViewServices.SelectedItems[0].SubItems[0].Text; // Servis adını alır
                ServiceController service = new ServiceController(serviceName); // Servis kontrolcüsü oluşturur
                try
                {
                    service.Stop(); // Servisi durdurur
                    service.WaitForStatus(ServiceControllerStatus.Stopped); // Servisin durduğunu bekler
                    service.Start(); // Servisi başlatır
                    service.WaitForStatus(ServiceControllerStatus.Running); // Servisin çalıştığını bekler
                    LoadServices(); // Servisleri yeniden yükler
                    MessageBox.Show($"Service {serviceName} restarted successfully."); // Başarı mesajı gösterir
                }
                catch (Exception ex) // Hata yakalama bloğu
                {
                    MessageBox.Show($"Failed to restart service {serviceName}: {ex.Message}"); // Hata mesajı gösterir
                }
            }
        }

        // Servis listesini yenileyen butonun tıklama event handler'ı
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadServices(); // Servisleri yeniden yükler
        }

        // Servis arayan butonun tıklama event handler'ı
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = textBoxSearch.Text.ToLower(); // Arama terimini alır ve küçük harfe çevirir
            foreach (ListViewItem item in listViewServices.Items) // Tüm liste öğelerini döner
            {
                // Arama terimi servis adı veya görüntü adında varsa
                if (item.SubItems[0].Text.ToLower().Contains(searchTerm) ||
                    item.SubItems[1].Text.ToLower().Contains(searchTerm))
                {
                    item.BackColor = System.Drawing.Color.Yellow; // Arka plan rengini sarı yapar
                }
                else
                {
                    item.BackColor = System.Drawing.Color.White; // Arka plan rengini beyaz yapar
                }
            }
        }
    }
}
