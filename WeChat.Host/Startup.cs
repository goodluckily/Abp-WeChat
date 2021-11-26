using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace WeChat.Host
{
    public class Startup
    {

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //模块化
            services.AddApplication<WeChatHostModule>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            //
            app.InitializeApplication();
        }



        //1.首先翔想 测试一下 有没有提交草稿的 接口权限


        //2.然后再试一下 公众号自定义菜单的功能

        //3.然后再试试 Rozoir 写一个 H5页面尝试尝试
    }
}
