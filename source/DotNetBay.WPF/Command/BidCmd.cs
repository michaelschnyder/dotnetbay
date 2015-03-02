using DotNetBay.WPF.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DotNetBay.WPF.Command
{
    public sealed class BidCmd : ICommand
    {
        public Action<object> ExecuteDelegate { get; set; }
        public Func<object, bool> CanExecuteDelegate { get; set; }
            
        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return CanExecuteDelegate(parameter);
        }
            
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            ExecuteDelegate(parameter);
        }
            
        #endregion
    }
}
