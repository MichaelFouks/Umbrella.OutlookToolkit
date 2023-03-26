using System.Diagnostics.Eventing.Reader;

namespace OutlookToolkit.WinForms
{
    public partial class MainForm : Form
    {
        private GuiController controller;
        private MainFormViewModel viewModel;

        public MainForm(MainFormViewModel viewModelIn, GuiController controllerIn)
        {
            InitializeComponent();

            controller = controllerIn;

            viewModel = viewModelIn;
            viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        private void ViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "StoreName" +
                "":
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
            controller.OpenOutlookStore();
        }
    }
}