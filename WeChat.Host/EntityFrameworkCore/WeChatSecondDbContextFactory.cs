using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using WeChat.EntityFramewoekCore;
using Volo.Abp.Data;
using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using Volo.Abp.EntityFrameworkCore.MySQL;
using WeChat.Domain.Shared.Setting;

namespace WeChat.Host.EntityFrameworkCore
{
    public class WeChatSecondDbContextFactory : IDesignTimeDbContextFactory<WeChatSecondDbContext>
    {
        public WeChatSecondDbContext CreateDbContext(string[] args)
        {
            
            var connName = ConnectionStringNameAttribute.GetConnStringName<WeChatSecondDbContext>();

            //MySql
            //var builder = new DbContextOptionsBuilder<WeChatSecondDbContext>()
            //    .UseMySql(WeChatAppSetting.DBConnectionStr, new MySqlServerVersion(new Version(8, 0, 27)));

            //SqlServer
            var builder = new DbContextOptionsBuilder<WeChatSecondDbContext>()
                .UseSqlServer(WeChatAppSetting.DBConnectionStr);

            return new WeChatSecondDbContext(builder.Options);
        }

        
    }
}
