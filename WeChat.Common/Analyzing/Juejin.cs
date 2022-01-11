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

        public static void GetJuejinNewsContent()
        {
            var netcnblogsList = new List<NetcnblogsDto>();
            var web = new HtmlWeb();

            //从url中加载
            HtmlDocument doc = web.Load(JuejinNewsUrl);
            //获得title标签节点，其子标签下的所有节点也在其中
            var itemHtmlNodes = doc.DocumentNode.SelectNodes("//a[@class='realtime_card']"); //一般是第一页 

            foreach (var itemNode in itemHtmlNodes)
            {
                //标题 
                var title = itemNode.SelectSingleNode(".//a[@class='byte-tooltip__wrapper']")?.InnerText?.Trim();
                if (string.IsNullOrWhiteSpace(title))
                {
                    title = itemNode.SelectSingleNode(".//a[@class='title_box']")?.InnerText?.Trim();
                }

                //内容简介
                var SubContent = itemNode.SelectSingleNode(".//p[@class='brief']")?.InnerText?.Trim();

                //作者名称
                var author = itemNode.SelectSingleNode(".//div[@class='popover-box user-popover']")?.InnerText?.Trim();

                //作者主页地址
                var authorManUrl = "https://juejin.cn/user/" + itemNode.SelectSingleNode(".//div[@class='tools jh-news-item-action-area']")?.Attributes["data-news-id"].Value.Trim();



                netcnblogsList.Add(new NetcnblogsDto()
                {

                });
            }

        }
    }
}
