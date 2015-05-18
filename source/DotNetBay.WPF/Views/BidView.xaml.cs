using System.Windows;

using DotNetBay.Model;
using DotNetBay.WPF.ViewModel;

using Microsoft.Practices.Unity;

namespace DotNetBay.WPF.Views
{
    /// <summary>
    /// Interaction logic for SellView.xaml
    /// </summary>
    public partial class BidView : Window
    {
        public BidView(Auction selectedAuction)
        {
            this.InitializeComponent();

            this.DataContext = WpfUnityContainer.Instance.Resolve<BidViewModel>(new ParameterOverride("selectedAuction", selectedAuction));
        }
    }
}
