using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using WeChat.Application.Result;
using WeChat.Domain.IRepository;
using WeChat.Http.WebCrawler;
using WeChat.Shared;
using WeChat.Shared.DtoModels;
using WeChat.Shared.Enums;

namespace WeChat.Application.Services.Api
{
    [Route("Blogs")]
    public class BlogsService : BaseApiService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public BlogsService(
            IServiceScopeFactory serviceScopeFactory,
            IHttpContextAccessor httpContextAccessor)//
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceScopeFactory = serviceScopeFactory;
        }

        /// <summary>
        ///Csdn
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetCsdn")]
        public async Task<PageResult> GetCsdn([FromBody] ReqPgeParamsDto paramsDto)
        {
            //3 csdn
            List<CsdnblogsDto> data = null;
            if (RedisCommon.ExistsKey("CsdnBlogs"))
            {
                data = RedisCommon.Get<List<CsdnblogsDto>>("CsdnBlogs");
            }
            else 
            {
                data = await CsdnCrawler.GetCsdnOtherContentAsync(paramsDto.RefreshCount);
                data.ForEach(x => x.Id = GuidGenerator.Create());
                RedisCommon.SetJsonValue("CsdnBlogs", data, 10);
            }
           
            return Result.Page((int)HttpStatusCode.OK, new Application.Result.PageDataModel 
            {
                list = data,
                pageNum = paramsDto.pageNum,
                pageSize = paramsDto.pageSize,
                total = data.Count
            });
        }
    }
}
