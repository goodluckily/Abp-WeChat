using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeChat.Shared
{
    public static class ImageCommon
    {
        public static async Task<(string imgBase64, string sufFixName,string downLoadImgName)> DownloadImageAsBase64(string imageUrl, HttpClient httpClient = null)
        {
            if (httpClient is null)
            {
                httpClient = new HttpClient();
            }
            // 下载图片
            byte[] imageBytes = await httpClient.GetByteArrayAsync(imageUrl);

            // 将字节数组转换为 Base64 编码的字符串
            string base64String = Convert.ToBase64String(imageBytes);
            var sufFixName = GetUrlImgSuffix(imageUrl);
            var imgBase64 = $"data:image/{sufFixName};base64," + base64String;
            var downLoadImgName = Path.GetFileName(imageUrl)?.Replace(".", "") + "." + sufFixName;
            return (imgBase64, sufFixName, downLoadImgName);

        }

        private static string GetUrlImgSuffix(string imageUrl)
        {
            // 使用 Uri 类来解析 URL
            Uri uri = new Uri(imageUrl);
            // 使用 Path 类来获取文件的扩展名
            string extension = Path.GetExtension(uri.LocalPath)?.Replace(".", "")?.Replace("!1", "");
            return extension;
        }
    }
}
