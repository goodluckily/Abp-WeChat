﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using WeChat.Domain.WeChat;
using WeChat.EntityFramewoekCore;

namespace WeChat.Host.EntityFrameworkCore
{
    public class WeChatSecondDbContext : AbpDbContext<WeChatSecondDbContext>
    {
        public WeChatSecondDbContext(DbContextOptions<WeChatSecondDbContext> options) : base(options)
        {

        }

        public DbSet<Token> tokenLapses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureWarehouse();
        }
    }
}
