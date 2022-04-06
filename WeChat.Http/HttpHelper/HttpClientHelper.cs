using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WeChat.Http.HttpHelper
{
    public class HttpClientHelper
    {
        #region Get请求

        /// <summary>
        /// get请求返回的字符串 简洁
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string GetRequest(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(new Uri(url)).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        /// <summary>
        /// get请求返回的二进制
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public byte[] GetRequestByteArr(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(new Uri(url)).Result;
                return response.Content.ReadAsByteArrayAsync().Result;
            }
        }

        // Get请求 包含状态码
        public string GetResponse(string url, out string statusCode)
        {
            string result = string.Empty;
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = httpClient.GetAsync(url).Result;
                statusCode = response.StatusCode.ToString();
                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsStringAsync().Result;
                }
            }
            return result;
        }

        // 泛型：Get请求
        public T GetResponse<T>(string url) where T : class, new()
        {
            T result = default(T);
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = httpClient.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    Task<string> t = response.Content.ReadAsStringAsync();
                    string s = t.Result;
                    string json = JsonConvert.DeserializeObject(s).ToString();
                    result = JsonConvert.DeserializeObject<T>(json);
                }
            }
            return result;
        }

        #endregion

        #region Post请求
        /// <summary>
        /// post请求返回的字符串
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string PostResponse(string url, string jsonStr = "")
        {
            using (HttpClient httpClient = new HttpClient())
            {
                StringContent sc = new StringContent(jsonStr);
                sc.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
                var response = httpClient.PostAsync(new Uri(url), sc).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        /// <summary>
        /// post请求返回的字符串(Job请求Api时专用)
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string PostResponseForJobApi(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                httpClient.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("zh-CN"));
                StringContent sc = new StringContent("");
                sc.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = httpClient.PostAsync(new Uri(url), sc).Result;
                var data = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject(data).ToString();
            }
        }

        /// <summary>
        /// post请求返回的字符串
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string PostResponse(string url, Dictionary<string, object> contentDic = null)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                contentDic = contentDic ?? new Dictionary<string, object>();
                var contentStr = JsonConvert.SerializeObject(contentDic);
                StringContent sc = new StringContent(contentStr);
                sc.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
                var response = httpClient.PostAsync(new Uri(url), sc).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        // Post请求
        public string PostResponse(string url, string postData, out string statusCode)
        {
            string result = string.Empty;
            //设置Http的正文
            HttpContent httpContent = new StringContent(postData);
            //设置Http的内容标头
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            //设置Http的内容标头的字符
            httpContent.Headers.ContentType.CharSet = "utf-8";
            using (HttpClient httpClient = new HttpClient())
            {
                //异步Post
                HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;
                //输出Http响应状态码
                statusCode = response.StatusCode.ToString();
                //确保Http响应成功
                if (response.IsSuccessStatusCode)
                {
                    //异步读取json
                    result = response.Content.ReadAsStringAsync().Result;
                }
            }
            return result;
        }


        public string PostResponse(string url, MultipartFormDataContent content)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
                var response = httpClient.PostAsync(new Uri(url), content).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }


        // 泛型：Post请求
        public T PostResponse<T>(string url, string postData) where T : class, new()
        {
            T result = default(T);

            HttpContent httpContent = new StringContent(postData);
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            httpContent.Headers.ContentType.CharSet = "utf-8";
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    Task<string> t = response.Content.ReadAsStringAsync();
                    string s = t.Result;
                    //Newtonsoft.Json
                    string json = JsonConvert.DeserializeObject(s).ToString();
                    result = JsonConvert.DeserializeObject<T>(json);
                }
            }
            return result;
        }




        #endregion

        #region Put请求

        // Put请求
        public string PutResponse(string url, string putData, out string statusCode)
        {
            string result = string.Empty;
            HttpContent httpContent = new StringContent(putData);
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            httpContent.Headers.ContentType.CharSet = "utf-8";
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = httpClient.PutAsync(url, httpContent).Result;
                statusCode = response.StatusCode.ToString();
                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsStringAsync().Result;
                }
            }
            return result;
        }

        // 泛型：Put请求
        public T PutResponse<T>(string url, string putData) where T : class, new()
        {
            T result = default(T);
            HttpContent httpContent = new StringContent(putData);
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            httpContent.Headers.ContentType.CharSet = "utf-8";
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = httpClient.PutAsync(url, httpContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    Task<string> t = response.Content.ReadAsStringAsync();
                    string s = t.Result;
                    string json = JsonConvert.DeserializeObject(s).ToString();
                    result = JsonConvert.DeserializeObject<T>(json);
                }
            }
            return result;
        }
        #endregion
    }
}
