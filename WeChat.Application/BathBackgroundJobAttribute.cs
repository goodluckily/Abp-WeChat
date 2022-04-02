using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WeChat.Application
{
    [AttributeUsage(AttributeTargets.Method)]
    public class BathBackgroundJobAttribute : Attribute, IActionFilter
    {
        private readonly string _jobName;
        private readonly string _corn;
        private readonly string _queue = "default";

        /// <summary>
        /// 标记为定时任务方法
        /// </summary>
        /// <param name="JobName">定时任务名称</param>
        /// <param name="Corn">corn表达式</param>
        /// <param name="Queue">所属队列</param>
        /// <remarks>传入的参数为准</remarks>
        public BathBackgroundJobAttribute(string JobName = "", string Corn = "", string Queue = "default")
        {
            _jobName = JobName;
            _corn = Corn;
            _queue = Queue;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //得到控制器的jobName 以构造擦传入的为准

            string controller = context.RouteData.Values["Controller"].ToString();
            string action = context.RouteData.Values["Action"].ToString();
            string method = context.HttpContext.Request.Method;


            var aa = context.ActionDescriptor.DisplayName;

            context.ActionArguments["test"] = "测试";
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
