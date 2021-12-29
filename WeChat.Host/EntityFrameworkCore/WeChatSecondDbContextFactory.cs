using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using WeChat.EntityFramewoekCore;
using Volo.Abp.Data;
using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using Volo.Abp.EntityFrameworkCore.MySQL;

namespace WeChat.Host.EntityFrameworkCore
{
    public class WeChatSecondDbContextFactory : IDesignTimeDbContextFactory<WeChatSecondDbContext>
    {
        public WeChatSecondDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var connName = ConnectionStringNameAttribute.GetConnStringName<WeChatSecondDbContext>();
            Console.WriteLine(connName);

            //MySql
            //var builder = new DbContextOptionsBuilder<WeChatSecondDbContext>()
            //    .UseMySql(configuration.GetConnectionString("WeChat"), new MySqlServerVersion(new Version(8, 0, 27)));

            //SqlServer
            var builder = new DbContextOptionsBuilder<WeChatSecondDbContext>()
                .UseSqlServer(configuration.GetConnectionString("WeChat"));

            return new WeChatSecondDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
