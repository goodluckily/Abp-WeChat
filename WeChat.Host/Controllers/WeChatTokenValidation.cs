using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeChat.Host.WeChat;

namespace WeChat.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class WeChatTokenValidation : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public WeChatTokenValidation(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        ///  检查签名是否正确:
        /// </summary>
        /// <param name="signature"></param>
        /// <param name="timestamp"></param>
        /// <param name="nonce"></param>
        /// <param name="echostr"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TokenValidation(string signature, string timestamp, string nonce, string echostr)
        {
            //验证token
            var token = _configuration["WeChatConfig:Token"];
            if (string.IsNullOrEmpty(token)) return Content("请先设置Token！");
            var isWeiXin = BasicAPI.Check(signature, timestamp, nonce, token);
            if (isWeiXin)
            {
                return Content(echostr); //返回随机字符串则表示验证通过
            }
            return Content("不是微信消息请求"); //返回随机字符串则表示验证通过
        }


        /// <summary>
        /// 换取Token 准备开始自定义菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAccessToken")]
        public ActionResult GetAccessToken()
        {
            //验证token
            var appid = _configuration["WeChatConfig:Appid"];
            var appSecret = _configuration["WeChatConfig:AppSecret"];
            var access_token = BasicAPI.GetAccessToken(appid, appSecret).access_token;
            var js = JSAPI.GetTickect(access_token);
            return Content(appSecret+"---"+ js); //返回随机字符串则表示验证通过
        }
    }
}
