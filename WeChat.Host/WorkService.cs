using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WeChat.Application.Services.Job;

namespace WeChat.Host
{
    public class WorkService : BackgroundService
    {
        //private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<WorkService> _logger;
        private readonly IServiceProvider _provider;
        public WorkService(ILogger<WorkService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _provider = serviceProvider;

        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("WorkService is starting.");
            while (!stoppingToken.IsCancellationRequested)
            {

                // do something
                _logger.LogInformation($"WorkService is running.{DateTime.Now}");
                //RecurringJob.AddOrUpdate("Test", () => Console.WriteLine($"Test is running.{DateTime.Now}"), Cron.Minutely, timeZone: TimeZoneInfo.Local);


                ////动态
                //dynamic configuration = _provider.GetRequiredService(typeof(CodeDeaultblogsJob));
                //await configuration.CodeDeaultblogsContent();


                //循环检查激活/刷新的意思?
                await Task.Delay(new TimeSpan(0, 5, 0), stoppingToken);
            }
            _logger.LogInformation("WorkService is stopping.");
        }
    }
}