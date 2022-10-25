using System;
using Nancy.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using WeChat.Shared.Localization.Exceptions;
using WeChat.Shared.Module;

namespace WeChat.Shared
{
    [DependsOn(
        typeof(AbpValidationModule),
        typeof(WeChatLocalizationModule) //多语言的相关模块配置
        )]
    public class WeChatDomainSharedModule:AbpModule
    {
       
    }
}
