using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookToolkit.WinForms
{
    public class GuiController
    {
        private MainForm mainForm;
        private MainFormViewModel mainFormViewModel;

        internal void Start()
        {
            mainFormViewModel = new MainFormViewModel();

            Application.Run(mainForm = new MainForm(mainFormViewModel, this));
        }

        internal void OpenOutlookFile(string filePath)
        {
            bool success = false;

            success = true;

            if (success)
            {
                mainFormViewModel.OutlookDataFileName = filePath;
            }
        }
    }
}
