using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Net;
using WeChat.Application;
using WeChat.Common;
using WeChat.Domain.Shared.Enum;

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

            //控制器 输出
            _logger.LogError(new EventId(context.Exception.HResult), context.Exception, detail);

            //Db 输出
            NLogCommon.WriteDBLog(NLog.LogLevel.Error, LogTypeEnum.Web, detail, exception: new Exception(detail, context.Exception));

            context.Result = new JsonResult(new DataResult(false, detail));
            context.ExceptionHandled = true;
        }
    }
}
