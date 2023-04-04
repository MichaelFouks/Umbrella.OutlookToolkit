namespace OutlookToolkit.WinForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItemOpen = new ToolStripMenuItem();
            toolStripMenuItemWorkWithOutlookStores = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripMenuItemExit = new ToolStripMenuItem();
            openFileDialogPstFile = new OpenFileDialog();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabelStoreName = new ToolStripStatusLabel();
            toolStripOutlookStores = new ToolStrip();
            toolStripLabelOutlookStores = new ToolStripLabel();
            toolStripComboBoxOutlookStores = new ToolStripComboBox();
            splitContainerOutlookStores = new SplitContainer();
            groupBoxOutlookStoreFolders = new GroupBox();
            treeViewOutlookStoreFolders = new TreeView();
            groupBoxSelectedFolderDetails = new GroupBox();
            tableLayoutPanelSelectedFolderDetails = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            labelSelectedFolderName = new Label();
            labelSelectedFolderFullPath = new Label();
            labelSelectedFolderNumberOfSubfolders = new Label();
            labelSelectedFolderNumberOfEmailItems = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            toolStripOutlookStores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerOutlookStores).BeginInit();
            splitContainerOutlookStores.Panel1.SuspendLayout();
            splitContainerOutlookStores.Panel2.SuspendLayout();
            splitContainerOutlookStores.SuspendLayout();
            groupBoxOutlookStoreFolders.SuspendLayout();
            groupBoxSelectedFolderDetails.SuspendLayout();
            tableLayoutPanelSelectedFolderDetails.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(914, 30);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItemOpen, toolStripMenuItemWorkWithOutlookStores, toolStripSeparator1, toolStripMenuItemExit });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // toolStripMenuItemOpen
            // 
            toolStripMenuItemOpen.Name = "toolStripMenuItemOpen";
            toolStripMenuItemOpen.Size = new Size(260, 26);
            toolStripMenuItemOpen.Text = "Open PST file";
            toolStripMenuItemOpen.Click += toolStripMenuItemOpen_Click;
            // 
            // toolStripMenuItemWorkWithOutlookStores
            // 
            toolStripMenuItemWorkWithOutlookStores.Name = "toolStripMenuItemWorkWithOutlookStores";
            toolStripMenuItemWorkWithOutlookStores.Size = new Size(260, 26);
            toolStripMenuItemWorkWithOutlookStores.Text = "Work with Outlook Stores";
            toolStripMenuItemWorkWithOutlookStores.Click += toolStripMenuItemOpenStore_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(257, 6);
            // 
            // toolStripMenuItemExit
            // 
            toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            toolStripMenuItemExit.Size = new Size(260, 26);
            toolStripMenuItemExit.Text = "Exit";
            toolStripMenuItemExit.Click += toolStripMenuItemExit_Click;
            // 
            // openFileDialogPstFile
            // 
            openFileDialogPstFile.FileName = "openFileDialogOutlookFile";
            openFileDialogPstFile.Filter = "Local Data Files|*.pst";
            openFileDialogPstFile.Title = "Open PST file";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelStoreName });
            statusStrip1.Location = new Point(0, 578);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(914, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelStoreName
            // 
            toolStripStatusLabelStoreName.Name = "toolStripStatusLabelStoreName";
            toolStripStatusLabelStoreName.Size = new Size(95, 20);
            toolStripStatusLabelStoreName.Text = "Store Name: ";
            toolStripStatusLabelStoreName.TextAlign = ContentAlignment.MiddleLeft;
            toolStripStatusLabelStoreName.Visible = false;
            // 
            // toolStripOutlookStores
            // 
            toolStripOutlookStores.ImageScalingSize = new Size(20, 20);
            toolStripOutlookStores.Items.AddRange(new ToolStripItem[] { toolStripLabelOutlookStores, toolStripComboBoxOutlookStores });
            toolStripOutlookStores.Location = new Point(0, 0);
            toolStripOutlookStores.Name = "toolStripOutlookStores";
            toolStripOutlookStores.Size = new Size(914, 28);
            toolStripOutlookStores.TabIndex = 2;
            toolStripOutlookStores.Text = "Outlook Stores";
            // 
            // toolStripLabelOutlookStores
            // 
            toolStripLabelOutlookStores.Name = "toolStripLabelOutlookStores";
            toolStripLabelOutlookStores.Size = new Size(110, 25);
            toolStripLabelOutlookStores.Text = "Outlook Stores:";
            // 
            // toolStripComboBoxOutlookStores
            // 
            toolStripComboBoxOutlookStores.DropDownStyle = ComboBoxStyle.DropDownList;
            toolStripComboBoxOutlookStores.Name = "toolStripComboBoxOutlookStores";
            toolStripComboBoxOutlookStores.Size = new Size(250, 28);
            toolStripComboBoxOutlookStores.Sorted = true;
            toolStripComboBoxOutlookStores.SelectedIndexChanged += toolStripComboBoxOutlookStores_SelectedIndexChanged;
            // 
            // splitContainerOutlookStores
            // 
            splitContainerOutlookStores.Dock = DockStyle.Fill;
            splitContainerOutlookStores.Location = new Point(0, 0);
            splitContainerOutlookStores.Name = "splitContainerOutlookStores";
            // 
            // splitContainerOutlookStores.Panel1
            // 
            splitContainerOutlookStores.Panel1.Controls.Add(groupBoxOutlookStoreFolders);
            // 
            // splitContainerOutlookStores.Panel2
            // 
            splitContainerOutlookStores.Panel2.Controls.Add(groupBoxSelectedFolderDetails);
            splitContainerOutlookStores.Size = new Size(914, 514);
            splitContainerOutlookStores.SplitterDistance = 304;
            splitContainerOutlookStores.TabIndex = 3;
            // 
            // groupBoxOutlookStoreFolders
            // 
            groupBoxOutlookStoreFolders.Controls.Add(treeViewOutlookStoreFolders);
            groupBoxOutlookStoreFolders.Dock = DockStyle.Fill;
            groupBoxOutlookStoreFolders.Location = new Point(0, 0);
            groupBoxOutlookStoreFolders.Name = "groupBoxOutlookStoreFolders";
            groupBoxOutlookStoreFolders.Size = new Size(304, 514);
            groupBoxOutlookStoreFolders.TabIndex = 0;
            groupBoxOutlookStoreFolders.TabStop = false;
            groupBoxOutlookStoreFolders.Text = "Store Folders";
            // 
            // treeViewOutlookStoreFolders
            // 
            treeViewOutlookStoreFolders.Dock = DockStyle.Fill;
            treeViewOutlookStoreFolders.Location = new Point(3, 23);
            treeViewOutlookStoreFolders.Name = "treeViewOutlookStoreFolders";
            treeViewOutlookStoreFolders.Size = new Size(298, 488);
            treeViewOutlookStoreFolders.TabIndex = 0;
            treeViewOutlookStoreFolders.NodeMouseClick += treeViewOutlookStoreFolders_NodeMouseClick;
            // 
            // groupBoxSelectedFolderDetails
            // 
            groupBoxSelectedFolderDetails.Controls.Add(tableLayoutPanelSelectedFolderDetails);
            groupBoxSelectedFolderDetails.Dock = DockStyle.Top;
            groupBoxSelectedFolderDetails.Location = new Point(0, 0);
            groupBoxSelectedFolderDetails.Name = "groupBoxSelectedFolderDetails";
            groupBoxSelectedFolderDetails.Size = new Size(606, 201);
            groupBoxSelectedFolderDetails.TabIndex = 0;
            groupBoxSelectedFolderDetails.TabStop = false;
            groupBoxSelectedFolderDetails.Text = "Folder Details";
            // 
            // tableLayoutPanelSelectedFolderDetails
            // 
            tableLayoutPanelSelectedFolderDetails.ColumnCount = 2;
            tableLayoutPanelSelectedFolderDetails.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelSelectedFolderDetails.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelSelectedFolderDetails.Controls.Add(label1, 0, 0);
            tableLayoutPanelSelectedFolderDetails.Controls.Add(label2, 0, 1);
            tableLayoutPanelSelectedFolderDetails.Controls.Add(label3, 0, 3);
            tableLayoutPanelSelectedFolderDetails.Controls.Add(label4, 0, 2);
            tableLayoutPanelSelectedFolderDetails.Controls.Add(labelSelectedFolderName, 1, 0);
            tableLayoutPanelSelectedFolderDetails.Controls.Add(labelSelectedFolderFullPath, 1, 1);
            tableLayoutPanelSelectedFolderDetails.Controls.Add(labelSelectedFolderNumberOfSubfolders, 1, 2);
            tableLayoutPanelSelectedFolderDetails.Controls.Add(labelSelectedFolderNumberOfEmailItems, 1, 3);
            tableLayoutPanelSelectedFolderDetails.Dock = DockStyle.Fill;
            tableLayoutPanelSelectedFolderDetails.Location = new Point(3, 23);
            tableLayoutPanelSelectedFolderDetails.Name = "tableLayoutPanelSelectedFolderDetails";
            tableLayoutPanelSelectedFolderDetails.RowCount = 5;
            tableLayoutPanelSelectedFolderDetails.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanelSelectedFolderDetails.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanelSelectedFolderDetails.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanelSelectedFolderDetails.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanelSelectedFolderDetails.RowStyles.Add(new RowStyle());
            tableLayoutPanelSelectedFolderDetails.Size = new Size(600, 175);
            tableLayoutPanelSelectedFolderDetails.TabIndex = 0;
            tableLayoutPanelSelectedFolderDetails.Paint += tableLayoutPanelSelectedFolderDetails_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(98, 20);
            label1.TabIndex = 0;
            label1.Text = "Folder Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 30);
            label2.Name = "label2";
            label2.Size = new Size(113, 20);
            label2.TabIndex = 1;
            label2.Text = "Full folder path:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 90);
            label3.Name = "label3";
            label3.Size = new Size(165, 20);
            label3.TabIndex = 2;
            label3.Text = "Number of email items:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 60);
            label4.Name = "label4";
            label4.Size = new Size(157, 20);
            label4.TabIndex = 3;
            label4.Text = "Number of subfolders:";
            // 
            // labelSelectedFolderName
            // 
            labelSelectedFolderName.AutoSize = true;
            labelSelectedFolderName.Location = new Point(174, 0);
            labelSelectedFolderName.Name = "labelSelectedFolderName";
            labelSelectedFolderName.Size = new Size(0, 20);
            labelSelectedFolderName.TabIndex = 4;
            // 
            // labelSelectedFolderFullPath
            // 
            labelSelectedFolderFullPath.AutoSize = true;
            labelSelectedFolderFullPath.Location = new Point(174, 30);
            labelSelectedFolderFullPath.Name = "labelSelectedFolderFullPath";
            labelSelectedFolderFullPath.Size = new Size(0, 20);
            labelSelectedFolderFullPath.TabIndex = 5;
            // 
            // labelSelectedFolderNumberOfSubfolders
            // 
            labelSelectedFolderNumberOfSubfolders.AutoSize = true;
            labelSelectedFolderNumberOfSubfolders.Location = new Point(174, 60);
            labelSelectedFolderNumberOfSubfolders.Name = "labelSelectedFolderNumberOfSubfolders";
            labelSelectedFolderNumberOfSubfolders.Size = new Size(0, 20);
            labelSelectedFolderNumberOfSubfolders.TabIndex = 6;
            // 
            // labelSelectedFolderNumberOfEmailItems
            // 
            labelSelectedFolderNumberOfEmailItems.AutoSize = true;
            labelSelectedFolderNumberOfEmailItems.Location = new Point(174, 90);
            labelSelectedFolderNumberOfEmailItems.Name = "labelSelectedFolderNumberOfEmailItems";
            labelSelectedFolderNumberOfEmailItems.Size = new Size(0, 20);
            labelSelectedFolderNumberOfEmailItems.TabIndex = 7;
            // 
            // panel1
            // 
            panel1.Controls.Add(toolStripOutlookStores);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 30);
            panel1.Name = "panel1";
            panel1.Size = new Size(914, 34);
            panel1.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.Controls.Add(splitContainerOutlookStores);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 64);
            panel2.Name = "panel2";
            panel2.Size = new Size(914, 514);
            panel2.TabIndex = 5;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "Outlook Toolkit";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            toolStripOutlookStores.ResumeLayout(false);
            toolStripOutlookStores.PerformLayout();
            splitContainerOutlookStores.Panel1.ResumeLayout(false);
            splitContainerOutlookStores.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerOutlookStores).EndInit();
            splitContainerOutlookStores.ResumeLayout(false);
            groupBoxOutlookStoreFolders.ResumeLayout(false);
            groupBoxSelectedFolderDetails.ResumeLayout(false);
            tableLayoutPanelSelectedFolderDetails.ResumeLayout(false);
            tableLayoutPanelSelectedFolderDetails.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItemOpen;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem toolStripMenuItemExit;
        private OpenFileDialog openFileDialogPstFile;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabelStoreName;
        private ToolStripMenuItem toolStripMenuItemWorkWithOutlookStores;
        private ToolStrip toolStripOutlookStores;
        private ToolStripLabel toolStripLabelOutlookStores;
        private ToolStripComboBox toolStripComboBoxOutlookStores;
        private SplitContainer splitContainerOutlookStores;
        private GroupBox groupBoxOutlookStoreFolders;
        private TreeView treeViewOutlookStoreFolders;
        private Panel panel1;
        private Panel panel2;
        private GroupBox groupBoxSelectedFolderDetails;
        private TableLayoutPanel tableLayoutPanelSelectedFolderDetails;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label labelSelectedFolderName;
        private Label labelSelectedFolderFullPath;
        private Label labelSelectedFolderNumberOfSubfolders;
        private Label labelSelectedFolderNumberOfEmailItems;
    }
}