﻿using System;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using WeChat.Shared.Localization.Exceptions;

namespace WeChat.Shared
{
    [DependsOn(
        typeof(AbpValidationModule)
        )]
    public class WeChatDomainSharedModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(op=> {
                op.FileSets.AddEmbedded<WeChatDomainSharedModule>("WeChat.Shared");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                     .Add<ExceptionResource>("zh-Hans")
                    .AddVirtualJson("/Localization/Exceptions");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("WeChat", typeof(ExceptionResource));
            });
        }
    }
}
