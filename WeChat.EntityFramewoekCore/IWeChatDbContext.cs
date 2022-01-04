using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using WeChat.Domain;
using WeChat.Domain.Shared.Setting;
using WeChat.Domain.WeChat;

namespace WeChat.EntityFramewoekCore
{
    [ConnectionStringName(WeChatAppSetting.ConnectionKey)]
    public interface IWeChatDbContext: IEfCoreDbContext
    {
        public DbSet<Token> tokenLapses { get; set; }
        public DbSet<Log> logs { get; set; }
    }
}
