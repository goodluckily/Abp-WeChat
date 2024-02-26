using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChat.Shared.DtoModels
{
    public class ReqPgeParamsDto
    {
        public string endTime { get; set; }
        public string startTime { get; set; }
        public int RefreshCount { get; set; } = 2;
        public int pageNum { get; set; }
        public int pageSize { get; set; }
        public int type { get; set; }

        //是否启用缓存
        public bool iscache { get; set; } = true;

        /// <summary>
        /// 其他 or 推荐
        /// </summary>
        public string BlogType { get; set; }

        /// <summary>
        /// 数据缓存时长 分
        /// </summary>
        public int RerdisCacheMinute { get; set; } = 5;
    }
}
