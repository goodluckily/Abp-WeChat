using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeChat.Domain;
using WeChat.Domain.IRepository;
using WeChat.Shared;
using WeChat.Http.WebCrawler;
using Autofac.Extras.DynamicProxy;
using Microsoft.AspNetCore.Authorization;

namespace WeChat.Application.Services.Job
{
    /// <summary>
    /// CodeDeault
    /// </summary>
    [Route("CodeDeaultblogsJob")]
    public class CodeDeaultblogsJob : BaseApiService
    {
        public ICodeDeaultblogsRepository _codeDeaultblogsRepository { get; init; }

        //private readonly ICodeDeaultblogsRepository _codeDeaultblogsRepository;
        //public CodeDeaultblogsJob(ICodeDeaultblogsRepository codeDeaultblogsRepository)
        //{
        //    _codeDeaultblogsRepository = codeDeaultblogsRepository;
        //    _codeDeaultblogsRepository = codeDeaultblogsRepository;
        //}

        /// <summary>
        /// CodeDeaultblogs信息抓取 All 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCodeDeaultblogsAll")]
        public async Task<DataResult> GetCodeDeaultblogsAsyncAll() => Json(await _codeDeaultblogsRepository.GetCodeDeaultblogsAll());


        [AllowAnonymous]
        [HttpPost("CodeDeaultblogsContent")]
        [BathBackgroundJob]
        public async Task<DataResult> CodeDeaultblogsContent(string key)
        {
            var codedeaultblogList = new List<CodeDeaultblogs>();
            var result = CodeDeaultCrawler.GetCodeDeaultContent();
            //数据转换
            var dbcodedeaults = ObjectMapper.Map<List<CodeDeaultblogsDto>, List<CodeDeaultblogs>>(result);

            //自己去重
            dbcodedeaults = dbcodedeaults.Where((x, i) => dbcodedeaults.FindIndex(z => z.Title == x.Title) == i).ToList();

            //事先检查数据库存不存在 同作者 标题的文章 一样的话 就不保存
            //var currenmtUserId = CurrentUserId();

            var thisDataTime = DateTime.Now;

            var clientDBlogsList = await _codeDeaultblogsRepository.GetCodeDeaultblogsAll();

            //db 去重
            dbcodedeaults.ForEach(item =>
            {
                var isChecket = clientDBlogsList.Any(x => x.Title == item.Title);
                if (!isChecket) codedeaultblogList.Add(item);
            });

            codedeaultblogList.ForEach(x =>
            {
                x.CreateTime = thisDataTime;
                x.IsDel = false;
            });

            //db add
            var data = await _codeDeaultblogsRepository.CreateCodeDeaultblogsAsync(codedeaultblogList);
            return Json(data);
        }
    }
}
