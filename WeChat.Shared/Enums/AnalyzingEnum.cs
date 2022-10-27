using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChat.Shared.Enums
{
    public enum AnalyzingEnum
    {
        [Description("资讯")]
        ZiXun = 1,

        [Description("博客")]
        BoKe = 2,

        [Description("文章")]
        WenZhang = 3,

        [Description("热点")]
        ReDian = 4,

        [Description(".NET专题")]
        NET = 5,

        [Description("数据库专题")]
        SQL = 6,

        [Description("前端专题")]
        Web = 7,
    }
}
