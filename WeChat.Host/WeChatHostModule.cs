using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;
using WeChat.Application;
using WeChat.EntityFramewoekCore;
using WeChat.Host.EntityFrameworkCore;

namespace WeChat.Host
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutofacModule),
        typeof(WeChatSwaggerModule),//swagger 模块
        typeof(WeChatApplicationModule),
        typeof(WeChatEntityFrameworkCoreModule)
        )]
    public class WeChatHostModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var services = context.Services;
            //多语言设置
            Configure<AbpLocalizationOptions>(op =>
            {
                op.Languages.Add(new LanguageInfo("en", "en", "English"));
                op.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));

                //options.Languages.Add(new LanguageInfo("ar", "ar", "العربية"));
                //options.Languages.Add(new LanguageInfo("cs", "cs", "Čeština"));
                //options.Languages.Add(new LanguageInfo("en-GB", "en-GB", "English (UK)"));
                //options.Languages.Add(new LanguageInfo("fi", "fi", "Finnish"));
                //options.Languages.Add(new LanguageInfo("fr", "fr", "Français"));
                //options.Languages.Add(new LanguageInfo("hi", "hi", "Hindi", "in"));
                //options.Languages.Add(new LanguageInfo("it", "it", "Italian", "it"));
                //options.Languages.Add(new LanguageInfo("hu", "hu", "Magyar"));
                //options.Languages.Add(new LanguageInfo("pt-BR", "pt-BR", "Português (Brasil)"));
                //options.Languages.Add(new LanguageInfo("ro-RO", "ro-RO", "Română"));
                //options.Languages.Add(new LanguageInfo("ru", "ru", "Русский"));
                //options.Languages.Add(new LanguageInfo("sk", "sk", "Slovak"));
                //options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe"));
                //options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文"));
                //options.Languages.Add(new LanguageInfo("de-DE", "de-DE", "Deutsch"));
                //options.Languages.Add(new LanguageInfo("es", "es", "Español"));
            });

            services.AddAbpDbContext<WeChatDbContext>(options=> 
            {
                options.AddDefaultRepositories();
            });

            services.AddAbpDbContext<WeChatSecondDbContext>();

            Configure<AbpDbContextOptions>(optios=> 
            {
                optios.UseMySQL();
            });

        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseUnitOfWork();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
