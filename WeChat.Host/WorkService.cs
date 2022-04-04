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

namespace WeChat.Host
{
    public class WorkService : BackgroundService, ITransientDependency
    {
        private readonly ILogger<WorkService> _logger;
        private readonly IServiceProvider _provider;
        private readonly IHostEnvironment _hostEnvironment;
        private readonly HttpClientHelper httpClientHelper;

        public WorkService(ILogger<WorkService> logger, IServiceProvider serviceProvider, IWebHostEnvironment hostEnvironment)
        {
            var aa = ConfigCommon.Configuration["urls"];
            _logger = logger;
            _provider = serviceProvider;
            httpClientHelper = new HttpClientHelper();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("WorkService is starting.");
            while (!stoppingToken.IsCancellationRequested)
            {

                // do something
                _logger.LogInformation($"WorkService is running.{DateTime.Now}");

                //RecurringJob.AddOrUpdate("Test", () => Console.WriteLine($"Test is running.{DateTime.Now}"), Cron.Minutely, timeZone: TimeZoneInfo.Local);
                //RecurringJob.AddOrUpdate("CodeDeaultblogsContent", () => _codeDeaultblogsJob.CodeDeaultblogsContent().Wait(), Cron.Daily(18, 40), TimeZoneInfo.Local);

                //await BathHangfireJobAsync();

                //可以之后的这个是可以的 哈哈 url请求数据
                RecurringJob.AddOrUpdate("httpCodeDeaultblogsContent", () => Test(), Cron.Daily(23, 55), TimeZoneInfo.Local);

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

        public void Test()
        {
            var result = httpClientHelper.PostResponse("http://127.0.0.1:5555/CodeDeaultblogsJob/CodeDeaultblogsContent", "");
        }
    }
}