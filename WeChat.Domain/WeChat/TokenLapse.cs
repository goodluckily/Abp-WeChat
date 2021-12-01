using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Volo.Abp.Domain.Entities.Auditing;

namespace WeChat.Domain.WeChat
{
    public class TokenLapse : FullAuditedAggregateRoot<Guid>
    {
        public string Access_Token { get; set; }
        public int Expires_In { get; set; }
        public DateTime OperationTime { get; set; }

        public TokenLapse()
        {

        }
        public TokenLapse([NotNull, MaxLength(500)] string access_Token, [NotNull, MaxLength(20)] int expires_In, DateTime operationTime)
        {
            Access_Token = access_Token;
            Expires_In = expires_In;
            OperationTime = operationTime;
        }


        internal void UpdateTokenLapse(string access_Token, int expires_In, DateTime operationTime)
        {
            Access_Token = access_Token;
            Expires_In = expires_In;
            OperationTime = operationTime;
        }
    }
}
