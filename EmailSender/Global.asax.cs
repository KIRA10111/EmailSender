using EmailSender.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


namespace EmailSender
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutofacConfig.ConfigureContainer();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Logger();
        }
        //public void Logger()
        //{
        //    var config = new NLog.Config.LoggingConfiguration();

        //    // Targets where to log to: File and Console
        //    var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "${basedir}/logs/Log.${level}.current.txt" };
        //    var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

        //    // Rules for mapping loggers to targets            
        //    config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
        //    config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
        //    config.AddRule(LogLevel.Error, LogLevel.Fatal, logfile);

        //    // Apply config           
        //    LogManager.Configuration = config;
        //}
    }
}
