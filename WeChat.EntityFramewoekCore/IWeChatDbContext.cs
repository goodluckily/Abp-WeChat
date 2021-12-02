using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using WeChat.Domain;
using WeChat.Domain.WeChat;

namespace WeChat.EntityFramewoekCore
{
    [ConnectionStringName(WeChatDbProperties.ConnectionStringName)]
    public interface IWeChatDbContext: IEfCoreDbContext
    {
        public DbSet<TokenLapse> tokenLapses { get; set; }
    }
}
