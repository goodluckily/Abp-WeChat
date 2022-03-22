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

namespace WeChat.Application.Services.Api
{
    public class FreePublish : BaseService
    {
        /// <summary>
        /// 获取发布文章内容
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get")]
        public async Task<DataResult> GetStudentList()
        {
            var token = await GetTokenAsync(WeiChatEnum.Test);
            var afsadf = BasicAPI.PostFreePublish(token);
            return Json("");
        }
    }
}
