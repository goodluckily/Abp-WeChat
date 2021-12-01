using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeChat.Host.WeChat;

namespace WeChat.Host.Controllers
{
    public class BaseController : Controller
    {
        private readonly IConfiguration _configuration;

        public BaseController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        /// <summary>
        /// 获取Tocken
        /// </summary>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        protected string GetToken()
        {
            //验证token
            var appid = _configuration["WeChatConfig:Appid"];
            var appSecret = _configuration["WeChatConfig:AppSecret"];
            var accessDynamic = BasicAPI.GetAccessToken(appid, appSecret);
            var access_token = accessDynamic.access_token;
            var expires_in = accessDynamic.expires_in;
            //var js = JSAPI.GetTickect(access_token);
            return access_token;
        }


        /// <summary>
        /// 获取jsapi_ticket
        /// </summary>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        protected string GetJsToken()
        {
            //token
            var access_token = GetToken();
            //js token
            var jsTicket = JSAPI.GetTickect(access_token);

            //开始数据持久化到数据库
            return jsTicket;
        }
    }
}
