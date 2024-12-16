using System;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Management;
using System.Net;

namespace SysInspector
{
    public partial class SystemInformationForm : Form
    {
        public SystemInformationForm()
        {
            InitializeComponent();
        }

        // btnGetSystemInfo butonuna tıklama event handler'ı
        private void btnGetSystemInfo_Click(object sender, EventArgs e)
        {
            // Log dosyasının yolu
            string logFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SysInspector", "SystemInformation_log.txt");
            Directory.CreateDirectory(Path.GetDirectoryName(logFilePath)); // Dizin yoksa oluşturur

            using (StreamWriter writer = new StreamWriter(logFilePath, true)) // Log dosyasına ekleme modunda yazar
            {
                writer.WriteLine("====================================");
                writer.WriteLine("System Information Log - " + DateTime.Now);
                writer.WriteLine("====================================");
                writer.WriteLine();

                writer.WriteLine("Checking DNS Client info..."); // DNS istemci bilgilerini kontrol eder
                string dnsInfo = GetDnsClientInfo();
                writer.WriteLine(dnsInfo);
                textBoxSystemInfo.AppendText("DNS Client info:\n" + dnsInfo + "\n");

                writer.WriteLine("Checking active network adapters..."); // Aktif ağ adaptörlerini kontrol eder
                string networkAdapters = GetActiveNetworkAdapters();
                writer.WriteLine(networkAdapters);
                textBoxSystemInfo.AppendText("Active network adapters:\n" + networkAdapters + "\n");

                writer.WriteLine("Checking system info (e.g., BIOS Mode, TPM status, Device model, OS version, TimeZone)..."); // Sistem bilgilerini kontrol eder
                string systemInfo = GetSystemInfo();
                writer.WriteLine(systemInfo);
                textBoxSystemInfo.AppendText("System info:\n" + systemInfo + "\n");

                writer.WriteLine("Checking active sessions..."); // Aktif oturumları kontrol eder
                string activeSessions = GetActiveSessions();
                writer.WriteLine(activeSessions);
                textBoxSystemInfo.AppendText("Active sessions:\n" + activeSessions + "\n");

                writer.WriteLine("====================================");
                writer.WriteLine("System Information retrieval completed.");
                writer.WriteLine("====================================");
                writer.WriteLine();
            }
        }

