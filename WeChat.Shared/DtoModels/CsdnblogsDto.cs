﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WeChat.Shared.Enums;

namespace WeChat.Shared
{
    public class CsdnblogsDto: BlogsBaseDto
    {
        public string? Title { get; set; }
        public string? Img { get; set; }
        public string? SubContent { get; set; }
        public string? ContentUrl { get; set; }
        public string? Author { get; set; }
        public string? AuthorManUrl { get; set; }
        public string? CreatedAt { get; set; }

        public string? ProductType { get; set; }

        public int? DiggNum { get; set; }//点赞数
        public int? CommentNum { get; set; }
        public int? ReadNum { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AnalyzingEnum? AnalyzingType { get; set; }
    }
}
