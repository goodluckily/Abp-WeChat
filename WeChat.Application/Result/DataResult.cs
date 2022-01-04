using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WeChat.Application
{
    public class DataResult
    {

        public DataResult(bool flag, object data = null, string message = "")
        {
            this.Code = flag ? (int)HttpStatusCode.OK : (int)HttpStatusCode.InternalServerError;
            this.Data = data;
        }

        public DataResult(bool flag, long? total = null, object data = null, string message = "")
        {
            this.Code = flag ? (int)HttpStatusCode.OK : (int)HttpStatusCode.InternalServerError;
            this.Total = total;
            this.Data = data;
            this.Message = message;
        }

        public DataResult(int code, string message)
        {
            this.Code = code;
            this.Message = message;
        }

        public DataResult(bool flag, string message)
        {
            this.Code = flag ? (int)HttpStatusCode.OK : (int)HttpStatusCode.InternalServerError;
            this.Message = message;
        }

        public int Code { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
        public long? Total { get; set; }
    }
}
