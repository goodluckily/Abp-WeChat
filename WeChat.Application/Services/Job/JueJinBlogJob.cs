﻿using System;
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
using WeChat.Common.Analyzing;

namespace WeChat.Application.Services.Job
{

    [Route("JueJinBlogJob")]
    public class JueJinBlogJob : BaseService
    {
        private readonly IJueJinblogsRepository _jueJinblogsRepository;

        public JueJinBlogJob(IJueJinblogsRepository jueJinblogsRepository)
        {
            _jueJinblogsRepository = jueJinblogsRepository;
        }

        [HttpGet("getJueJinblogsAll")]
        public async Task<DataResult> GetJueJinblogsAllAsync()
        {
            var data = await _jueJinblogsRepository.GetJueJinblogsAll();
            return Json(data);
        }

        [HttpPost("CreateJueJinblogs")]
        public async Task<DataResult> CreateJueJinblogs()
        {
            var result = Juejin.GetJuejinNewsContentForApi();
            //数据转换
            var dbJueJinblogs = ObjectMapper.Map<List<JueJinblogsDto>, List<JueJinblogs>>(result);

            //事先检查数据库存不存在 同作者 标题的文章 一样的话 就不保存
            var currenmtUserId = CurrentUserId();
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
                x.CreateUserId = currenmtUserId;
                x.CreateTime = thisDataTime;
                x.IsActive = true;
                x.IsDel = false;
            });
            var data = await _jueJinblogsRepository.CreateJueJinblogsAsync(cnblogs);
            return Json(data);
        }
    }
}
