using System;
using System.Threading;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WeChat.Application.Services.Job;
using Volo.Abp.DependencyInjection;
using WeChat.Http.HttpHelper;
using System.Net.Http;
using WeChat.Shared;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using WeChat.Application;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using WeChat.Host.Job;

namespace WeChat.Host
{
    public class WorkService : BackgroundService, ITransientDependency
    {
        private readonly ILogger<WorkService> _logger;
        private readonly IServiceProvider _provider;
        private readonly HttpClientHelper httpClientHelper;
        private readonly string JobHostAddress = "";

        public WorkService(ILogger<WorkService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _provider = serviceProvider;
            httpClientHelper = new HttpClientHelper();
            JobHostAddress = ConfigCommon.Configuration["JobHostAddress"];
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("WorkService is starting.");

            #region old版本 注释 !!!
            //while (!stoppingToken.IsCancellationRequested)
            //{
            //    _logger.LogInformation($"WorkService is running.{DateTime.Now}");

            //    #region MyRegion
            //    //do something
            //    //RecurringJob.AddOrUpdate("Test", () => Console.WriteLine($"Test is running.{DateTime.Now}"), Cron.Minutely, timeZone: TimeZoneInfo.Local);
            //    //RecurringJob.AddOrUpdate("CodeDeaultblogsContent", () => _codeDeaultblogsJob.CodeDeaultblogsContent().Wait(), Cron.Daily(18, 40), TimeZoneInfo.Local);
            //    //await BathHangfireJobAsync(); 
            //    #endregion

            //    #region Old
            //    //动态
            //    //dynamic configuration = _provider.GetRequiredService(typeof(CodeDeaultblogsJob));
            //    //这里可能需要反射
            //    //await configuration.CodeDeaultblogsContent(); 
            //    #endregion

            //    //循环检查激活/刷新的意思 这个以后改成配置文件的时候用到
            //    await Task.Delay(new TimeSpan(0, 30, 0), stoppingToken);
            //}
            #endregion

            #region 模拟
            ////可以之后的这个是可以的 哈哈 url请求数据
            //RecurringJob.AddOrUpdate("baidu", () => Console.WriteLine("baidu"), "0 */2 * * * ?", TimeZoneInfo.Local);// 每隔2分钟执行一次
            //RecurringJob.AddOrUpdate("tengxun", () => Console.WriteLine("tengxun"), "0 */3 * * * ?", TimeZoneInfo.Local);// 每隔3分钟执行一次 
            #endregion

            var routeJobs = GetApplicationJobRoutes.GetJobRoutes();
            var nowTime = DateTime.Now;
            var startTime = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, 19, 30, 0);
            var endTime = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, 20, 30, 0);
            //批量添加Job任务
            while (!stoppingToken.IsCancellationRequested)
            {
                foreach (var jobPath in routeJobs)
                {
                    //获取分钟时间
                    var randomTim = GetRandomTime(startTime, endTime);
                    _logger.LogWarning("aa============" + randomTim.ToString());
                    RecurringJob.AddOrUpdate(jobPath, () => PostApiRequestJobService(jobPath), Cron.Daily(randomTim.Hour, randomTim.Minute), TimeZoneInfo.Local);
                }
                _logger.LogInformation($"WorkService is UpDate.{DateTime.Now}");
                //循环检查激活/刷新的意思 这个以后改成配置文件的时候用到
                await Task.Delay(new TimeSpan(1, 0, 0), stoppingToken);
            }
            _logger.LogInformation("WorkService is stopping.");
        }

        /// <summary>
        /// Api的方式请求Job里面的ApiService
        /// </summary>
        /// <param name="servicePath"></param>
        public void PostApiRequestJobService(string servicePath)
        {
            var loadJobUrl = JobHostAddress + servicePath;
            var result = httpClientHelper.PostResponse(loadJobUrl, "");
            _logger.LogInformation($"{servicePath}-------->{result}");
        }

        //获取指定时间范围内的随机时间
        public DateTime GetRandomTime(DateTime startTime, DateTime endTime)
        {
            var random = new Random();
            var startInt = (int)startTime.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            var endInt = (int)endTime.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            var randomInt = random.Next(startInt, endInt);
            return new DateTime(1970, 1, 1).AddSeconds(randomInt);
        }
    }
}