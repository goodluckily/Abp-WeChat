﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChat.Domain;
using WeChat.Http.HttpHelper;
using WeChat.Shared;
using WeChat.Shared.Enums;
using WeChat.Shared.Localization.Exceptions;

namespace WeChat.Application.Services.Api
{
    /// <summary>
    /// 测试控制器
    /// </summary>
    [AllowAnonymous]
    public class TestService : BaseApiService
    {
        private IRazorViewEngine _razorViewEngine;
        private IServiceProvider _serviceProvider;
        private ITempDataProvider _tempDataProvider;
        private readonly IStringLocalizer<LangueResource> _stringLocalizer;

        public TestService(
            IRazorViewEngine engine,
            IServiceProvider serviceProvider,
            ITempDataProvider tempDataProvider,
            IStringLocalizer<LangueResource> stringLocalizer
            )
        {
            this._razorViewEngine = engine;
            this._serviceProvider = serviceProvider;
            this._tempDataProvider = tempDataProvider;
            _stringLocalizer = stringLocalizer;
        }

        /// <summary>
        /// 获取学生信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("getStudentList")]
        public DataResult GetStudentList()
        {
            var data = new List<object>()
            {
                new {Id=1,Name="AA",Age=11,Address="深圳" },
                new {Id=2,Name="BB",Age=22,Address="北京" },
                new {Id=3,Name="CC",Age=33,Address="上海" },
                new {Id=4,Name="DD",Age=44,Address="广州" },
                new {Id=5,Name="EE",Age=55,Address="重庆" },
            };
            return Result.Json(data);
        }

        /// <summary>
        /// 测试Job的Key是否正确
        /// </summary>
        /// <returns></returns>
        [HttpGet("testRequestUrl")]
        public DataResult Get(string key)
        {
            var http = new HttpClientHelper();
            var result = http.PostResponseForJobApi($"http://127.0.0.1:9999/CodeDeaultblogsJob/CodeDeaultblogsContent?key={key}");
            return Result.Json(result);
        }


        /// <summary>
        /// Razor 转 Html
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>

        [HttpGet("testRazorToHtml")]
        public async Task<DataResult> TestRazorToHtml(string path = "TemplateRazor/TestList")
        {
            var razorT = new TemplateHtmlCommon(_razorViewEngine, _serviceProvider, _tempDataProvider);
            var aaaaa = new List<Log>();
            aaaaa.Add(new Log() { Message = "1111111" });
            aaaaa.Add(new Log() { Message = "2222222" });
            aaaaa.Add(new Log() { Message = "3333333" });
            var dic = new Dictionary<string, object?>();
            dic.Add("Name", "cy");
            dic.Add("Address", "深圳");
            dic.Add("Age", 18);
            var aa = await razorT.TemplateRazorToHtml(path, aaaaa, dic);
            return Result.Json(aa);
        }

        /// <summary>
        /// Html 转 PDF
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>

        [HttpGet("TestHtmlToPdf")]
        public async Task<FileStreamResult> TestHtmlToPdf(string path = "TemplateRazor/TestList")
        {
            var razorT = new TemplateHtmlCommon(_razorViewEngine, _serviceProvider, _tempDataProvider);
            var aaaaa = new List<Log>();
            for (int i = 0; i < 10000; i++)
            {
                aaaaa.Add(new Log() { Message = i.ToString(), MachineIp = "127.0.0.1" });
            }
            var dic = new Dictionary<string, object?>();
            dic.Add("Name", "cy");
            dic.Add("Address", "深圳");
            dic.Add("Age", 18);
            var aa = await razorT.TemplateRazorToHtml(path, aaaaa, dic);
            //DinkToPdfCommon.HtmlToPdf(aa);
            var result = DinkToPdfCommon.Convert(aa);

            var stream = new MemoryStream(result, 0, result.Length);
            stream.Position = 0;
            return new FileStreamResult(stream, "application/pdf") { FileDownloadName = $"{DateTime.Now.Ticks}.pdf" };
        }


        /// <summary>
        /// 多语言相关配置
        /// </summary>
        /// <returns></returns>
        [HttpGet("TestLocalizer")]
        public async Task<DataResult> TestLocalizer(CultureEnum cultureEnum)
        {
            switch (cultureEnum)
            {
                case CultureEnum.English:
                    CultureInfo.CurrentCulture = new CultureInfo("en");//英文
                    CultureInfo.CurrentUICulture = new CultureInfo("en");
                    break;
                case CultureEnum.zhHans:
                    CultureInfo.CurrentCulture = new CultureInfo("zh-Hans");//简体中文
                    CultureInfo.CurrentUICulture = new CultureInfo("zh-Hans");
                    break;
                case CultureEnum.zhHant:
                    CultureInfo.CurrentCulture = new CultureInfo("zh-Hant");//繁体中文-台湾
                    CultureInfo.CurrentUICulture = new CultureInfo("zh-Hant");
                    break;
                default:
                    goto case CultureEnum.zhHans;
            }
            var data1 = _stringLocalizer["HelloWorld","cycycy"];
            var data2 = _stringLocalizer["HelloWorldData","cycycy","18"];
            var data3 = _stringLocalizer["HelloWorldData", "18", "cycycy"];
            var data = new
            {
                data1,
                data2,
                data3
            };
            return Result.Json(data);
        }
    }
}
