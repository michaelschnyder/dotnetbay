using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DotNetBay.Core;
using DotNetBay.Model;
using DotNetBay.WPF.Commands;

namespace DotNetBay.WPF.ViewModels
{
    public sealed class AuctionListViewModel
    {

        public AuctionListViewModel()
        {
            this.InitAuctions();
            this.NewAuction = new NewAuctionCmd();
        }

        public ObservableCollection<Auction> Auctions { get; private set; }

        public ICommand NewAuction { get; private set; }

        private void InitAuctions()
        {
            this.Auctions = new ObservableCollection<Auction>();
            App app = (App) App.Current;
            var memberService = new SimpleMemberService(app.MainRepository);
            var service = new AuctionService(app.MainRepository, memberService);

            foreach (var auction in service.GetAll())
            {
                this.Auctions.Add(auction);
            }
        }
    }
}
