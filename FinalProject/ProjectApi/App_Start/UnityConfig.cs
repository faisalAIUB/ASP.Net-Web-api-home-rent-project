using System.Web.Http;
using Unity;
using Unity.WebApi;
using ProjectInterface;
using ProjectRepository;

namespace ProjectApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IRentAdRepository, RentAdRepository>();
            container.RegisterType<IThanaRepository, ThanaRepository>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}