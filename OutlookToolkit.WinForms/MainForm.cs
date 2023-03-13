namespace OutlookToolkit.WinForms
{
    public partial class MainForm : Form
    {
        MainFormViewModel viewModel;

        public MainForm()
        {
            InitializeComponent();

            viewModel = new MainFormViewModel();
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == openFileDialogOutlookFile.ShowDialog())
            {
                viewModel.OutlookDataFileName = openFileDialogOutlookFile.FileName;
            }
        }
    }
}