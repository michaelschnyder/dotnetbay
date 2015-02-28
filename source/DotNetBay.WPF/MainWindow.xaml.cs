using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DotNetBay.Core;
using DotNetBay.Model;

namespace DotNetBay.WPF
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.InitAuctions();
            this.DataContext = this;
        }

        public ObservableCollection<Auction> Auctions { get; private set; }

        private void InitAuctions()
        {
            this.Auctions = new ObservableCollection<Auction>();
            App app = (App)App.Current;
            var memberService = new SimpleMemberService(app.MainRepository);
            var service = new AuctionService(app.MainRepository, memberService);

            foreach (var auction in service.GetAll())
            {
                this.Auctions.Add(auction);
            }
        }
    }
}
