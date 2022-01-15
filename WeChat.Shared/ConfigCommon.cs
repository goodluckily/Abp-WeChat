using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WeChat.Domain.Shared
{
    public class ConfigCommon
    {
        public static IConfiguration Configuration { get; set; }
        static ConfigCommon()
        {
            Configuration = new ConfigurationBuilder()
                .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
                .Build();
        }

        public static T GetConfig<T>(string key)
        {
            return Configuration.GetSection(key).Get<T>();
        }
    }
}
