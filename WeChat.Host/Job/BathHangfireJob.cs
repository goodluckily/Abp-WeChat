using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WeChat.Application;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace WeChat.Host.Job
{
    public class BathHangfireJob
    {
        private readonly ILogger<BathHangfireJob> _logger;
        private readonly IServiceProvider _serviceProvider;

        public BathHangfireJob(ILogger<BathHangfireJob> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }
        /// <summary>
        /// 处理循环 操作Job的任务方法
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public async Task BathHangfireJobAsync()
        {
            //1.反射得到所有 定时任务类
            var assembly = Assembly.Load("WeChat.Application");
            var types = assembly.GetTypes().Where(x => x.Namespace == "WeChat.Application.Services.Job");

            var asdfas = types.Select(s => s.GetCustomAttributes()).ToList();
            //包含次特性的类
            var classArray = types.Where(s => s.GetMethods().Any(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(BathBackgroundJobAttribute)))).ToList();

            //结果数据集合 全部的任务
            var JobServiceData = new List<(Type t, string ServiceName, List<string> MethedNames)>();
            foreach (var t in classArray)
            {
                //获取方法特性中ActionName为GetSchoolAll的特性
                var jobMethods = t.GetMethods().Where(s => s.CustomAttributes.Any(x => x.AttributeType == typeof(BathBackgroundJobAttribute))).ToList();
                if (!jobMethods.Any()) continue;

                var methodsData = new List<string>();
                foreach (var item in jobMethods)
                {
                    var methedName = item.Name;
                    _logger.LogInformation($"========={t.Name}下的方法{methedName}=========进行匹配Job加载......");

                    #region 注释(曾研究的方向)
                    //var bathBackgroundJobAttr = item.CustomAttributes.FirstOrDefault(x => x.AttributeType == typeof(BathBackgroundJobAttribute));
                    //var jobName = bathBackgroundJobAttr.ConstructorArguments[0].Value;
                    //var corn = bathBackgroundJobAttr.ConstructorArguments[1].Value;
                    //var queue = bathBackgroundJobAttr.ConstructorArguments[2].Value; 


                    //方法一 OK
                    //await configuration.CodeDeaultblogsContent();

                    //方法二 NO
                    //await configuration.methedName();

                    //属性注入仓储拿获取???
                    //var addMethod = t.GetMethod(methedName);
                    //await addMethod.Invoke(configuration, null);
                    #endregion

                    methodsData.Add(methedName);
                }
                JobServiceData.Add((t, t.Name, methodsData));
            }
            var OkJsonData = JsonConvert.SerializeObject(JobServiceData);
            _logger.LogInformation(OkJsonData);

            //分配任务
            await RunJobByService(JobServiceData);

            //准备动态拼接Http的Post请求 唉真是醉了 这种特殊的实现 哈哈
        }

        public async Task RunJobByService(List<(Type t, string ServiceName, List<string> MethedNames)> JobServiceData)
        {
            foreach (var itemjob in JobServiceData)
            {
                //动态获取service
                dynamic requiredService = _serviceProvider.GetRequiredService(itemjob.t);
                switch (itemjob.ServiceName)
                {
                    case "CodeDeaultblogsJob":
                        await requiredService.CodeDeaultblogsContent();
                        break;
                    case "CsdnBlogJob":
                        await requiredService.CsdnBlogContent();
                        await requiredService.CsdnTuiJianContent();
                        break;
                    case "CTO51blogsJob":
                        await requiredService.CTO51blogsContentAsync();
                        break;
                    case "ItHomeblogsJob":
                        await requiredService.ItHomeblogsContent();
                        await requiredService.ItHomeblogsMicrosoftContent();
                        break;
                    case "JueJinBlogJob":
                        await requiredService.JueJinblogs();
                        break;
                    case "NetBlogJob":
                        await requiredService.Netcnblogs();
                        await requiredService.Newscnblogs();
                        break;
                    case "OsChinablogsJob":
                        await requiredService.OsChinablogsContent();
                        break;
                    case "SegmentfaultblogsJob":
                        await requiredService.SegmentfaultblogsContent();
                        break;
                }
            }
        }
    }
}
