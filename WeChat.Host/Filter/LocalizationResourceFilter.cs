using System;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Volo.Abp.Localization;

namespace WeChat.Host.Filter
{
    public class LocalizationResourceFilter : Attribute, IResourceFilter
    {
        #region old
        //private readonly IOptions<RequestLocalizationOptions> _options;

        //public LocalizationFilter(IOptions<RequestLocalizationOptions> options)
        //{
        //    _options = options;
        //}

        //public void OnResourceExecuted(ResourceExecutedContext context)
        //{
        //}

        //public void OnResourceExecuting(ResourceExecutingContext context)
        //{
        //    var culture = _options.Value.DefaultRequestCulture.Culture;
        //    CultureInfo.CurrentCulture = culture;
        //    CultureInfo.CurrentUICulture = culture;
        //} 
        #endregion

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            //后
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            //前
            var lang = context.HttpContext.Request.Headers["Accept-Language"].ToString();
            switch (lang)
            {
                case "en":
                    CultureInfo.CurrentCulture = new CultureInfo("en");//英文
                    CultureInfo.CurrentUICulture = new CultureInfo("en");
                    break;
                case "zh-Hans":
                    CultureInfo.CurrentCulture = new CultureInfo("zh-Hans");//简体中文
                    CultureInfo.CurrentUICulture = new CultureInfo("zh-Hans");
                    break;
                case "zh-Hant":
                    CultureInfo.CurrentCulture = new CultureInfo("zh-Hant");//繁体中文-台湾
                    CultureInfo.CurrentUICulture = new CultureInfo("zh-Hant");
                    break;
                default:
                    goto case "zh-Hans";
            }
        }
    }
}
