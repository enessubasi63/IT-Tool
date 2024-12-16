# IT Tool

![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)
![.NET](https://img.shields.io/badge/.NET-Framework-blue.svg)
![C#](https://img.shields.io/badge/C%23-programming_language-blue.svg)

## **Table of Contents**

- [Overview](#overview)
- [Features](#features)
- [Architecture](#architecture)
- [Installation](#installation)
- [Usage](#usage)
- [Modules](#modules)
  - [1. Troubleshoot](#1-troubleshoot)
  - [2. URL Analyzer](#2-url-analyzer)
  - [3. Service Manager](#3-service-manager)
  - [4. Other Tools](#4-other-tools)
    - [4.1 Azure Check](#41-azure-check)
    - [4.2 Hostname Management](#42-hostname-management)
      - [4.2.1 Hostname Controller](#421-hostname-controller)
      - [4.2.2 No IP Resolution](#422-no-ip-resolution)
      - [4.2.3 Hostname Verification](#423-hostname-verification)
    - [4.3 Telnet Tool](#43-telnet-tool)
    - [4.4 Cache Clearing](#44-cache-clearing)
    - [4.5 AD Query](#45-ad-query)
- [Contributing](#contributing)
- [License](#license)
- [Acknowledgements](#acknowledgements)

---

## **Overview**

**IT Tool** is an advanced Windows Forms application meticulously crafted to streamline and automate the daily operations of IT professionals. Developed by the Urfa IT team for the MPlus IT department, this comprehensive tool amalgamates various management, analysis, and troubleshooting functionalities into a single, cohesive platform. Leveraging the power of C# and the .NET Framework, IT Tool offers a robust and user-friendly interface designed to enhance efficiency, reduce manual workloads, and ensure seamless IT operations within a Windows-based environment.

---

## **Features**

- **Multi-Tab Interface:** Organize and access different tools and functionalities through a structured tabbed layout.
- **Automated Troubleshooting:** Perform comprehensive network and service diagnostics with just a few clicks.
- **URL Analysis:** Analyze URLs for link accessibility, resource integrity, and port availability.
- **Service Management:** Manage Windows services effortlessly, including starting, stopping, and restarting services.
- **Extensive Toolset:** Access a variety of auxiliary tools such as Azure AD checks, hostname management, Telnet operations, cache clearing, and Active Directory queries.
- **Asynchronous Operations:** Ensure a responsive user interface by executing time-consuming tasks asynchronously.
- **Logging & Reporting:** Save logs of all operations for future reference and auditing purposes.
- **PowerShell Integration:** Execute advanced system commands and scripts directly from the application.
- **User-Friendly UI:** Intuitive design with clear indicators, progress bars, and detailed result displays.

---

## **Architecture**

IT Tool is architected as a modular Windows Forms application, promoting scalability and maintainability. The application is structured into distinct modules, each encapsulating specific functionalities. The primary components include:

- **Main Form (Form1):** Serves as the entry point, housing the TabControl that navigates between different modules.
- **Modules:** Each module is implemented as a separate form, handling specialized tasks such as troubleshooting, URL analysis, service management, and more.
- **Utility Classes:** Encapsulate common functionalities like PowerShell script execution, directory services interactions, and asynchronous operations.

### **Technologies Used**

- **Language:** C#
- **Framework:** .NET Framework
- **UI Library:** Windows Forms
- **Libraries:**
  - **HtmlAgilityPack:** For parsing and analyzing HTML content.
  - **System.DirectoryServices:** For interacting with Active Directory.
  - **System.ServiceProcess:** For managing Windows services.
  - **System.Net.NetworkInformation:** For network-related operations.
  - **System.Management:** For system management tasks.
- **Version Control:** GitHub for source code management and collaboration.

---

## **Installation**

### **Prerequisites**

- **Operating System:** Windows 7 or later
- **.NET Framework:** Version 4.7.2 or higher
- **Development Environment:** Visual Studio 2019 or later (for building from source)

### **Steps**

1. **Clone the Repository**

   ```bash
   git clone https://github.com/YourGitHubUsername/IT-Tool.git
   ```

2. **Open the Solution**

   - Launch **Visual Studio**.
   - Navigate to **File > Open > Project/Solution**.
   - Select the `IT-Tool.sln` file from the cloned repository.

3. **Restore NuGet Packages**

   - Right-click on the solution in the **Solution Explorer**.
   - Select **Restore NuGet Packages** to ensure all dependencies are resolved.

4. **Build the Project**

   - Set the `IT Tool` project as the **Startup Project**.
   - Click **Build > Build Solution** or press `Ctrl+Shift+B`.

5. **Run the Application**

   - Start the application by pressing `F5` or clicking the **Start** button in Visual Studio.

---

## **Usage**

Upon launching **IT Tool**, users are greeted with a multi-tabbed interface, each tab representing a distinct module designed to handle specific IT tasks. Below is a detailed guide on navigating and utilizing each module effectively.

### **1. Troubleshoot**

#### **Purpose**

The **Troubleshoot** module is designed to perform comprehensive diagnostics on network ports, Windows services, and system configurations. It caters to both finance and non-finance environments, ensuring tailored troubleshooting based on the selected context.

#### **How to Use**

1. **Select Mode:**
   - Choose between **Finance** or **Non-Finance** modes using the radio buttons.

2. **Start Troubleshooting:**
   - Click the **Start Troubleshoot** button to initiate the diagnostic process.

3. **View Results:**
   - Results are displayed in a `DataGridView`, detailing each check's status.

### **2. URL Analyzer**

#### **Purpose**

The **URL Analyzer** module analyzes specified URLs to verify the accessibility of links, resources, and ports. It provides insights into the integrity and availability of web resources.

#### **How to Use**

1. **Enter URL:**
   - Input the target URL in the provided text box.

2. **Analyze:**
   - Click the **Analyze** button to commence the analysis.

3. **Monitor Progress:**
   - A `ProgressBar` indicates the analysis progress.

4. **Review Results:**
   - Detailed results are displayed in a `DataGridView`, including link and resource statuses.

### **3. Service Manager**

#### **Purpose**

The **Service Manager** module facilitates the management of Windows services. Users can start, stop, restart, and monitor the status of various services directly from the application.

#### **How to Use**

1. **View Services:**
   - The `ListView` displays all installed Windows services with their statuses.

2. **Manage Services:**
   - Select a service from the list and choose to **Start**, **Stop**, or **Restart** using the corresponding buttons.

3. **Search Services:**
   - Utilize the search functionality to filter services by name or display name.

### **4. Other Tools**

The **Other Tools** module serves as a hub for auxiliary tools, each addressing specific IT needs. The available tools include:

#### **4.1 Azure Check**

##### **Purpose**

Verify if a device is joined to Azure Active Directory (Azure AD) and facilitate the joining process if necessary.

##### **How to Use**

1. **Check Azure Join Status:**
   - Click the **Check Azure Join** button to determine the device's Azure AD status.

2. **Join Azure AD:**
   - If the device is not joined, the **Join Azure** button becomes visible. Click it to initiate the Azure AD joining process.

3. **View Results:**
   - Results are displayed in the text box, indicating the success or failure of the operations.

#### **4.2 Hostname Management**

Hostname Management comprises three sub-tools: **Hostname Controller**, **No IP Resolution**, and **Hostname Verification**.

##### **4.2.1 Hostname Controller**

###### **Purpose**

Generate and verify hostnames based on a specified project prefix, ensuring they are registered within the domain.

###### **How to Use**

1. **Enter Project Prefix and Count:**
   - Input the project prefix and the number of hostnames to check.

2. **Initiate Check:**
   - Click the **Check Hostname** button to start the verification process.

3. **Review Results:**
   - Results are displayed in the `ListView`, highlighting hostnames not present in the domain.

##### **4.2.2 No IP Resolution**

###### **Purpose**

Identify hostnames that are part of the domain but fail to resolve to an IP address, assisting in network troubleshooting.

###### **How to Use**

1. **Enter Hostname Prefix and Count:**
   - Provide the hostname prefix and the number of devices to check.

2. **Log No IP Devices:**
   - Click the **Log No IP Devices** button to perform the check.

3. **Save Logs:**
   - Save the results using the **Save Log** button for future reference.

##### **4.2.3 Hostname Verification**

###### **Purpose**

Manually verify a list of hostnames to determine their domain membership and IP resolution status.

###### **How to Use**

1. **Enter Hostnames:**
   - Input a comma-separated list of hostnames to verify.

2. **Verify Hostnames:**
   - Click the **Verify Hostnames** button to start the verification process.

3. **View Categorized Results:**
   - Results are categorized and displayed in separate `ListView` controls:
     - **Not in Domain**
     - **In Domain with IP**
     - **In Domain without IP**

4. **Export Results:**
   - Use the export buttons to save the results to text files.

#### **4.3 Telnet Tool**

##### **Purpose**

Perform Telnet and Ping operations on multiple IP addresses and ports to assess network connectivity and service availability.

##### **How to Use**

1. **Enter IPs and Port:**
   - Input a comma-separated list of IP addresses and specify the target port.

2. **Execute Telnet:**
   - Click the **Telnet** button to attempt connections to each IP-port pair.

3. **View Telnet Results:**
   - Results are displayed in the `ListView`, indicating successful or failed connections.

4. **Enable Telnet Client:**
   - If Telnet Client is not enabled, click the **Enable Telnet** button to install it via PowerShell.

5. **Assign IPs:**
   - Input IP addresses for Ping operations and click **Assign IP** to check their reachability.

6. **Save Logs:**
   - Use the **Save Log** buttons to export Telnet and Ping results.

#### **4.4 Cache Clearing**

##### **Purpose**

Clear various system caches to optimize performance and free up disk space by removing temporary files from RAM, browsers, and Microsoft Office.

##### **How to Use**

1. **Select Cache Types:**
   - Choose the caches you wish to clear by selecting the corresponding checkboxes:
     - **RAM Cleaning**
     - **Browser Cleaning**
     - **Microsoft Office Cleaning**

2. **Clear Cache:**
   - Click the **Clear Cache** button to initiate the selected cache clearing operations.

3. **View Results:**
   - Results and any encountered errors are displayed in the text box.

#### **4.5 AD Query**

##### **Purpose**

Search and retrieve user account information from Active Directory, facilitating user management and auditing.

##### **How to Use**

1. **Enter Username:**
   - Input the username to search within Active Directory.

2. **Execute Search:**
   - Click the **Search** button or press **Enter** to perform the search.

3. **View Results:**
   - Results are displayed in the `DataGridView`, showing details such as:
     - **Name**
     - **User Logon Name**
     - **State**
     - **Description**

4. **Copy Information:**
   - Click the **Copy** button in the respective row to copy the user logon name and description to the clipboard.

---

## **Modules**

### **1. Troubleshoot**

#### **Purpose**

The **Troubleshoot** module is designed to perform comprehensive diagnostics on network ports, Windows services, and system configurations. It caters to both finance and non-finance environments, ensuring tailored troubleshooting based on the selected context.

#### **Key Functionalities**

- **Finance/Non-Finance Modes:** Select the operational context to execute relevant diagnostic checks.
- **Port Connectivity Checks:** Validate the accessibility of critical network ports using Telnet.
- **Service Status Monitoring:** Check the status of essential Windows services like Windows Time, NetBIOS, and IPv6.
- **Automated Reporting:** Display results in a structured `DataGridView` for easy interpretation.

#### **Technical Details**

- **Asynchronous Operations:** Utilizes `TcpClient` for Telnet connections and `Ping` for network reachability checks, executed asynchronously to maintain a responsive UI.
- **Service Management:** Leverages `ServiceController` to query and monitor Windows services.
- **System Configuration Checks:** Implements `ManagementObjectSearcher` for NetBIOS and IPv6 status verification.

---

### **2. URL Analyzer**

#### **Purpose**

The **URL Analyzer** module scrutinizes specified URLs to ensure the accessibility and integrity of embedded links, scripts, images, and other resources. It also verifies the responsiveness of specific ports associated with the target URL.

#### **Key Functionalities**

- **Resource Parsing:** Extract and validate links, scripts, and images within the provided URL using `HtmlAgilityPack`.
- **Port Accessibility Testing:** Assess the accessibility of critical ports (80, 443, 8122) on the target server.
- **Progress Tracking:** Utilize a `ProgressBar` to provide real-time feedback on the analysis process.
- **Detailed Reporting:** Present comprehensive results in a `DataGridView`, highlighting accessible and inaccessible resources.

#### **Technical Details**

- **HTML Parsing:** Employs `HtmlAgilityPack` to parse and navigate the HTML structure of the target URL.
- **Asynchronous Networking:** Uses `HttpClient` for fetching content and `TcpClient` for port testing, ensuring non-blocking operations.
- **Error Handling:** Implements robust exception handling to gracefully manage network-related errors and provide meaningful feedback.

---

### **3. Service Manager**

#### **Purpose**

The **Service Manager** module empowers IT administrators to efficiently manage Windows services. It offers functionalities to start, stop, restart, and monitor the status of various services, enhancing system administration capabilities.

#### **Key Functionalities**

- **Service Listing:** Display all installed Windows services with details such as service name, display name, status, and startup type.
- **Service Control:** Provide options to start, stop, or restart selected services directly from the interface.
- **Search and Highlight:** Enable quick filtering of services based on name or display name for streamlined management.
- **Real-Time Updates:** Refresh the service list to reflect the current state after any control operation.

#### **Technical Details**

- **Service Interaction:** Utilizes the `ServiceController` class to interact with Windows services, facilitating control operations and status queries.
- **User Interface:** Implements a `ListView` to present service information in an organized and readable format.
- **Error Management:** Incorporates exception handling to manage and report errors encountered during service control operations.

---

### **4. Other Tools**

The **Other Tools** module serves as a centralized hub for auxiliary tools, each addressing specific IT needs. This modular approach enhances the application's extensibility and ensures that a wide range of IT tasks can be performed within a single interface.

#### **4.1 Azure Check**

##### **Purpose**

Verify if a device is joined to Azure Active Directory (Azure AD) and facilitate the joining process if it is not. This tool assists in managing device compliance and integration within an Azure-centric environment.

##### **Key Functionalities**

- **Azure AD Status Check:** Execute PowerShell scripts to determine the Azure AD join status of the device.
- **Azure AD Join:** If the device is not joined, initiate the Azure AD joining process through PowerShell commands.
- **Result Display:** Present the outcomes of the checks and join operations within a dedicated text box, providing immediate feedback to the user.

##### **Technical Details**

- **PowerShell Integration:** Executes PowerShell scripts using the `Process` class to interact with system commands.
- **Asynchronous Execution:** Ensures that PowerShell commands run without blocking the UI, maintaining application responsiveness.
- **Error Handling:** Captures and displays errors encountered during script execution, facilitating troubleshooting.

---

#### **4.2 Hostname Management**

The **Hostname Management** sub-module encompasses three distinct tools: **Hostname Controller**, **No IP Resolution**, and **Hostname Verification**. Each tool addresses specific aspects of hostname management within a networked environment.

##### **4.2.1 Hostname Controller**

###### **Purpose**

Generate and verify hostnames based on a specified project prefix, ensuring they are registered within the domain. This tool aids in maintaining a consistent and conflict-free naming convention across the network.

###### **Key Functionalities**

- **Hostname Generation:** Create hostnames by appending numerical identifiers to a user-defined project prefix.
- **Domain Verification:** Check if the generated hostnames exist within the Active Directory domain.
- **Result Logging:** Display and log hostnames that are not present in the domain for further action.

###### **Technical Details**

- **Active Directory Interaction:** Uses `DirectoryEntry` and `DirectorySearcher` classes to query Active Directory for hostname existence.
- **Asynchronous Processing:** Performs hostname checks asynchronously to avoid UI freezes during bulk operations.
- **Error Reporting:** Logs any exceptions or errors encountered during the domain verification process.

##### **4.2.2 No IP Resolution**

###### **Purpose**

Identify hostnames that are part of the domain but fail to resolve to an IP address. This tool is essential for diagnosing network issues related to DNS resolution and ensuring all domain devices are reachable.

###### **Key Functionalities**

- **Hostname Verification:** Confirm if hostnames exist within the domain.
- **IP Resolution Check:** Attempt to resolve hostnames to IP addresses using DNS.
- **Result Exporting:** Save the list of hostnames without IP resolution to a text file for auditing and remediation.

###### **Technical Details**

- **Concurrent Processing:** Employs `Parallel.ForEach` and `ConcurrentBag` for efficient processing of multiple hostnames.
- **DNS Operations:** Utilizes the `Dns.GetHostEntry` method to perform IP resolution.
- **Logging Mechanism:** Maintains a log file to record the progress and results of the operations.

##### **4.2.3 Hostname Verification**

###### **Purpose**

Manually verify a list of hostnames to determine their domain membership and IP resolution status. This tool provides a detailed categorization of hostnames, facilitating targeted network maintenance.

###### **Key Functionalities**

- **Manual Input:** Accept a comma-separated list of hostnames for verification.
- **Categorized Results:** Classify hostnames into three categories:
  - **Not in Domain**
  - **In Domain with IP**
  - **In Domain without IP**
- **Export Options:** Allow users to export each category of results to separate text files for reporting purposes.

###### **Technical Details**

- **Active Directory Queries:** Similar to other hostname tools, utilizes `DirectoryEntry` and `DirectorySearcher` for domain verification.
- **DNS Resolution:** Checks IP resolution using the `Dns.GetHostEntry` method.
- **User Feedback:** Provides real-time progress updates via a `ProgressBar` and categorizes results in multiple `ListView` controls.

---

#### **4.3 Telnet Tool**

##### **Purpose**

Perform Telnet and Ping operations on multiple IP addresses and ports to assess network connectivity and service availability. This tool is crucial for network diagnostics and ensuring the operational status of various services.

##### **Key Functionalities**

- **Telnet Connectivity:** Attempt to establish Telnet connections to specified IP-port pairs.
- **Ping Tests:** Conduct Ping operations to verify the reachability of IP addresses.
- **Telnet Client Activation:** Provide an option to enable the Telnet Client on the system via PowerShell.
- **Result Logging:** Save Telnet and Ping operation results to text files for analysis and record-keeping.

##### **Technical Details**

- **Asynchronous Networking:** Implements asynchronous methods using `TcpClient` and `Ping` classes to handle multiple network operations concurrently.
- **PowerShell Scripting:** Executes PowerShell commands to enable the Telnet Client when required.
- **User Interface Integration:** Displays results in `ListView` controls, updating statuses in real-time.
- **Error Handling:** Captures and logs errors encountered during network operations, ensuring users are informed of any connectivity issues.

---

#### **4.4 Cache Clearing**

##### **Purpose**

Clear various system caches to optimize performance and free up disk space by removing temporary files from RAM, browsers, and Microsoft Office applications. This tool helps maintain system efficiency and resolves issues caused by corrupted cache files.

##### **Key Functionalities**

- **RAM Cache Clearing:** Remove temporary files from `AppData\Local\Temp` and `Windows\Temp` directories.
- **Browser Cache Clearing:** Delete cached data from browsers, specifically targeting the Google Chrome cache directory.
- **Microsoft Office Cache Clearing:** Clear temporary files from Microsoft Office applications to prevent performance degradation.
- **Result Display:** Provide real-time feedback on cache clearing operations within a text box, indicating success or detailing any errors encountered.

##### **Technical Details**

- **Directory Management:** Utilizes `DirectoryInfo` to navigate and manage file system directories.
- **File and Directory Deletion:** Implements robust methods to delete files and directories, handling exceptions to prevent application crashes.
- **User Feedback:** Continuously updates the user on the status of cache clearing operations, ensuring transparency and accountability.

---

#### **4.5 AD Query**

##### **Purpose**

Search and retrieve user account information from Active Directory, facilitating user management and auditing processes. This tool allows IT administrators to query user details efficiently and copy relevant information for reporting or documentation purposes.

##### **Key Functionalities**

- **User Search:** Input a username to search within Active Directory and retrieve associated user information.
- **Detailed Results:** Display user details such as Name, User Logon Name, State, and Description in a `DataGridView`.
- **Clipboard Integration:** Enable copying of user logon names and descriptions directly to the clipboard for easy transfer to other applications.
- **Interactive UI:** Provide an intuitive interface with search functionality triggered by button clicks or the Enter key.

##### **Technical Details**

- **Active Directory Integration:** Leverages `DirectoryEntry` and `DirectorySearcher` for querying user information within the AD.
- **Data Presentation:** Utilizes `DataGridView` for organized and sortable display of user data.
- **Clipboard Operations:** Implements clipboard functionality to allow users to copy selected data seamlessly.
- **Error Handling:** Ensures that any errors during the search process are captured and communicated to the user effectively.

---

## **Contributing**

Contributions are highly encouraged and appreciated! To contribute to **IT Tool**, please follow the guidelines below:

1. **Fork the Repository**
   - Click the **Fork** button at the top-right corner of this repository page to create a personal copy.

2. **Clone the Fork**
   - Clone your forked repository to your local machine:
     ```bash
     git clone https://github.com/YourGitHubUsername/IT-Tool.git
     ```

3. **Create a Branch**
   - Navigate to the project directory and create a new branch for your feature or bugfix:
     ```bash
     git checkout -b feature/YourFeatureName
     ```

4. **Make Changes**
   - Implement your changes or add new features. Ensure that your code adheres to the project's coding standards and practices.

5. **Commit Changes**
   - Commit your changes with clear and descriptive messages:
     ```bash
     git commit -m "Add detailed logging to Telnet Tool"
     ```

6. **Push to Your Fork**
   - Push your changes to your forked repository:
     ```bash
     git push origin feature/YourFeatureName
     ```

7. **Create a Pull Request**
   - Navigate to the original repository on GitHub and click the **Compare & pull request** button.
   - Provide a clear and concise description of your changes, referencing any related issues.

8. **Review and Feedback**
   - The maintainers will review your pull request. Be prepared to make any necessary revisions based on feedback.

---

## **License**

This project is licensed under the **MIT License**. You are free to use, modify, and distribute this software as long as you include the original license and copyright notice.

---


## **Acknowledgements**

- **.NET Foundation:** For providing the robust .NET Framework.
- **HtmlAgilityPack Contributors:** For developing the HTML parsing library.
- **Open Source Community:** For their invaluable contributions to the tools and libraries used in this project.
- **MPlus IT Team:** For their continuous support and feedback during the development of this application.

---

**Thank you for choosing IT Tool!**  
We hope this application enhances your IT operations, providing a unified and efficient platform for all your management and troubleshooting needs. Your feedback and contributions are instrumental in making IT Tool even better.
