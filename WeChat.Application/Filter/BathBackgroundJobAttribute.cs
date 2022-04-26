using System;
using Microsoft.AspNetCore.Mvc.Filters;
using WeChat.Shared;

namespace WeChat.Application
{
    [AttributeUsage(AttributeTargets.Method)]
    public class BathBackgroundJobAttribute : Attribute
    {
        private readonly string _jobName;
        private readonly string _corn;
        private readonly string _queue = "default";

        /// <summary>
        /// 标记为定时任务方法(便于反射得到post路由地址)
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
    }
}
