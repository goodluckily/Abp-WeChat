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
    /// 51 CTO
    /// </summary>
    [Route("CTO51blogsJob")]
    public class CTO51blogsJob : BaseJobService
    {
        public ICTO51blogsRepository _cTO51BlogsRepository { get; init; }

        //private readonly ICTO51blogsRepository _cTO51BlogsRepository;
        //public CTO51blogsJob(ICTO51blogsRepository cTO51BlogsRepository)
        //{
        //    _cTO51BlogsRepository = cTO51BlogsRepository;
        //}

        /// <summary>
        /// 保存51 CTO 数据信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("CTO51blogsContent")]
        [BathBackgroundJob]
        public async Task<DataResult> CTO51blogsContentAsync(string key)
        {
            var CTO51blogsList = new List<CTO51blogs>();

            var result = await CTO51Crawler.Get51CTOContentAsync();

            //数据转换
            var dbCTO51blogs = ObjectMapper.Map<List<CTO51blogsDto>, List<CTO51blogs>>(result);

            //自己去重
            dbCTO51blogs = dbCTO51blogs.Where((x, i) => dbCTO51blogs.FindIndex(z => z.Title == x.Title) == i).ToList();

            //事先检查数据库存不存在 同作者 标题的文章 一样的话 就不保存
            var thisDataTime = DateTime.Now;

            var clientDBlogsList = await _cTO51BlogsRepository.GetCTO51blogsAll();

            //db 去重
            dbCTO51blogs.ForEach(item =>
            {
                var isChecket = clientDBlogsList.Any(x => x.Title == item.Title);
                if (!isChecket) CTO51blogsList.Add(item);
            });

            CTO51blogsList.ForEach(x =>
            {
                x.CreateTime = thisDataTime;
                x.IsDel = false;
            });

            //db add
            var data = await _cTO51BlogsRepository.CreateCTO51blogsAsync(CTO51blogsList);
            return Result.Json(data);
        }
    }
}
