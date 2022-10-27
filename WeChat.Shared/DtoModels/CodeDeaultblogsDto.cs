using System;
using WeChat.Shared.Enums;

namespace WeChat.Shared
{
    public class CodeDeaultblogsDto
    {
        public string? Title { get; set; }
        public string? ContentUrl { get; set; }
        public string? SubContent { get; set; }
        public string? Category { get; set; }
        public DateTime? ReleaseTime { get; set; }

        /// <summary>
        /// 阅读
        /// </summary>
        public int? ReadNum { get; set; }
        /// <summary>
        /// 评论
        /// </summary>
        public int? CommentNum { get; set; }

        /// <summary>
        /// 喜欢
        /// </summary>
        public int? LikeNum { get; set; }
        /// <summary>
        /// 收藏
        /// </summary>

        public int? CollectionNum { get; set; }

        public AnalyzingEnum? AnalyzingType { get; set; }
    }
}
