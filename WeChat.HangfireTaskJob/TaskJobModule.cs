using System;
using Hangfire;
using Volo.Abp;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;
using WeChat.Shared;
using Hangfire.Dashboard.BasicAuthorization;
using Hangfire.MySql;
using Volo.Abp.Autofac;
using Volo.Abp.AspNetCore.Mvc;
using WeChat.Application;
using WeChat.EntityFramewoekCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Guids;
using WeChat.HangfireTaskJob.HangJob;

namespace WeChat.HangfireTaskJob
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutofacModule),
        typeof(AbpEntityFrameworkCoreMySQLModule),//mysql
        typeof(WeChatApplicationModule),
        typeof(WeChatEntityFrameworkCoreModule)
        )]
    public class TaskJobModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {

            var services = context.Services;
            var configuration = services.GetConfiguration();
            var mySqlConnectionString = ConfigCommon.Configuration["ConnectionStrings:WeChat"];

            //1.配置动态API控制器
            //2.这里定义了 Application 里面可以自动的实现 webapi
            services.Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                //[RemoteService(true)] 指定API 隐藏
                options.ConventionalControllers.Create(typeof(WeChatApplicationModule).Assembly);
            });

            #region DB

            services.AddAbpDbContext<WeChatDbContext>(options =>
            {
                options.AddDefaultRepositories(includeAllEntities: true);
            });

            Configure<AbpDbContextOptions>(optios =>
            {
                optios.UseMySQL();
                //optios.UseSqlServer();
                //Microsoft.EntityFrameworkCore.Proxies //需要安装Buget包
                //optios.DbContextOptions.UseLazyLoadingProxies(); //启用延时加载
            });

            #region 依据数据库类型 配置 Guid
            //SequentialAtEnd（默认）适用于SQL Server。
            //SequentialAsString由MySQL和PostgreSQL 使用。
            //SequentialAsBinary由Oracle 使用
            Configure<AbpSequentialGuidGeneratorOptions>(options =>
            {
                options.DefaultSequentialGuidType = SequentialGuidType.SequentialAsString; //mysql 使用
            });
            #endregion

            #endregion

            #region Job
            services.AddHangfire(config =>
                {
                    config.UseStorage(
                        new MySqlStorage(mySqlConnectionString,
                        new MySqlStorageOptions
                        {
                            TransactionTimeout = TimeSpan.FromMinutes(5),//交易超时。默认值为 1 分钟
                            TablesPrefix = "hangfire_",//数据库中表的前缀。默认为无
                        }));
                });
            //开始使用Hangfire服务
            services.AddHangfireServer(config =>
            {
                config.WorkerCount = 5;
                config.ServerName = "WeChat_Hangfire";//服务器名称
                config.Queues = new[] { "jobs", "apis", "default" };//队列名称，只能为小写
            });
            #endregion
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();

            #region 注释
            //var logger = context.ServiceProvider.GetRequiredService<ILogger<MyConsoleAppModule>>();
            //var configuration = context.ServiceProvider.GetRequiredService<IConfiguration>();
            //logger.LogInformation($"MySettingName => {configuration["MySettingName"]}");
            //var hostEnvironment = context.ServiceProvider.GetRequiredService<IHostEnvironment>();
            //logger.LogInformation($"EnvironmentName => {hostEnvironment.EnvironmentName}"); 
            #endregion

            #region Hangfire
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
            #endregion

            //模拟调用 有回到了原点 哈哈
            //只不过项目单独提炼出来了而已
            HandBathHangfire.BathHangfireJob(context);
        }
    }
}



//2.得到定时任务 特性下的方法

//3.依据参数 执行方法
//RecurringJob.AddOrUpdate("powerfuljob", () => Console.Write("Powerful!"), "0 12 * */2");

//2022/04/03 代办
//尝试Job任务依然使用授权
//1.dynamic 调用内部方法跳过授权 看能不能行
//2.可能得switch配置方法调用了


//可以尝试 ui和定时服务分开
