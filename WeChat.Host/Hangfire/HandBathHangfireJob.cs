using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WeChat.Application;
using WeChat.Application.HangJob;
using WeChat.Application.Services.Job;

namespace WeChat.Host.Hangfire
{
    public static class HandBathHangfireJob
    {
        public static async Task UseBathHangfireJob(this IServiceProvider service)
        {
            //HandBathHangfire.BathHangfireJob();
            using (IServiceScope serviceScope = service.CreateScope())
            {
                IServiceProvider provider = serviceScope.ServiceProvider;

                var csdnJob = provider.GetRequiredService<CsdnBlogJob>();
                //测试 只是执行一次
                BackgroundJob.Enqueue(() => csdnJob.CsdnTuiJianContent().Wait());

                //到时候这里准备用定时任务 nssm 部署控制器单独部署一个用来高windows服务 到时候用来测试,检验性能,查看如何

                //1.检测定时任务时候正常运行

                //2.查看占用资源

                //3.测试效果,检查端口是否能正常打开之类的

                //4.资源释放之类的
            }
        }

    }
}
