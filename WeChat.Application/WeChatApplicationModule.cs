using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using WeChat.Application.Mapping;
using WeChat.Domain;

namespace WeChat.Application
{
    [DependsOn(
        typeof(AbpDddApplicationModule),
        typeof(AbpAutoMapperModule),
        typeof(WeChatDomainModule)
        )]
    public class WeChatApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            // Use AutoMapper for MyModule
            context.Services.AddAutoMapperObjectMapper<WeChatApplicationModule>();

           Configure<AbpAutoMapperOptions>(options =>
           {
               options.AddProfile<WeChatMappingProfile>(validate: true);
           });
        }
    }
}
