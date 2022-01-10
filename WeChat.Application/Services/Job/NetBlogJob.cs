using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChat.Application.Contracts.DtoModels;
using WeChat.Domain.IRepository;
using WeChat.Domain.WeChat;

namespace WeChat.Application.Services.Job
{
    [Route("NetBlogJob")]
    public class NetBlogJob : BaseService
    {
        private readonly INetcnblogsRepository _netcnblogsRepository;
        private readonly Blogs _blogs;

        public NetBlogJob(INetcnblogsRepository netcnblogsRepository, Blogs blogs)
        {
            _netcnblogsRepository = netcnblogsRepository;
            _blogs = blogs;
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
            var blogResult = _blogs.GetCnblogsContent();

            var dbNetblogs = ObjectMapper.Map<List<NetcnblogsDto>, List<Netcnblogs>>(blogResult);

            var currenmtUserId = CurrentUserId();
            var thisDataTime = DateTime.Now;

            dbNetblogs.ForEach(x =>
            {
                x.CreateUserId = currenmtUserId;
                x.CreateTime = thisDataTime;
                x.IsActive = true;
                x.IsDel = false;
            });

            var netBlogsList = await _netcnblogsRepository.CreateNetcnblogsAsync(dbNetblogs);
            return Json(netBlogsList);
        }
    }
}
