using Microsoft.AspNetCore.Builder;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using WeChat.Application;

namespace WeChat.Application.HangJob
{
    public static class HandBathHangfire
    {
        /// <summary>
        /// 处理循环 操作Job的任务方法
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static void BathHangfireJob()
        {
            //1.反射得到所有 定时任务类
            //var types = Assembly.Load("WeChat.Application").GetTypes().Where(x => x.Namespace == "WeChat.Application.Services.Job");
            ////var classArray = types.Where(s => s.CustomAttributes.Any(x => x.AttributeType == typeof(BathBackgroundJobAttribute))).ToList();
            //foreach (var t in types)
            //{
            //    //获取方法特性中ActionName为GetSchoolAll的特性
            //    var jobMethods = t.GetMethods().Where(s => s.CustomAttributes.Any(x => x.AttributeType == typeof(BathBackgroundJobAttribute))).ToList();
            //    if (!jobMethods.Any()) continue;
            //    foreach (var item in jobMethods)
            //    {
            //        var methedName = item.Name;
            //        var bathBackgroundJobAttr = item.CustomAttributes.FirstOrDefault(x => x.AttributeType == typeof(BathBackgroundJobAttribute));
            //        var jobName = bathBackgroundJobAttr.ConstructorArguments[0].Value;
            //        var corn = bathBackgroundJobAttr.ConstructorArguments[1].Value;
            //        var queue = bathBackgroundJobAttr.ConstructorArguments[2].Value;

            //        Type type;                          // 存储类
            //        Object obj;                         // 存储类的实例

            //        var tname = t.Name;
            //        type = Type.GetType(tname);      // 通过类名获取同名类
            //        obj = System.Activator.CreateInstance(t);       // 创建实例

            //        MethodInfo method = type.GetMethod(methedName, new Type[] { });      // 获取方法信息
            //        object[] parameters = null;
            //        method.Invoke(obj, parameters);

            //        item.Invoke(t, null);
            //    }
            //}

            //2.得到定时任务 特性下的方法

            //3.依据参数 执行方法
            //RecurringJob.AddOrUpdate("powerfuljob", () => Console.Write("Powerful!"), "0 12 * */2");




        }
    }
}
