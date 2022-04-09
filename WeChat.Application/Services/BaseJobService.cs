using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Services;
using WeChat.Application.Result;

namespace WeChat.Application.Services
{

    [NonController]
    [CheckKeyBackgroundJob]//自定义特性的权限key验证
    public class BaseJobService : ApplicationService
    {
        /// <summary>
        /// 返回值包装
        /// </summary>
        public IResultService Result { get; init; }
    }
}