        // DNS istemci bilgilerini alan metod
        private string GetDnsClientInfo()
        {
            string dnsInfo = "";
            try
            {
                NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface adapter in adapters)
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    foreach (IPAddress dns in properties.DnsAddresses)
                    {
                        dnsInfo += "DNS Address: " + dns.ToString() + Environment.NewLine;
                    }
                }
            }
            catch (Exception ex)
            {
                dnsInfo = "Error retrieving DNS info: " + ex.Message;
            }
            return dnsInfo;
        }

        // Aktif ağ adaptörlerini alan metod
        private string GetActiveNetworkAdapters()
        {
            string adapterInfo = "";
            try
            {
                NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface adapter in adapters)
                {
                    if (adapter.OperationalStatus == OperationalStatus.Up)
                    {
                        adapterInfo += "Name: " + adapter.Name + Environment.NewLine;
                        adapterInfo += "Description: " + adapter.Description + Environment.NewLine;
                        adapterInfo += "MAC Address: " + adapter.GetPhysicalAddress().ToString() + Environment.NewLine;

                        IPInterfaceProperties properties = adapter.GetIPProperties();
                        foreach (UnicastIPAddressInformation ip in properties.UnicastAddresses)
                        {
                            adapterInfo += "IP Address: " + ip.Address.ToString() + Environment.NewLine;
                        }

                        adapterInfo += "-------------------------------" + Environment.NewLine;
                    }
                }
            }
            catch (Exception ex)
            {
                adapterInfo = "Error retrieving network adapter info: " + ex.Message;
            }
            return adapterInfo;
        }

        // Aktif oturumları alan metod
        private string GetActiveSessions()
        {
            string sessionInfo = "";
            try
            {
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_LogonSession WHERE LogonType = 2");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                ManagementObjectCollection sessions = searcher.Get();

                foreach (ManagementObject session in sessions)
                {
                    string sessionId = session["LogonId"].ToString();
                    ObjectQuery userQuery = new ObjectQuery($"ASSOCIATORS OF {{Win32_LogonSession.LogonId={sessionId}}} WHERE AssocClass=Win32_LoggedOnUser Role=Dependent");
                    ManagementObjectSearcher userSearcher = new ManagementObjectSearcher(userQuery);
                    ManagementObjectCollection users = userSearcher.Get();

                    foreach (ManagementObject user in users)
                    {
                        sessionInfo += "User: " + user["Name"].ToString() + Environment.NewLine;
                    }
                    sessionInfo += "Logon ID: " + sessionId + Environment.NewLine;
                    sessionInfo += "Logon Time: " + ManagementDateTimeConverter.ToDateTime(session["StartTime"].ToString()) + Environment.NewLine;
                    sessionInfo += "-------------------------------" + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                sessionInfo = "Error retrieving session info: " + ex.Message;
            }
            return sessionInfo;
        }

        // Sistem bilgilerini alan metod
        private string GetSystemInfo()
        {
            string systemInfo = "";
            try
            {
                systemInfo += "BIOS Mode: " + GetBiosMode() + Environment.NewLine;
                systemInfo += "TPM Status: " + GetTpmStatus() + Environment.NewLine;
                systemInfo += "Device Model: " + GetDeviceModel() + Environment.NewLine;
                systemInfo += "OS Version: " + Environment.OSVersion.ToString() + Environment.NewLine;
                systemInfo += "TimeZone: " + TimeZoneInfo.Local.DisplayName + Environment.NewLine;
                systemInfo += "Processor Count: " + Environment.ProcessorCount + Environment.NewLine;
                systemInfo += "System Page Size: " + Environment.SystemPageSize + Environment.NewLine;
                systemInfo += "User Domain Name: " + Environment.UserDomainName + Environment.NewLine;
                systemInfo += "User Name: " + Environment.UserName + Environment.NewLine;
                systemInfo += "Machine Name: " + Environment.MachineName + Environment.NewLine;
                systemInfo += "System Directory: " + Environment.SystemDirectory + Environment.NewLine;
                systemInfo += "Tick Count: " + Environment.TickCount + Environment.NewLine;
                systemInfo += "64-bit OS: " + Environment.Is64BitOperatingSystem + Environment.NewLine;
                systemInfo += "64-bit Process: " + Environment.Is64BitProcess + Environment.NewLine;
                systemInfo += GetProcessorInfo();
                systemInfo += GetDiskDrives();
                systemInfo += GetMemoryInfo();
                systemInfo += GetNetworkInterfaces();
            }
            catch (Exception ex)
            {
                systemInfo = "Error retrieving system info: " + ex.Message;
            }
            return systemInfo;
        }

        // BIOS modunu alan metod
        private string GetBiosMode()
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS"))
                {
                    foreach (ManagementObject bios in searcher.Get())
                    {
                        return bios["BIOSVersion"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error retrieving BIOS mode: " + ex.Message;
            }
            return "Unknown";
        }

        // TPM durumunu alan metod
        private string GetTpmStatus()
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Tpm"))
                {
                    foreach (ManagementObject tpm in searcher.Get())
                    {
                        return tpm["IsEnabled_InitialValue"].ToString() == "True" ? "Enabled" : "Disabled";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error retrieving TPM status: " + ex.Message;
            }
            return "Unknown";
        }

        // Cihaz modelini alan metod
        private string GetDeviceModel()
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem"))
                {
                    foreach (ManagementObject system in searcher.Get())
                    {
                        return system["Model"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error retrieving device model: " + ex.Message;
            }
            return "Unknown";
        }

        // İşlemci bilgilerini alan metod
        private string GetProcessorInfo()
        {
            string processorInfo = "";
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor"))
                {
                    foreach (ManagementObject processor in searcher.Get())
                    {
                        processorInfo += "Name: " + processor["Name"].ToString() + Environment.NewLine;
                        processorInfo += "Manufacturer: " + processor["Manufacturer"].ToString() + Environment.NewLine;
                        processorInfo += "Description: " + processor["Description"].ToString() + Environment.NewLine;
                        processorInfo += "ProcessorId: " + processor["ProcessorId"].ToString() + Environment.NewLine;
                        processorInfo += "Architecture: " + processor["Architecture"].ToString() + Environment.NewLine;
                        processorInfo += "NumberOfCores: " + processor["NumberOfCores"].ToString() + Environment.NewLine;
                        processorInfo += "NumberOfLogicalProcessors: " + processor["NumberOfLogicalProcessors"].ToString() + Environment.NewLine;
                        processorInfo += "MaxClockSpeed: " + processor["MaxClockSpeed"].ToString() + " MHz" + Environment.NewLine;
                        processorInfo += "CurrentClockSpeed: " + processor["CurrentClockSpeed"].ToString() + " MHz" + Environment.NewLine;
                        processorInfo += "L2CacheSize: " + processor["L2CacheSize"].ToString() + " KB" + Environment.NewLine;
                        processorInfo += "L3CacheSize: " + processor["L3CacheSize"].ToString() + " KB" + Environment.NewLine;
                        processorInfo += "--------------------------------" + Environment.NewLine;
                    }
                }
            }
            catch (Exception ex)
            {
                processorInfo = "Error retrieving processor info: " + ex.Message;
            }
            return processorInfo;
        }

        // Disk sürücülerini alan metod
        private string GetDiskDrives()
        {
            string diskInfo = "";
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive"))
                {
                    foreach (ManagementObject disk in searcher.Get())
                    {
                        diskInfo += "Model: " + disk["Model"].ToString() + Environment.NewLine;
                        diskInfo += "InterfaceType: " + disk["InterfaceType"].ToString() + Environment.NewLine;
                        diskInfo += "MediaType: " + disk["MediaType"].ToString() + Environment.NewLine;
                        diskInfo += "Size: " + (Convert.ToInt64(disk["Size"]) / (1024 * 1024 * 1024)) + " GB" + Environment.NewLine;
                        diskInfo += "Partitions: " + disk["Partitions"].ToString() + Environment.NewLine;
                        diskInfo += "--------------------------------" + Environment.NewLine;
                    }
                }
            }
            catch (Exception ex)
            {
                diskInfo = "Error retrieving disk info: " + ex.Message;
            }
            return diskInfo;
        }

        // Bellek bilgilerini alan metod
        private string GetMemoryInfo()
        {
            string memoryInfo = "";
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory"))
                {
                    foreach (ManagementObject memory in searcher.Get())
                    {
                        memoryInfo += "Capacity: " + (Convert.ToInt64(memory["Capacity"]) / (1024 * 1024 * 1024)) + " GB" + Environment.NewLine;
                        memoryInfo += "Speed: " + memory["Speed"].ToString() + " MHz" + Environment.NewLine;
                        memoryInfo += "Manufacturer: " + memory["Manufacturer"].ToString() + Environment.NewLine;
                        memoryInfo += "SerialNumber: " + memory["SerialNumber"].ToString() + Environment.NewLine;
                        memoryInfo += "--------------------------------" + Environment.NewLine;
                    }
                }
            }
            catch (Exception ex)
            {
                memoryInfo = "Error retrieving memory info: " + ex.Message;
            }
            return memoryInfo;
        }

        // Ağ arayüzlerini alan metod
        private string GetNetworkInterfaces()
        {
            string networkInfo = "";
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapter WHERE NetConnectionStatus=2"))
                {
                    foreach (ManagementObject adapter in searcher.Get())
                    {
                        networkInfo += "Name: " + adapter["Name"].ToString() + Environment.NewLine;
                        networkInfo += "MAC Address: " + adapter["MACAddress"].ToString() + Environment.NewLine;
                        networkInfo += "Speed: " + adapter["Speed"].ToString() + " bps" + Environment.NewLine;
                        networkInfo += "AdapterType: " + adapter["AdapterType"].ToString() + Environment.NewLine;
                        networkInfo += "Manufacturer: " + adapter["Manufacturer"].ToString() + Environment.NewLine;
                        networkInfo += "--------------------------------" + Environment.NewLine;
                    }
                }
            }
            catch (Exception ex)
            {
                networkInfo = "Error retrieving network interface info: " + ex.Message;
            }
            return networkInfo;
        }
    }
}
