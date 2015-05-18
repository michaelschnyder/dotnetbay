using System.Windows;

using DotNetBay.WPF.ViewModel;

using Microsoft.Practices.Unity;

namespace DotNetBay.WPF.Views
{
    /// <summary>
    /// Interaction logic for SellView.xaml
    /// </summary>
    public partial class SellView : Window
    {
        public SellView()
        {
            this.InitializeComponent();

            this.DataContext = WpfUnityContainer.Instance.Resolve<SellViewModel>();
        }
    }
}
