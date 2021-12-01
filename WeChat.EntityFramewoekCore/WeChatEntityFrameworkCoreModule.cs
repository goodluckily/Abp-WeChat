using System;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using WeChat.Domain;

namespace WeChat.EntityFramewoekCore
{
    [DependsOn(
        typeof(AbpEntityFrameworkCoreModule),
        typeof(WeChatDomainModule)
        )]
    public class WeChatEntityFrameworkCoreModule:AbpModule
    {
    }
}
