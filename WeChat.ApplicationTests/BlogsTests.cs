using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChat.Application.Services;
using WeChat.Common.Analyzing;

namespace WeChat.ApplicationTests
{
    [TestClass()]
    public class BlogsTests
    {
        [TestMethod()]
        public void GetCnblogsContentTest()
        {
            //1
            //Blogs.GetNetCnblogsContent();

            //2
            //Blogs.GetToDayNewsCnblogsContent();

            //3
            //new ATest().jiexiContent().Wait();

            //4
            //Juejin.GetJuejinNewsContent();

            //4
            Juejin.GetJuejinNewsContentForApi();
        }
    }
}
