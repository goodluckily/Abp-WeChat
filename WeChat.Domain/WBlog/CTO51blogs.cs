using System;
using WeChat.Shared;
using WeChat.Shared.Enums;

namespace WeChat.Domain
{
    public class CTO51blogs : BaseJobEntity
    {
        public string? Title { get; set; }
        public string? SubContent { get; set; }
        public string? ContentUrl { get; set; }
        public string? Img { get; set; }
        public string? KeyWords { get; set; }
        public string? SourceType { get; set; }
        public DateTime? ReleaseTime { get; set; }
        public AnalyzingEnum? AnalyzingType { get; set; }
    }
}
