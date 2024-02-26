using System;

namespace WeChat.Shared
{
    public class BlogsBaseDto 
    {
        public Guid Id { get; set; }
        public string SufixName { get; set; }
        public string DownLoadImgName { get; set; }
        /// <summary>
        /// 获取时间
        /// </summary>
        public string LoadContextTime { get; set; }
        public string? ImgBase64 { get; set; }

    }
}
