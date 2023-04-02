using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umbrella.OutlookToolkit
{
    public class StoreFolder
    {
        public StoreFolder()
        { 
            Folders = new List<StoreFolder>();
        }

        public StoreFolder? ParentFolder {get;set;}
        
        public List<StoreFolder> Folders { get; set; }

        public string? Name { get; set; }

        public string? FullPath { get; set; }

        public string EntryId { get; set; }
    }
}
