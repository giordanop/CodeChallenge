using System;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using CodeChallenge.Web.Job;
using FluentScheduler;
using Microsoft.Owin;
using Newtonsoft.Json.Serialization;
using Owin;

[assembly: OwinStartup(typeof(CodeChallenge.Web.Startup))]

namespace CodeChallenge.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var configuration = new HttpConfiguration();
            WebApiConfig.Register(configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            TaskManager.Initialize(new SchedulerBeacon()); 
            app.UseWebApi(configuration);
        }
    }
}
