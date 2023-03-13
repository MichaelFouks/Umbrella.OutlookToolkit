using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Outlook;

namespace Umbrella.OutlookToolkit
{
    public class StoreProvider
    {
        private readonly string storeFileName;

        private StoreProvider() { }

        public StoreProvider(string storeFileNameIn)
        {
            storeFileName = storeFileNameIn ?? throw new ArgumentNullException(nameof(storeFileNameIn));
        }
    }
}
