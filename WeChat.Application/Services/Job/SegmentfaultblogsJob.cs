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
    /// 思否
    /// </summary>
    [Route("Segmentfaultblogs")]
    public class SegmentfaultblogsJob : BaseJobService
    {
        public ISegmentfaultblogsRepository _segmentfaultblogsRepository { get; init; }

        //private readonly ISegmentfaultblogsRepository _segmentfaultblogsRepository;
        //public SegmentfaultblogsJob(ISegmentfaultblogsRepository segmentfaultblogsRepository)
        //{
        //    _segmentfaultblogsRepository = segmentfaultblogsRepository;
        //}

        [HttpPost("SegmentfaultblogsContent")]
        public async Task<DataResult> SegmentfaultblogsContent()
        {
            var segmentfaultblogList = new List<Segmentfaultblogs>();

            var result = await SegmentfaulCrawler.GetSegmentfaulCrawlerContentAsync();

            //数据转换
            var dbSegmentfaults = ObjectMapper.Map<List<SegmentfaultblogsDto>, List<Segmentfaultblogs>>(result);

            //自己去重
            dbSegmentfaults = dbSegmentfaults.Where((x, i) => dbSegmentfaults.FindIndex(z => z.Author == x.Author && z.Title == x.Title) == i).ToList();

            //事先检查数据库存不存在 同作者 标题的文章 一样的话 就不保存
            var thisDataTime = DateTime.Now;

            var clientDBlogsList = await _segmentfaultblogsRepository.GetSegmentfaultblogsAll();

            //db 去重
            dbSegmentfaults.ForEach(item =>
            {
                var isChecket = clientDBlogsList.Any(x => x.Title == item.Title && x.Author == item.Author);
                if (!isChecket) segmentfaultblogList.Add(item);
            });

            segmentfaultblogList.ForEach(x =>
            {
                x.CreateTime = thisDataTime;
                x.IsDel = false;
            });

            //db add
            var data = await _segmentfaultblogsRepository.CreateSegmentfaultblogsAsync(segmentfaultblogList);
            return Result.Json(data);
        }
    }
}
