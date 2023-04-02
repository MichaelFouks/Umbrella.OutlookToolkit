using System.Diagnostics.Eventing.Reader;
using Umbrella.OutlookToolkit;

namespace OutlookToolkit.WinForms
{
    public partial class MainForm : Form
    {
        private GuiController controller;
        private MainFormViewModel viewModel;

        public MainForm(MainFormViewModel viewModelIn, GuiController controllerIn)
        {
            InitializeComponent();

            toolStripOutlookStores.Visible = false;
            splitContainerOutlookStores.Visible = false;

            controller = controllerIn;

            viewModel = viewModelIn;
            viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        private void ViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "StoreName":
                    {
                        if (string.IsNullOrEmpty(viewModel.StoreName))
                        {
                            toolStripStatusLabelStoreName.Text = $"Outlook File Name: none opened";
                            toolStripStatusLabelStoreName.Visible = false;
                        }
                        else
                        {
                            toolStripStatusLabelStoreName.Text = $"Outlook File Name: {viewModel.StoreName}";
                            toolStripStatusLabelStoreName.Visible = true;
                        }
                        break;
                    }
                case "OutlookStoresToolbarVisible":
                    {
                        toolStripOutlookStores.Visible = viewModel.OutlookStoresToolbarVisible;
                        splitContainerOutlookStores.Visible = viewModel.OutlookStoresToolbarVisible;
                        break;
                    }
                case "AvailableOutlookStoreNames":
                    {
                        if (
                            viewModel.AvailableOutlookStoreNames is null
                            ||
                            !viewModel.AvailableOutlookStoreNames.Any()
                        )
                        {
                            toolStripComboBoxOutlookStores.Items.Clear();
                        }
                        else
                        {
                            toolStripComboBoxOutlookStores.Items.AddRange(viewModel.AvailableOutlookStoreNames.ToArray());
                        }

                        break;
                    }
                case "RootFolder":
                    {
                        treeViewOutlookStoreFolders.BeginUpdate();

                        treeViewOutlookStoreFolders.Nodes.Clear();

                        foreach (StoreFolder folder in viewModel.RootFolder.Folders)
                        {
                            treeViewOutlookStoreFolders.Nodes.Add(folder.FullPath, folder.Name);
                        }
                        

                        treeViewOutlookStoreFolders.EndUpdate();

                        break;
                    }
            }
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == openFileDialogPstFile.ShowDialog())
            {
                controller.OpenPstFile(openFileDialogPstFile.FileName);
            }
        }

        private void toolStripMenuItemOpenStore_Click(object sender, EventArgs e)
        {
            controller.ListOutlookStores();
        }

        private void toolStripComboBoxOutlookStores_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.PopulateOutlookStoreInfo((string)toolStripComboBoxOutlookStores.SelectedItem);
        }
    }
}