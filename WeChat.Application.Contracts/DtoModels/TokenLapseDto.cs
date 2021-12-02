using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChat.Application.Contracts.DtoModels
{
    public class TokenLapseDto
    {
        [NotNull, MaxLength(500)]
        public string Access_Token { get; set; }
        public int Expires_In { get; set; }
        public DateTime OperationTime { get; set; }
    }
}
