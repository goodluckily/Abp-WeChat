using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using NLog.Web;
using WeChat.Shared;
using WeChat.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using WeChat.EntityFramewoekCore;

namespace WeChat.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            try
            {
                //确保NLog.config中连接字符串与appsettings.json中同步
                var mySqlConnectionString = ConfigCommon.GetConfig<string>("ConnectionStrings:WeChat");
                NLogCommon.EnsureNlogConfig("NLog.config", mySqlConnectionString);
                //其他项目启动时需要做的事情
                //code
                NLogCommon.WriteDBLog(NLog.LogLevel.Trace, LogTypeEnum.Web, "网站启动成功");

                host.Run();
            }
            catch (Exception ex)
            {
                //使用nlog写到本地日志文件（万一数据库没创建/连接成功）
                string errorMessage = "网站启动初始化数据异常";
                NLogCommon.WriteFileLog(NLog.LogLevel.Error, LogTypeEnum.Web, errorMessage, exception: new Exception(errorMessage, ex));
                NLogCommon.WriteDBLog(NLog.LogLevel.Error, LogTypeEnum.Web, errorMessage, exception: new Exception(errorMessage, ex));
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
                .UseAutofac()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //webBuilder.UseUrls("http://127.0.0.1:9999/", "http://localhost:9999/");
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureServices(services =>
                {
                    //后台任务
                    //services.AddHostedService<WorkService>();
                    
                    //初始化种子数据
                    services.AddHostedService<InitSeedDataServer> ();
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                }).UseNLog();//NLog 依赖注入
    }
}
