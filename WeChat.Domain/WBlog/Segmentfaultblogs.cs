using System;
using WeChat.Shared;

namespace WeChat.Domain
{
    public class Segmentfaultblogs : BaseJobEntity
    {
        public string? Title { get; set; }
        public string? ContentUrl { get; set; }
        public string? Author { get; set; }
        public string? Img { get; set; }
        public string? AuthorManUrl { get; set; }
        public DateTime? ReleaseTime { get; set; }

        public int? DiggNum { get; set; }//点赞数
        public int? CommentNum { get; set; }
        public AnalyzingEnum? AnalyzingType { get; set; }
    }
}
