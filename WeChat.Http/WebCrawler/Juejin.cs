using System.Collections.Generic;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WeChat.Domain.Shared;
using WeChat.Http.Helper;

namespace WeChat.Http.WebCrawler
{
    /// <summary>
    /// 稀土掘金
    /// </summary>
    public class Juejin
    {
        public static string JuejinNewsUrl = "https://juejin.cn/news?sort=weekly_hottest";

        /// <summary>
        /// 缺点 主图 地址获取不到
        /// </summary>
        /// <returns></returns>
        public static List<JueJinblogsDto> GetJuejinNewsContent()
        {
            var juejinblogsList = new List<JueJinblogsDto>();
            var web = new HtmlWeb();

            //从url中加载
            HtmlDocument doc = web.Load(JuejinNewsUrl);
            //获得title标签节点，其子标签下的所有节点也在其中
            var itemHtmlNodes = doc.DocumentNode.SelectNodes("//a[@class='realtime_card hashot']"); //一般是第一页  热榜前三
            var juejinUrl = "https://juejin.cn";
            var nuewsUserUrl = juejinUrl + "/user/";
            foreach (var itemNode in itemHtmlNodes)
            {
                //原文地址
                var contentUrl = juejinUrl + itemNode.Attributes["href"].Value;

                //标题 
                var title = itemNode.SelectSingleNode(".//div[@class='title_box']")?.InnerText?.Trim();
                if (string.IsNullOrWhiteSpace(title))
                {
                    title = itemNode.SelectSingleNode(".//span[@class='title_box']")?.InnerText?.Trim();
                }

                //主图
                var Img = itemNode.SelectSingleNode(".//img[@class='lazy thumbnail']")?.Attributes["src"]?.Value?.Trim();//
                var aaa = itemNode.SelectSingleNode(".//img[@alt='年终盘点服务网格：实用当先，生态为本']")?.Attributes["src"]?.Value?.Trim();
                //内容简介
                var SubContent = itemNode.SelectSingleNode(".//p[@class='brief']")?.InnerText?.Trim();

                //作者名称
                var author = itemNode.SelectSingleNode(".//div[@class='popover-box user-popover']")?.InnerText?.Trim();

                //作者主页地址
                var authorManUrl = nuewsUserUrl + itemNode.SelectSingleNode(".//div[@class='tools jh-news-item-action-area']")?.Attributes["data-news-id"].Value.Trim();

                //时间
                var ReleaseTimeStr = itemNode.SelectSingleNode(".//div[@class='tools jh-news-item-action-area']/p[@class='date']")?.InnerText?.Trim();

                //点赞数
                var GiveLikeNum = itemNode.SelectSingleNode(".//div[@class='tools jh-news-item-action-area']/p[@class='liked']")
                    ?.InnerText?.Replace("点赞", "").Trim().TryParseToInt();

                //品论数
                var CommentNum = itemNode.SelectSingleNode(".//div[@class='tools jh-news-item-action-area']/p[@class='comment']")
                    ?.InnerText?.Replace("评论", "").Trim().TryParseToInt();

                juejinblogsList.Add(new JueJinblogsDto()
                {
                    Author = author,
                    Title = title,
                    //ReleaseTime = ReleaseTimeStr,
                    SubContent = SubContent,
                    Img = Img,
                    AuthorManUrl = authorManUrl,
                    CommentNum = CommentNum,
                    ContentUrl = contentUrl,
                    GiveLikeNum = GiveLikeNum,
                    AnalyzingType = AnalyzingEnum.ReDian,
                });
            }

            return juejinblogsList;
        }


        /// <summary>
        /// 最新资讯
        /// </summary>
        /// <returns></returns>

        public static List<JueJinblogsDto> GetJuejinNewsContentForApi()
        {
            var juejinblogsList = new List<JueJinblogsDto>();

            var apiUrl = "https://api.juejin.cn/recommend_api/v1/news/list";

            //对大50个数据
            var json = "{\"limit\":60,\"recommend_mode\":1,\"sort_type\":600}";

            var result = CommonHelper.PostRequestStr(apiUrl, json);

            var juejinUrl = "https://juejin.cn";
            var nuewsUserUrl = juejinUrl + "/user/";
            var nuewsContentUrl = juejinUrl + "/news/";

            JObject _jObject = JObject.Parse(result);
            var code = _jObject["err_msg"].ToString();
            if (code.Equals("success"))
            {
                var data = _jObject["data"];
                foreach (var item in data)
                {
                    var cInfo = JsonConvert.DeserializeObject<dynamic>(item["content_info"].ToString());

                    var cUser = JsonConvert.DeserializeObject<dynamic>(item["author_user_info"].ToString());

                    var cCounter = JsonConvert.DeserializeObject<dynamic>(item["content_counter"].ToString());

                    var pushTime = cInfo.publish_time;
                    juejinblogsList.Add(new JueJinblogsDto
                    {
                        Title = cInfo.title,//标题
                        SubContent = cInfo.brief,//内容简介
                        Img = cInfo.thumbnail,//内容图片
                        Author = cUser.user_name,//作者
                        AuthorManUrl = nuewsUserUrl + cUser.user_id,//作者主页地址
                        ContentUrl = nuewsContentUrl + cInfo.content_id,//源内容地址

                        GiveLikeNum = cCounter.digg,//点赞数
                        ReadNum = cCounter.view,//展示阅读数
                        CommentNum = cCounter.comment,//评论数
                        HotIndex = cCounter.hot_index,//热门系数
                        ReleaseTime = ((long)pushTime).ToDateByStamp(),//发布时间
                        AnalyzingType = AnalyzingEnum.ReDian,
                    });
                }
            }

            return juejinblogsList;
        }


        //这是从掘金插件 Api里面得到的 后端资源
        //更多资源请观察 掘金插件地址(https://juejin.cn/extension)
        //https://api.juejin.cn/recommend_api/v1/article/recommend_cate_feed
        //POST
        //{"limit":20,"client_type":6587,"cursor":"0","id_type":2,"cate_id":"6809637769959178254","sort_type":200}
    }
}
