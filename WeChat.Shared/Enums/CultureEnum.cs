using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChat.Shared.Enums
{
    public enum CultureEnum
    {
        [Description("English")]
        English,
        [Description("简体中文")]
        zhHans,
        [Description("繁体中文")]
        zhHant
    }
}
