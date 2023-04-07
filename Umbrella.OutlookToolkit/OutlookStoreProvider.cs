using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Mail;

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
                        ParentFolder = rootFolderModel, 
                        FoldersCount = childFolder.Folders.Count, 
                        MailItemsCount = childFolder.Items.Count
                    };

                    rootFolderModel.Folders.Add(childFolderModel);

                    //foreach (object item in childFolder.Items)
                    //{
                    //    if (item is MailItem mailItem)
                    //    {
                    //        StoreEmailItem mailItemModel = new StoreEmailItem()
                    //        {
                    //            ParentFolder = childFolderModel,
                    //            EntryId = mailItem.EntryID,
                    //            Subject = mailItem.Subject,
                    //            Body = mailItem.Body,
                    //            SentOn = mailItem.SentOn
                    //        };

                    //        childFolderModel.EmailItems.Add(mailItemModel);
                    //    }
                    //}
                }
            }

            return rootFolderModel;
        }

        public StoreFolder? GetStoreFolder(string entryId)
        {
            if( entryId == null || string.IsNullOrEmpty(entryId) )
            {
                throw new ArgumentNullException(nameof(entryId));
            }

            Application application = new();
            NameSpace outlookNamespaces = application.GetNamespace("MAPI");

            // Login using default profile
            outlookNamespaces.Logon(application.DefaultProfileName);

            Store store = outlookNamespaces.Stores[storeName];
            MAPIFolder rootFolder = store.GetRootFolder();

            foreach (MAPIFolder childFolder in rootFolder.Folders)
            {
                if (childFolder.EntryID == entryId)
                {
                    return new StoreFolder()
                        {
                            Name = childFolder.Name,
                            FullPath = childFolder.FullFolderPath,
                            EntryId = childFolder.EntryID,
                            MailItemsCount = childFolder.Items.Count,
                            FoldersCount = childFolder.Folders.Count
                        };
                }
            }

            return null;
        }

        public void ExportFolder(string folderEntryId, string archiveRootFolder)
        {
            if (folderEntryId == null || string.IsNullOrEmpty(folderEntryId))
            {
                throw new ArgumentNullException(nameof(folderEntryId));
            }
            if (archiveRootFolder == null || string.IsNullOrEmpty(archiveRootFolder))
            {
                throw new ArgumentNullException(nameof(archiveRootFolder));
            }

            Application application = new();
            NameSpace outlookNamespaces = application.GetNamespace("MAPI");

            // Login using default profile
            outlookNamespaces.Logon(application.DefaultProfileName);

            Store store = outlookNamespaces.Stores[storeName];
            MAPIFolder rootFolder = store.GetRootFolder();

            MAPIFolder? mapiFolderToExport = null;
            foreach (MAPIFolder childFolder in rootFolder.Folders)
            {
                if (childFolder.EntryID == folderEntryId)
                {
                    mapiFolderToExport = childFolder; 

                    break;
                }
            }

            if(mapiFolderToExport == null)
            {
                return;
            }

            DirectoryInfo archiveDirectory = new DirectoryInfo(archiveRootFolder);

            foreach (object item in mapiFolderToExport.Items)
            {
                if (item is MailItem mailItem)
                {
                    string senderEmailAddress = mailItem.SenderEmailAddress;
                    if(IsValidEmail(senderEmailAddress))
                    {
                        archiveDirectory.CreateSubdirectory(senderEmailAddress);
                    }
                    
                }

                GC.Collect();
            }
        }


        private static bool IsValidEmail(string email)
        {
            return MailAddress.TryCreate(email, out _);
        }
    }
}
