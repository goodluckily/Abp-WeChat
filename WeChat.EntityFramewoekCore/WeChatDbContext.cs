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
    public class WeChatDbContext : AbpDbContext<WeChatDbContext>, IWeChatDbContext
    {
        public WeChatDbContext(DbContextOptions<WeChatDbContext> options):base(options)
        {

        }

        public DbSet<TokenLapse> tokenLapses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ConfigureWarehouse();
        }
    }
}
