using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Services;

namespace WeChat.Application.Services.Api
{
    [Route("publish")]
    public class PublishService : ApplicationService
    {

        /// <summary>
        /// 发布检测 这个需要另启站点数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Get(string path)
        {
            var publishPath = "";
            //var path = Environment.CurrentDirectory;
            if (!string.IsNullOrWhiteSpace(path))
            {
                publishPath = path;
            }
            var filename = "app_offline.htm";
            var publichPath = Path.Combine(publishPath, filename);
            var result = string.Empty;
            if (System.IO.File.Exists(publichPath))
            {
                System.IO.File.Delete(publichPath);
                result = "Success,文件发布成功！";
            }
            else
            {
                result = "Warning,可能存在发布失败的情况,请手动检查一下~";
            }
            return result;
        }
    }
}
