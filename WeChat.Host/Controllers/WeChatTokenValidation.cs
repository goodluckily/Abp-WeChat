using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static WeChat.Host.WeChat.WeChatTokenValidation;

namespace WeChat.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class WeChatTokenValidation : ControllerBase
    {
        [HttpGet]
        public ActionResult TokenValidation()
        {
            //验证token
            string token = "abcd123456";   //验证token，随意填写  
            string signature = HttpContext.Request.Query["signature"].ToString();
            string timestamp = HttpContext.Request.Query["timestamp"].ToString();
            string nonce = HttpContext.Request.Query["nonce"].ToString();
            string echostr = HttpContext.Request.Query["echostr"].ToString(); //随机数

            var isWeiXin = CheckSignature.Check(signature, signature, nonce, token);
            if (isWeiXin)
            {
                return Content(echostr); //返回随机字符串则表示验证通过
            }
            return Content(echostr); //返回随机字符串则表示验证通过
        }
    }
}
