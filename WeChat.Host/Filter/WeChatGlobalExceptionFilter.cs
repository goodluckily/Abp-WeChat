using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

namespace WeChat.Host.Filter
{
    public class WeChatGlobalExceptionFilter:IExceptionFilter
    {
        private readonly ILogger<WeChatGlobalExceptionFilter> _logger;

        public WeChatGlobalExceptionFilter(Microsoft.Extensions.Logging.ILogger<WeChatGlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(new EventId(context.Exception.HResult),context.Exception,context.Exception.Message);
            context.Result = new JsonResult(new { code = 500, err = "系统异常" });
            context.ExceptionHandled = true;
        }
    }
}
