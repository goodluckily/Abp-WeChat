using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.Modularity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Reflection;
using System.IO;
using System;
using Microsoft.AspNetCore.Hosting;
using WeChat.Host.Filter;
using Hangfire;

namespace WeChat.Host
{
    public class WeChatSwaggerModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var services = context.Services;
            var hostingEnvironment = services.GetHostingEnvironment(); // == services.GetSingletonInstance<IWebHostEnvironment>();
            // 添加Swagger API文档
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "WeChat API", Version = "v1" });
                options.CustomSchemaIds(x => x.FullName);
                options.DocInclusionPredicate((docName, description) => true);

                //省略其他代码
                //options.DocumentFilter<SwaggerEnumFilter>();

                //启用swagger验证功能
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "在下框中输入请求头中需要添加Jwt授权Token：Bearer Token",
                    Name = "Authorization",
                    In = ParameterLocation.Cookie,
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                // 添加swagger-API方法注释
                var xmlapppath = Path.Combine(AppContext.BaseDirectory, "WeChat.Application.xml");
                if (File.Exists(xmlapppath))
                    options.IncludeXmlComments(xmlapppath, true);

                // 添加swagger-自定义控制器注释
                var xmlapipath = Path.Combine(AppContext.BaseDirectory, "WeChat.Host.xml");
                if (File.Exists(xmlapipath))//
                    options.IncludeXmlComments(xmlapipath, true);
            });
        }
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "WeChat API");
                //swagger 默认折叠
                options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            });
        }
    }
}
