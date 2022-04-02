using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;
using Volo.Abp;
using WeChat.Application;
using WeChat.Application.Services.Job;
using WeChat.Shared;

namespace WeChat.HangfireTaskJob.HangJob
{
    public static class HandBathHangfire
    {
        /// <summary>
        /// 处理循环 操作Job的任务方法
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static async void BathHangfireJob(ApplicationInitializationContext context)
        {
            var config = context.GetConfiguration();

            //1.反射得到所有 定时任务类
            var assembly = Assembly.Load("WeChat.Application");
            var types = assembly.GetTypes().Where(x => x.Namespace == "WeChat.Application.Services.Job");

            var asdfas = types.Select(s => s.GetCustomAttributes()).ToList();
            //包含次特性的类
            var classArray = types.Where(s => s.GetMethods().Any(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(BathBackgroundJobAttribute)))).ToList();
            foreach (var t in classArray)
            {
                //获取方法特性中ActionName为GetSchoolAll的特性
                var jobMethods = t.GetMethods().Where(s => s.CustomAttributes.Any(x => x.AttributeType == typeof(BathBackgroundJobAttribute))).ToList();
                if (!jobMethods.Any()) continue;
                foreach (var item in jobMethods)
                {
                    #region 注释
                    dynamic methedName = item.Name;
                    //var bathBackgroundJobAttr = item.CustomAttributes.FirstOrDefault(x => x.AttributeType == typeof(BathBackgroundJobAttribute));
                    //var jobName = bathBackgroundJobAttr.ConstructorArguments[0].Value;
                    //var corn = bathBackgroundJobAttr.ConstructorArguments[1].Value;
                    //var queue = bathBackgroundJobAttr.ConstructorArguments[2].Value; 
                    #endregion

                    ////动态
                    dynamic configuration = context.ServiceProvider.GetRequiredService(t);

                    //方法一 OK
                    //await configuration.CodeDeaultblogsContent();

                    //方法二 NO
                    //await configuration.methedName();

                    //属性注入仓储拿获取???
                    //var addMethod = t.GetMethod(methedName);
                    //await addMethod.Invoke(configuration, null);

                    Console.WriteLine("ok");
                }

                //2.得到定时任务 特性下的方法

                //3.依据参数 执行方法
                //RecurringJob.AddOrUpdate("powerfuljob", () => Console.Write("Powerful!"), "0 12 * */2");


            }
        }

        public static void GetConfigurationJobManagerRun()
        {
            var jobManagerDic = ConfigCommon.Configuration["ConnectionStrings:WeChat"];

        }
    }
}
