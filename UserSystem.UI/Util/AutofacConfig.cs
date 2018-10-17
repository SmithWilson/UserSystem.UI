using Autofac;
using Autofac.Integration.Mvc;
using Entity;
using Service.Implementations.Auth;
using Service.Implementations.DbService;
using ServiceContract.Abstractions.Auth;
using ServiceContract.Abstractions.DbService;
using System.Web.Mvc;

namespace UserSystem.UI.Util
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            
            builder.RegisterType<UserSystemContext>().InstancePerRequest();
            builder.RegisterType<AccountService>()
                .As<IAccountService>();
            builder.RegisterType<SaltService>().As<ISaltService>();
            
            var container = builder.Build();
            
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}