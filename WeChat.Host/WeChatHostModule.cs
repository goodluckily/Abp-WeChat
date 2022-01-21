using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.ExceptionHandling;
using Volo.Abp.Autofac;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Guids;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using WeChat.Application;
using WeChat.Shared;
using WeChat.EntityFramewoekCore;
using WeChat.Host.Filter;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace WeChat.Host
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutofacModule),
        //typeof(AbpEntityFrameworkCoreSqlServerModule),//sqlserver
        typeof(AbpEntityFrameworkCoreMySQLModule),//mysql
        typeof(WeChatApplicationModule),
        typeof(WeChatEntityFrameworkCoreModule),
        //typeof(AbpSwashbuckleModule),//框架自带的  Swagger 模块 注释!!!
        typeof(WeChatSwaggerModule),//使用自己定义的 Swagger 模块
        typeof(BackgroundJobsModule)//hangfire 定时任务的添加
        )]
    public class WeChatHostModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var services = context.Services;
            var mySqlConnectionString = ConfigCommon.Configuration["ConnectionStrings:WeChat"];

            #region 静态类的配置文件
            //var configuration = BuildConfiguration();
            //configuration.GetSection("ConnectionStrings").Bind(new WeChatAppSetting());
            //configuration.GetSection("WeChatConfig").Bind(new WeChatAppSetting());
            //configuration.GetSection("JWT").Bind(new WeChatAppSetting());
            #endregion

            //1.配置动态API控制器
            //2.这里定义了 Application 里面可以自动的实现 webapi
            services.Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                //[RemoteService(true)] 指定API 隐藏
                options.ConventionalControllers.Create(typeof(WeChatApplicationModule).Assembly);
            });

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

            Configure<AbpDbContextOptions>(optios =>
            {
                optios.UseMySQL();
                //optios.UseSqlServer();

                //Microsoft.EntityFrameworkCore.Proxies //需要安装Buget包
                //optios.DbContextOptions.UseLazyLoadingProxies(); //启用延时加载
            });

            #endregion

            //2.异常处理 3.返回结果处理
            Configure<MvcOptions>(options =>
            {
                var filterEx = options.Filters.ToList().FirstOrDefault(x => x is ServiceFilterAttribute attribute && attribute.ServiceType.Equals(typeof(AbpExceptionFilter)));
                if (filterEx is not null)
                    options.Filters.Remove(filterEx);//1.移除 abp定义的
                options.Filters.Add(typeof(WeChatGlobalExceptionFilter));//2.添加自己写的 异常处理
                options.Filters.Add(typeof(WeChatActionFilter));//3.添加自己写的  控制器 AOP
            });

            #region Session

            services.AddSession(options =>
            {
                options.Cookie.Name = ".WeChat.Session";
                options.IdleTimeout = System.TimeSpan.FromDays(1);//设置session的过期时间
                options.Cookie.HttpOnly = true;//设置在浏览器不能通过js获得该cookie的值
                options.Cookie.SameSite = SameSiteMode.Strict;//严格模式
            });

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();

            #endregion

            #region JWT or authtoken配置

            //密钥
            var secretKey = ConfigCommon.Configuration["JWT:SecretKey"];
            var key = Encoding.UTF8.GetBytes(secretKey);

            //jwt鉴权授权
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;

                x.Events = new JwtBearerEvents
                {
                    //先触发MessageReceived事件，来获取Token
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.HttpContext.Request.Cookies["Authtoken"];
                        var requestPath = context.HttpContext.Request.Path.Value;
                        if (!string.IsNullOrWhiteSpace(accessToken))//&& requestPath.Contains("hubs/signalr")
                        {
                            context.Token = accessToken;
                        }
                        return System.Threading.Tasks.Task.CompletedTask;
                    },
                    //此处为权限验证失败后触发的事件
                    OnChallenge = async context =>
                    {
                        //var accessToken = context.HttpContext.Request.Cookies["Authtoken"];
                        //var requestPath = context.HttpContext.Request.Path.Value;

                        //此处代码为终止.Net Core默认的返回类型和数据结果，这个很重要哦，必须
                        context.HandleResponse();
                        //自定义返回的数据类型
                        context.Response.ContentType = "application/json";
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                        context.Response.StatusCode = (int)HttpStatusCode.OK;

                        //清除
                        context.HttpContext.Response.Headers.Remove("Authorization");
                        context.HttpContext.Response.Cookies.Delete("Authtoken");
                        context.HttpContext.Response.Cookies.Delete("RoleValue");

                        await context.Response.WriteAsJsonAsync(new DataResult((int)HttpStatusCode.Unauthorized, "失效,请重新登陆"));
                        return;
                    }
                };

                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,//是否验证SecurityKey token 正确性
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    RequireExpirationTime = true,//是否需要验证 过期时间
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            #endregion

            #region 依据数据类型 配置 Guid
            //SequentialAtEnd（默认）适用于SQL Server。
            //SequentialAsString由MySQL和PostgreSQL 使用。
            //SequentialAsBinary由Oracle 使用
            Configure<AbpSequentialGuidGeneratorOptions>(options =>
            {
                options.DefaultSequentialGuidType = SequentialGuidType.SequentialAsString; //mysql 使用
            });
            #endregion


            #region 健康检查

            //db
            services.AddHealthChecks().AddMySql(
                connectionString: mySqlConnectionString,
                name: "sql",
                failureStatus: HealthStatus.Degraded,
                tags: new string[] { "db", "sql", "mysql" },
                System.TimeSpan.FromMinutes(3));

            services.AddHealthChecksUI(setupSettings: set =>
            {
                set.SetEvaluationTimeInSeconds(10);//将 UI 配置为每 10 秒轮询一次健康检查更新
                set.AddHealthCheckEndpoint("HealthCheck", "/Health/Index");
            }).AddMySqlStorage(mySqlConnectionString);
            #endregion
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

            app.UseAuthentication();  //添加认证
            app.UseAuthorization();   //添加授权

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapHealthChecksUI(option =>
                {
                    option.UIPath = "/hc-ui";
                });
            });
        }

        //private static IConfigurationRoot BuildConfiguration()
        //{
        //    var builder = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json", optional: false);

        //    return builder.Build();
        //}
    }
}
