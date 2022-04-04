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
    /// 开源中国
    /// </summary>
    [Route("OsChinablogsJob")]
    public class OsChinablogsJob : BaseJobService
    {
        public IOsChinablogsRepository _osChinablogsRepository { get; init; }

        //private readonly IOsChinablogsRepository _osChinablogsRepository;
        //public OsChinablogsJob(IOsChinablogsRepository osChinablogsRepository)
        //{
        //    _osChinablogsRepository = osChinablogsRepository;
        //}

        /// <summary>
        /// 开源中国 博客文章
        /// </summary>
        /// <returns></returns>
        [HttpPost("OsChinablogsContent")]
        [BathBackgroundJob]
        public async Task<DataResult> OsChinablogsContent()
        {
            var OsChinablogsList = new List<OsChinablogs>();

            var result = OsChinaCrawler.GetOsChinaBlogContent();

            //数据转换
            var dbSegmentfaults = ObjectMapper.Map<List<OsChinablogsDto>, List<OsChinablogs>>(result);

            //自己去重
            dbSegmentfaults = dbSegmentfaults.Where((x, i) => dbSegmentfaults.FindIndex(z => z.Author == x.Author && z.Title == x.Title) == i).ToList();

            //事先检查数据库存不存在 同作者 标题的文章 一样的话 就不保存
            var thisDataTime = DateTime.Now;

            var clientDBlogsList = await _osChinablogsRepository.GetOsChinablogsAll();

            //db 去重
            dbSegmentfaults.ForEach(item =>
            {
                var isChecket = clientDBlogsList.Any(x => x.Title == item.Title && x.Author == item.Author);
                if (!isChecket) OsChinablogsList.Add(item);
            });

            OsChinablogsList.ForEach(x =>
            {
                x.CreateTime = thisDataTime;
                x.IsDel = false;
            });

            //db add
            var data = await _osChinablogsRepository.CreateOsChinablogsAsync(OsChinablogsList);
            return Result.Json(data);
        }
    }
}
