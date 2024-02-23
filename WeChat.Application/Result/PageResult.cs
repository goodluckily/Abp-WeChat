using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Polly.Caching;
using static AutoMapper.Internal.ExpressionFactory;

namespace WeChat.Application.Result
{
    public class PageResult
    {
        public PageResult(int code,PageDataModel data)
        {
            this.code = code;
            this.data = data;
        }
        public PageDataModel data {  get; set; }
        public int code { get; set; } = (int)HttpStatusCode.OK;
        public int msg {  get; set; }
    }

    public class PageDataModel 
    {
        public object list { get; set; }
        public int pageNum { get; set; }
        public int pageSize { get; set; }
        public int total { get; set; }
    }
}
