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
    public class ItHomeCrawler
    {
        public static string itHomeUrl = "https://it.ithome.com/";

        public static string itHomeUrlMicrosoft = "https://it.ithome.com/microsoft";

        /// <summary>
        /// IT资讯最新
        /// </summary>
        /// <returns></returns>
        public static List<ItHomeblogsDto> GetItHomeNews()
        {
            var web = new HtmlWeb();
            //从url中加载
            HtmlDocument doc = web.Load(itHomeUrl);
            List<ItHomeblogsDto> itHomeblogsList = JieXiItHomeHtml(doc);
            return itHomeblogsList;
        }

        /// <summary>
        /// 微软最新资讯
        /// </summary>
        /// <returns></returns>
        public static List<ItHomeblogsDto> GetItHomeMicrosoftNews()
        {
            var web = new HtmlWeb();
            //从url中加载
            HtmlDocument doc = web.Load(itHomeUrlMicrosoft);
            List<ItHomeblogsDto> itHomeblogsList = JieXiItHomeHtml(doc);
            return itHomeblogsList;
        }

        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private static List<ItHomeblogsDto> JieXiItHomeHtml(HtmlDocument doc)
        {
            var itHomeblogsList = new List<ItHomeblogsDto>();
            //获得title标签节点，其子标签下的所有节点也在其中
            var itemHtmlNodes = doc.DocumentNode.SelectNodes("//ul[@class='bl']/li"); //一般是第一页 的20条数据
            foreach (var itemNode in itemHtmlNodes)
            {
                //标题
                var title = itemNode.SelectSingleNode(".//a[@class='img']/img")?.Attributes["alt"].Value?.Trim();

                //主图
                var img = itemNode.SelectSingleNode(".//a[@class='img']/img")?.Attributes["src"]?.Value?.Trim();

                //内容简介 介绍
                var subContent = itemNode.SelectSingleNode(".//div[@class='m']")?.InnerText.Trim();

                //内容原始文章地址
                var contentUrl = itemNode.SelectSingleNode(".//a[@class='img']")?.Attributes["href"]?.Value?.Trim();

                //发布时间 item_foot
                var itemFootContent = itemNode.SelectSingleNode(".//div[@class='c']")?.Attributes["data-ot"]?.Value?.Trim();
                var releaseTime = itemFootContent.TryParseToDateTime();

                var tagesNodes = itemNode.SelectNodes(".//div[@class='tags']/a");
                var tagesList = new List<string>();
                var tagesHrefList = new List<string>();
                foreach (var tage in tagesNodes)
                {
                    var thistage = tage?.InnerText?.Trim();
                    var thishref = tage?.Attributes["href"]?.Value?.Trim();
                    tagesList.Add(thistage);
                    tagesHrefList.Add(thishref);
                }

                var tagesStr = string.Join(",", tagesList);
                var tageshrefStr = string.Join(",", tagesHrefList);

                itHomeblogsList.Add(new ItHomeblogsDto()
                {
                    Title = title,
                    Img = img,
                    SubContent = subContent,
                    ContentUrl = contentUrl,
                    ReleaseTime = releaseTime,
                    Tags = tagesStr,
                    TagsUrl = tageshrefStr,
                    AnalyzingType = AnalyzingEnum.ZiXun
                });
            }

            return itHomeblogsList;
        }
    }
}
