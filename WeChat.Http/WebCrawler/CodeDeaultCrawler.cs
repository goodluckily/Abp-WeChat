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
    public class CodeDeaultCrawler
    {
        public static string codeDeaultUrl = "https://codedefault.com/post/list";


        public static List<CodeDeaultblogsDto> GetCodeDeaultContent()
        {
            var codeDeaultblogsList = new List<CodeDeaultblogsDto>();

            var web = new HtmlWeb();
            //从url中加载
            HtmlDocument doc = web.Load(codeDeaultUrl);
            //获得title标签节点，其子标签下的所有节点也在其中
            var itemHtmlNodes = doc.DocumentNode.SelectNodes("//div[@class='post-items']/div"); //一般是第一页 的20条数据
            foreach (var itemNode in itemHtmlNodes)
            {
                //标题
                var title = itemNode.SelectSingleNode(".//a[@class='media-heading title']")?.InnerText?.Trim();
                if (title is null) continue;

                //内容简介 介绍
                var subContent = itemNode.SelectSingleNode(".//p[@class='post-item-summary']")?.InnerText.Trim();

                //内容原始文章地址
                var contentUrl = itemNode.SelectSingleNode(".//a[@class='media-heading title']")?.Attributes["href"].Value.Trim();

                //喜欢
                var likeNum = itemNode.SelectSingleNode(".//a[@class='ts-icon-home btn-like']/span")?.InnerText.Trim()?.TryParseToInt();

                //浏览
                var showNum = itemNode.SelectSingleNode(".//div[@class='post-left-view']/span")?.InnerText.Trim()?.TryParseToInt();

                //item_foot
                var itemFoo = itemNode.SelectNodes(".//div[@class='post-extra-data']/span");

                var category = itemFoo[0].InnerText.Trim();
                var shijian = itemFoo[1].InnerText.Trim()?.TryParseToDateTime();
                var pinlun = itemFoo[2].InnerText?.Replace("评论", "").Trim()?.TryParseToInt();
                var shoucang = itemFoo[3].InnerText?.Replace("收藏", "").Trim()?.TryParseToInt();

                codeDeaultblogsList.Add(new CodeDeaultblogsDto()
                {
                    Title = title,
                    SubContent = subContent,
                    ContentUrl = contentUrl,
                    Category = category,
                    ReleaseTime = shijian,
                    CollectionNum = shoucang,
                    CommentNum = pinlun,
                    LikeNum = likeNum,
                    ReadNum = showNum,
                    AnalyzingType = AnalyzingEnum.WenZhang
                });
            }
            return codeDeaultblogsList;

        }
    }
}
