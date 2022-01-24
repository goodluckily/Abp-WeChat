using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using WeChat.Domain;
using WeChat.Domain.IRepository;
using Microsoft.AspNetCore.Cors;
using Volo.Abp.ObjectMapping;
using AutoMapper;
using Volo.Abp.Guids;
using WeChat.Shared;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Services;

namespace WeChat.Application.Services.Api
{
    [Route("health")]
    public class HealthService : ApplicationService
    {
        /// <summary>
        /// 健康检查
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Get()
        {
            return "ok";
        }
    }
}
