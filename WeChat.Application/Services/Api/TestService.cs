using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChat.Http.HttpHelper;

namespace WeChat.Application.Services.Api
{
    /// <summary>
    /// 测试控制器
    /// </summary>
    [AllowAnonymous]
    public class TestService : BaseApiService
    {
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
    }
}
