using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using WeChat.Domain.Shared.Enum;

namespace WeChat.Domain.WeChat
{
    public class Netcnblogs : BaseEntity
    {
        public string? Title { get; set; }
        public string? Img { get; set; }
        public string? Content { get; set; }
        public int? RecommendNum { get; set; }
        public string? Author { get; set; }
        public string? AuthorManUrl { get; set; }
        public DateTime? ReleaseTime { get; set; }
        public int? CommentNum { get; set; }
        public int? ReadNum { get; set; }
        public AnalyzingEnum? AnalyzingType { get; set; }
    }
}
