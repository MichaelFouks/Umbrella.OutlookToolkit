using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umbrella.OutlookToolkit
{
    public class OutlookStoreProvider : IStoreProvider
    {
        private readonly string? storeName;

        public static IEnumerable<string> GetAvailableOutlookStores()
        {
            Application application = new Application();
            NameSpace outlookNamespaces = application.GetNamespace("MAPI");

            // Login using default profile
            outlookNamespaces.Logon(application.DefaultProfileName);

            List<string> result = new();

            foreach (Store store in outlookNamespaces.Stores)
            {
                result.Add(store.DisplayName);
            }

            return result;
        }

        private OutlookStoreProvider() { }

        public OutlookStoreProvider(string storeNameIn)
        {
            if (string.IsNullOrEmpty(storeNameIn))
            {
                throw new ArgumentException($"'{nameof(storeNameIn)}' cannot be null or empty.", nameof(storeNameIn));
            }

            storeName = storeNameIn;
        }

        public IEnumerable<MailItem> GetMailItems()
        {
            Application application = new Application();
            NameSpace outlookNamespaces = application.GetNamespace("MAPI");

            // Login using default profile
            outlookNamespaces.Logon(application.DefaultProfileName);

            Store store = outlookNamespaces.Stores[storeName];
            MAPIFolder rootFolder = store.GetRootFolder();

#if DEBUG
            foreach (Folder folder in rootFolder.Folders) 
            {
                Debug.WriteLine($"Folder Name: {folder.Name}; folder Entry ID: {folder.EntryID}; folder path: {folder.FullFolderPath}");
            }
#endif

            MAPIFolder inboxFolder = rootFolder.Folders["Inbox"];

            List<MailItem> result = new();
            foreach (var item in inboxFolder.Items)
            {
                if (item is MailItem mailItem)
                {
                    result.Add(mailItem);
                }
            }

            return result;
        }

        public StoreFolder GetStoreFolders()
        {
            Application application = new Application();
            NameSpace outlookNamespaces = application.GetNamespace("MAPI");

            // Login using default profile
            outlookNamespaces.Logon(application.DefaultProfileName);

            Store store = outlookNamespaces.Stores[storeName];
            MAPIFolder rootFolder = store.GetRootFolder();

            StoreFolder rootFolderModel = new StoreFolder()
            {
                Name = rootFolder.Name,
                FullPath = rootFolder.FullFolderPath,
                EntryId = rootFolder.EntryID,
                ParentFolder = null
            };

            foreach(MAPIFolder childFolder in rootFolder.Folders)
            {
                if (
                    childFolder.DefaultItemType == OlItemType.olMailItem
                    &&  (
                            childFolder.Folders.Count > 0
                            || childFolder.Items.Count > 0  
                        )
                    )
                {

                    StoreFolder childFolderModel = new StoreFolder()
                    {
                        Name = childFolder.Name,
                        FullPath = childFolder.FullFolderPath,
                        EntryId = childFolder.EntryID,
                        ParentFolder = rootFolderModel
                    };

                    rootFolderModel.Folders.Add(childFolderModel);
                }
            }

            return rootFolderModel;
        }
    }
}
