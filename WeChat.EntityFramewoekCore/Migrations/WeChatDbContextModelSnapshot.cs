﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Volo.Abp.EntityFrameworkCore;
using WeChat.EntityFramewoekCore;

namespace WeChat.EntityFramewoekCore.Migrations
{
    [DbContext(typeof(WeChatDbContext))]
    partial class WeChatDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("_Abp_DatabaseProvider", EfCoreDatabaseProvider.MySql)
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("WeChat.Domain.CTO51blogs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int?>("AnalyzingType")
                        .HasColumnType("int");

                    b.Property<string>("ContentUrl")
                        .HasColumnType("longtext")
                        .HasComment("文章完整地址Url");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Img")
                        .HasColumnType("longtext")
                        .HasComment("主图");

                    b.Property<bool?>("IsDel")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("KeyWords")
                        .HasColumnType("longtext")
                        .HasComment("关键词");

                    b.Property<DateTime?>("ReleaseTime")
                        .HasColumnType("datetime(6)")
                        .HasComment("时间");

                    b.Property<string>("SourceType")
                        .HasColumnType("longtext")
                        .HasComment("来源类型");

                    b.Property<string>("SubContent")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext")
                        .HasComment("标题");

                    b.HasKey("Id");

                    b.ToTable("CTO51blogs");
                });

            modelBuilder.Entity("WeChat.Domain.Cnblogs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int?>("AnalyzingType")
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .HasMaxLength(520)
                        .HasColumnType("varchar(520)")
                        .HasComment("作者");

                    b.Property<string>("AuthorManUrl")
                        .HasColumnType("longtext")
                        .HasComment("作者主页地址");

                    b.Property<int?>("CommentNum")
                        .HasColumnType("int")
                        .HasComment("评论数");

                    b.Property<string>("ContentUrl")
                        .HasColumnType("longtext")
                        .HasComment("文章完整地址Url");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Img")
                        .HasColumnType("longtext")
                        .HasComment("主图");

                    b.Property<bool?>("IsDel")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("ReadNum")
                        .HasColumnType("int")
                        .HasComment("阅读数");

                    b.Property<int?>("RecommendNum")
                        .HasColumnType("int")
                        .HasComment("推荐数");

                    b.Property<DateTime?>("ReleaseTime")
                        .HasColumnType("datetime(6)")
                        .HasComment("发布时间");

                    b.Property<string>("SubContent")
                        .HasColumnType("longtext")
                        .HasComment("文章简介");

                    b.Property<string>("Title")
                        .HasColumnType("longtext")
                        .HasComment("标题");

                    b.HasKey("Id");

                    b.ToTable("Cnblogs");
                });

            modelBuilder.Entity("WeChat.Domain.CodeDeaultblogs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int?>("AnalyzingType")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .HasColumnType("longtext");

                    b.Property<int?>("CollectionNum")
                        .HasColumnType("int");

                    b.Property<int?>("CommentNum")
                        .HasColumnType("int");

                    b.Property<string>("ContentUrl")
                        .HasColumnType("longtext")
                        .HasComment("文章完整地址Url");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<bool?>("IsDel")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("LikeNum")
                        .HasColumnType("int");

                    b.Property<int?>("ReadNum")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReleaseTime")
                        .HasColumnType("datetime(6)")
                        .HasComment("发布时间");

                    b.Property<string>("SubContent")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext")
                        .HasComment("标题");

                    b.HasKey("Id");

                    b.ToTable("CodeDeaultblogs");
                });

            modelBuilder.Entity("WeChat.Domain.Csdnblogs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int?>("AnalyzingType")
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .HasMaxLength(520)
                        .HasColumnType("varchar(520)")
                        .HasComment("作者");

                    b.Property<string>("AuthorManUrl")
                        .HasColumnType("longtext")
                        .HasComment("作者主页地址");

                    b.Property<int?>("CommentNum")
                        .HasColumnType("int")
                        .HasComment("评论数");

                    b.Property<string>("ContentUrl")
                        .HasColumnType("longtext")
                        .HasComment("文章完整地址Url");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedAt")
                        .HasColumnType("longtext")
                        .HasComment("创建");

                    b.Property<int?>("DiggNum")
                        .HasColumnType("int")
                        .HasComment("点赞数");

                    b.Property<string>("Img")
                        .HasColumnType("longtext")
                        .HasComment("主图");

                    b.Property<bool?>("IsDel")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ProductType")
                        .HasColumnType("longtext");

                    b.Property<int?>("ReadNum")
                        .HasColumnType("int")
                        .HasComment("阅读数");

                    b.Property<string>("SubContent")
                        .HasColumnType("longtext")
                        .HasComment("文章简介");

                    b.Property<string>("Title")
                        .HasColumnType("longtext")
                        .HasComment("标题");

                    b.HasKey("Id");

                    b.ToTable("Csdnblogs");
                });

            modelBuilder.Entity("WeChat.Domain.ItHomeblogs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int?>("AnalyzingType")
                        .HasColumnType("int");

                    b.Property<string>("ContentUrl")
                        .HasColumnType("longtext")
                        .HasComment("文章完整地址Url");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Img")
                        .HasColumnType("longtext")
                        .HasComment("主图");

                    b.Property<bool?>("IsDel")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("ReleaseTime")
                        .HasColumnType("datetime(6)")
                        .HasComment("发布时间");

                    b.Property<string>("SubContent")
                        .HasColumnType("longtext");

                    b.Property<string>("Tags")
                        .HasColumnType("longtext")
                        .HasComment("标签");

                    b.Property<string>("TagsUrl")
                        .HasColumnType("longtext")
                        .HasComment("标签地址");

                    b.Property<string>("Title")
                        .HasColumnType("longtext")
                        .HasComment("标题");

                    b.HasKey("Id");

                    b.ToTable("ItHomeblogs");
                });

            modelBuilder.Entity("WeChat.Domain.JueJinblogs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int?>("AnalyzingType")
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .HasMaxLength(520)
                        .HasColumnType("varchar(520)")
                        .HasComment("作者");

                    b.Property<string>("AuthorManUrl")
                        .HasColumnType("longtext")
                        .HasComment("作者主页地址");

                    b.Property<int?>("CommentNum")
                        .HasColumnType("int")
                        .HasComment("评论数");

                    b.Property<string>("ContentUrl")
                        .HasColumnType("longtext")
                        .HasComment("文章完整地址Url");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("GiveLikeNum")
                        .HasColumnType("int")
                        .HasComment("点赞数");

                    b.Property<double?>("HotIndex")
                        .HasColumnType("double")
                        .HasComment("热门系数");

                    b.Property<string>("Img")
                        .HasColumnType("longtext")
                        .HasComment("主图");

                    b.Property<bool?>("IsDel")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("ReadNum")
                        .HasColumnType("int")
                        .HasComment("阅读数");

                    b.Property<DateTime?>("ReleaseTime")
                        .HasColumnType("datetime(6)")
                        .HasComment("发布时间");

                    b.Property<string>("SubContent")
                        .HasColumnType("longtext")
                        .HasComment("文章简介");

                    b.Property<string>("Title")
                        .HasColumnType("longtext")
                        .HasComment("标题");

                    b.HasKey("Id");

                    b.ToTable("JueJinblogs");
                });

            modelBuilder.Entity("WeChat.Domain.Log", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Exception")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("LogDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LogLevel")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasComment("日志等级");

                    b.Property<string>("LogType")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasComment("日志类型");

                    b.Property<string>("Logger")
                        .HasColumnType("longtext");

                    b.Property<string>("MachineIp")
                        .HasColumnType("longtext");

                    b.Property<string>("MachineName")
                        .HasColumnType("longtext");

                    b.Property<string>("Message")
                        .HasColumnType("longtext");

                    b.Property<string>("NetRequestMethod")
                        .HasColumnType("longtext");

                    b.Property<string>("NetRequestUrl")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("char(36)")
                        .HasComment("操作人");

                    b.HasKey("Id");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("WeChat.Domain.OsChinablogs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int?>("AnalyzingType")
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .HasMaxLength(520)
                        .HasColumnType("varchar(520)")
                        .HasComment("作者");

                    b.Property<string>("AuthorManUrl")
                        .HasColumnType("longtext")
                        .HasComment("作者主页地址");

                    b.Property<int?>("CommentNum")
                        .HasColumnType("int")
                        .HasComment("评论数");

                    b.Property<string>("ContentUrl")
                        .HasColumnType("longtext")
                        .HasComment("文章完整地址Url");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Img")
                        .HasColumnType("longtext")
                        .HasComment("主图");

                    b.Property<bool?>("IsDel")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("LikeNum")
                        .HasColumnType("int")
                        .HasComment("喜欢数");

                    b.Property<int?>("ReadNum")
                        .HasColumnType("int")
                        .HasComment("阅读数");

                    b.Property<string>("ReleaseTimeStr")
                        .HasColumnType("longtext")
                        .HasComment("时间");

                    b.Property<string>("SubContent")
                        .HasColumnType("longtext")
                        .HasComment("文章简介");

                    b.Property<string>("Title")
                        .HasColumnType("longtext")
                        .HasComment("标题");

                    b.HasKey("Id");

                    b.ToTable("OsChinablogs");
                });

            modelBuilder.Entity("WeChat.Domain.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasComment("说明");

                    b.Property<DateTime?>("EditTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("EditUserId")
                        .HasColumnType("char(36)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsDel")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3a03022a-4eb8-4fab-7d8b-7a3d1a9a513e"),
                            CreateTime = new DateTime(2022, 4, 3, 23, 13, 59, 992, DateTimeKind.Local).AddTicks(9640),
                            CreateUserId = new Guid("3a03022a-4eb8-fef4-33c0-be5f1f8ec581"),
                            Description = "最高权限管理者",
                            IsActive = true,
                            IsDel = false,
                            Name = "管理者"
                        });
                });

            modelBuilder.Entity("WeChat.Domain.Segmentfaultblogs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int?>("AnalyzingType")
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .HasMaxLength(520)
                        .HasColumnType("varchar(520)")
                        .HasComment("作者");

                    b.Property<string>("AuthorManUrl")
                        .HasColumnType("longtext")
                        .HasComment("作者主页地址");

                    b.Property<int?>("CommentNum")
                        .HasColumnType("int")
                        .HasComment("评论数");

                    b.Property<string>("ContentUrl")
                        .HasColumnType("longtext")
                        .HasComment("文章完整地址Url");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("DiggNum")
                        .HasColumnType("int")
                        .HasComment("点赞数");

                    b.Property<string>("Img")
                        .HasColumnType("longtext")
                        .HasComment("主图");

                    b.Property<bool?>("IsDel")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("ReleaseTime")
                        .HasColumnType("datetime(6)")
                        .HasComment("发布时间");

                    b.Property<string>("Title")
                        .HasColumnType("longtext")
                        .HasComment("标题");

                    b.HasKey("Id");

                    b.ToTable("Segmentfaultblogs");
                });

            modelBuilder.Entity("WeChat.Domain.Token", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Access_Token")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasComment("Token");

                    b.Property<double?>("Expires_In")
                        .HasColumnType("double")
                        .HasComment("多少秒后失效");

                    b.Property<DateTime?>("OperationTime")
                        .HasColumnType("datetime(6)")
                        .HasComment("操作时间");

                    b.Property<int>("TokenType")
                        .HasColumnType("int");

                    b.Property<int>("WeiChatType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Token");
                });

            modelBuilder.Entity("WeChat.Domain.UserAndRoleMap", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("char(36)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserAndRoleMap");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("3a03022a-4eb8-fef4-33c0-be5f1f8ec581"),
                            RoleId = new Guid("3a03022a-4eb8-4fab-7d8b-7a3d1a9a513e"),
                            CreateTime = new DateTime(2022, 4, 3, 23, 13, 59, 993, DateTimeKind.Local).AddTicks(629),
                            CreateUserId = new Guid("3a03022a-4eb8-fef4-33c0-be5f1f8ec581")
                        });
                });

            modelBuilder.Entity("WeChat.Domain.UserInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AvatarUrl")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasComment("头像Url地址");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("EditTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("EditUserId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsDel")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LoginName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NickName")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("PassWrod")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("UserInfo");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3a03022a-4eb8-fef4-33c0-be5f1f8ec581"),
                            CreateTime = new DateTime(2022, 4, 3, 23, 13, 59, 992, DateTimeKind.Local).AddTicks(7368),
                            IsActive = true,
                            IsDel = true,
                            LoginName = "admin",
                            NickName = "管理员",
                            PassWrod = "123456"
                        });
                });

            modelBuilder.Entity("WeChat.Domain.UserAndRoleMap", b =>
                {
                    b.HasOne("WeChat.Domain.Role", "Role")
                        .WithMany("UserAndRoleMaps")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WeChat.Domain.UserInfo", "UserInfo")
                        .WithMany("UserAndRoleMaps")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("WeChat.Domain.Role", b =>
                {
                    b.Navigation("UserAndRoleMaps");
                });

            modelBuilder.Entity("WeChat.Domain.UserInfo", b =>
                {
                    b.Navigation("UserAndRoleMaps");
                });
#pragma warning restore 612, 618
        }
    }
}
