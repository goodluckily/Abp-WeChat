using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Guids;
using Volo.Abp.Users;
using WeChat.Domain.WeChat;

namespace WeChat.EntityFramewoekCore
{
    public static class WeChatDbContextModelBuilderExtensions
    {
        public static void ConfigureWarehouse(this ModelBuilder builder, IGuidGenerator _guidGenerator)
        {

            #region 示例

            ////简单的 一对多
            //modelBuilder.Entity<School>()
            //.HasMany(p => p.Students)
            //.WithOne(p => p.School)
            //.HasForeignKey(p => p.SId);


            ////组合外键
            //modelBuilder.Entity<Car>().HasKey(x => new { x.State, x.LicensePlate }); //依据状态 车牌 组合
            //modelBuilder.Entity<RecordOfSale>().HasOne(x => x.Car).WithMany(x => x.SaleHistory)
            //    .HasForeignKey(s => new { s.CarState, s.CarLicensePlate }); //绑定 依据状态 车牌 组合

            ////1.也就是 主键索引 是聚集的
            ////2.这种组合索引是非聚集的

            ////1.指定字段为 外键字段 [ForeignKey("外键字段名称")]

            ////2.影子外键
            //modelBuilder.Entity<Blog>().Property<int>("BlogForeignKey");


            //modelBuilder.Entity<User>().HasKey(x => x.Id);
            //modelBuilder.Entity<Role>().HasKey(x => x.Id);

            //modelBuilder.Entity<Post>().HasKey(x=>x.PostId);
            //modelBuilder.Entity<Tag>().HasKey(x => x.TagId);

            //第三方表的 多<==>多 间接多对多关系

            //第一种
            //modelBuilder.Entity<UserAndRoleMap>().HasKey(t => new { t.UserId, t.RoleId });
            //modelBuilder.Entity<UserAndRoleMap>()
            //    .HasOne(pt => pt.User)
            //    .WithMany(p => p.userAndRoleMaps)
            //    .HasForeignKey(pt => pt.UserId);
            //modelBuilder.Entity<UserAndRoleMap>()
            //    .HasOne(pt => pt.Role)
            //    .WithMany(t => t.userAndRoleMaps)
            //    .HasForeignKey(pt => pt.RoleId);

            // modelBuilder.Entity<Post>()
            //.HasMany(p => p.Tags)
            //.WithMany(p => p.Posts)
            //.UsingEntity<PostTag>(
            //    j => j
            //        .HasOne(pt => pt.Tag)
            //        .WithMany(t => t.PostTags)
            //        .HasForeignKey(pt => pt.TagId),
            //    j => j
            //        .HasOne(pt => pt.Post)
            //        .WithMany(p => p.PostTags)
            //        .HasForeignKey(pt => pt.PostId),
            //    j =>
            //    {
            //        //j.Property(pt => pt.PublicationDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            //        j.HasKey(t => new { t.PostId, t.TagId });
            //    });

            ////多<==>多
            ////0.
            //builder.Entity<UserAndRoleMap>(b =>
            //{
            //    b.ToTable(nameof(UserAndRoleMap));
            //    b.HasKey(t => new { t.UserId, t.RoleId });
            //});

            ////1.
            //builder.Entity<UserAndRoleMap>(b =>
            //{
            //    b.HasKey(x => x.UserId);
            //    //2
            //    builder.Entity<UserAndRoleMap>(b =>
            //    {
            //        b.HasOne(x => x.Role).WithMany(x => x.userAndRoleMap);
            //        b.HasKey(x => x.RoleId);
            //    });
            //});


            #endregion

            builder.Entity<Token>(b =>
            {
                b.ToTable(nameof(Token));
                // 不执行时，实体从基类继承的字段，可以会缺少描述和一些配置信息
                b.ConfigureByConvention();

                b.Property(f => f.Access_Token).HasMaxLength(500).HasComment("Token");
                b.Property(f => f.Expires_In).HasComment("多少秒后失效");
                b.Property(f => f.OperationTime).HasComment("操作时间");
            });

            builder.Entity<Log>(b =>
            {
                b.ToTable(nameof(Log));
                b.ConfigureByConvention();

                //HasColumnName 用来设置要映射的列名
                //HasComment    表或列的注释
                b.Property(f => f.UserId).HasComment("操作人");
                b.Property(f => f.LogType).HasMaxLength(50).HasComment("日志类型");
                b.Property(f => f.LogLevel).HasMaxLength(50).HasComment("日志等级");
            });

            #region 用户相关的 种子数据
            var userInfo = new UserInfo(_guidGenerator.Create())
            {
                LoginName = "admin",
                PassWrod = "123456",
                NickName = "管理员",
                IsActive = true,
                IsDel = true,
                CreateTime = DateTime.Now,
            };
            var role = new Role(_guidGenerator.Create())// 这里如何切换成  IGuidGenerator   _guidGenerator.Create() ???
            {
                Name = "管理者",
                Description = "最高权限管理者",
                CreateUserId = userInfo.Id,
                CreateTime = DateTime.Now,
                IsActive = true,
                IsDel = false
            };
            var userAndroleMap = new UserAndRoleMap()
            {
                UserId = userInfo.Id,
                RoleId = role.Id,
                CreateUserId = userInfo.Id,
                CreateTime = DateTime.Now
            };
            #endregion

            builder.Entity<UserInfo>(b =>
            {
                b.ToTable(nameof(UserInfo));
                b.Property(f => f.LoginName).HasMaxLength(50).IsRequired();
                b.Property(f => f.PassWrod).HasMaxLength(150).IsRequired();
                b.Property(f => f.NickName).HasMaxLength(150);
                b.Property(f => f.Email).HasMaxLength(50);
                b.Property(f => f.Phone).HasMaxLength(50);
                b.Property(f => f.AvatarUrl).HasMaxLength(150).HasComment("头像Url地址");

                //种子数据
                b.HasData(userInfo);
                b.ConfigureByConvention();
            });

            builder.Entity<Role>(b =>
            {
                b.ToTable(nameof(Role));
                b.Property(f => f.Name).HasMaxLength(50);
                b.Property(f => f.Description).HasMaxLength(150).HasComment("说明");

                b.HasData(role);
                b.ConfigureByConvention();
            });

            builder.Entity<UserAndRoleMap>(b => { b.HasData(userAndroleMap); b.ConfigureByConvention(); });

            //多对多关系 指定
            builder.Entity<UserInfo>().HasMany(x => x.Roles).WithMany(x => x.UserInfos)
                .UsingEntity<UserAndRoleMap>(
                    j => j.HasOne(pt => pt.Role).WithMany(t => t.UserAndRoleMaps).HasForeignKey(pt => pt.RoleId),
                    j => j.HasOne(pt => pt.UserInfo).WithMany(a => a.UserAndRoleMaps).HasForeignKey(p => p.UserId),
                    j =>
                    {
                        j.HasKey(x => new { x.UserId, x.RoleId });
                    }
                );

            //博客园
            builder.Entity<Netcnblogs>(b =>
            {
                b.ToTable(nameof(Netcnblogs));
                b.Property(f => f.Title).HasComment("标题");
                b.Property(f => f.Img).HasComment("主图");
                b.Property(f => f.SubContent).HasComment("文章简介");
                b.Property(f => f.ContentUrl).HasComment("文章完整地址Url");
                b.Property(f => f.Author).HasMaxLength(520).HasComment("作者");
                b.Property(f => f.AuthorManUrl).HasComment("作者主页地址");
                b.Property(f => f.ReleaseTime).HasComment("发布时间");

                b.Property(f => f.CommentNum).HasComment("评论数");
                b.Property(f => f.RecommendNum).HasComment("推荐数");
                b.Property(f => f.ReadNum).HasComment("阅读数");

                b.ConfigureByConvention();
            });
            //掘金
            builder.Entity<JueJinblogs>(b =>
            {
                b.ToTable(nameof(JueJinblogs));
                b.Property(f => f.Title).HasComment("标题");
                b.Property(f => f.Img).HasComment("主图");
                b.Property(f => f.SubContent).HasComment("文章简介");
                b.Property(f => f.ContentUrl).HasComment("文章完整地址Url");
                b.Property(f => f.Author).HasMaxLength(520).HasComment("作者");
                b.Property(f => f.AuthorManUrl).HasComment("作者主页地址");
                b.Property(f => f.ReleaseTime).HasComment("发布时间");
                b.Property(f => f.HotIndex).HasComment("热门系数");
                b.Property(f => f.ReadNum).HasComment("阅读数");

                b.Property(f => f.CommentNum).HasComment("评论数");
                b.Property(f => f.GiveLikeNum).HasComment("点赞数");

                b.ConfigureByConvention();
            });
        }
    }
}
