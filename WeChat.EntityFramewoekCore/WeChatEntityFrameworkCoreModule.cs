using System;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;
using WeChat.Domain;

namespace WeChat.EntityFramewoekCore
{
    [DependsOn(
        typeof(AbpEntityFrameworkCoreSqlServerModule),//sqlserver
        //typeof(AbpEntityFrameworkCoreMySQLModule),//mysql
        typeof(WeChatDomainModule)
        )]
    public class WeChatEntityFrameworkCoreModule : AbpModule
    {

    }
}
