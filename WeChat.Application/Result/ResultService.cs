using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WeChat.Application.Result
{
    public class ResultService : IResultService
    {
        #region 返回值封装

        [NonAction]
        public virtual DataResult Json(object data, string message = "")
        {
            var result = new DataResult(true, data, message);
            return result;
        }
        [NonAction]
        public virtual DataResult Json(long total, object data, string message = "")
        {
            var result = new DataResult(true, total, data, message);
            return result;
        }
        [NonAction]
        public virtual DataResult Ok(string message)
        {
            var result = new DataResult(true, message);
            return result;
        }
        [NonAction]
        public virtual DataResult Error(string message)
        {
            var result = new DataResult(false, message);
            return result;
        }
        #endregion
    }
}
