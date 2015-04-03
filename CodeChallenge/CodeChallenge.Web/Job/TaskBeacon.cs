using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Caching;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Web.Hosting;
using CodeChallenge.Api.Client;
using CodeChallenge.Api.Client.HttpClient;
using CodeChallenge.Api.Client.Object;
using FluentScheduler;
using FluentScheduler.Model;

namespace CodeChallenge.Web.Job
{
    public class TaskBeacon : ITaskBeacon
	{
		private readonly object _lock = new object();
		private bool _shuttingDown;
		public TaskBeacon()
        {
            // Register this task with the hosting environment. Allows for a more graceful stop of the task, in the case of IIS shutting down.
			HostingEnvironment.RegisterObject(this);

        }

        public void Execute()
		{
			lock (_lock)
			{
				if (_shuttingDown)
					return;

				//Do work, son!
			   
                //TODO: IOC
			    ICodeChallengeClient client = new CodeChallengeClientFactory().Create(ConfigurationManager.AppSettings["Api"]);
			    var result= client.BeaconResource.GetBeaconsFeed().Result.Data.Result;
			    result.LastUpdate = DateTime.Now;
			    MemoryCache.Default.Set("BeaconsFeed",result,DateTimeOffset.MaxValue);
			}
		}

		public void Stop(bool immediate)
		{
			// Locking here will wait for the lock in Execute to be released until this code can continue.
			lock (_lock)
			{
				_shuttingDown = true;
			}
			HostingEnvironment.UnregisterObject(this);
		}
	}
}