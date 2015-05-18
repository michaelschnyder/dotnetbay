using DotNetBay.Core;
using DotNetBay.Data.EF;
using DotNetBay.Interfaces;

using Microsoft.Practices.Unity;

namespace DotNetBay.WebApp
{
    public class WebAppUnityContainer : UnityContainer
    {
        private static WebAppUnityContainer instance;

        public WebAppUnityContainer()
        {
            this.RegisterType<IMainRepository, EFMainRepository>(new HierarchicalLifetimeManager());
            this.RegisterType<IAuctionService, AuctionService>(new HierarchicalLifetimeManager());
            this.RegisterType<IMemberService, SimpleMemberService>(new HierarchicalLifetimeManager());
        }

        public static IUnityContainer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WebAppUnityContainer();
                }

                return instance;
            }
        }
    }
}