using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Outlook;
using Umbrella.OutlookToolkit;

namespace OutlookToolkit.WinForms
{
    public class MainFormViewModel : INotifyPropertyChanged
    {
        private string? storeName;
        private IEnumerable<MailItem> mailItems;
        private bool outlookStoresToolbarVisible = true;
        private IEnumerable<string>? availableOutlookStoreNames;
        private StoreFolder? rootFolder;

        public string? StoreName
        {
            get => storeName;
            set
            {
                storeName = value;
                NotifyPropertyChanged();
            }
        }

        public IEnumerable<MailItem> MailItems
        {
            get => mailItems;
            set
            {
                mailItems = value;
                NotifyPropertyChanged();
            }
        }

        public bool OutlookStoresToolbarVisible
        {
            get => outlookStoresToolbarVisible;
            set
            {
                outlookStoresToolbarVisible = value;
                NotifyPropertyChanged();
            }
        }

        public IEnumerable<string>? AvailableOutlookStoreNames
        {
            get => availableOutlookStoreNames;
            set
            {
                availableOutlookStoreNames = value;
                NotifyPropertyChanged();
            }
        }

        public StoreFolder? RootFolder 
        { 
            get => rootFolder;
            set 
            { 
                rootFolder = value;
                NotifyPropertyChanged();
            }
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler? PropertyChanged;

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
