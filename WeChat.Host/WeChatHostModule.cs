using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.IO;
using System.Linq;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.ExceptionHandling;
using Volo.Abp.Autofac;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;
using WeChat.Application;
using WeChat.Domain.Shared.Setting;
using WeChat.EntityFramewoekCore;
using WeChat.Host.EntityFrameworkCore;
using WeChat.Host.Filter;

namespace WeChat.Host
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcModule),

        //typeof(AbpSwashbuckleModule),//框架自带的  Swagger 模块 注释!!!
        typeof(WeChatSwaggerModule),//使用自己定义的 Swagger 模块

        typeof(AbpEntityFrameworkCoreSqlServerModule),//sqlserver
        //typeof(AbpEntityFrameworkCoreMySQLModule),//mysql

        typeof(WeChatApplicationModule),
        typeof(WeChatEntityFrameworkCoreModule),
        typeof(AbpAutofacModule)
        )]
    public class WeChatHostModule : AbpModule
    {

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var services = context.Services;


            #region 静态类的配置文件
            var configuration = BuildConfiguration();
            configuration.GetSection("ConnectionStrings").Bind(new WeChatAppSetting());
            configuration.GetSection("WeChatConfig").Bind(new WeChatAppSetting()); 
            #endregion

            //1.配置动态API控制器
            //2.这里定义了 Application 里面可以自动的实现 webapi
            services.Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                //[RemoteService(true)] 指定API 隐藏
                options.ConventionalControllers.Create(typeof(WeChatApplicationModule).Assembly);
            });

            var sdfas = WeChatAppSetting.ConnectionKey;
            //跨域配置
            services.AddCors(option =>
            {
                option.AddPolicy("CorsPolicy", op =>
                {
                    op.SetIsOriginAllowed((x) => true)
                       .AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
                });
            });

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

            #region DB
            services.AddAbpDbContext<WeChatDbContext>(options =>
                {
                    options.AddDefaultRepositories(includeAllEntities: true);
                });

            services.AddAbpDbContext<WeChatSecondDbContext>(options =>
            {
                options.AddDefaultRepositories(includeAllEntities: true);
            });

            Configure<AbpDbContextOptions>(optios =>
            {
                //optios.UseMySQL();
                optios.UseSqlServer();
            });

            #endregion

            //异常处理
            Configure<MvcOptions>(options =>
            {
                var filterEx = options.Filters.ToList().FirstOrDefault(x => x is ServiceFilterAttribute attribute && attribute.ServiceType.Equals(typeof(AbpExceptionFilter)));
                if (filterEx is not null)
                    options.Filters.Remove(filterEx);//1.移除 abp定义的
                options.Filters.Add(typeof(WeChatGlobalExceptionFilter));//2.添加自己写的
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

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }


        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
