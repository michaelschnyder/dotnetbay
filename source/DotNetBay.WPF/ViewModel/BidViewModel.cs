using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBay.WPF.ViewModel
{
    class BidViewModel : ViewModelBase
    {

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyPropertyChanged("Title");
                
            }
        }

    }
}
