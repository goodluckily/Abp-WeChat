using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WeChat.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeChatTokenValidation : ControllerBase
    {
        [HttpGet]
        public void TokenValidation()
        {
            //验证token
            string token = "aabbcc";   //验证token，随意填写  
            string signature = HttpContext.Request.Query["signature"].ToString();
            string timestamp = HttpContext.Request.Query["timestamp"].ToString();
            string nonce = HttpContext.Request.Query["nonce"].ToString();
            string echostr = HttpContext.Request.Query["echostr"].ToString(); //随机数

            List<String> strs = new List<string>();
            strs.Add(token);
            strs.Add(timestamp);
            strs.Add(nonce);
            strs.Sort();//这里进行字典排序
            string GetStr = "";
            strs.ForEach(a => GetStr += a);//得到排序后的字符串
        }

        /// <summary>
        /// 验证微信签名
        /// </summary>
        /// <returns></returns>
        /// * 将token、timestamp、nonce三个参数进行字典序排序
        /// * 将三个参数字符串拼接成一个字符串进行sha1加密
        /// * 开发者获得加密后的字符串可与signature对比，标识该请求来源于微信。
        private bool CheckSignature()
        {
            string access_token = "sohovan";

            string signature = HttpContext.Request.Query["signature"].ToString();
            string timestamp = HttpContext.Request.Query["timestamp"].ToString();
            string nonce = HttpContext.Request.Query["nonce"].ToString();
            string[] ArrTmp = { access_token, timestamp, nonce };
            Array.Sort(ArrTmp);     //字典排序
            string tmpStr = string.Join("", ArrTmp);
            tmpStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");

            if (tmpStr.ToLower() == signature)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 对字符串进行SHA1加密
        /// </summary>
        /// <param name="strIN">需要加密的字符串</param>
        /// <returns>密文</returns>
        public string SHA1_Encrypt(string Source_String)
        {
            byte[] StrRes = Encoding.Default.GetBytes(Source_String);
            HashAlgorithm iSHA = new SHA1CryptoServiceProvider();
            StrRes = iSHA.ComputeHash(StrRes);
            StringBuilder EnText = new StringBuilder();

            foreach (byte iByte in StrRes)
            {
                EnText.AppendFormat("{0:x2}", iByte);
            }
            return EnText.ToString();
        }
    }
}
