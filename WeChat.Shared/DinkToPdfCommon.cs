

using WkHtmlToPdfDotNet;

namespace WeChat.Shared
{
    public static class DinkToPdfCommon
    {
        //收费暂时不用
        public static void HtmlToPdf(string html)
        {
            //var bytes = Encoding.UTF8.GetBytes(html);
            //MemoryStream ms = new MemoryStream();
            //ms.Write(bytes, 0, bytes.Length);
            //ms.Position = 0;
            //var doc = new Document(ms, loadOptions: new LoadOptions { LoadFormat = LoadFormat.Html });
            //var aa = doc.Save("Output.pdf");
        }

        public static byte[] Convert(string htmlContent)
        {
            var converter = new SynchronizedConverter(new PdfTools());
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                },
                Objects = {
                    new ObjectSettings() {
                        PagesCount = true,
                        HtmlContent = htmlContent,
                        WebSettings = { DefaultEncoding = "utf-8" },
                        HeaderSettings = { FontSize = 9, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 }
                    }
                }
            };
            //var converter = new BasicConverter(new PdfTools());
            return converter.Convert(doc);
        }
    }
}
