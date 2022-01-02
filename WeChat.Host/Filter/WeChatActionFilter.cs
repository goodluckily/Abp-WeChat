using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.Auditing;

namespace WeChat.Host.Filter
{
    public class WeChatActionFilter : ActionFilterAttribute
    {
        private readonly ILogger<WeChatActionFilter> _logger;

        public WeChatActionFilter(ILogger<WeChatActionFilter> logger)
        {
            _logger = logger;
        }

        //之前
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var action = context.RouteData.Values["action"];
            var controller = context.RouteData.Values["controller"];
            var requestMessage = context.HttpContext.Request.Method + "     " + controller + "/" + action;

            _logger.LogInformation(requestMessage);
            base.OnActionExecuting(context);
        }

        //之后
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            //var action = context.RouteData.Values["action"];
            //var controller = context.RouteData.Values["controller"];
            //var contentType = context.HttpContext.Request.ContentType;
            //var mothodType = context.HttpContext.Request.Method;

            //获取参数数组 
            //var value = (context.Result as ObjectResult)?.Value ?? (context.Result as JsonResult)?.Value;
            //var code = context.HttpContext.Response.StatusCode;
            //var result = new JsonResult(new { code, data = value, error = "", detail = "" });
            //context.Result = result;
        }
    }
}
