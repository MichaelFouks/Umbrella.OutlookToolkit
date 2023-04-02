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
                mainFormViewModel.OutlookStoresToolbarVisible = false;
            }
        }

        internal void ListOutlookStores() 
        {
            IEnumerable<string> availableStoreNames 
                = OutlookStoreProvider.GetAvailableOutlookStores().OrderBy(qentry => qentry);

            mainFormViewModel.OutlookStoresToolbarVisible= true;   
            mainFormViewModel.AvailableOutlookStoreNames= availableStoreNames;
        }

        internal void PopulateOutlookStoreInfo(string outlookStoreName)
        {
            OutlookStoreProvider provider = new OutlookStoreProvider(outlookStoreName);

            mainFormViewModel.RootFolder = provider.GetStoreFolders();
        }
    }
}
