using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;
using WeChat.Domain;

namespace WeChat.EntityFramewoekCore
{
    [DependsOn(
        //typeof(AbpEntityFrameworkCoreSqlServerModule),//sqlserver
        typeof(AbpEntityFrameworkCoreMySQLModule),//mysql
        typeof(WeChatDomainModule)
        )]
    public class WeChatEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var services = context.Services;
            //services.AddAbpDbContext<WeChatDbContext>();
        }
    }
}
