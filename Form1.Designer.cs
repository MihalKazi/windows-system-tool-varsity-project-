namespace SystemToolkit_Full
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPerformance = new System.Windows.Forms.TabPage();
            this.progressRAM = new System.Windows.Forms.ProgressBar();
            this.progressCPU = new System.Windows.Forms.ProgressBar();
            this.lblCPU = new System.Windows.Forms.Label();
            this.lblRAM = new System.Windows.Forms.Label();
            this.tabProcesses = new System.Windows.Forms.TabPage();
            this.txtProcessFilter = new System.Windows.Forms.TextBox();
            this.lblProcessFilter = new System.Windows.Forms.Label();
            this.btnKillProcess = new System.Windows.Forms.Button();
            this.btnRefreshProcesses = new System.Windows.Forms.Button();
            this.lvProcesses = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.tabSystemInfo = new System.Windows.Forms.TabPage();
            this.btnRefreshSystemInfo = new System.Windows.Forms.Button();
            this.lvSystemInfo = new System.Windows.Forms.ListView();
            this.columnHeaderProperty = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderValue = new System.Windows.Forms.ColumnHeader();
            this.tabRegistry = new System.Windows.Forms.TabPage();
            this.btnRefreshRegistry = new System.Windows.Forms.Button();
            this.tvRegistry = new System.Windows.Forms.TreeView();
            this.tabDiskInfo = new System.Windows.Forms.TabPage();
            this.btnRefreshDiskInfo = new System.Windows.Forms.Button();
            this.lvDiskInfo = new System.Windows.Forms.ListView();
            this.columnHeaderDrive = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderType = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderLabel = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderSize = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderFree = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderFreePercent = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderFormat = new System.Windows.Forms.ColumnHeader();
            this.tabControl.SuspendLayout();
            this.tabPerformance.SuspendLayout();
            this.tabProcesses.SuspendLayout();
            this.tabSystemInfo.SuspendLayout();
            this.tabRegistry.SuspendLayout();
            this.tabDiskInfo.SuspendLayout();
            this.SuspendLayout();

            // tabControl
            this.tabControl.Controls.Add(this.tabPerformance);
            this.tabControl.Controls.Add(this.tabProcesses);
            this.tabControl.Controls.Add(this.tabSystemInfo);
            this.tabControl.Controls.Add(this.tabRegistry);
            this.tabControl.Controls.Add(this.tabDiskInfo);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 450);
            this.tabControl.TabIndex = 0;
            this.tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl_Selected);

            // tabPerformance
            this.tabPerformance.Controls.Add(this.progressRAM);
            this.tabPerformance.Controls.Add(this.progressCPU);
            this.tabPerformance.Controls.Add(this.lblCPU);
            this.tabPerformance.Controls.Add(this.lblRAM);
            this.tabPerformance.Location = new System.Drawing.Point(4, 22);
            this.tabPerformance.Name = "tabPerformance";
            this.tabPerformance.Padding = new System.Windows.Forms.Padding(3);
            this.tabPerformance.Size = new System.Drawing.Size(792, 424);
            this.tabPerformance.TabIndex = 0;
            this.tabPerformance.Text = "Performance";
            this.tabPerformance.UseVisualStyleBackColor = true;

            // progressRAM
            this.progressRAM.Location = new System.Drawing.Point(20, 85);
            this.progressRAM.Name = "progressRAM";
            this.progressRAM.Size = new System.Drawing.Size(750, 23);
            this.progressRAM.TabIndex = 3;

            // progressCPU
            this.progressCPU.Location = new System.Drawing.Point(20, 45);
            this.progressCPU.Name = "progressCPU";
            this.progressCPU.Size = new System.Drawing.Size(750, 23);
            this.progressCPU.TabIndex = 2;

            // lblCPU
            this.lblCPU.AutoSize = true;
            this.lblCPU.Location = new System.Drawing.Point(20, 20);
            this.lblCPU.Name = "lblCPU";
            this.lblCPU.Size = new System.Drawing.Size(68, 13);
            this.lblCPU.TabIndex = 0;
            this.lblCPU.Text = "CPU Usage: ";

            // lblRAM
            this.lblRAM.AutoSize = true;
            this.lblRAM.Location = new System.Drawing.Point(20, 70);
            this.lblRAM.Name = "lblRAM";
            this.lblRAM.Size = new System.Drawing.Size(80, 13);
            this.lblRAM.TabIndex = 1;
            this.lblRAM.Text = "Available RAM: ";

            // tabProcesses
            this.tabProcesses.Controls.Add(this.txtProcessFilter);
            this.tabProcesses.Controls.Add(this.lblProcessFilter);
            this.tabProcesses.Controls.Add(this.btnKillProcess);
            this.tabProcesses.Controls.Add(this.btnRefreshProcesses);
            this.tabProcesses.Controls.Add(this.lvProcesses);
            this.tabProcesses.Location = new System.Drawing.Point(4, 22);
            this.tabProcesses.Name = "tabProcesses";
            this.tabProcesses.Padding = new System.Windows.Forms.Padding(3);
            this.tabProcesses.Size = new System.Drawing.Size(792, 424);
            this.tabProcesses.TabIndex = 1;
            this.tabProcesses.Text = "Processes";
            this.tabProcesses.UseVisualStyleBackColor = true;

            // txtProcessFilter
            this.txtProcessFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProcessFilter.Location = new System.Drawing.Point(85, 10);
            this.txtProcessFilter.Name = "txtProcessFilter";
            this.txtProcessFilter.Size = new System.Drawing.Size(520, 20);
            this.txtProcessFilter.TabIndex = 4;
            this.txtProcessFilter.TextChanged += new System.EventHandler(this.txtProcessFilter_TextChanged);

            // lblProcessFilter
            this.lblProcessFilter.AutoSize = true;
            this.lblProcessFilter.Location = new System.Drawing.Point(8, 13);
            this.lblProcessFilter.Name = "lblProcessFilter";
            this.lblProcessFilter.Size = new System.Drawing.Size(71, 13);
            this.lblProcessFilter.TabIndex = 3;
            this.lblProcessFilter.Text = "Filter by name:";

            // btnKillProcess
            this.btnKillProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKillProcess.Location = new System.Drawing.Point(703, 8);
            this.btnKillProcess.Name = "btnKillProcess";
            this.btnKillProcess.Size = new System.Drawing.Size(80, 23);
            this.btnKillProcess.TabIndex = 2;
            this.btnKillProcess.Text = "Kill Process";
            this.btnKillProcess.UseVisualStyleBackColor = true;
            this.btnKillProcess.Click += new System.EventHandler(this.btnKillProcess_Click);

            // btnRefreshProcesses
            this.btnRefreshProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshProcesses.Location = new System.Drawing.Point(617, 8);
            this.btnRefreshProcesses.Name = "btnRefreshProcesses";
            this.btnRefreshProcesses.Size = new System.Drawing.Size(80, 23);
            this.btnRefreshProcesses.TabIndex = 1;
            this.btnRefreshProcesses.Text = "Refresh";
            this.btnRefreshProcesses.UseVisualStyleBackColor = true;
            this.btnRefreshProcesses.Click += new System.EventHandler(this.btnRefreshProcesses_Click);

            // lvProcesses
            this.lvProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lvProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lvProcesses.FullRowSelect = true;
            this.lvProcesses.GridLines = true;
            this.lvProcesses.HideSelection = false;
            this.lvProcesses.Location = new System.Drawing.Point(6, 37);
            this.lvProcesses.MultiSelect = false;
            this.lvProcesses.Name = "lvProcesses";
            this.lvProcesses.Size = new System.Drawing.Size(780, 381);
            this.lvProcesses.TabIndex = 0;
            this.lvProcesses.UseCompatibleStateImageBehavior = false;
            this.lvProcesses.View = System.Windows.Forms.View.Details;

            // columnHeader1
            this.columnHeader1.Text = "Process Name";
            this.columnHeader1.Width = 150;

            // columnHeader2
            this.columnHeader2.Text = "PID";
            this.columnHeader2.Width = 50;

            // columnHeader3
            this.columnHeader3.Text = "Memory Usage";
            this.columnHeader3.Width = 100;

            // columnHeader4
            this.columnHeader4.Text = "Priority";
            this.columnHeader4.Width = 50;

            // columnHeader5
            this.columnHeader5.Text = "Start Time";
            this.columnHeader5.Width = 150;

            // columnHeader6
            this.columnHeader6.Text = "Threads";
            this.columnHeader6.Width = 60;

            // columnHeader7
            this.columnHeader7.Text = "Status";
            this.columnHeader7.Width = 100;

            // tabSystemInfo
            this.tabSystemInfo.Controls.Add(this.btnRefreshSystemInfo);
            this.tabSystemInfo.Controls.Add(this.lvSystemInfo);
            this.tabSystemInfo.Location = new System.Drawing.Point(4, 22);
            this.tabSystemInfo.Name = "tabSystemInfo";
            this.tabSystemInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabSystemInfo.Size = new System.Drawing.Size(792, 424);
            this.tabSystemInfo.TabIndex = 2;
            this.tabSystemInfo.Text = "System Info";
            this.tabSystemInfo.UseVisualStyleBackColor = true;

            // btnRefreshSystemInfo
            this.btnRefreshSystemInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshSystemInfo.Location = new System.Drawing.Point(703, 8);
            this.btnRefreshSystemInfo.Name = "btnRefreshSystemInfo";
            this.btnRefreshSystemInfo.Size = new System.Drawing.Size(80, 23);
            this.btnRefreshSystemInfo.TabIndex = 1;
            this.btnRefreshSystemInfo.Text = "Refresh";
            this.btnRefreshSystemInfo.UseVisualStyleBackColor = true;
            this.btnRefreshSystemInfo.Click += new System.EventHandler(this.btnRefreshSystemInfo_Click);

            // lvSystemInfo
            this.lvSystemInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSystemInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderProperty,
            this.columnHeaderValue});
            this.lvSystemInfo.FullRowSelect = true;
            this.lvSystemInfo.GridLines = true;
            this.lvSystemInfo.HideSelection = false;
            this.lvSystemInfo.Location = new System.Drawing.Point(6, 37);
            this.lvSystemInfo.Name = "lvSystemInfo";
            this.lvSystemInfo.Size = new System.Drawing.Size(780, 381);
            this.lvSystemInfo.TabIndex = 0;
            this.lvSystemInfo.UseCompatibleStateImageBehavior = false;
            this.lvSystemInfo.View = System.Windows.Forms.View.Details;

            // columnHeaderProperty
            this.columnHeaderProperty.Text = "Property";
            this.columnHeaderProperty.Width = 200;

            // columnHeaderValue
            this.columnHeaderValue.Text = "Value";
            this.columnHeaderValue.Width = 500;

            // tabRegistry
            this.tabRegistry.Controls.Add(this.btnRefreshRegistry);
            this.tabRegistry.Controls.Add(this.tvRegistry);
            this.tabRegistry.Location = new System.Drawing.Point(4, 22);
            this.tabRegistry.Name = "tabRegistry";
            this.tabRegistry.Padding = new System.Windows.Forms.Padding(3);
            this.tabRegistry.Size = new System.Drawing.Size(792, 424);
            this.tabRegistry.TabIndex = 3;
            this.tabRegistry.Text = "Registry";
            this.tabRegistry.UseVisualStyleBackColor = true;
            // txtRegistrySearch
            this.txtRegistrySearch = new System.Windows.Forms.TextBox();
            this.txtRegistrySearch.Location = new System.Drawing.Point(85, 10);
            this.txtRegistrySearch.Name = "txtRegistrySearch";
            this.txtRegistrySearch.Size = new System.Drawing.Size(520, 20);
            this.txtRegistrySearch.TabIndex = 4;

            // lblRegistrySearch
            this.lblRegistrySearch = new System.Windows.Forms.Label();
            this.lblRegistrySearch.AutoSize = true;
            this.lblRegistrySearch.Location = new System.Drawing.Point(8, 13);
            this.lblRegistrySearch.Name = "lblRegistrySearch";
            this.lblRegistrySearch.Size = new System.Drawing.Size(71, 13);
            this.lblRegistrySearch.TabIndex = 3;
            this.lblRegistrySearch.Text = "Search Keys:";

            // btnRegistrySearch
            this.btnRegistrySearch = new System.Windows.Forms.Button();
            this.btnRegistrySearch.Location = new System.Drawing.Point(617, 8);
            this.btnRegistrySearch.Name = "btnRegistrySearch";
            this.btnRegistrySearch.Size = new System.Drawing.Size(80, 23);
            this.btnRegistrySearch.TabIndex = 2;
            this.btnRegistrySearch.Text = "Search";
            this.btnRegistrySearch.UseVisualStyleBackColor = true;
            this.btnRegistrySearch.Click += new System.EventHandler(this.btnRegistrySearch_Click);

            // Add controls to the Registry tab
            this.tabRegistry.Controls.Add(this.txtRegistrySearch);
            this.tabRegistry.Controls.Add(this.lblRegistrySearch);
            this.tabRegistry.Controls.Add(this.btnRegistrySearch);

            // btnRefreshRegistry
            this.btnRefreshRegistry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshRegistry.Location = new System.Drawing.Point(703, 8);
            this.btnRefreshRegistry.Name = "btnRefreshRegistry";
            this.btnRefreshRegistry.Size = new System.Drawing.Size(80, 23);
            this.btnRefreshRegistry.TabIndex = 1;
            this.btnRefreshRegistry.Text = "Refresh";
            this.btnRefreshRegistry.UseVisualStyleBackColor = true;
            this.btnRefreshRegistry.Click += new System.EventHandler(this.btnRefreshRegistry_Click);

            // tvRegistry
            this.tvRegistry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tvRegistry.Location = new System.Drawing.Point(6, 37);
            this.tvRegistry.Name = "tvRegistry";
            this.tvRegistry.Size = new System.Drawing.Size(780, 381);
            this.tvRegistry.TabIndex = 0;
            this.tvRegistry.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvRegistry_BeforeExpand);

            // tabDiskInfo
            this.tabDiskInfo.Controls.Add(this.btnRefreshDiskInfo);
            this.tabDiskInfo.Controls.Add(this.lvDiskInfo);
            this.tabDiskInfo.Location = new System.Drawing.Point(4, 22);
            this.tabDiskInfo.Name = "tabDiskInfo";
            this.tabDiskInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabDiskInfo.Size = new System.Drawing.Size(792, 424);
            this.tabDiskInfo.TabIndex = 4;
            this.tabDiskInfo.Text = "Disk Info";
            this.tabDiskInfo.UseVisualStyleBackColor = true;

            // btnRefreshDiskInfo
            this.btnRefreshDiskInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshDiskInfo.Location = new System.Drawing.Point(703, 8);
            this.btnRefreshDiskInfo.Name = "btnRefreshDiskInfo";
            this.btnRefreshDiskInfo.Size = new System.Drawing.Size(80, 23);
            this.btnRefreshDiskInfo.TabIndex = 1;
            this.btnRefreshDiskInfo.Text = "Refresh";
            this.btnRefreshDiskInfo.UseVisualStyleBackColor = true;
            this.btnRefreshDiskInfo.Click += new System.EventHandler(this.btnRefreshDiskInfo_Click);

            // lvDiskInfo
            this.lvDiskInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lvDiskInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderDrive,
            this.columnHeaderType,
            this.columnHeaderLabel,
            this.columnHeaderSize,
            this.columnHeaderFree,
            this.columnHeaderFreePercent,
            this.columnHeaderFormat});
            this.lvDiskInfo.FullRowSelect = true;
            this.lvDiskInfo.GridLines = true;
            this.lvDiskInfo.HideSelection = false;
            this.lvDiskInfo.Location = new System.Drawing.Point(6, 37);
            this.lvDiskInfo.Name = "lvDiskInfo";
            this.lvDiskInfo.Size = new System.Drawing.Size(780, 381);
            this.lvDiskInfo.TabIndex = 0;
            this.lvDiskInfo.UseCompatibleStateImageBehavior = false;
            this.lvDiskInfo.View = System.Windows.Forms.View.Details;

            // columnHeaderDrive
            this.columnHeaderDrive.Text = "Drive";
            this.columnHeaderDrive.Width = 50;

            // columnHeaderType
            this.columnHeaderType.Text = "Type";
            this.columnHeaderType.Width = 80;

            // columnHeaderLabel
            this.columnHeaderLabel.Text = "Label";
            this.columnHeaderLabel.Width = 100;

            // columnHeaderSize
            this.columnHeaderSize.Text = "Total Size";
            this.columnHeaderSize.Width = 100;

            // columnHeaderFree
            this.columnHeaderFree.Text = "Free Space";
            this.columnHeaderFree.Width = 100;

            // columnHeaderFreePercent
            this.columnHeaderFreePercent.Text = "Free %";
            this.columnHeaderFreePercent.Width = 70;

            // columnHeaderFormat
            this.columnHeaderFormat.Text = "Format";
            this.columnHeaderFormat.Width = 70;

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.Text = "System Toolkit";
            this.tabControl.ResumeLayout(false);
            this.tabPerformance.ResumeLayout(false);
            this.tabPerformance.PerformLayout();
            this.tabProcesses.ResumeLayout(false);
            this.tabProcesses.PerformLayout();
            this.tabSystemInfo.ResumeLayout(false);
            this.tabRegistry.ResumeLayout(false);
            this.tabDiskInfo.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPerformance;
        private System.Windows.Forms.TabPage tabProcesses;
        private System.Windows.Forms.TabPage tabSystemInfo;
        private System.Windows.Forms.TabPage tabRegistry;
        private System.Windows.Forms.TabPage tabDiskInfo;
        private System.Windows.Forms.Label lblCPU;
        private System.Windows.Forms.Label lblRAM;
        private System.Windows.Forms.ProgressBar progressCPU;
        private System.Windows.Forms.ProgressBar progressRAM;
        private System.Windows.Forms.ListView lvProcesses;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button btnRefreshProcesses;
        private System.Windows.Forms.Button btnKillProcess;
        private System.Windows.Forms.TextBox txtProcessFilter;
        private System.Windows.Forms.Label lblProcessFilter;
        private System.Windows.Forms.ListView lvSystemInfo;
        private System.Windows.Forms.ColumnHeader columnHeaderProperty;
        private System.Windows.Forms.ColumnHeader columnHeaderValue;
        private System.Windows.Forms.Button btnRefreshSystemInfo;
        private System.Windows.Forms.TreeView tvRegistry;
        private System.Windows.Forms.Button btnRefreshRegistry;
        private System.Windows.Forms.ListView lvDiskInfo;
        private System.Windows.Forms.ColumnHeader columnHeaderDrive;
        private System.Windows.Forms.ColumnHeader columnHeaderType;
        private System.Windows.Forms.ColumnHeader columnHeaderLabel;
        private System.Windows.Forms.ColumnHeader columnHeaderSize;
        private System.Windows.Forms.ColumnHeader columnHeaderFree;
        private System.Windows.Forms.ColumnHeader columnHeaderFreePercent;
        private System.Windows.Forms.ColumnHeader columnHeaderFormat;
        private System.Windows.Forms.Button btnRefreshDiskInfo;
        private System.Windows.Forms.TextBox txtRegistrySearch;
        private System.Windows.Forms.Button btnRegistrySearch;
        private System.Windows.Forms.Label lblRegistrySearch;
    }
}