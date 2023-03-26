using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OutlookToolkit.WinForms
{
    public class SelectOutlookStoreFormViewModel : INotifyPropertyChanged
    {
        private IEnumerable<string>? availableOutlookStoreNames;
        private string? selectedOutlookStoreName;

        private SelectOutlookStoreFormViewModel() { }

        public SelectOutlookStoreFormViewModel(IEnumerable<string> availableOutlookStoreNamesIn) 
        { 
            availableOutlookStoreNames = availableOutlookStoreNamesIn ?? throw new ArgumentNullException(nameof(availableOutlookStoreNamesIn));
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

        public string? SelectedOutlookStoreName 
        { 
            get => selectedOutlookStoreName;
            set
            {
                selectedOutlookStoreName = value;
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
