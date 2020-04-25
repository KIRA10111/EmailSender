using Autofac;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using EmailSender.Busines.Interfaces;
using EmailSender.Data;
using EmailSender.Busines.Repositories;

namespace EmailSender.DependencyInjection
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<LoggingRequestRepository>().As<ILoggingRequestRepository>()
                .WithParameter("context", new ApplicationDbContext());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}