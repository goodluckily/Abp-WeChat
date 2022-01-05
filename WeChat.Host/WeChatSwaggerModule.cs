using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Reflection;
using System.IO;
using System;

namespace WeChat.Host
{
    [DependsOn(
        typeof(AbpSwashbuckleModule)
        )]
    public class WeChatSwaggerModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var services = context.Services;

            // 添加Swagger API文档
            services.AddAbpSwaggerGen(options =>
            {
                //获取注释文档路径  bin\Debug\net5.0\XXXXXX.xml
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //显示方法注释
                options.IncludeXmlComments(xmlPath, true);

                options.CustomSchemaIds(x => x.FullName);
                options.DocInclusionPredicate((docName, description) => true);
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "WeChat API", Version = "v1" });

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

                //添加全局安全条件
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            app.UseSwagger();
            app.UseAbpSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Warehouse API");

                //swagger 默认折叠
                options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            });
        }
    }
}
