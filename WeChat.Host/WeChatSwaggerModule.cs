using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;

namespace WeChat.Host
{
    [DependsOn(
        typeof(AbpSwashbuckleModule)
        )]
    public class WeChatSwaggerModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var services = context.Services;
            // 添加Swagger API文档
            services.AddAbpSwaggerGen(options =>
            {
                options.CustomSchemaIds(x => x.FullName);
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "WeChat API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
            });


        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            app.UseSwagger();
            app.UseAbpSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Warehouse API");
            });
        }
    }
}
