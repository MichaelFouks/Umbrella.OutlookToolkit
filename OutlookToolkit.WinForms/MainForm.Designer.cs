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
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            toolStripOutlookStores.SuspendLayout();
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
            toolStripOutlookStores.Location = new Point(0, 30);
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(toolStripOutlookStores);
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
    }
}