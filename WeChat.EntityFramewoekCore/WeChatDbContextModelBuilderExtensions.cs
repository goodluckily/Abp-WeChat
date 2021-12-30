using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;
using WeChat.Domain.WeChat;

namespace WeChat.EntityFramewoekCore
{
    public static class WeChatDbContextModelBuilderExtensions
    {
        public static void ConfigureWarehouse(this ModelBuilder builder)
        {
            builder.Entity<Token>(b =>
            {
                b.ToTable(nameof(Token));
                // 不执行时，实体从基类继承的字段，可以会缺少描述和一些配置信息
                b.ConfigureByConvention();

                b.Property(f => f.Access_Token).HasMaxLength(500).HasComment("Token");
                b.Property(f => f.Expires_In).HasComment("多少秒后失效");
                b.Property(f => f.OperationTime).HasComment("操作时间");
            });
        }
    }
}
