using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Services;

namespace WeChat.Application.Services
{
    [NonController]
    [AllowAnonymous]
    public class BaseJobService : ApplicationService
    {
        /// <summary>
        /// 返回结果统一
        /// </summary>
        public IResultService Result { get; init; }

    }
}
