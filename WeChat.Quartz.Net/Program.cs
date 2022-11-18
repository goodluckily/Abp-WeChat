using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Calendar;
using Quartz.Impl.Matchers;

namespace WeChat.Quartz.Net
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var schedulerFactory = new StdSchedulerFactory();
            var scheduler = await schedulerFactory.GetScheduler();
            await scheduler.Start();
            Console.WriteLine($"任务调度器已启动");

            ////创建作业1
            //var jobDetail = JobBuilder.Create<HelloQuartzJob>().Build();



            //创建作业2
            //var jobDetail = JobBuilder.Create<SayHelloJob>()
            //                            .SetJobData(new JobDataMap() {
            //                    new KeyValuePair<string, object>("UserName", "Tom")
            //                            }) .Build();

            //创建作业3
            var jobDetail = JobBuilder.Create<SayHelloJob>()
                            .SetJobData(new JobDataMap() {
                                new KeyValuePair<string, object>("UserName", "Tom"),
                                new KeyValuePair<string, object>("RunSuccess", false)
                            })
                            .StoreDurably(true)
                            .RequestRecovery(true)
                            .WithIdentity("SayHelloJob-Tom", "DemoGroup")
                            .WithDescription("Say hello to Tom job")
                            .Build();

            //除此之外，Quartz.Net还支持两个非常有用的特性：
            //DisallowConcurrentExecution：禁止并行执行，该特性是针对JobDetail生效的
            //PersistJobDataAfterExecution：在执行完成后持久化JobData，该特性是针对Job类型生效的，意味着所有使用该Job的JobDetail都会在执行完成后持久化JobData。


            //触发器1 SampleTrigger
            //var trigger = TriggerBuilder.Create()
            //                            .WithSimpleSchedule(m =>
            //                            {
            //                                m.WithRepeatCount(3).WithIntervalInSeconds(1);
            //                            })
            //                            .Build();

            //触发器2 CronTrigger
            var trigger = TriggerBuilder.Create()
                            .WithCronSchedule("*/1 * * * * ?")
                            .Build();

            //日历：Calendar
            var calandar = new HolidayCalendar();
            calandar.AddExcludedDate(DateTime.Today);

            await scheduler.AddCalendar("holidayCalendar", calandar, false, false);

            //**** 将MyJobListener添加到Scheduler中 用于添加日志
            scheduler.ListenerManager.AddJobListener(new MyJobListener(), GroupMatcher<JobKey>.AnyGroup());

            //**** 将MyTriggerListener添加到Scheduler中
            //scheduler.ListenerManager.AddTriggerListener(new MyTriggerListener(), GroupMatcher<TriggerKey>.AnyGroup());

            //**** 添加SchedulerListener的代码如下
            //scheduler.ListenerManager.AddSchedulerListener(new MySchedListener());

            //添加调度
            await scheduler.ScheduleJob(jobDetail, trigger);

            await Task.Delay(TimeSpan.FromSeconds(200));
        }

        public class HelloQuartzJob : IJob
        {
            public Task Execute(IJobExecutionContext context)
            {
                return Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Hello Quartz.Net");
                });
            }
        }

        [PersistJobDataAfterExecution]
        public class SayHelloJob : IJob
        {
            public string UserName { get; set; }
            public string RunSuccess { get; set; }

            public Task Execute(IJobExecutionContext context)
            {
                return Task.Factory.StartNew(() =>
                {
                    Console.WriteLine($"Hello {UserName}!,{RunSuccess}");
                });
            }
        }
    }
}
