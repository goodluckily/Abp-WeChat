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
    }
}
