using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChat.Domain.Shared;

namespace WeChat.Domain
{
    public class JueJinblogs : BaseEntity
    {
        public string? Title { get; set; }
        public string? Img { get; set; }
        public string? SubContent { get; set; }
        public string? ContentUrl { get; set; }
        public string? Author { get; set; }
        public string? AuthorManUrl { get; set; }
        public DateTime? ReleaseTime { get; set; }
        public int? CommentNum { get; set; }
        public int? GiveLikeNum { get; set; }
        public int? ReadNum { get; set; }
        public double? HotIndex { get; set; }
        public AnalyzingEnum? AnalyzingType { get; set; }
    }
}
