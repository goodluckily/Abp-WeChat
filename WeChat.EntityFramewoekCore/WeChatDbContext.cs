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

namespace WeChat.EntityFramewoekCore
{
    [ConnectionStringName("WeChat")]
    public class WeChatDbContext : AbpDbContext<WeChatDbContext>
    {

        public WeChatDbContext(DbContextOptions<WeChatDbContext> options) : base(options)
        {
        }

        #region 暂时使用的是 自动注册
        //public DbSet<Token> tokenLapses { get; set; }
        //public DbSet<Log> logs { get; set; }

        //public DbSet<UserInfo> UserInfo { get; set; }
        //public DbSet<Role> Role { get; set; }
        //public DbSet<UserAndRoleMap> UserAndRoleMap { get; set; }

        //public DbSet<Cnblogs> Cnblogs { get; set; }
        //public DbSet<JueJinblogs> JueJinblogs { get; set; }
        //public DbSet<Csdnblogs> Csdnblogs { get; set; }
        //public DbSet<Segmentfaultblogs> Segmentfaultblogs { get; set; }
        //public DbSet<ItHomeblogs> ItHomeblogs { get; set; }
        //public DbSet<CodeDeaultblogs> CodeDeaultblogs { get; set; }
        //public DbSet<OsChinablogs> OsChinablogs { get; set; }
        //public DbSet<CTO51blogs> CTO51blogs { get; set; } 
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ConfigureWarehouse(GuidGenerator);
        }
    }
}
