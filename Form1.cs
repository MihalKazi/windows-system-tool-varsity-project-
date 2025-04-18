using System;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SystemToolkit_Full
{
    public partial class Form1 : Form
    {
        private Timer performanceTimer = new Timer();
        private PerformanceCounter cpuCounter;
        private PerformanceCounter ramCounter;

        public Form1()
        {
            InitializeComponent();
            InitializePerformanceCounters();
            LoadSystemInfo();
            LoadProcesses();
            LoadRegistryData();
            LoadDiskInfo();
            performanceTimer.Interval = 1000;
            performanceTimer.Tick += UpdatePerformance;
            performanceTimer.Start();
        }

        private void InitializePerformanceCounters()
        {
            try
            {
                cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to initialize performance counters: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePerformance(object sender, EventArgs e)
        {
            try
            {
                float cpu = cpuCounter.NextValue();
                float ram = ramCounter.NextValue();
                float totalRam = GetTotalPhysicalMemory();
                float usedRamPercentage = 100 - (ram / totalRam * 100);

                lblCPU.Text = $"CPU Usage: {cpu:0.00}%";
                progressCPU.Value = (int)Math.Min(cpu, 100);

                lblRAM.Text = $"Available RAM: {ram:0.00} MB / {totalRam:0.00} MB ({usedRamPercentage:0.00}% used)";
                progressRAM.Value = (int)Math.Min(usedRamPercentage, 100);
            }
            catch (Exception ex)
            {
                lblCPU.Text = "CPU Usage: Error reading data";
                lblRAM.Text = "RAM Usage: Error reading data";
            }
        }

        private float GetTotalPhysicalMemory()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT TotalPhysicalMemory FROM Win32_ComputerSystem");
                foreach (ManagementObject obj in searcher.Get())
                {
                    return Convert.ToInt64(obj["TotalPhysicalMemory"]) / (1024 * 1024);
                }
                return 8192; // Default to 8GB if we can't get the value
            }
            catch
            {
                return 8192; // Default value
            }
        }

        private void LoadSystemInfo()
        {
            lvSystemInfo.Items.Clear();

            try
            {
                // Basic system information
                AddSystemInfoItem("OS Version", Environment.OSVersion.ToString());
                AddSystemInfoItem("Machine Name", Environment.MachineName);
                AddSystemInfoItem("User Name", Environment.UserName);
                AddSystemInfoItem(".NET Version", Environment.Version.ToString());
                AddSystemInfoItem("Uptime", TimeSpan.FromMilliseconds(Environment.TickCount64).ToString(@"dd\.hh\:mm\:ss"));
                AddSystemInfoItem("Processor Count", Environment.ProcessorCount.ToString());

                // WMI queries for additional hardware info
                try
                {
                    // CPU info
                    ManagementObjectSearcher cpuSearcher = new ManagementObjectSearcher("SELECT Name, NumberOfCores FROM Win32_Processor");
                    foreach (ManagementObject obj in cpuSearcher.Get())
                    {
                        AddSystemInfoItem("CPU", obj["Name"]?.ToString() ?? "Unknown");
                        AddSystemInfoItem("CPU Cores", obj["NumberOfCores"]?.ToString() ?? "Unknown");
                    }

                    // BIOS info
                    ManagementObjectSearcher biosSearcher = new ManagementObjectSearcher("SELECT Manufacturer, ReleaseDate FROM Win32_BIOS");
                    foreach (ManagementObject obj in biosSearcher.Get())
                    {
                        AddSystemInfoItem("BIOS Manufacturer", obj["Manufacturer"]?.ToString() ?? "Unknown");
                    }
                }
                catch (Exception ex)
                {
                    AddSystemInfoItem("Hardware Info", $"Error retrieving data: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading system information: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddSystemInfoItem(string name, string value)
        {
            ListViewItem item = new ListViewItem(name);
            item.SubItems.Add(value);
            lvSystemInfo.Items.Add(item);
        }

        private void LoadDiskInfo()
        {
            lvDiskInfo.Items.Clear();

            try
            {
                DriveInfo[] allDrives = DriveInfo.GetDrives();
                foreach (DriveInfo drive in allDrives)
                {
                    try
                    {
                        if (drive.IsReady)
                        {
                            ListViewItem item = new ListViewItem(drive.Name);
                            item.SubItems.Add(drive.DriveType.ToString());
                            item.SubItems.Add(drive.VolumeLabel);
                            item.SubItems.Add(FormatBytes(drive.TotalSize));
                            item.SubItems.Add(FormatBytes(drive.AvailableFreeSpace));
                            item.SubItems.Add($"{(double)drive.AvailableFreeSpace / drive.TotalSize:P2}");
                            item.SubItems.Add(drive.DriveFormat);
                            lvDiskInfo.Items.Add(item);
                        }
                    }
                    catch (Exception ex)
                    {
                        ListViewItem item = new ListViewItem(drive.Name);
                        item.SubItems.Add("Error");
                        item.SubItems.Add(ex.Message);
                        lvDiskInfo.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading disk information: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string FormatBytes(long bytes)
        {
            string[] suffixes = { "B", "KB", "MB", "GB", "TB", "PB" };
            int counter = 0;
            double size = bytes;
            while (size > 1024 && counter < suffixes.Length - 1)
            {
                size /= 1024;
                counter++;
            }
            return $"{size:N2} {suffixes[counter]}";
        }

        private void LoadProcesses()
        {
            lvProcesses.Items.Clear();
            try
            {
                foreach (var process in Process.GetProcesses().OrderBy(p => p.ProcessName))
                {
                    try
                    {
                        var item = new ListViewItem(process.ProcessName);
                        item.SubItems.Add(process.Id.ToString());

                        // Add more process details
                        try { item.SubItems.Add(FormatBytes(process.WorkingSet64)); } catch { item.SubItems.Add("N/A"); }
                        try { item.SubItems.Add(process.BasePriority.ToString()); } catch { item.SubItems.Add("N/A"); }
                        try { item.SubItems.Add(process.StartTime.ToString("g")); } catch { item.SubItems.Add("N/A"); }
                        try { item.SubItems.Add(process.Threads.Count.ToString()); } catch { item.SubItems.Add("N/A"); }
                        try { item.SubItems.Add(process.Responding ? "Responding" : "Not Responding"); } catch { item.SubItems.Add("N/A"); }

                        // Store process ID in the tag for kill functionality
                        item.Tag = process.Id;

                        lvProcesses.Items.Add(item);
                    }
                    catch
                    {
                        // Skip processes we can't access due to permissions
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading processes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRegistryData()
        {
            tvRegistry.Nodes.Clear();

            try
            {
                // Add root keys
                TreeNode hkcuNode = tvRegistry.Nodes.Add("HKEY_CURRENT_USER", "HKEY_CURRENT_USER");
                TreeNode hklmNode = tvRegistry.Nodes.Add("HKEY_LOCAL_MACHINE", "HKEY_LOCAL_MACHINE");
                TreeNode hkcrNode = tvRegistry.Nodes.Add("HKEY_CLASSES_ROOT", "HKEY_CLASSES_ROOT");
                TreeNode hkuNode = tvRegistry.Nodes.Add("HKEY_USERS", "HKEY_USERS");
                TreeNode hkccNode = tvRegistry.Nodes.Add("HKEY_CURRENT_CONFIG", "HKEY_CURRENT_CONFIG");

                // Add placeholder nodes to show expandability
                hkcuNode.Nodes.Add("Loading...");
                hklmNode.Nodes.Add("Loading...");
                hkcrNode.Nodes.Add("Loading...");
                hkuNode.Nodes.Add("Loading...");
                hkccNode.Nodes.Add("Loading...");

                // Expand HKEY_CURRENT_USER to show some activity
                hkcuNode.Expand();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing registry view: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tvRegistry.Nodes.Add("Error loading registry data");
            }
        }

        private void tvRegistry_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                TreeNode node = e.Node;

                // Skip if we've already loaded this node
                if (node.Nodes.Count == 1 && node.Nodes[0].Text == "Loading...")
                {
                    node.Nodes.Clear();

                    RegistryKey baseKey = null;
                    string subKeyPath = "";

                    // Determine which root key we're dealing with
                    if (node.FullPath.StartsWith("HKEY_CURRENT_USER"))
                    {
                        baseKey = Registry.CurrentUser;
                        subKeyPath = node.FullPath.Replace("HKEY_CURRENT_USER", "").TrimStart('\\');
                    }
                    else if (node.FullPath.StartsWith("HKEY_LOCAL_MACHINE"))
                    {
                        baseKey = Registry.LocalMachine;
                        subKeyPath = node.FullPath.Replace("HKEY_LOCAL_MACHINE", "").TrimStart('\\');
                    }
                    else if (node.FullPath.StartsWith("HKEY_CLASSES_ROOT"))
                    {
                        baseKey = Registry.ClassesRoot;
                        subKeyPath = node.FullPath.Replace("HKEY_CLASSES_ROOT", "").TrimStart('\\');
                    }
                    else if (node.FullPath.StartsWith("HKEY_USERS"))
                    {
                        baseKey = Registry.Users;
                        subKeyPath = node.FullPath.Replace("HKEY_USERS", "").TrimStart('\\');
                    }
                    else if (node.FullPath.StartsWith("HKEY_CURRENT_CONFIG"))
                    {
                        baseKey = Registry.CurrentConfig;
                        subKeyPath = node.FullPath.Replace("HKEY_CURRENT_CONFIG", "").TrimStart('\\');
                    }

                    if (baseKey != null)
                    {
                        try
                        {
                            // If this is a root node with no subpath
                            if (string.IsNullOrEmpty(subKeyPath))
                            {
                                string[] subKeyNames = baseKey.GetSubKeyNames();
                                if (subKeyNames.Length > 0)
                                {
                                    foreach (var keyName in subKeyNames.Take(100))
                                    {
                                        TreeNode newNode = node.Nodes.Add(keyName);

                                        // Check if this key has subkeys
                                        try
                                        {
                                            using (RegistryKey testKey = baseKey.OpenSubKey(keyName))
                                            {
                                                if (testKey != null &&
                                                   (testKey.GetSubKeyNames().Length > 0 || testKey.GetValueNames().Length > 0))
                                                {
                                                    newNode.Nodes.Add("Loading...");
                                                }
                                            }
                                        }
                                        catch { newNode.Nodes.Add("Loading..."); }
                                    }
                                }
                                else
                                {
                                    node.Nodes.Add("(No subitems)");
                                }
                            }
                            else
                            {
                                using (RegistryKey subKey = baseKey.OpenSubKey(subKeyPath))
                                {
                                    if (subKey != null)
                                    {
                                        // Add subkeys
                                        string[] subKeyNames = subKey.GetSubKeyNames();
                                        if (subKeyNames.Length > 0)
                                        {
                                            foreach (var keyName in subKeyNames.Take(100))
                                            {
                                                TreeNode newNode = node.Nodes.Add(keyName);

                                                // Try to open the key to see if it has subkeys
                                                try
                                                {
                                                    using (RegistryKey testKey = subKey.OpenSubKey(keyName))
                                                    {
                                                        if (testKey != null &&
                                                           (testKey.GetSubKeyNames().Length > 0 || testKey.GetValueNames().Length > 0))
                                                        {
                                                            newNode.Nodes.Add("Loading...");
                                                        }
                                                    }
                                                }
                                                catch { newNode.Nodes.Add("Loading..."); }
                                            }
                                        }

                                        // Add values
                                        string[] valueNames = subKey.GetValueNames();
                                        if (valueNames.Length > 0)
                                        {
                                            foreach (var valueName in valueNames)
                                            {
                                                try
                                                {
                                                    object value = subKey.GetValue(valueName);
                                                    string valueType = subKey.GetValueKind(valueName).ToString();
                                                    string displayName = string.IsNullOrEmpty(valueName) ? "(Default)" : valueName;
                                                    string displayValue = (value == null) ? "(null)" : value.ToString();

                                                    TreeNode valueNode = node.Nodes.Add($"{displayName} = {displayValue} ({valueType})");
                                                    valueNode.ForeColor = System.Drawing.Color.Blue;
                                                }
                                                catch { }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        node.Nodes.Add("(Cannot access this key)");
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            node.Nodes.Add($"Access Error: {ex.Message}");
                        }
                    }

                    // If we didn't find any subnodes, show a placeholder
                    if (node.Nodes.Count == 0)
                    {
                        node.Nodes.Add("(No subitems)");
                    }
                }
            }
            catch (Exception ex)
            {
                e.Node.Nodes.Clear();
                e.Node.Nodes.Add($"Error: {ex.Message}");
            }
        }

        private void btnRefreshProcesses_Click(object sender, EventArgs e)
        {
            LoadProcesses();
        }

        private void btnKillProcess_Click(object sender, EventArgs e)
        {
            if (lvProcesses.SelectedItems.Count > 0)
            {
                try
                {
                    ListViewItem item = lvProcesses.SelectedItems[0];
                    int pid = (int)item.Tag;

                    DialogResult result = MessageBox.Show(
                        $"Are you sure you want to terminate the process '{item.Text}' (PID: {pid})?",
                        "Confirm Process Termination",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        Process process = Process.GetProcessById(pid);
                        process.Kill();

                        // Refresh the process list
                        LoadProcesses();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to terminate process: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a process to terminate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRefreshRegistry_Click(object sender, EventArgs e)
        {
            LoadRegistryData();
        }

        private void btnRefreshSystemInfo_Click(object sender, EventArgs e)
        {
            LoadSystemInfo();
        }

        private void btnRefreshDiskInfo_Click(object sender, EventArgs e)
        {
            LoadDiskInfo();
        }

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tabDiskInfo && lvDiskInfo.Items.Count == 0)
            {
                LoadDiskInfo();
            }
        }

        private void txtProcessFilter_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProcessFilter.Text))
            {
                LoadProcesses();
            }
            else
            {
                string filter = txtProcessFilter.Text.ToLower();
                lvProcesses.Items.Clear();

                try
                {
                    foreach (var process in Process.GetProcesses().Where(p =>
                        p.ProcessName.ToLower().Contains(filter) ||
                        p.Id.ToString().Contains(filter)).OrderBy(p => p.ProcessName))
                    {
                        try
                        {
                            var item = new ListViewItem(process.ProcessName);
                            item.SubItems.Add(process.Id.ToString());

                            // Add more process details
                            try { item.SubItems.Add(FormatBytes(process.WorkingSet64)); } catch { item.SubItems.Add("N/A"); }
                            try { item.SubItems.Add(process.BasePriority.ToString()); } catch { item.SubItems.Add("N/A"); }
                            try { item.SubItems.Add(process.StartTime.ToString("g")); } catch { item.SubItems.Add("N/A"); }
                            try { item.SubItems.Add(process.Threads.Count.ToString()); } catch { item.SubItems.Add("N/A"); }
                            try { item.SubItems.Add(process.Responding ? "Responding" : "Not Responding"); } catch { item.SubItems.Add("N/A"); }

                            // Store process ID in the tag for kill functionality
                            item.Tag = process.Id;

                            lvProcesses.Items.Add(item);
                        }
                        catch
                        {
                            // Skip processes we can't access due to permissions
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error filtering processes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Add registry search functionality
        private void btnRegistrySearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRegistrySearch.Text))
            {
                MessageBox.Show("Please enter a search term.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string searchTerm = txtRegistrySearch.Text.ToLower();
            tvRegistry.Nodes.Clear();
            TreeNode resultsNode = tvRegistry.Nodes.Add("Search Results", "Search Results for: " + txtRegistrySearch.Text);

            // Search in common locations
            SearchRegistry(Registry.CurrentUser, "HKEY_CURRENT_USER", searchTerm, resultsNode);
            SearchRegistry(Registry.LocalMachine, "HKEY_LOCAL_MACHINE", searchTerm, resultsNode);

            if (resultsNode.Nodes.Count == 0)
            {
                resultsNode.Nodes.Add("No results found");
            }

            resultsNode.Expand();
        }

        private void SearchRegistry(RegistryKey baseKey, string baseKeyName, string searchTerm, TreeNode resultsNode, string currentPath = "", int depth = 0)
        {
            if (depth > 3) return; // Limit depth to prevent hanging

            try
            {
                foreach (string subKeyName in baseKey.GetSubKeyNames())
                {
                    if (subKeyName.ToLower().Contains(searchTerm))
                    {
                        TreeNode foundNode = resultsNode.Nodes.Add(subKeyName, $"{baseKeyName}\\{(currentPath.Length > 0 ? currentPath + "\\" : "")}{subKeyName}");
                        foundNode.Nodes.Add("Loading...");
                    }

                    if (depth < 2) // Only search 2 levels deep for performance
                    {
                        try
                        {
                            using (RegistryKey subKey = baseKey.OpenSubKey(subKeyName))
                            {
                                if (subKey != null)
                                {
                                    string newPath = currentPath.Length > 0 ? currentPath + "\\" + subKeyName : subKeyName;
                                    SearchRegistry(subKey, baseKeyName, searchTerm, resultsNode, newPath, depth + 1);
                                }
                            }
                        }
                        catch { }
                    }
                }

                // Also search values for the search term
                foreach (string valueName in baseKey.GetValueNames())
                {
                    if (valueName.ToLower().Contains(searchTerm))
                    {
                        string displayPath = $"{baseKeyName}\\{(currentPath.Length > 0 ? currentPath : "")}";
                        TreeNode foundNode = resultsNode.Nodes.Add(valueName, $"{displayPath} - Value: {valueName}");
                        foundNode.ForeColor = System.Drawing.Color.Blue;
                    }
                }
            }
            catch { }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Clean up resources
            performanceTimer.Stop();
            if (cpuCounter != null) cpuCounter.Dispose();
            if (ramCounter != null) ramCounter.Dispose();
            base.OnFormClosing(e);
        }
    }
}