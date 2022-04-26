using Microsoft.AspNetCore.Mvc;
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
