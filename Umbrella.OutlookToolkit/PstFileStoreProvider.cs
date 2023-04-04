using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Outlook;

namespace Umbrella.OutlookToolkit
{
    public class PstFileStoreProvider : IStoreProvider
    {
        private readonly string storeFileName;

        private PstFileStoreProvider() { }

        public PstFileStoreProvider(string storeFileNameIn)
        {
            storeFileName = storeFileNameIn ?? throw new ArgumentNullException(nameof(storeFileNameIn));
        }

        public IEnumerable<MailItem> GetMailItems()
        {
            List<MailItem> items = new List<MailItem>();

            Application application = new Application();
            NameSpace outlookNamespaces = application.GetNamespace("MAPI");

            // Login using default profile
            outlookNamespaces.Logon(application.DefaultProfileName);

            foreach (Store store in outlookNamespaces.Stores)
            {
                Debug.Write(store.DisplayName);
            }

            // Add PST file (Outlook Data File) to Default Profile
            outlookNamespaces.AddStore(storeFileName);

            //MAPIFolder rootFolder = outlookNamespaces.Stores[pstName].GetRootFolder();
            //// Traverse through all folders in the PST file
            //// TODO: This is not recursive, refactor
            //Folders subFolders = rootFolder.Folders;
            //foreach (Folder folder in subFolders)
            //{
            //    Items items = folder.Items;
            //    foreach (object item in items)
            //    {
            //        if (item is MailItem)
            //        {
            //            MailItem mailItem = item as MailItem;
            //            mailItems.Add(mailItem);
            //        }
            //    }
            //}
            // Remove PST file from Default Profile
            //outlookNamespaces.RemoveStore(rootFolder);

            return items;
        }

        public StoreFolder GetStoreFolders()
        {
            throw new NotImplementedException();
        }

        public StoreFolder? GetStoreFolder(string entryId)
        {
            throw new NotImplementedException();
        }
    }
}
