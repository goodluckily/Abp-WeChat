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
        public async Task jiexiContent()
        {
            var url = "https://tmsearch.uspto.gov/bin/gate.exe?f=login&p_lang=english&p_d=trmk";

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

                //var dic = new Dictionary<String, String>();
                //dic.Add("f", "toc");
                //dic.Add("state", state[1]);
                //dic.Add("p_search", "search");
                //dic.Add("p_s_All", "");
                //dic.Add("p_s_ALL", "parigo");
                //dic.Add("a_default", "search");
                //dic.Add("a_search", "Submit");


                var adfa1sdf = await httpClient.PostAsync(url, formData);

                var asdfas = await adfa1sdf.Content.ReadAsStringAsync();

                var adfasdf = "";

            }
            catch (Exception ex)
            {
                var e = "";
            }
        }
    }
}
