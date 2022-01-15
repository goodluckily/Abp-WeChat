using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeChat.Domain.WeChat;
using WeChat.Domain.IRepository;
using WeChat.Domain.Shared;
using WeChat.Http.WebCrawler;

namespace WeChat.Application.Services.Job
{
    [Route("NetBlogJob")]
    public class NetBlogJob : BaseService
    {
        private readonly INetcnblogsRepository _netcnblogsRepository;
        public NetBlogJob(INetcnblogsRepository netcnblogsRepository)
        {
            _netcnblogsRepository = netcnblogsRepository;
        }

        [HttpGet("getAll")]
        public async Task<DataResult> GetAllAysnc()
        {
            var netBlogsList = await _netcnblogsRepository.GetAllAsync();
            return Json(netBlogsList);
        }

        /// <summary>
        /// 博客园 .NET技术专题文章
        /// </summary>
        /// <returns></returns>
        [HttpGet("createNetcnblogs")]
        public async Task<DataResult> createNetcnblogs()
        {
            //.NET 专题
            var blogNetResult = Blogs.GetNetCnblogsContent();
            //数据转换
            var dbNetblogs = ObjectMapper.Map<List<NetcnblogsDto>, List<Netcnblogs>>(blogNetResult);
            var clientDBNetCnblogsList = await _netcnblogsRepository.GetAllAsync(AnalyzingEnum.NET);
            var netBlogsList = await CreateCnBlogsData(dbNetblogs, clientDBNetCnblogsList);
            return Json(netBlogsList);
        }

        /// <summary>
        /// 博客园 新闻最新发布文章
        /// </summary>
        /// <returns></returns>
        [HttpGet("createNewscnblogs")]
        public async Task<DataResult> createNewscnblogs()
        {
            //热门新闻
            var blogNewsResut = Blogs.GetToDayNewsCnblogsContent();
            //数据转换
            var blogNews = ObjectMapper.Map<List<NetcnblogsDto>, List<Netcnblogs>>(blogNewsResut);
            var clientDBNewsCnblogsList = await _netcnblogsRepository.GetAllAsync(AnalyzingEnum.ReDian);
            var netNewsList = await CreateCnBlogsData(blogNews, clientDBNewsCnblogsList);
            return Json(netNewsList);
        }

        private async Task<List<Netcnblogs>> CreateCnBlogsData(List<Netcnblogs> dbNetblogs, List<Netcnblogs> clientDBNetcnblogsList)
        {
            var newNetcnblogs = new List<Netcnblogs>();
            //事先检查数据库存不存在 同作者 标题的文章 一样的话 就不保存
            var currenmtUserId = CurrentUserId();
            var thisDataTime = DateTime.Now;
            dbNetblogs.ForEach(item =>
            {
                var isChecket = clientDBNetcnblogsList.Any(x => x.Title == item.Title && x.Author == item.Author);
                if (!isChecket) newNetcnblogs.Add(item);
            });
            newNetcnblogs.ForEach(x =>
            {
                x.CreateUserId = currenmtUserId;
                x.CreateTime = thisDataTime;
                x.IsActive = true;
                x.IsDel = false;
            });
            var netBlogsList = await _netcnblogsRepository.CreateNetcnblogsAsync(newNetcnblogs);
            return netBlogsList;
        }
    }
}
