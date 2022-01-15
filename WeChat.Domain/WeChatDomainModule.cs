using System;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using WeChat.Shared;

namespace WeChat.Domain
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(WeChatDomainSharedModule)
        )]
    public class WeChatDomainModule:AbpModule
    {
    }
}
