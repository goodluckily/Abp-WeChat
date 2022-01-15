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
    [Route("CsdnBlogJob")]
    public class CsdnBlogJob : BaseService
    {
        private readonly ICsdnblogsRepository _csdnblogsRepository;

        public CsdnBlogJob(ICsdnblogsRepository csdnblogsRepository)
        {
            _csdnblogsRepository = csdnblogsRepository;
        }

        [HttpGet("getCsdnBlogContent")]
        public async Task<DataResult> GetCsdnBlogContent()
        {
            var csdnblogs = new List<Csdnblogs>();

            var result = await CsdnCrawler.GetCsdnOtherContentAsync();

            //数据转换
            var dbCsdnblogs = ObjectMapper.Map<List<CsdnblogsDto>, List<Csdnblogs>>(result);

            //自己去重
            dbCsdnblogs = dbCsdnblogs.Where((x, i) => dbCsdnblogs.FindIndex(z => z.Author == x.Author && z.Title == x.Title) == i).ToList();

            //事先检查数据库存不存在 同作者 标题的文章 一样的话 就不保存
            var currenmtUserId = CurrentUserId();
            var thisDataTime = DateTime.Now;

            var clientDBlogsList = await _csdnblogsRepository.GetCsdnblogsAll();

            //db 去重
            dbCsdnblogs.ForEach(item =>
            {
                var isChecket = clientDBlogsList.Any(x => x.Title == item.Title && x.Author == item.Author);
                if (!isChecket) csdnblogs.Add(item);
            });

            csdnblogs.ForEach(x =>
            {
                x.CreateUserId = currenmtUserId;
                x.CreateTime = thisDataTime;
                x.IsActive = true;
                x.IsDel = false;
            });

            //db add
            var data = await _csdnblogsRepository.CreateCsdnblogsAsync(csdnblogs);
            return Json(data);
        }

    }
}
