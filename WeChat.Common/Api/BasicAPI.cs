using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WeChat.Common
{
    // <summary>
    /// 对应微信API的 "基础支持"
    /// </summary>
    public class BasicAPI
    {
        /// <summary>
        /// 检查签名是否正确:
        /// http://mp.weixin.qq.com/wiki/index.php?title=%E6%8E%A5%E5%85%A5%E6%8C%87%E5%8D%97
        /// <summary>
        /// <param name="signature"></param>
        /// <param name="timestamp"></param>
        /// <param name="nonce"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static bool Check(string signature, string timestamp, string nonce, string token)
        {
            return signature == GetSignature(timestamp, nonce, token);
        }

        /// <summary>
        /// 返回正确的签名 https://developers.weixin.qq.com/doc/offiaccount/Basic_Information/Access_Overview.html
        /// </summary>
        /// <param name="timestamp"></param>
        /// <param name="nonce"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string GetSignature(string timestamp, string nonce, string token)
        {
            var arr = new[] { token, timestamp, nonce }.OrderBy(z => z).ToArray();
            var arrString = string.Join("", arr);
            //var enText = FormsAuthentication.HashPasswordForStoringInConfigFile(arrString, "SHA1");//使用System.Web.Security程序集
            var sha1 = SHA1.Create();
            var sha1Arr = sha1.ComputeHash(Encoding.UTF8.GetBytes(arrString));
            StringBuilder enText = new StringBuilder();
            foreach (var b in sha1Arr)
            {
                enText.AppendFormat("{0:x2}", b);
            }
            return enText.ToString();
        }

       

        /// <summary>
        /// 获取AccessToken
        /// http://mp.weixin.qq.com/wiki/index.php?title=%E8%8E%B7%E5%8F%96access_token
        /// </summary>
        /// <param name="grant_type"></param>
        /// <param name="appid"></param>
        /// <param name="secrect"></param>
        /// <returns>access_toke</returns>
        public static dynamic GetAccessToken(string appid, string secrect)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type={0}&appid={1}&secret={2}", "client_credential", appid, secrect);
            var client = new HttpClient();
            var result = client.GetAsync(url).Result;
            if (!result.IsSuccessStatusCode) return string.Empty;
            var token = DynamicJson.Parse(result.Content.ReadAsStringAsync().Result);
            return token;
        }
        /// <summary>
        /// 获取微信服务器IP地址
        ///http://mp.weixin.qq.com/wiki/0/2ad4b6bfd29f30f71d39616c2a0fcedc.html
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns>{"ip_list":["127.0.0.1","127.0.0.1"]}</returns>
        public static dynamic GetCallbackIP(string access_token)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/getcallbackip?access_token={0}", access_token);
            var client = new HttpClient();
            var result = client.GetAsync(url).Result;
            if (!result.IsSuccessStatusCode) return string.Empty;
            return DynamicJson.Parse(result.Content.ReadAsStringAsync().Result);
        }


        //创建菜单
        public static string CreateMenu(string token, string menu_txt)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}", token);
            Stream outstream = null;
            Stream instream = null;
            StreamReader sr = null;
            HttpWebResponse response = null;
            HttpWebRequest request = null;
            Encoding encoding = Encoding.UTF8;
            byte[] data = encoding.GetBytes(menu_txt);

            request = WebRequest.Create(url) as HttpWebRequest;//创建请求

            //写入数据
            CookieContainer cookieContainer = new CookieContainer();
            request.CookieContainer = cookieContainer;
            request.AllowAutoRedirect = true;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            outstream = request.GetRequestStream();
            outstream.Write(data, 0, data.Length);
            outstream.Close();

            //读取返回结果
            response = request.GetResponse() as HttpWebResponse;
            instream = response.GetResponseStream();
            sr = new StreamReader(instream, encoding);
            string content = sr.ReadToEnd();

            //读取操作码
            JObject my_toke_obj = (JObject)JsonConvert.DeserializeObject(content);
            string error_code = my_toke_obj["errcode"].ToString();

            return error_code;
        }

        //删除菜单
        public static dynamic DeleteMenu(string token)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/delete?access_token={0}", token);
            var client = new HttpClient();
            var result = client.GetAsync(url).Result;
            if (!result.IsSuccessStatusCode) return string.Empty;
            return DynamicJson.Parse(result.Content.ReadAsStringAsync().Result);
        }



        //创建草稿
        public static dynamic CreateDaft(string token,object content)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/draft/add?access_token={0}", token);
            var client = new HttpClient();
            var result = client.PostAsync(url, new StringContent(content.ToString())).Result;
            return DynamicJson.Parse(result.Content.ReadAsStringAsync().Result);
        }


        //Post 请求
        public static dynamic PostString(string requestUrl, string token, object content)
        {
            var url = string.Format(requestUrl, token);
            var client = new HttpClient();
            var result = client.PostAsync(url, new StringContent(content.ToString())).Result;
            return DynamicJson.Parse(result.Content.ReadAsStringAsync().Result);
        }


        public static async Task<string> UploadStringWithToken(string url, string accessToken, string fieldName, string fileName, Stream fileStream)
        {
            var content = BuildUploadContent(fieldName, fileName, fileStream);

            url = string.Format(url, accessToken);
            var http = new HttpClient();
            try
            {
                var response = await http.PostAsync(url, content).ConfigureAwait(false);
                return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


       

        private static MultipartFormDataContent BuildUploadContent(string fieldName, string fileName, Stream fileStream)
        {
            var boundary = Guid.NewGuid().ToString("n");
            var content = new MultipartFormDataContent(boundary);

            if (!string.IsNullOrWhiteSpace(fieldName))
                fieldName = '"' + fieldName + '"';

            if (!string.IsNullOrWhiteSpace(fileName))
                fileName = '"' + fileName + '"';

            content.Add(new StreamContent(fileStream), fieldName, fileName);

            //微信服务器不接受引号括起来的 boundary..
            content.Headers.Remove("Content-Type");
            content.Headers.TryAddWithoutValidation("Content-Type", "multipart/form-data; boundary=" + boundary);
            return content;
        }
    }
}
