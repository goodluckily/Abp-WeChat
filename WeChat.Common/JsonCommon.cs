using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WeChat.Common
{
    public class JsonCommon
    {
        public static string GetJsonStringSerializeObject(object ob)
        {
            string result = JsonConvert.SerializeObject(ob);
            return result;

        }
        /// <summary>
        /// 序列化对象返回json格式字符串 驼峰格式
        /// </summary>
        /// <param name="ob"></param>
        /// <returns></returns>
        public static string ObjectToJsonCamelCase(object ob)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            return JsonConvert.SerializeObject(ob, settings);

        }
        public static IEnumerable<T> GetJsonIEnumerableDeserialize<T>(string jsonString)
        {
            IEnumerable<T> result = JsonConvert.DeserializeObject<IEnumerable<T>>(jsonString);
            return result;
        }

        public static T GetJObjectDeserialize<T>(string jsonStr)
        {
            var resObj = JsonConvert.DeserializeObject<T>(jsonStr);
            return resObj;
        }
        public static string GetJTokenStringDeserialize(string obj, params object[] keys)
        {
            var jObject = (JObject)JsonConvert.DeserializeObject(obj);
            JToken token = jObject;

            foreach (var i in keys)  // 实现效果 token = jObject[keys1][keys2][keys3]......
            {
                token = token[i];
            }

            string result = token?.ToString();
            return result;

        }
        public static object GetJTokenStringDeserializeBeContains(string obj, string key, string source, string findkey)
        {
            object ob = null;
            var ajaxData = (JObject)JsonConvert.DeserializeObject(obj);

            JToken token = ajaxData[key]?.FirstOrDefault(x => source.Contains(x[findkey]?.ToString()));
            if (token != null)
            {
                ob = token["content"];
            }
            else
            {
                ob = ajaxData["data"]?.Select(x => $"\"{x["oid"].ToString()}\"");
            }

            return ob;

        }
        public static string GetJArrayStringDeserialize(string value, Dictionary<string, string> cookieDic)
        {
            //var cookieJson = (JArray)GetJsonIEnumerableDeserializeObject(value);
            var cookieJson = (JArray)JsonConvert.DeserializeObject(value);
            foreach (var json in cookieJson)
            {
                foreach (var dic in cookieDic)
                {
                    if (json["Name"].ToString().Equals(dic.Key))
                    {
                        json["Value"] = dic.Value;
                        break;
                    }
                }
            }
            string cookieStr = JsonConvert.SerializeObject(cookieJson);
            return cookieStr;
        }

        public static String GetSerializeObjectBySetting(object models, JsonSerializerSettings settings = null)
        {
            settings = settings ?? new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            return JsonConvert.SerializeObject(models, settings);
        }

        public static String GetSerializeObjectBySmall(object models)
        {
            return JsonConvert.SerializeObject(models, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }
    }
}
