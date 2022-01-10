using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChat.Application.Services;

namespace WeChat.ApplicationTests
{
    [TestClass()]
    public class BlogsTests
    {
        [TestMethod()]
        public void GetCnblogsContentTest()
        {
            var blog = new Blogs();
            blog.GetCnblogsContent();
        }
    }
}
