using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using WeChat.Shared;

namespace WeChat.Domain
{
    public class Token : Entity<Guid>
    {
        public WeiChatEnum WeiChatType { get; set; }
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
