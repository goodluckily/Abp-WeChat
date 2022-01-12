using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using WeChat.Application.Contracts.DtoModels;
using WeChat.Domain.WeChat;
using WeChat.Domain.IRepository;
using Microsoft.AspNetCore.Cors;
using Volo.Abp.ObjectMapping;
using AutoMapper;
using Volo.Abp.Guids;


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

        [HttpGet("createNetcnblogs")]
        public async Task<DataResult> createNetcnblogs()
        {
            //.net 专题
            var blogNetResult = Blogs.GetNetCnblogsContent();

            //热门新闻
            var blogNewsResut = Blogs.GetToDayNewsCnblogsContent();

            //数据转换
            var dbNetblogs = ObjectMapper.Map<List<NetcnblogsDto>, List<Netcnblogs>>(blogNetResult);

            var dbNewsblogs = ObjectMapper.Map<List<NetcnblogsDto>, List<Netcnblogs>>(blogNewsResut);

            //合并
            dbNetblogs.AddRange(dbNewsblogs);

            //事先检查数据库存不存在 同作者 标题的文章 一样的话 就不保存
            var currenmtUserId = CurrentUserId();
            var thisDataTime = DateTime.Now;

            var clientDBNetcnblogsList = await _netcnblogsRepository.GetAllAsync();
            var newNetcnblogs = new List<Netcnblogs>();

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
            return Json(netBlogsList);
        }
    }
}
