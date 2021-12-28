using System;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.Modularity;
using WeChat.Domain;

namespace WeChat.EntityFramewoekCore
{
    [DependsOn(
        typeof(AbpEntityFrameworkCoreMySQLModule),
        typeof(WeChatDomainModule)
        )]
    public class WeChatEntityFrameworkCoreModule:AbpModule
    {
    }
}
