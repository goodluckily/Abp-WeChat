using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeChat.Domain.IRepository;
using WeChat.Shared;
using WeChat.Http.WebCrawler;
using WeChat.Domain;
using Mapster;

namespace WeChat.Application.Services.Job
{

    /// <summary>
    /// 稀土掘金
    /// </summary>
    [Route("JueJinBlogJob")]
    public class JueJinBlogJob : BaseJobService
    {
        public IJueJinblogsRepository _jueJinblogsRepository { get; init; }

        //private readonly IJueJinblogsRepository _jueJinblogsRepository;
        //public JueJinBlogJob(IJueJinblogsRepository jueJinblogsRepository)
        //{
        //    _jueJinblogsRepository = jueJinblogsRepository;
        //}

        [HttpGet("getJueJinblogsAll")]
        public async Task<DataResult> GetJueJinblogsAllAsync()
        {
            var data = await _jueJinblogsRepository.GetJueJinblogsAll();
            return Result.Json(data);
        }

        [HttpPost("JueJinblogs")]
        public async Task<DataResult> JueJinblogs()
        {
            var result = JuejinCrawler.GetJuejinNewsContentForApi();
            //数据转换
            var dbJueJinblogs = result.Adapt<List<JueJinblogs>>(); //ObjectMapper.Map<List<JueJinblogsDto>, List<JueJinblogs>>(result);

            //事先检查数据库存不存在 同作者 标题的文章 一样的话 就不保存
            //var currenmtUserId = CurrentUserId();
            var thisDataTime = DateTime.Now;

            var clientDBlogsList = await _jueJinblogsRepository.GetJueJinblogsAll();
            var cnblogs = new List<JueJinblogs>();

            dbJueJinblogs.ForEach(item =>
            {
                var isChecket = clientDBlogsList.Any(x => x.Title == item.Title && x.Author == item.Author);
                if (!isChecket) cnblogs.Add(item);
            });

            cnblogs.ForEach(x =>
            {
                x.CreateTime = thisDataTime;
                x.IsDel = false;
            });
            var data = await _jueJinblogsRepository.CreateJueJinblogsAsync(cnblogs);
            return Result.Json(data);
        }
    }
}
