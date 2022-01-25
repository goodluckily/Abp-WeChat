using System;

namespace WeChat.Application
{
    [AttributeUsage(AttributeTargets.Method)]
    public class BathBackgroundJobAttribute : Attribute
    {
        private readonly string _jobName;
        private readonly string _corn;

        /// <summary>
        /// 标记为定时任务方法
        /// </summary>
        /// <param name="JobName">定时任务名称</param>
        /// <param name="Corn">corn表达式</param>
        /// <param name="Queue">所属队列</param>
        public BathBackgroundJobAttribute(string JobName, string Corn, string Queue = "default")
        {
            _jobName = JobName;
            _corn = Corn;
        }
    }
}
