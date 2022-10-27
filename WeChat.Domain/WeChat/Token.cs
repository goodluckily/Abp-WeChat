using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using WeChat.Shared;
using WeChat.Shared.Enums;

namespace WeChat.Domain
{
    public class Token : Entity<Guid>
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public WeiChatEnum WeiChatType { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public TokenEnum TokenType { get; set; }
        public string? Access_Token { get; set; }
        public double? Expires_In { get; set; }
        public DateTime? OperationTime { get; set; }

        public Token()
        {

        }
        public Token([NotNull, MaxLength(500)] string access_Token, [NotNull, MaxLength(20)] double? expires_In, DateTime? operationTime)
        {
            Access_Token = access_Token;
            Expires_In = expires_In;
            OperationTime = operationTime;
        }


        internal void UpdateTokenLapse(string access_Token, double? expires_In, DateTime? operationTime)
        {
            Access_Token = access_Token;
            Expires_In = expires_In;
            OperationTime = operationTime;
        }
    }
}
