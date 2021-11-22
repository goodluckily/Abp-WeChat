using System;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace WeChat.Domain
{
    [DependsOn(
        typeof(AbpDddDomainModule)
        )]
    public class WeChatDomainModule:AbpModule
    {
    }
}
