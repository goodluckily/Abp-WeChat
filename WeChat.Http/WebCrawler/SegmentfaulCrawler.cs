using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeChat.Domain.Shared;

namespace WeChat.Http.WebCrawler
{
    /// <summary>
    /// 思否
    /// </summary>
    public class SegmentfaulCrawler
    {
        /// <summary>
        /// 思否 主站地址
        /// </summary>
        public static string mainUrl = "https://segmentfault.com";

        /// <summary>
        /// 思否 后端地址
        /// </summary>
        public static string backendUrl = mainUrl + "/gateway/articles?query=channel&slug=backend&size=30&mode=scrollLoad&offset=";

        public static async Task<List<SegmentfaultblogsDto>> GetSegmentfaulCrawlerContentAsync(int scrollLoadCount = 3)
        {
            var segmentfaultList = new List<SegmentfaultblogsDto>();
            var httpClient = new HttpClient();

            var offset = string.Empty;
            for (int i = 1; i <= scrollLoadCount; i++)
            {
                if (!string.IsNullOrWhiteSpace(offset)) backendUrl = backendUrl + offset;
                var result = await httpClient.GetStringAsync(backendUrl);
                JObject _jObject = JObject.Parse(result);
                offset = _jObject["offset"].ToString();
                var data = _jObject["rows"];
                foreach (var item in data)
                {
                    var title = item["title"]?.ToString()?.Trim();//标题
                    var created = item["created"]?.ToString()?.TryParseToLong().ToDateByStamp();//创建时间
                    var url = mainUrl + "/a/" + item["id"]?.ToString()?.Trim();//原文Url

                    var Img = mainUrl + item["cover"]?.ToString()?.Trim();//图片

                    var nickname = item["user"]["name"]?.ToString()?.Trim();//作者昵称
                    var user_url = mainUrl + item["user"]["url"]?.ToString()?.Trim();//作者地址

                    var votes = item["votes"]?.ToString()?.Trim()?.TryParseToInt();//观看看数
                    var comments = item["comments"]?.ToString()?.Trim()?.TryParseToInt();//评论数

                    segmentfaultList.Add(new SegmentfaultblogsDto
                    {
                        Title = title,
                        ReleaseTime = created,
                        ContentUrl = url,
                        Img = Img,
                        Author = nickname,
                        AuthorManUrl = user_url,
                        DiggNum = votes,
                        CommentNum = comments,
                        AnalyzingType = AnalyzingEnum.WenZhang
                    });
                }

            }
            return segmentfaultList;
        }
    }
}
