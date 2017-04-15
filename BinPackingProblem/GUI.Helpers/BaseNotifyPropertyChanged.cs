using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Helpers
{
    public class BaseNotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            // Take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;              

            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
