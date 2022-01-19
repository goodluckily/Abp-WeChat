using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WeChat.Shared;
using WeChat.Http.Helper;


namespace WeChat.Http.WebCrawler
{
    public class OsChinaCrawler
    {
        public static string osChinaUrl = "https://www.oschina.net/";

        public static List<OsChinablogsDto> GetOsChinaBlogContent(int pageCount = 3)
        {
            var osChinaBlogsist = new List<OsChinablogsDto>();
            var web = new HtmlWeb();
            for (int i = 1; i <= pageCount; i++)
            {
                //从url中加载
                HtmlDocument doc = web.Load(osChinaUrl + "/blog/widgets/_blog_index_recommend_list?classification=0&p=" + i);
                var itemHtmlNodes = doc.DocumentNode.SelectNodes("//div[@class='item blog-item']"); //一般是第一页 数据
                foreach (var itemNode in itemHtmlNodes)
                {
                    //标题 
                    var title = itemNode.SelectSingleNode(".//a[@class='header']")?.Attributes["title"]?.Value?.Trim();

                    //原文地址
                    var contentUrl = itemNode.SelectSingleNode(".//a[@class='header']")?.Attributes["href"]?.Value?.Trim();

                    //内容简介
                    var SubContent = itemNode.SelectSingleNode(".//div[@class='description']")?.InnerText?.Trim();

                    //主图
                    var Img = itemNode.SelectSingleNode(".//a[@class='ui small image']/img")?.Attributes["src"]?.Value?.Trim();//

                    //作者名称
                    var footDetail = itemNode.SelectNodes(".//div[@class='ui horizontal list']/div");

                    var author = footDetail[0].SelectSingleNode(".//a").InnerText?.Trim();
                    var authorManUrl = footDetail[0].SelectSingleNode(".//a").Attributes["href"]?.Value?.Trim();
                    var shijian = footDetail[1].InnerText?.Trim();
                    var showNum = footDetail[2].InnerText?.Trim()?.TryParseToInt();
                    var pingNun = footDetail[3].InnerText?.Trim()?.TryParseToInt();
                    var likeNum = footDetail[4].InnerText?.Trim()?.TryParseToInt();


                    osChinaBlogsist.Add(new OsChinablogsDto()
                    {
                        Author = author,
                        AuthorManUrl = authorManUrl,
                        Title = title,
                        SubContent = SubContent,
                        ContentUrl = contentUrl,
                        Img = Img,
                        ReleaseTimeStr = shijian,
                        ReadNum = showNum,
                        CommentNum = pingNun,
                        LikeNum = likeNum,
                        AnalyzingType = AnalyzingEnum.BoKe,
                    });
                }
            }
            return osChinaBlogsist;
        }
    }
}
