using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace WeChat.Http.WeiChatApi
{
    public class DynamicJson
    {
        public static dynamic Parse(string json)
        {
            return JsonConvert.DeserializeObject<dynamic>(json);
        }
    }
}
