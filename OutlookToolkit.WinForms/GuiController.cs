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
            if (outlookStoreName is null || string.IsNullOrEmpty(outlookStoreName))
            {
                throw new ArgumentNullException(nameof(outlookStoreName));
            }

            IStoreProvider provider = new OutlookStoreProvider(outlookStoreName);

            mainFormViewModel.StoreName = outlookStoreName;
            mainFormViewModel.RootFolder = provider.GetStoreFolders();
        }

        internal void GetFolderExportGetails(string outlookStoreName, string folderEntryId)
        {
            if (outlookStoreName is null || string.IsNullOrEmpty(outlookStoreName))
            {
                throw new ArgumentNullException(nameof(outlookStoreName));
            }
            if (folderEntryId is null || string.IsNullOrEmpty(folderEntryId))
            {
                throw new ArgumentNullException(nameof(folderEntryId));
            }

            IStoreProvider provider = new OutlookStoreProvider(outlookStoreName);
            mainFormViewModel.SelectedStoreFolder = provider.GetStoreFolder(folderEntryId);
        }

        internal void ExportFolder(string outlookStoreName)
        {
            if (outlookStoreName is null || string.IsNullOrEmpty(outlookStoreName))
            {
                throw new ArgumentNullException(nameof(outlookStoreName));
            }

            IStoreProvider provider = new OutlookStoreProvider(outlookStoreName);
            provider.ExportFolder(
                mainFormViewModel.SelectedStoreFolder.EntryId, 
                mainFormViewModel.ArchiveFolderPath
            );
        }
    }
}
