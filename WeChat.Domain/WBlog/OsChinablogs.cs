﻿using System;
using WeChat.Shared;
using WeChat.Shared.Enums;

namespace WeChat.Domain
{
    public class OsChinablogs : BaseJobEntity
    {
        public string? Title { get; set; }
        public string? Img { get; set; }
        public string? SubContent { get; set; }
        public string? ContentUrl { get; set; }
        public string? Author { get; set; }
        public string? AuthorManUrl { get; set; }
        public string? ReleaseTimeStr { get; set; }
        public int? CommentNum { get; set; }
        public int? ReadNum { get; set; }
        public int? LikeNum { get; set; }
        public AnalyzingEnum? AnalyzingType { get; set; }
    }
}
