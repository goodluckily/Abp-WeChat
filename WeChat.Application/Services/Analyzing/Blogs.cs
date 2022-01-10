using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using WeChat.Application.Contracts.DtoModels;
using WeChat.Common;
using WeChat.Domain.Shared.Enum;

namespace WeChat.Application.Services
{

    /// <summary>
    /// 博客园  https://www.cnblogs.com/
    /// </summary>
    public class Blogs
    {
        /// <summary>
        /// .net 技术文章列表
        /// </summary>
        public static string netBlogsUrl = "https://www.cnblogs.com/legacy/cate/108698/";

        /// <summary>
        /// 新闻资讯列表
        /// </summary>
        public static string newsBlogsUrl = "https://www.cnblogs.com/news/";

        public List<NetcnblogsDto> GetCnblogsContent()
        {
            var netcnblogsList = new List<NetcnblogsDto>();
            var web = new HtmlWeb();

            //从url中加载
            HtmlDocument doc = web.Load(netBlogsUrl);
            //获得title标签节点，其子标签下的所有节点也在其中
            var itemHtmlNodes = doc.DocumentNode.SelectNodes("//div[@class='post_item']"); //一般是第一页 的20条数据
            foreach (var itemNode in itemHtmlNodes)
            {
                //标题
                var title = itemNode.SelectSingleNode(".//a[@class='titlelnk']").InnerText.Trim();

                //主图
                var img = itemNode.SelectSingleNode(".//img[@class='pfs']")?.Attributes["src"].Value.Trim();

                //内容介绍
                var content = itemNode.SelectSingleNode(".//p[@class='post_item_summary']")?.InnerText.Trim();

                //推荐数
                var recommendNum = itemNode.SelectSingleNode(".//span[@class='diggnum']")?.InnerText.Trim().TryParseToInt();

                //作者
                var author = itemNode.SelectSingleNode(".//a[@class='lightblue']")?.InnerText.Trim();

                //作者主页地址
                var authorManUrl = itemNode.SelectSingleNode(".//a[@class='lightblue']")?.Attributes["href"].Value.Trim();

                //发布时间 item_foot
                var itemFootContent = itemNode.SelectSingleNode(".//div[@class='post_item_foot']")?.InnerText;
                var releaseTime = itemFootContent?.Split("\r\n")[2].Replace("发布于", "").Trim().TryParseToDateTime();

                //评论数
                var commentNum = itemNode.SelectSingleNode(".//span[@class='article_comment']/a")?.InnerText
                    .Replace("评论(", "")
                    .Replace(")", "")
                    .Trim().TryParseToInt();

                //阅读数
                var readNum = itemNode.SelectSingleNode(".//span[@class='article_view']/a")?.InnerText
                    .Replace("阅读(", "")
                    .Replace(")", "")
                    .Trim().TryParseToInt();

                netcnblogsList.Add(new NetcnblogsDto()
                {
                    Title = title,
                    Img = img,
                    Content = content,
                    RecommendNum = recommendNum,
                    Author = author,
                    AuthorManUrl = authorManUrl,
                    ReleaseTime = releaseTime,
                    CommentNum = commentNum,
                    ReadNum = readNum,
                    AnalyzingType = AnalyzingEnum.NET
                });
            }

            return netcnblogsList;
        }

    }
}
