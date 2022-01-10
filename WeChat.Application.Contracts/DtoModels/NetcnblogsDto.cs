using System;
using WeChat.Domain.Shared.Enum;

namespace WeChat.Application.Contracts.DtoModels
{
    public class NetcnblogsDto
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

        public bool? IsDeleted { get; set; } = false;


    }
}
