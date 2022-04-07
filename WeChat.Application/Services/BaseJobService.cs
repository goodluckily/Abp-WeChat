using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Services;
using WeChat.Shared;

namespace WeChat.Application.Services
{
    [NonController]
    //这个太全局了,Get获取数据请求还是需要登陆验证的,
    //暂时还是需要把JobService和JobApi分开
    [AllowAnonymous]
    public class BaseJobService : ApplicationService
    {
        /// <summary>
        /// 返回结果统一
        /// </summary>
        public IResultService Result { get; init; }
    }
}
