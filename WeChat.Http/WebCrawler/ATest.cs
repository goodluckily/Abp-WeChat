using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;
using WeChat.Shared;

namespace WeChat.Http.WebCrawler
{
    public class ATest
    {
        public static async Task jiexiHttpClientContent(string url)
        {
            //url = "https://tmsearch.uspto.gov/bin/gate.exe?f=login&p_lang=english&p_d=trmk";

            try
            {
                StringBuilder sb_cookie = new StringBuilder();
                CookieContainer cookieContainer = new CookieContainer();
                var uri = new Uri(url);
                var handler = new HttpClientHandler() { UseCookies = true };
                handler.CookieContainer = cookieContainer;
                HttpClient httpClient = new HttpClient(handler);
                var html = await httpClient.GetStringAsync(url);
                var web = new HtmlWeb();
                //从url中加载
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);
                List<Cookie> cookies = cookieContainer.GetCookies(uri).Cast<Cookie>().ToList();


                var node = doc.DocumentNode.SelectSingleNode("//font/font/a");

                //获得title标签节点，其子标签下的所有节点也在其中

                //美国专利商标局
                var usQueryUrl = "https://tmsearch.uspto.gov" + node?.Attributes["href"]?.Value;

                var state = usQueryUrl.Split(new[] { "state=" }, StringSplitOptions.RemoveEmptyEntries);

                var postUrl = "https://tmsearch.uspto.gov/bin/showfield";

                string boundary = DateTime.Now.Ticks.ToString("X");
                var formData = new MultipartFormDataContent(boundary);

                formData.Add(new StringContent("toc"), "f");
                formData.Add(new StringContent(state[1]), "state");
                formData.Add(new StringContent("search"), "p_search");
                formData.Add(new StringContent(""), "p_s_All");
                formData.Add(new StringContent("parigo"), "p_s_ALL");
                formData.Add(new StringContent("search"), "a_default");
                formData.Add(new StringContent("Submit"), "a_search");

                var adfa1sdf = await httpClient.PostAsync(url, formData);

                var asdfas = await adfa1sdf.Content.ReadAsStringAsync();

                var adfasdf = "";

            }
            catch (Exception ex)
            {
                var e = "";
            }
        }

        public static void jiexiHtmlAgilityPackContent(string url)
        {

            ////从url中加载
            //HtmlDocument doc = web.Load(url);
            //var aa = doc.ToString();

            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(url).Result.Replace("data-src", "src");

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            //foreach (var script in doc.DocumentNode.Descendants("script").ToList())
            //    script.ParentNode.RemoveChild(script, false);

            //foreach (var style in doc.DocumentNode.Descendants("style").ToList())
            //    style.ParentNode.RemoveChild(style, false);


            //foreach (var link in doc.DocumentNode.Descendants("link").ToList())
            //    link.ParentNode.RemoveChild(link, false);


            var html111 = doc.DocumentNode.OuterHtml;

        }
    }
}
