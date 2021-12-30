using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChat.Domain.Shared.Setting
{
    public class WeChatAppSetting
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        public static string DBConnectionStr{ get; set; }
        /// <summary>
        /// 连接字符串 Key
        /// </summary>
        public const  string ConnectionKey = "DBConnectionStr";

        public static string Token { get; set; }
        public static string Appid { get; set; }
        public static string AppSecret { get; set; }
    }
}
