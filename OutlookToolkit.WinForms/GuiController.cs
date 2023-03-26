using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbrella.OutlookToolkit;
using Microsoft.Office.Interop.Outlook;

namespace OutlookToolkit.WinForms
{
    public class GuiController
    {
        private MainForm mainForm;
        private MainFormViewModel mainFormViewModel;

        internal void Start()
        {
            mainFormViewModel = new MainFormViewModel();

            System.Windows.Forms.Application.Run(mainForm = new MainForm(mainFormViewModel, this));
        }

        internal void OpenPstFile(string filePath)
        {
            bool success = false;

            if(string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException(nameof(filePath));

            IStoreProvider storeProvider = new PstFileStoreProvider(filePath);

            //mainFormViewModel.MailItems = storeProvider.GetMailItems();
            storeProvider.GetMailItems();

            success = true;

            if (success)
            {
                mainFormViewModel.StoreName = filePath;
            }
        }

        internal void OpenOutlookStore() 
        {
            bool success = false;

            IEnumerable<string> availableStoreNames 
                = OutlookStoreProvider.GetAvailableOutlookStores().OrderBy(qentry => qentry);

            SelectOutlookStoreFormViewModel selectOutlookStoreFormViewModel = new(availableStoreNames);
            SelectOutlookStoreForm selectOutlookStoreForm = new(selectOutlookStoreFormViewModel, this);
            if (DialogResult.OK == selectOutlookStoreForm.ShowDialog())
            {
                OutlookStoreProvider storePtovider = new(selectOutlookStoreFormViewModel.SelectedOutlookStoreName);
                mainFormViewModel.MailItems = storePtovider.GetMailItems();
            }

            success = true;

            if (success)
            {
            }
        }
    }
}
