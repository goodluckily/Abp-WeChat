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
using Microsoft.AspNetCore.Http;

namespace WeChat.Host
{
    public class WorkService : BackgroundService, ITransientDependency
    {
        private readonly ILogger<WorkService> _logger;
        private readonly IServiceProvider _provider;
        private readonly IHostEnvironment _hostEnvironment;
        private readonly HttpClientHelper httpClientHelper;
        private readonly string JobHostAddress = "";

        public WorkService(ILogger<WorkService> logger, IServiceProvider serviceProvider, IHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _provider = serviceProvider;
            _hostEnvironment = hostEnvironment;
            httpClientHelper = new HttpClientHelper();
            JobHostAddress = ConfigCommon.Configuration["JobHostAddress"];

            #region 统一地址的其他方式(注释)
            //IHttpContextFactory httpContextFactory
            //1.也可以使用标头的方式设置 BaseAddress
            //2.然后请求直接配置地址 /path 就可以了 
            #endregion
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //非Dev环境下运行
            if (!_hostEnvironment.IsDevelopment())
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

                //得到Job任务的所有路由地址
                var routeJobs = GetApplicationJobRoutes.GetJobRoutes();

                #region 批量添加Job任务 1.循环监听版本
                //while (!stoppingToken.IsCancellationRequested)
                //{
                //    _logger.LogInformation($"WorkService is UpDate.{DateTime.Now}");

                //    //Job任务
                //    AddOrUpdateRecurringJobByPath(routeJobs);

                //    //循环检查激活/刷新的意思 这个以后改成配置文件的时候用到
                //    await Task.Delay(new TimeSpan(6, 0, 0), stoppingToken);
                //} 
                #endregion

                //批量添加Job任务 2.放任后台任务版本
                AddOrUpdateRecurringJobByPath(routeJobs);

                _logger.LogInformation("WorkService is stopping.");
            }
        }

        /// <summary>
        /// 批量添加Job任务 
        /// </summary>
        /// <param name="routeJobs">Post 路由地址</param>
        private void AddOrUpdateRecurringJobByPath(List<string> routeJobs)
        {
            #region 随机时间范围设置
            var nowTime = DateTime.Now;
            var startHour = ConfigCommon.Configuration["JobStartHour"].TryParseToInt();
            var startMinute = ConfigCommon.Configuration["JobStartMinute"].TryParseToInt();
            var endHour = ConfigCommon.Configuration["JobEndHour"].TryParseToInt();
            var endMinute = ConfigCommon.Configuration["JobEndMinute"].TryParseToInt();

            var startTime = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, startHour, startMinute, 0);
            var endTime = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, endHour, endMinute, 0);
            #endregion

            #region 添加/更新Job任务
            foreach (var jobPath in routeJobs)
            {
                //获取范围内的随机时间
                var randomTim = GetRandomTime(startTime, endTime);
                _logger.LogWarning("aa============" + randomTim.ToString());
                RecurringJob.AddOrUpdate(jobPath, () => PostApiRequestJobService(jobPath), Cron.Daily(randomTim.Hour, randomTim.Minute), TimeZoneInfo.Local);
            }
            #endregion
        }

        /// <summary>
        /// Api的方式请求Job里面的ApiService
        /// </summary>
        /// <param name="servicePath"></param>
        public void PostApiRequestJobService(string servicePath)
        {
            var loadJobUrl = JobHostAddress + servicePath;
            var serverKey = ConfigCommon.Configuration["JobExecutionApiKey"].ToString();
            var md5Key = StringCommon.Md5(serverKey);
            loadJobUrl = loadJobUrl + "?key=" + md5Key;
            var result = httpClientHelper.PostResponseForJobApi(loadJobUrl);
            _logger.LogInformation($"{servicePath}-------->{result}");
        }

        /// <summary>
        /// 获取指定时间范围内的随机时间
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
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