using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Quartz;
using Quartz.Core;

namespace WeChat.Quartz.Net
{
    public class MySchedListener : ISchedulerListener
    {
        public Task JobAdded(IJobDetail jobDetail, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        Task ISchedulerListener.JobDeleted(JobKey jobKey, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task ISchedulerListener.JobInterrupted(JobKey jobKey, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task ISchedulerListener.JobPaused(JobKey jobKey, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task ISchedulerListener.JobResumed(JobKey jobKey, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task ISchedulerListener.JobScheduled(ITrigger trigger, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task ISchedulerListener.JobsPaused(string jobGroup, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task ISchedulerListener.JobsResumed(string jobGroup, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task ISchedulerListener.JobUnscheduled(TriggerKey triggerKey, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task ISchedulerListener.SchedulerError(string msg, SchedulerException cause, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task ISchedulerListener.SchedulerInStandbyMode(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task ISchedulerListener.SchedulerShutdown(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task ISchedulerListener.SchedulerShuttingdown(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task ISchedulerListener.SchedulerStarted(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task ISchedulerListener.SchedulerStarting(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task ISchedulerListener.SchedulingDataCleared(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task ISchedulerListener.TriggerFinalized(ITrigger trigger, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task ISchedulerListener.TriggerPaused(TriggerKey triggerKey, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task ISchedulerListener.TriggerResumed(TriggerKey triggerKey, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task ISchedulerListener.TriggersPaused(string triggerGroup, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task ISchedulerListener.TriggersResumed(string triggerGroup, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
