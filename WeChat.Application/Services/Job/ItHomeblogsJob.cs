﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeChat.Domain;
using WeChat.Domain.IRepository;
using WeChat.Shared;
using WeChat.Http.WebCrawler;
using System.Threading;

namespace WeChat.Application.Services.Job
{
    /// <summary>
    /// IT之家
    /// </summary>
    [Route("ItHomeblogsJob")]
    public class ItHomeblogsJob : BaseService
    {
        private readonly IItHomeblogsRepository _itHomeblogsRepository;

        public ItHomeblogsJob(IItHomeblogsRepository itHomeblogsRepository)
        {
            _itHomeblogsRepository = itHomeblogsRepository;
        }

        /// <summary>
        /// 获取It之家 微软资讯
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetItHomeblogsAll")]
        public async Task<DataResult> GetItHomeblogsAll()
        {
            var data = await _itHomeblogsRepository.GetItHomeblogsAll();
            return Json(data);
        }

        /// <summary>
        /// 获取 It之家的 IT资讯最新
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetItHomeblogsContent")]
        public async Task<DataResult> GetItHomeblogsContent()
        {
            var result = ItHomeCrwaler.GetItHomeNews();
            List<ItHomeblogs> itHomeblogList = await GetAddDbBlogs(result);
            //db add
            var data = await _itHomeblogsRepository.CreateItHomeblogsAsync(itHomeblogList);
            return Json(data);
        }

        /// <summary>
        /// 获取It之家 微软资讯
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetItHomeblogsMicrosoftContent")]
        public async Task<DataResult> GetItHomeblogsMicrosoftContent()
        {
            var result = ItHomeCrwaler.GetItHomeMicrosoftNews();
            List<ItHomeblogs> itHomeblogList = await GetAddDbBlogs(result);
            //db add
            var data = await _itHomeblogsRepository.CreateItHomeblogsAsync(itHomeblogList);
            return Json(data);
        }

        /// <summary>
        /// Api解析 去重
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private async Task<List<ItHomeblogs>> GetAddDbBlogs(List<ItHomeblogsDto> result)
        {

            var itHomeblogList = new List<ItHomeblogs>();
            //数据转换
            var dbitHomes = ObjectMapper.Map<List<ItHomeblogsDto>, List<ItHomeblogs>>(result);

            //自己去重
            dbitHomes = dbitHomes.Where((x, i) => dbitHomes.FindIndex(z => z.Title == x.Title) == i).ToList();

            //事先检查数据库存不存在 同作者 标题的文章 一样的话 就不保存
            var currenmtUserId = CurrentUserId();
            var thisDataTime = DateTime.Now;

            var clientDBlogsList = await _itHomeblogsRepository.GetItHomeblogsAll();

            //db 去重
            dbitHomes.ForEach(item =>
            {
                var isChecket = clientDBlogsList.Any(x => x.Title == item.Title);
                if (!isChecket) itHomeblogList.Add(item);
            });

            itHomeblogList.ForEach(x =>
            {
                x.CreateUserId = currenmtUserId;
                x.CreateTime = thisDataTime;
                x.IsActive = true;
                x.IsDel = false;
            });
            return itHomeblogList;
        }
    }
}