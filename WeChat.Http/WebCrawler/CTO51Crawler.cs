using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeChat.Shared;
using WeChat.Shared.Enums;

namespace WeChat.Http.WebCrawler
{
    public class CTO51Crawler
    {
        public static string CTO51Url = "https://api-media.51cto.com/";

        public static async Task<List<CTO51blogsDto>> Get51CTOContentAsync(int pageCount = 2)
        {
            var CTO51blogsList = new List<CTO51blogsDto>();
            var httpClient = new HttpClient();
            for (int i = 1; i <= pageCount; i++)
            {
                var requestUrl = CTO51Url + $"index/index/recommend?page={i}&page_size=50&limit_time=0&name_en=developer";
                var result = await httpClient.GetStringAsync(requestUrl);
                JObject _jObject = JObject.Parse(result);
                var code = _jObject["code"].ToString();
                if (code.ToLower().Equals("200"))
                {
                    var data = _jObject["data"]["data"]["list"];
                    foreach (var item in data)
                    {
                        var title = item["title"]?.ToString()?.Trim();//标题
                        var desc = item["abstract"]?.ToString()?.Trim();//内容简介
                        var pubdate = item["pubdate"]?.ToString()?.Trim()?.TryParseToDateTime();//时间
                        var source_type = item["source_type"]?.ToString()?.Trim();//类型
                        var url = item["url"]?.ToString()?.Trim();//原文Url
                        var img = item["cover"]?.ToString()?.Trim();
                        var keywordList = item["keyword"];
                        var keywordListStr = new List<string>();
                        foreach (var itemkeywor in keywordList)
                        {
                            keywordListStr.Add(itemkeywor["name"]?.ToString());
                        }
                        var keywords = string.Join(",", keywordListStr);
                        CTO51blogsList.Add(new CTO51blogsDto
                        {
                            Title = title,
                            SubContent = desc,
                            Img = img,
                            ReleaseTime = pubdate,
                            SourceType = source_type,
                            ContentUrl = url,
                            KeyWords = keywords,
                            AnalyzingType = AnalyzingEnum.WenZhang
                        });
                    }
                }
            }
            return CTO51blogsList;
        }
    }
}
