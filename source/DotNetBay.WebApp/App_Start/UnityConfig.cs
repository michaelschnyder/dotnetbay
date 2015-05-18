using System.Web.Mvc;
using Unity.Mvc5;

namespace DotNetBay.WebApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            DependencyResolver.SetResolver(new UnityDependencyResolver(WebAppUnityContainer.Instance));
        }
    }
}