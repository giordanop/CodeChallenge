using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeChallenge.Web.Job;
using FluentScheduler;
using FluentScheduler.Model;
using Moq;
using NUnit.Framework;

namespace CodeChallenge.Web.Tests.Job
{
    [TestFixture]
    public class SchedulerBeaconTests
    {
        [SetUp]
        public void Initialize()
        {
            
        }

        [Test]
        public void Should_Be_Able_To_Schedule_ITaskBeacon()
        {
            var task1 = new Mock<ITaskBeacon>();
            var task2 = new Mock<ITaskBeacon>();
            task1.Setup(m => m.Execute());
            task2.Setup(m => m.Execute());
            var schedule = new Schedule(task1.Object).AndThen(task2.Object);
            schedule.Execute();

            while (TaskManager.RunningSchedules.Any())
            {
                Thread.Sleep(1);
            }
            task1.Verify(m => m.Execute(), Times.Once());
            task2.Verify(m => m.Execute(), Times.Once());
        }
        
        [Test]
        public void Should_Be_Able_To_Run_Scheduler_Beacon()
        {
            //TODO: build a fake job and execute it
            //TaskManager.Initialize(new SchedulerBeacon()); 

        }



    }
}
