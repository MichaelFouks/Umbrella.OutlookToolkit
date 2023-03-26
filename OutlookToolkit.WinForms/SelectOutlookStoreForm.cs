using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutlookToolkit.WinForms
{
    public partial class SelectOutlookStoreForm : Form
    {
        private GuiController controller;
        private readonly SelectOutlookStoreFormViewModel viewModel;

        public SelectOutlookStoreForm(
            SelectOutlookStoreFormViewModel viewModelIn,
            GuiController controllerIn
        )
        {
            InitializeComponent();

            controller = controllerIn;

            viewModel = viewModelIn;

            comboBoxAvailableStoreNames.Items.AddRange(
                viewModel.AvailableOutlookStoreNames.ToArray()
            );
        }

        private void comboBoxAvailableStoreNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            viewModel.SelectedOutlookStoreName = (string)comboBoxAvailableStoreNames.SelectedItem;
        }
    }
}
