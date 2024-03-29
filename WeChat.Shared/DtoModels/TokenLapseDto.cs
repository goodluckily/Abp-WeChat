﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChat.Shared
{
    /// <summary>
    /// token 转换DTO
    /// </summary>
    public class TokenLapseDto
    {
        public string Access_Token { get; set; }
        public int Expires_In { get; set; }
        public DateTime OperationTime { get; set; }
    }
}
