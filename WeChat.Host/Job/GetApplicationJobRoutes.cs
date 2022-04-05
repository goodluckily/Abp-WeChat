using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using WeChat.Application;

namespace WeChat.Host.Job
{
    public class GetApplicationJobRoutes
    {
        /// <summary>
        /// 获取api下的job任务路由
        /// </summary>
        /// <returns></returns>
        public static List<string> GetJobRoutes()
        {
            var JobRouterList = new List<string>();

            #region new版本
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

                var routeName = t.GetCustomAttributes();
                var ControlRouteAttribute = t.CustomAttributes.FirstOrDefault(x => x.AttributeType.Name == "RouteAttribute");
                //1.得到service(控制器的)路由名称没有就是类名称
                var RouteControlName = ControlRouteAttribute != null ? ControlRouteAttribute.ConstructorArguments[0].Value?.ToString() : t.Name;
                var methodsData = new List<string>();
                foreach (var item in jobMethods)
                {
                    var RouteMethedName = item.CustomAttributes.FirstOrDefault(x => x.AttributeType == typeof(HttpPostAttribute));
                    //2.得到方法的路由名称,没有就是方法名称
                    var MethedName = RouteMethedName != null ? RouteMethedName.ConstructorArguments[0].Value?.ToString() : item.Name;
                    JobRouterList.Add($"{RouteControlName}/{MethedName}");
                }
            }
            #endregion

            return JobRouterList;
        }
    }
}
