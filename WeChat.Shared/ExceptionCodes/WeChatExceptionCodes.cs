using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChat.Shared
{
    public class WeChatExceptionCodes
    {
        public static string NotFound => "WeChat:NotFound";
        public static string IdIsNullOrEmpty => "WeChat:IdIsNullOrEmpty";
        public static string CodeAlreadyExist => "WeChat:CodeAlreadyExist";
        public static string TokenIsEmpty => "WeChat:TokenIsEmpty";
        public static string NameIsTheSame => "WeChat:NameIsTheSame";
    }
}
