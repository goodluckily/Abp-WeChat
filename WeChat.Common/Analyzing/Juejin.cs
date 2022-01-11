using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using WeChat.Application.Contracts.DtoModels;
using WeChat.Common;
using WeChat.Domain.Shared.Enum;


namespace WeChat.Common.Analyzing
{
    /// <summary>
    /// 稀土掘金
    /// </summary>
    public class Juejin
    {
        public static string JuejinNewsUrl = "https://juejin.cn/news?sort=weekly_hottest";

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
                var Img = itemNode.SelectSingleNode(".//img[@class='lazy thumbnail']")?.Attributes["src"]?.Value?.Trim();

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
                    ReleaseTimeStr = ReleaseTimeStr,
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
    }
}
