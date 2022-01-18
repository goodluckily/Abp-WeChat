using System;

namespace WeChat.Shared
{
    public class ItHomeblogsDto
    {
        public string? Title { get; set; }
        public string? ContentUrl { get; set; }
        public string? SubContent { get; set; }
        public string? Tags { get; set; }

        public string? TagsUrl { get; set; }
        public string? Img { get; set; }
        public DateTime? ReleaseTime { get; set; }
        public AnalyzingEnum? AnalyzingType { get; set; }
    }
}
