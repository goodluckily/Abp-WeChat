using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore.DependencyInjection;

namespace WeChat.EntityFramewoekCore
{
    public static class ServiceDynamicDbSet
    {
        public static void AddDefaultRepositories(this IServiceCollection services)
        {
            // 传递一个AbpCommonDbContextRegistrationOptions类型，便于RepositoryRegistrarBase基类属性注入
            var options = new AbpDbContextRegistrationOptions(typeof(WeChatDbContext), services);

            // 我们上边自定义获取EntityType实现注入默认仓储
            new EfCoreRepositoryCustomerRegistrar(options).AddRepositories();
        }
    }
}
