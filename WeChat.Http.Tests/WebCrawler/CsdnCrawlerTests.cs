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
            //var aaa = CsdnCrawler.GetCsdnOtherContentAsync().Result;

            //var aaaaaaaa = SegmentfaulCrawler.GetSegmentfaulCrawlerContentAsync().Result;

            //ItHomeCrwaler.GetItHomeNews();
            //ItHomeCrwaler.GetItHomeMicrosoftNews();

            CodeDeaultCrawler.GetCodeDeaultContent();
        }
    }
}