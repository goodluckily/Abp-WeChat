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
            }
        }

    }
}
