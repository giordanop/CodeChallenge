using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Hosting;
using FluentScheduler;
using FluentScheduler.Model;

namespace CodeChallenge.Web.Job
{
    public interface ITaskBeacon : ITask, IRegisteredObject
    {
    }
}