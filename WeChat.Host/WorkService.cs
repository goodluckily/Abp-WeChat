using System;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WeChat.Application;
using WeChat.Application.Services.Job;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Volo.Abp.Uow;
using Volo.Abp.DependencyInjection;

namespace WeChat.Host
{
    public class WorkService : BackgroundService, ITransientDependency
    {
        //private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<WorkService> _logger;
        private readonly IServiceProvider _provider;
        private readonly CodeDeaultblogsJob _codeDeaultblogsJob;

        public WorkService(ILogger<WorkService> logger, IServiceProvider serviceProvider, CodeDeaultblogsJob codeDeaultblogsJob)
        {
            _logger = logger;
            _provider = serviceProvider;
            _codeDeaultblogsJob = codeDeaultblogsJob;
        }

        [UnitOfWork]
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("WorkService is starting.");



            while (!stoppingToken.IsCancellationRequested)
            {

                // do something
                _logger.LogInformation($"WorkService is running.{DateTime.Now}");
                //RecurringJob.AddOrUpdate("Test", () => Console.WriteLine($"Test is running.{DateTime.Now}"), Cron.Minutely, timeZone: TimeZoneInfo.Local);

                //await BathHangfireJobAsync();


                RecurringJob.AddOrUpdate("CodeDeaultblogsContent", () => _codeDeaultblogsJob.CodeDeaultblogsContent().Wait(), Cron.Daily(18, 40), TimeZoneInfo.Local);

                #region OK
                //动态
                //dynamic configuration = _provider.GetRequiredService(typeof(CodeDeaultblogsJob));
                //这里可能需要反射
                //await configuration.CodeDeaultblogsContent(); 
                #endregion



                //循环检查激活/刷新的意思
                await Task.Delay(new TimeSpan(0, 30, 0), stoppingToken);
            }
            _logger.LogInformation("WorkService is stopping.");
        }

        /// <summary>
        /// 处理循环 操作Job的任务方法
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public async Task BathHangfireJobAsync()
        {
            //1.反射得到所有 定时任务类
            var assembly = Assembly.Load("WeChat.Application");
            var types = assembly.GetTypes().Where(x => x.Namespace == "WeChat.Application.Services.Job");

            var asdfas = types.Select(s => s.GetCustomAttributes()).ToList();
            //包含次特性的类
            var classArray = types.Where(s => s.GetMethods().Any(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(BathBackgroundJobAttribute)))).ToList();

            //结果数据集合 全部的任务
            var JobServiceData = new List<(Type t, string ServiceName, List<string> MethedNames)>();
            foreach (var t in classArray)
            {
                //获取方法特性中ActionName为GetSchoolAll的特性
                var jobMethods = t.GetMethods().Where(s => s.CustomAttributes.Any(x => x.AttributeType == typeof(BathBackgroundJobAttribute))).ToList();
                if (!jobMethods.Any()) continue;

                var methodsData = new List<string>();
                foreach (var item in jobMethods)
                {
                    var methedName = item.Name;
                    _logger.LogInformation($"========={t.Name}下的方法{methedName}=========进行匹配Job加载......");

                    #region 注释(曾研究的方向)
                    //var bathBackgroundJobAttr = item.CustomAttributes.FirstOrDefault(x => x.AttributeType == typeof(BathBackgroundJobAttribute));
                    //var jobName = bathBackgroundJobAttr.ConstructorArguments[0].Value;
                    //var corn = bathBackgroundJobAttr.ConstructorArguments[1].Value;
                    //var queue = bathBackgroundJobAttr.ConstructorArguments[2].Value; 


                    //方法一 OK
                    //await configuration.CodeDeaultblogsContent();

                    //方法二 NO
                    //await configuration.methedName();

                    //属性注入仓储拿获取???
                    //var addMethod = t.GetMethod(methedName);
                    //await addMethod.Invoke(configuration, null);
                    #endregion

                    methodsData.Add(methedName);
                }
                JobServiceData.Add((t, t.Name, methodsData));
            }
            var OkJsonData = JsonConvert.SerializeObject(JobServiceData);
            _logger.LogInformation(OkJsonData);

            //分配任务
            await RunJobByService(JobServiceData);

            //准备动态拼接Http的Post请求 唉真是醉了 这种特殊的实现 哈哈
        }

        [UnitOfWork]
        public async Task RunJobByService(List<(Type t, string ServiceName, List<string> MethedNames)> JobServiceData)
        {
            foreach (var itemjob in JobServiceData)
            {
                //动态获取service
                dynamic requiredService = _provider.GetRequiredService(itemjob.t);
                switch (itemjob.ServiceName)
                {
                    case "CodeDeaultblogsJob":
                        await requiredService.CodeDeaultblogsContent();
                        break;
                    case "CsdnBlogJob":
                        await requiredService.CsdnBlogContent();
                        await requiredService.CsdnTuiJianContent();
                        break;
                    case "CTO51blogsJob":
                        await requiredService.CTO51blogsContentAsync();
                        break;
                    case "ItHomeblogsJob":
                        await requiredService.ItHomeblogsContent();
                        await requiredService.ItHomeblogsMicrosoftContent();
                        break;
                    case "JueJinBlogJob":
                        await requiredService.JueJinblogs();
                        break;
                    case "NetBlogJob":
                        await requiredService.Netcnblogs();
                        await requiredService.Newscnblogs();
                        break;
                    case "OsChinablogsJob":
                        await requiredService.OsChinablogsContent();
                        break;
                    case "SegmentfaultblogsJob":
                        await requiredService.SegmentfaultblogsContent();
                        break;
                }
            }
        }
    }
}