using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using WeChat.Shared.Localization.Exceptions;
using System.Globalization;

namespace WeChat.Shared.Module
{
    public class WeChatLocalizationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(op =>
            {
                op.FileSets.AddEmbedded<WeChatDomainSharedModule>("WeChat.Shared");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                     .Add<LangueResource>("zh-Hans")
                     //.Add<LangueResource>("en")
                    .AddVirtualJson("/Localization/Resources");
                options.DefaultResourceType = typeof(LangueResource);

                options.Languages.Add(new LanguageInfo("en", "en", "English"));
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
                options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁体中文"));
            });
            
            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("WeChat", typeof(LangueResource));
            });

        }
    }
}
