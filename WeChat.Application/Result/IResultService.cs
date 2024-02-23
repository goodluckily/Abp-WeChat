using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.DependencyInjection;

namespace WeChat.Application.Result
{
    public interface IResultService : ISingletonDependency
    {
        #region 返回值封装

        [NonAction]
        DataResult Json(object data, string message = "");

        [NonAction]
        DataResult Json(long total, object data, string message = "");

        [NonAction] DataResult Ok(string message);

        [NonAction]
        DataResult Error(string message);

        [NonAction]
        PageResult Page(int code, PageDataModel pageData);
        #endregion
    }
}
