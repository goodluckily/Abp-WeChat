using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChat.Domain.Shared.Enum
{
    public enum LogTypeEnum
    {
        [Description("网站")]
        Web,
        [Description("数据库")]
        DataBase,
        [Description("Api接口")]
        ApiRequest,
        [Description("中间件")]
        Middleware
    }
}
