using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umbrella.OutlookToolkit
{
    public class StoreEmailItem
    {
        public StoreFolder? ParentFolder { get; set; }

        public string? EntryId { get; set; }

        public string? Subject { get; set; }

        public string? Body { get; set; }

        public DateTime SentOn { get; set; }

        public string? SenderName { get; set; }

        public string? SenderEmail { get; set;}

    }
}
