using System.Runtime.Caching;
using FluentScheduler;

namespace CodeChallenge.Web.Job
{
    public class SchedulerBeacon : Registry
    {
        public SchedulerBeacon(int interval = 10)
        {
            // Schedule an ITask to run at an interval
            
            Schedule<TaskBeacon>().ToRunNow().AndEvery(interval).Seconds();

        }
    }
}