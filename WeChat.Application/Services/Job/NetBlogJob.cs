using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeChat.Domain;
using WeChat.Domain.IRepository;
using WeChat.Shared;
using WeChat.Http.WebCrawler;

namespace WeChat.Application.Services.Job
{
    /// <summary>
    /// 博客园
    /// </summary>
    [Route("NetBlogJob")]
    public class NetBlogJob : BaseJobService
    {
        public INetcnblogsRepository _netcnblogsRepository { get; init; }

        //private readonly INetcnblogsRepository _netcnblogsRepository;
        //public NetBlogJob(INetcnblogsRepository netcnblogsRepository)
        //{
        //    _netcnblogsRepository = netcnblogsRepository;
        //}

        [HttpGet("getAll")]
        public async Task<DataResult> GetAllAysnc()
        {
            var netBlogsList = await _netcnblogsRepository.GetAllAsync();
            return Result.Json(netBlogsList);
        }

        /// <summary>
        /// 博客园 .NET技术专题文章
        /// </summary>
        /// <returns></returns>
        [HttpPost("Netcnblogs")]
        [BathBackgroundJob]
        public async Task<DataResult> Netcnblogs([FromBody] string key)
        {
            //.NET 专题
            var blogNetResult = CnblogesCrawler.GetNetCnblogsContent();
            //数据转换
            var dbNetblogs = ObjectMapper.Map<List<NetcnblogsDto>, List<Cnblogs>>(blogNetResult);
            var clientDBNetCnblogsList = await _netcnblogsRepository.GetAllAsync(AnalyzingEnum.NET);
            var netBlogsList = await CreateCnBlogsData(dbNetblogs, clientDBNetCnblogsList);
            return Result.Json(netBlogsList);
        }

        /// <summary>
        /// 博客园 新闻最新发布文章
        /// </summary>
        /// <returns></returns>
        [HttpPost("Newscnblogs")]
        [BathBackgroundJob]
        public async Task<DataResult> Newscnblogs([FromBody] string key)
        {
            //热门新闻
            var blogNewsResut = CnblogesCrawler.GetToDayNewsCnblogsContent();
            //数据转换
            var blogNews = ObjectMapper.Map<List<NetcnblogsDto>, List<Cnblogs>>(blogNewsResut);
            var clientDBNewsCnblogsList = await _netcnblogsRepository.GetAllAsync(AnalyzingEnum.ReDian);
            var netNewsList = await CreateCnBlogsData(blogNews, clientDBNewsCnblogsList);
            return Result.Json(netNewsList);
        }

        private async Task<List<Cnblogs>> CreateCnBlogsData(List<Cnblogs> dbNetblogs, List<Cnblogs> clientDBNetcnblogsList)
        {
            var newNetcnblogs = new List<Cnblogs>();
            //事先检查数据库存不存在 同作者 标题的文章 一样的话 就不保存
            var thisDataTime = DateTime.Now;
            dbNetblogs.ForEach(item =>
            {
                var isChecket = clientDBNetcnblogsList.Any(x => x.Title == item.Title && x.Author == item.Author);
                if (!isChecket) newNetcnblogs.Add(item);
            });
            newNetcnblogs.ForEach(x =>
            {
                x.CreateTime = thisDataTime;
                x.IsDel = false;
            });
            var netBlogsList = await _netcnblogsRepository.CreateNetcnblogsAsync(newNetcnblogs);
            return netBlogsList;
        }
    }
}
