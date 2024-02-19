using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeChat.Http.WebCrawler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChat.Http.WebCrawler.Tests
{
    [TestClass()]
    public class CsdnCrawlerTests
    {
        [TestMethod()]
        public void GetCsdnOtherContentTest()
        {
            //1 博客园
            var aaadsfasdf = CnblogesCrawler.GetNetCnblogsContent();

            //2 码友网
            var asfsafsafs = CodeDeaultCrawler.GetCodeDeaultContent();

            //3 csdn
            var aaa = CsdnCrawler.GetCsdnOtherContentAsync().Result;

            //4 51CTO
            var aa = CTO51Crawler.Get51CTOContentAsync().Result;

            //5
            var sfasfasf = ItHomeCrawler.GetItHomeNews();

            //6
            //var sfasfasfsaf = JuejinCrawler.GetJuejinNewsContent();

            //7
            var fasfssfffffdf = OsChinaCrawler.GetOsChinaBlogContent();

            //8
            var aaaaadgfdfaaa = SegmentfaulCrawler.GetSegmentfaulCrawlerContentAsync().Result;

            //2.
            var sfasfsaf = CodeDeaultCrawler.GetCodeDeaultContent();

            //公众号文章的爬虫
            var url = "https://mp.weixin.qq.com/s/n9SU3BgIYFJiUgk2ZD8y7A";
            ATest.jiexiHtmlAgilityPackContent(url);
        }
    }
}