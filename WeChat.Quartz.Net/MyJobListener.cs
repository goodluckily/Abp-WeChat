using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Quartz;

namespace WeChat.Quartz.Net
{
    public class MyJobListener : IJobListener
    {
        public string Name { get; } = nameof(MyJobListener);

        public Task JobToBeExecuted(IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            //Job即将执行
            return Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"Job: {context.JobDetail.Key} 即将执行");
            });
        }

        public Task JobExecutionVetoed(IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            return Task.Factory.StartNew(() => {
                Console.WriteLine($"Job: {context.JobDetail.Key} 被否决执行");
            });
        }

        public Task JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException, CancellationToken cancellationToken = default)
        {
            //Job执行完成
            return Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"Job: {context.JobDetail.Key} 执行完成");
            });
        }
    }
}
