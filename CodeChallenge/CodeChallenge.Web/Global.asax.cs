using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CodeChallenge.Web.Job;
using FluentScheduler;
using FluentScheduler.Model;

namespace CodeChallenge.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            TaskManager.UnobservedTaskException += TaskManager_UnobservedTaskException;
            TaskManager.Initialize(new SchedulerBeacon()); 
        }

        protected void Application_End(object sender, EventArgs e)
        {
            TaskManager.Stop();
        }

        static void TaskManager_UnobservedTaskException(TaskExceptionInformation sender, UnhandledExceptionEventArgs e)
        {
            //log
        }
    }
}
