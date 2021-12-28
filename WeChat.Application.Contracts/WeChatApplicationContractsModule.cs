using System;
using Volo.Abp.Application;
using Volo.Abp.Modularity;
using WeChat.Domain.Shared;

namespace WeChat.Application.Contracts
{
    [DependsOn(
        typeof(AbpDddApplicationContractsModule),
        typeof(WeChatDomainSharedModule)
        )]
    public class WeChatApplicationContractsModule:AbpModule
    {
    }
}
