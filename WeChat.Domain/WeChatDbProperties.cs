using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChat.Domain
{
    public class WeChatDbProperties
    {
        public static string DbTablePrefix { get; set; } = "wechat_";
        public static string DbSchema { get; set; } = null;
        public const string ConnectionStringName = "WeChat";
    }
}
