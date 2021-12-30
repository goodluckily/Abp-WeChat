using Nancy.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WeChat.Common
{
    public class WebapiHelper
    {

        #region HttpClient

        /// <summary>
        /// Get请求指定的URL地址
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <returns></returns>
        public static string GetWebAPI(string url)
        {
            string result = "";
            string strOut = "";
            try
            {
                result = GetWebAPI(url, out strOut);
            }
            catch (Exception ex)
            {
                //LogHelper.Error("调用后台服务出现异常！", ex);
            }
            return result;
        }

        /// <summary>
        /// Get请求指定的URL地址
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="statusCode">Response返回的状态</param>
        /// <returns></returns>
        public static string GetWebAPI(string url, out string statusCode)
        {
            string result = string.Empty;
            statusCode = string.Empty;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = httpClient.GetAsync(url).Result;
                    statusCode = response.StatusCode.ToString();

                    if (response.IsSuccessStatusCode)
                    {
                        result = response.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        //LogHelper.Warn("调用后台服务返回失败：" + url + Environment.NewLine + SerializeObject(response));
                    }
                }
            }
            catch (Exception ex)
            {
                //LogHelper.Error("调用后台服务出现异常！", ex);
            }
            return result;
        }

        /// <summary>
        /// Get请求指定的URL地址
        /// </summary>
        /// <typeparam name="T">返回的json转换成指定实体对象</typeparam>
        /// <param name="url">URL地址</param>
        /// <returns></returns>
        public static T GetWebAPI<T>(string url) where T : class, new()
        {
            T result = default(T);
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = httpClient.GetAsync(url).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        Task<string> t = response.Content.ReadAsStringAsync();
                        string s = t.Result;
                        string jsonNamespace = DeserializeObject<T>(s).ToString();
                        result = DeserializeObject<T>(s);
                    }
                    else
                    {
                        //LogHelper.Warn("调用后台服务返回失败：" + url + Environment.NewLine + SerializeObject(response));
                    }
                }
            }
            catch (Exception ex)
            {
                //LogHelper.Error("调用后台服务出现异常！", ex);
            }

            return result;
        }

        /// <summary>
        /// Post请求指定的URL地址
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="postData">提交到Web的Json格式的数据：如:{"ErrCode":"FileErr"}</param>
        /// <returns></returns>
        public static string PostWebAPI(string url, string postData)
        {
            string result = "";
            HttpStatusCode strOut = HttpStatusCode.BadRequest;
            try
            {
                result = PostWebAPI(url, postData, out strOut);
            }
            catch (Exception ex)
            {
                //LogHelper.Error("调用后台服务出现异常！", ex);
            }
            return result;

        }

        /// <summary>
        /// Post请求指定的URL地址
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="postData">提交到Web的Json格式的数据：如:{"ErrCode":"FileErr"}</param>
        /// <param name="statusCode">Response返回的状态</param>
        /// <returns></returns>
        public static string PostWebAPI(string url, string postData, out HttpStatusCode httpStatusCode)
        {
            string result = string.Empty;
            httpStatusCode = HttpStatusCode.BadRequest;
            //设置Http的正文
            HttpContent httpContent = new StringContent(postData);
            //设置Http的内容标头
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            //设置Http的内容标头的字符
            httpContent.Headers.ContentType.CharSet = "utf-8";

            HttpClientHandler httpHandler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            try
            {
                //using (HttpClient httpClient = new HttpClient(httpHandler))
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.Timeout = new TimeSpan(0, 0, 5);
                    //异步Post
                    HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;
                    //输出Http响应状态码
                    httpStatusCode = response.StatusCode;
                    //确保Http响应成功
                    if (response.IsSuccessStatusCode)
                    {
                        //异步读取json
                        result = response.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        //LogHelper.Warn("调用后台服务返回失败：" + url + Environment.NewLine + SerializeObject(response));
                    }
                }
            }
            catch (Exception ex)
            {
                //LogHelper.Error("调用后台服务出现异常！", ex);
            }
            return result;
        }

        /// <summary>
        /// Post请求指定的URL地址
        /// </summary>
        /// <typeparam name="T">返回的json转换成指定实体对象</typeparam>
        /// <param name="url">URL地址</param>
        /// <param name="postData">提交到Web的Json格式的数据：如:{"ErrCode":"FileErr"}</param>
        /// <returns></returns>
        public static T PostWebAPI<T>(string url, string postData) where T : class, new()
        {
            T result = default(T);

            HttpContent httpContent = new StringContent(postData);
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            httpContent.Headers.ContentType.CharSet = "utf-8";

            HttpClientHandler httpHandler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            try
            {
                using (HttpClient httpClient = new HttpClient(httpHandler))
                {
                    HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        Task<string> t = response.Content.ReadAsStringAsync();
                        string s = t.Result;
                        //Newtonsoft.Json
                        string jsonNamespace = DeserializeObject<T>(s).ToString();
                        result = DeserializeObject<T>(s);
                    }
                    else
                    {
                        //LogHelper.Warn("调用后台服务返回失败：" + url + Environment.NewLine + SerializeObject(response));
                    }
                }
            }
            catch (Exception ex)
            {
                //LogHelper.Error("调用后台服务出现异常！", ex);
            }
            return result;
        }

        /// <summary>
        /// Put请求指定的URL地址
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="putData">提交到Web的Json格式的数据：如:{"ErrCode":"FileErr"}</param>
        /// <returns></returns>
        public static string PutWebAPI(string url, string putData)
        {
            string result = "";
            string strOut = "";
            result = PutWebAPI(url, putData, out strOut);
            return result;
        }

        /// <summary>
        /// Put请求指定的URL地址
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="putData">提交到Web的Json格式的数据：如:{"ErrCode":"FileErr"}</param>
        /// <param name="statusCode">Response返回的状态</param>
        /// <returns></returns>
        public static string PutWebAPI(string url, string putData, out string statusCode)
        {
            string result = statusCode = string.Empty;
            HttpContent httpContent = new StringContent(putData);
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            httpContent.Headers.ContentType.CharSet = "utf-8";
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = httpClient.PutAsync(url, httpContent).Result;
                    statusCode = response.StatusCode.ToString();
                    if (response.IsSuccessStatusCode)
                    {
                        result = response.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        //LogHelper.Warn("调用后台服务返回失败：" + url + Environment.NewLine + SerializeObject(response));
                    }
                }
            }
            catch (Exception ex)
            {
                //LogHelper.Error("调用后台服务出现异常！", ex);
            }
            return result;
        }

        /// <summary>
        /// Put请求指定的URL地址
        /// </summary>
        /// <typeparam name="T">返回的json转换成指定实体对象</typeparam>
        /// <param name="url">URL地址</param>
        /// <param name="putData">提交到Web的Json格式的数据：如:{"ErrCode":"FileErr"}</param>
        /// <returns></returns>
        public static T PutWebAPI<T>(string url, string putData) where T : class, new()
        {
            T result = default(T);
            HttpContent httpContent = new StringContent(putData);
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            httpContent.Headers.ContentType.CharSet = "utf-8";
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = httpClient.PutAsync(url, httpContent).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        Task<string> t = response.Content.ReadAsStringAsync();
                        string s = t.Result;
                        string jsonNamespace = DeserializeObject<T>(s).ToString();
                        result = DeserializeObject<T>(s);
                    }
                    else
                    {
                        //LogHelper.Warn("调用后台服务返回失败：" + url + Environment.NewLine + SerializeObject(response));
                    }
                }
            }
            catch (Exception ex)
            {
                //LogHelper.Error("调用后台服务出现异常！", ex);
            }
            return result;
        }

        /// <summary> 
        /// 对象转JSON 
        /// </summary> 
        /// <param name="obj">对象</param> 
        /// <returns>JSON格式的字符串</returns> 
        public static string SerializeObject(object obj)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                return jss.Serialize(obj);
            }
            catch (Exception ex)
            {
                throw new Exception("JSONHelper.SerializeObject(object obj): " + ex.Message);
            }
        }

        /// <summary>
        /// 将Json字符串转换为对像  
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string json)
        {
            JavaScriptSerializer Serializer = new JavaScriptSerializer();
            T objs = default(T);
            try
            {
                objs = Serializer.Deserialize<T>(json);
            }
            catch (Exception ex)
            {
                //LogHelper.Error("JSONHelper.DeserializeObject 转换对象失败。", ex);
                throw new Exception("JSONHelper.DeserializeObject<T>(string json): " + ex.Message);
            }
            return objs;

        }

        #endregion

        private static HttpResponseMessage HttpPost(string url, HttpContent httpContent)
        {
            HttpResponseMessage response = null;
            HttpClientHandler httpHandler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            try
            {
                //using (HttpClient httpClient = new HttpClient(httpHandler))
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.Timeout = new TimeSpan(0, 0, 5);
                    //异步Post
                    response = httpClient.PostAsync(url, httpContent).Result;
                }
            }
            catch (Exception ex)
            {
                //LogHelper.Error("调用后台服务出现异常！", ex);
            }
            return response;
        }

    }
}
