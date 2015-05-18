using System.Windows;

using DotNetBay.WPF.ViewModel;

using Microsoft.Practices.Unity;

namespace DotNetBay.WPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            this.DataContext = WpfUnityContainer.Instance.Resolve<MainViewModel>();
        }
    }
}
