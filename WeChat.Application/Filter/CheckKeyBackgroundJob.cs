using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using WeChat.Shared;

namespace WeChat.Application
{
    public class CheckKeyBackgroundJob : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.ActionArguments.TryGetValue("key", out object keyValue);
            string reKey = keyValue != null ? keyValue.ToString() : "";
            if (!IsServerMd5(reKey))
                throw new Exception("请求Key错误");
        }


        /// <summary>
        /// key比较
        /// </summary>
        /// <param name="reponseKey"></param>
        /// <returns></returns>
        public bool IsServerMd5(string reponseKey)
        {
            var strConfig = ConfigCommon.Configuration["JobExecutionApiKey"].ToString();
            var serverKey = StringCommon.Md5(strConfig);
            return reponseKey == serverKey;
        }
    }
}
