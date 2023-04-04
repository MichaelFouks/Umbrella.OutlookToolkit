using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Outlook;

namespace Umbrella.OutlookToolkit
{
    public interface IStoreProvider
    {
        public IEnumerable<MailItem> GetMailItems();
        public StoreFolder GetStoreFolders();

        public StoreFolder? GetStoreFolder(string entryId);
    }
}
