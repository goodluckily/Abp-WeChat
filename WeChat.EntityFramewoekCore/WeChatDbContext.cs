using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Guids;
using WeChat.Domain;
using WeChat.Domain.Shared.Setting;
using WeChat.Domain.WeChat;

namespace WeChat.EntityFramewoekCore
{
    [ConnectionStringName("WeChat")]
    public class WeChatDbContext : AbpDbContext<WeChatDbContext>
    {

        public WeChatDbContext(DbContextOptions<WeChatDbContext> options) : base(options)
        {
        }

        public DbSet<Token> tokenLapses { get; set; }
        public DbSet<Log> logs { get; set; }

        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserAndRoleMap> UserAndRoleMap { get; set; }

        public DbSet<Netcnblogs> Netcnblogs { get; set; }
        public DbSet<JueJinblogs> JueJinblogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ConfigureWarehouse(GuidGenerator);
        }
    }
}
