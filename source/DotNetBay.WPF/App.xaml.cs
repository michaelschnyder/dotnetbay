using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DotNetBay.Interfaces;
using DotNetBay.Data;
using DotNetBay.Data.FileStorage;
using DotNetBay.Core.Execution;

namespace DotNetBay.WPF
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        
        public App()
        {
            this.MainRepository = new FileSystemRepositoryFactory("test.txt").CreateMainRepository();
            this.AuctionRunner = new AuctionRunner(this.MainRepository);
            this.AuctionRunner.Start();
        }

        public IMainRepository MainRepository
        {
            get; private set;
        }

        public IAuctionRunner AuctionRunner
        {
            get; private set;
        }
    }
}
