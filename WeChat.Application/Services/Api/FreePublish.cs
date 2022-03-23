using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using WeChat.Domain;
using WeChat.Domain.IRepository;
using WeChat.Shared;
using WeChat.Http.WeiChatApi;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WeChat.Application.Services.Api
{
    public class FreePublish : BaseService
    {
        /// <summary>
        /// 获取发布文章内容
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetStudentList")]
        public async Task<DataResult> GetStudentList()
        {
            var token = await GetTokenAsync(WeiChatEnum.NiKoKoL);
            Dictionary<string, object> dic = new();
            dic.Add("offset", 0);
            dic.Add("count", 20);
            //dic.Add("no_content", 0);
            //var result = WeChatApi.PostFreePublish(token, dic);
            return Json("");
        }
    }
}
