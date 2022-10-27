using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.Auditing;
using WeChat.Shared;
using WeChat.Shared.Enums;

namespace WeChat.Host.Filter
{
    public class WeChatActionFilter : ActionFilterAttribute
    {
        private readonly ILogger<WeChatActionFilter> _logger;

        public WeChatActionFilter(ILogger<WeChatActionFilter> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Action 之
        /// </summary>
        /// <param name="context"></param>
        /// <remarks>AllowAnonymous特性下的得不到用户Id</remarks>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var actionDescriptor = context.ActionDescriptor;
            //判断拥有此特性的话 就不需要再获取用户信息了
            var isAllowAnonymous = actionDescriptor.EndpointMetadata.Any(x => x is AllowAnonymousAttribute || x is NonActionAttribute);

            var controller = context.RouteData.Values["controller"]?.ToString();
            var action = context.RouteData.Values["action"]?.ToString();
            var method = context.HttpContext.Request.Method;
            var route = controller + "/" + action;
            var userId = string.Empty;
            if (!isAllowAnonymous)
            {
                var userIdGuid = AuthCommon.GetUserId(context.HttpContext.User);
                userId = userIdGuid == Guid.Empty ? string.Empty : userIdGuid.ToString();
            }
            //控制台---->操作日志记录
            _logger.LogInformation(method + "   " + route);
            //数据库---->所有请求地址记录
            NLogCommon.WriteDBLog(NLog.LogLevel.Info, LogTypeEnum.ApiRequest, route, userId);
            base.OnActionExecuting(context);
        }

        /// <summary>
        /// Action 之后
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            #region 得到请求参数之类的注释
            //var action = context.RouteData.Values["action"];
            //var controller = context.RouteData.Values["controller"];
            //var contentType = context.HttpContext.Request.ContentType;
            //var mothodType = context.HttpContext.Request.Method;

            //获取参数数组 
            //var value = (context.Result as ObjectResult)?.Value ?? (context.Result as JsonResult)?.Value;
            //var code = context.HttpContext.Response.StatusCode;
            //var result = new JsonResult(new { code, data = value, error = "", detail = "" });
            //context.Result = result; 
            #endregion
        }
    }
}
