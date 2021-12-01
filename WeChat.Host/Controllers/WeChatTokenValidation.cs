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
    public partial class WeChatTokenValidation : BaseController
    {
        private readonly IConfiguration _configuration;

        public WeChatTokenValidation(IConfiguration configuration) : base(configuration)
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
        /// 换取Token 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAccessToken")]
        public ActionResult GetAccessToken()
        {
            var token = GetToken();
            var jstoken = GetJsToken();
            return Content(token + "---" + jstoken); //返回随机字符串则表示验证通过
        }
    }
}
