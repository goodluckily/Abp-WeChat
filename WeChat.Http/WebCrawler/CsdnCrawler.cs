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

namespace WeChat.Http.WebCrawler
{
    public class CsdnCrawler
    {
        public static string csdnOtherUrl = "https://blog.csdn.net/api/articles?type=more&category=other&shown_offset=0";

        public static string csdnTuiJianUrl = "https://cms-api.csdn.net/v1/web_home/select_content?componentIds=www-blog-recommend";

        /// <summary>
        /// 得到 csdn的 <<其他>> 下的文章内容
        /// </summary>
        /// <param name="refreshCount"></param>
        /// <returns></returns>
        public static async Task<List<CsdnblogsDto>> GetCsdnOtherContentAsync(int refreshCount = 10)
        {
            var csdnOtherList = new List<CsdnblogsDto>();
            var httpClient = new HttpClient();
            for (int i = 1; i <= refreshCount; i++)
            {
                var result = await httpClient.GetStringAsync(csdnOtherUrl);
                JObject _jObject = JObject.Parse(result);
                var code = _jObject["status"].ToString();
                if (code.ToLower().Equals("true"))
                {
                    var data = _jObject["articles"];
                    foreach (var item in data)
                    {
                        var title = item["title"]?.ToString()?.Trim();//标题
                        var desc = item["desc"]?.ToString()?.Trim();//内容简介
                        var created_at = item["created_at"]?.ToString()?.Trim();//创建时间
                        var product_type = item["product_type"]?.ToString()?.Trim();//文章类型
                        var url = item["url"]?.ToString()?.Trim();//原文Url
                        var img = item["avatarurl"]?.ToString()?.Trim();

                        var nickname = item["nickname"]?.ToString()?.Trim();//作者昵称
                        var user_url = item["user_url"]?.ToString()?.Trim();//作者地址

                        var views = item["views"]?.ToString()?.Trim()?.TryParseToInt();//观看看数
                        var digg = item["digg"]?.ToString()?.Trim()?.TryParseToInt();//点赞数
                        var comments = item["comments"]?.ToString()?.Trim()?.TryParseToInt();//评论数

                        csdnOtherList.Add(new CsdnblogsDto
                        {
                            Title = title,
                            SubContent = desc,
                            Img = img,
                            CreatedAt = created_at,
                            ProductType = product_type,
                            ContentUrl = url,
                            Author = nickname,
                            AuthorManUrl = user_url,
                            ReadNum = views,
                            DiggNum = digg,
                            CommentNum = comments,
                            AnalyzingType = AnalyzingEnum.BoKe
                        });
                    }
                }
            }
            return csdnOtherList;
        }


        /// <summary>
        /// 得到 csdn的 推荐 下的文章内容
        /// </summary>
        /// <param name="refreshCount"></param>
        /// <returns></returns>
        public static async Task<List<CsdnblogsDto>> GetCsdnTuiJianContentAsync(int refreshCount = 10)
        {
            var csdnOtherList = new List<CsdnblogsDto>();
            var httpClient = new HttpClient();
            for (int i = 1; i <= refreshCount; i++)
            {
                var result = await httpClient.GetStringAsync(csdnTuiJianUrl);
                JObject _jObject = JObject.Parse(result);
                var code = _jObject["code"].ToString();
                if (code.ToLower().Equals("200"))
                {
                    var data = _jObject["data"]["www-blog-recommend"]["info"];
                    foreach (var itemObject in data)
                    {
                        var item = itemObject["extend"];
                        var title = item["title"]?.ToString()?.Trim();//标题
                        var desc = item["desc"]?.ToString()?.Trim();//内容简介
                        var created_at = item["created_at"]?.ToString()?.Trim();//创建时间
                        var product_type = item["product_type"]?.ToString()?.Trim();//文章类型
                        var url = item["url"]?.ToString()?.Trim();//原文Url
                        var img = item["avatarurl"]?.ToString()?.Trim();

                        var nickname = item["nickname"]?.ToString()?.Trim();//作者昵称
                        var user_url = "https://blog.csdn.net/" + item["user_name"]?.ToString()?.Trim();//作者地址

                        var views = item["views"]?.ToString()?.Trim()?.TryParseToInt();//观看看数
                        var digg = item["digg"]?.ToString()?.Trim()?.TryParseToInt();//点赞数
                        var comments = item["comments"]?.ToString()?.Trim()?.TryParseToInt();//评论数

                        csdnOtherList.Add(new CsdnblogsDto
                        {
                            Title = title,
                            SubContent = desc,
                            Img = img,
                            CreatedAt = created_at,
                            ProductType = product_type,
                            ContentUrl = url,
                            Author = nickname,
                            AuthorManUrl = user_url,
                            ReadNum = views,
                            DiggNum = digg,
                            CommentNum = comments,
                            AnalyzingType = AnalyzingEnum.BoKe
                        });
                    }
                }
            }
            return csdnOtherList;
        }
    }
}
