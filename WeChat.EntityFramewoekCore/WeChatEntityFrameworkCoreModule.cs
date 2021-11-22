using System;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace WeChat.EntityFramewoekCore
{
    [DependsOn(
        typeof(AbpEntityFrameworkCoreModule)
        )]
    public class WeChatEntityFrameworkCoreModule:AbpModule
    {
    }
}
