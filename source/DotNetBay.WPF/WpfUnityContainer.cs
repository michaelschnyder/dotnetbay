using DotNetBay.Core;
using DotNetBay.WPF.Services;

using Microsoft.Practices.Unity;

namespace DotNetBay.WPF
{
    public class WpfUnityContainer : UnityContainer
    {
        private static IUnityContainer instance;

        public WpfUnityContainer()
        {
            this.RegisterType<IAuctionService, RemoteAuctionService>(new ContainerControlledLifetimeManager());
        }

        public static IUnityContainer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WpfUnityContainer();
                }

                return instance;
            }
        }
    }
}
