using System;
using System.Threading.Tasks;
using Hangfire;
using Volo.Abp;
using Volo.Abp.BackgroundJobs.Hangfire;
using Volo.Abp.Modularity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WeChat.Shared;
using Hangfire.Dashboard.BasicAuthorization;
using Hangfire.MySql;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace WeChat.Host
{
    [DependsOn(typeof(AbpBackgroundJobsHangfireModule))]
    public class BackgroundJobsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var services = context.Services;
            var configuration = services.GetConfiguration();
            var hostingEnvironment = services.GetHostingEnvironment();

            var mySqlConnectionString = ConfigCommon.Configuration["ConnectionStrings:WeChat"];
            services.AddHangfire(config =>
            {
                config.UseStorage(
                    new MySqlStorage(mySqlConnectionString,
                    new MySqlStorageOptions
                    {
                        TransactionTimeout = TimeSpan.FromMinutes(5),//交易超时。默认值为 1 分钟
                        TablesPrefix = "hangfire_"//数据库中表的前缀。默认为无
                    }));
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();

            //Hangfire 的界面显示  /hangfire 查看 "": {
            var hangfireLogin = ConfigCommon.Configuration["Hangfire:Login"];
            var hangfirePwd = ConfigCommon.Configuration["Hangfire:Password"];
            app.UseHangfireDashboard(pathMatch: "/job", options: new DashboardOptions
            {
                Authorization = new[]
                    {
                    new BasicAuthAuthorizationFilter(new BasicAuthAuthorizationFilterOptions
                    {
                        RequireSsl = false,//是否启用ssl验证，即https
                        SslRedirect = false,
                        LoginCaseSensitive = true,
                        Users = new []
                        {
                            new BasicAuthAuthorizationUser
                            {
                                   Login = hangfireLogin,
                                   PasswordClear = hangfirePwd
                            }
                        }
                    })
                },
                DashboardTitle = "WeChat任务调度中心"
            });

            //开始使用Hangfire服务
            app.UseHangfireServer(new BackgroundJobServerOptions
            {
                //WorkerCount 并发任务数 用的是默认的20
                WorkerCount = 5,
                ServerName = "WeChat_Hangfire",//服务器名称
                Queues = new[] { "jobs", "apis", "default" },//队列名称，只能为小写
            });

            //var service = context.ServiceProvider;
            //service.UseWallpaperJob();
            //service.UseHotNewsJob();
            //service.UsePuppeteerTestJob();
        }
    }
}
