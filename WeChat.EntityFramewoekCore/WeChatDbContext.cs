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
    public class WeChatDbContext : AbpDbContext<WeChatDbContext>, IWeChatDbContext
    {
        public WeChatDbContext(DbContextOptions<WeChatDbContext> options):base(options)
        {
        }

        public DbSet<Token> tokenLapses { get; set; }
        public DbSet<Log> logs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ConfigureWarehouse();
        }
    }
}
