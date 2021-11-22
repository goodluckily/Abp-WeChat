using System;
using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace WeChat.Application.Contracts
{
    [DependsOn(
        typeof(AbpDddApplicationContractsModule)
        )]
    public class WeChatApplicationContractsModule:AbpModule
    {
    }
}
