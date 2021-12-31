using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using WeChat.Application;

namespace WeChat.Host.Filter
{
    public class WeChatGlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<WeChatGlobalExceptionFilter> _logger;

        public WeChatGlobalExceptionFilter(ILogger<WeChatGlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var detail = context.Exception.Message;
            _logger.LogError(new EventId(context.Exception.HResult), context.Exception, detail);
            context.Result = new JsonResult(new DataResult(false, detail));
            context.ExceptionHandled = true;
        }
    }
}
