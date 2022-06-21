using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;

namespace WeChat.Shared
{
    public class TemplateHtmlCommon
    {
        private IRazorViewEngine _razorViewEngine;
        private IServiceProvider _serviceProvider;
        private ITempDataProvider _tempDataProvider;

        public TemplateHtmlCommon(
            IRazorViewEngine engine,
            IServiceProvider serviceProvider,
            ITempDataProvider tempDataProvider)
        {
            this._razorViewEngine = engine;
            this._serviceProvider = serviceProvider;
            this._tempDataProvider = tempDataProvider;
        }

        /// <summary>
        /// 提供模版和参数,把Razor转html的方法
        /// </summary>
        /// <param name="templatePath">控制模版视图的路径 (Home/TemplateIndex)</param>
        /// <param name="modelData">Model 绑定数据</param>
        /// <param name="viewDataDic">传统 ViewData["key"]="value"; 使用</param>
        /// <returns>返回解析后的 Html字符串</returns>
        public async Task<string> TemplateRazorToHtml<T>(string templatePath, List<T> modelData = null, Dictionary<string, object?> viewDataDic = null) where T : class
        {
            var httpContext = new DefaultHttpContext() { RequestServices = _serviceProvider };
            var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());

            using (StringWriter sw = new StringWriter())
            {
                //ViewEngines.Engines.FindView查找View。
                var viewResult = _razorViewEngine.FindView(actionContext, templatePath, false);

                if (viewResult.View == null)
                {
                    return string.Empty;
                }

                var metadataProvider = new EmptyModelMetadataProvider();
                var msDictionary = new ModelStateDictionary();
                var viewDataDictionary = new ViewDataDictionary(metadataProvider, msDictionary);

                //参数 值
                if (modelData != null)
                    viewDataDictionary.Model = modelData;

                //参数 值
                if (viewDataDic != null)
                {
                    foreach (var item in viewDataDic)
                    {
                        viewDataDictionary.Add(item.Key, item.Value);
                    }
                }

                var tempDictionary = new TempDataDictionary(actionContext.HttpContext, _tempDataProvider);
                var viewContext = new ViewContext(
                    actionContext,
                    viewResult.View,
                    viewDataDictionary,
                    tempDictionary,
                    sw,
                    new HtmlHelperOptions()
                );
                await viewResult.View.RenderAsync(viewContext);
                var html = sw.ToString();
                return html;
            }
        }
    }
}
