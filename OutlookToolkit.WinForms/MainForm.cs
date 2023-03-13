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
                case "OutlookDataFileName":
                    {
                        if (string.IsNullOrEmpty(viewModel.OutlookDataFileName))
                        {
                            toolStripStatusLabelOutlookFileName.Text = $"Outlook File Name: none opened";
                            toolStripStatusLabelOutlookFileName.Visible = false;
                        }
                        else
                        {
                            toolStripStatusLabelOutlookFileName.Text = $"Outlook File Name: {viewModel.OutlookDataFileName}";
                            toolStripStatusLabelOutlookFileName.Visible = true;
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
            if (DialogResult.OK == openFileDialogOutlookFile.ShowDialog())
            {
                controller.OpenOutlookFile(openFileDialogOutlookFile.FileName);
            }
        }
    }
}