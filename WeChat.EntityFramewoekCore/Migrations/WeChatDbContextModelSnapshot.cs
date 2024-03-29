﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
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
                .HasAnnotation("_Abp_DatabaseProvider", EfCoreDatabaseProvider.SqlServer)
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WeChat.Domain.CTO51blogs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("AnalyzingType")
                        .HasColumnType("int");

                    b.Property<string>("ContentUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("文章完整地址Url");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Img")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("主图");

                    b.Property<bool?>("IsDel")
                        .HasColumnType("bit");

                    b.Property<string>("KeyWords")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("关键词");

                    b.Property<DateTime?>("ReleaseTime")
                        .HasColumnType("datetime2")
                        .HasComment("时间");

                    b.Property<string>("SourceType")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("来源类型");

                    b.Property<string>("SubContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("标题");

                    b.HasKey("Id");

                    b.ToTable("CTO51blogs");
                });

            modelBuilder.Entity("WeChat.Domain.Cnblogs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("AnalyzingType")
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .HasMaxLength(520)
                        .HasColumnType("nvarchar(520)")
                        .HasComment("作者");

                    b.Property<string>("AuthorManUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("作者主页地址");

                    b.Property<int?>("CommentNum")
                        .HasColumnType("int")
                        .HasComment("评论数");

                    b.Property<string>("ContentUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("文章完整地址Url");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Img")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("主图");

                    b.Property<bool?>("IsDel")
                        .HasColumnType("bit");

                    b.Property<int?>("ReadNum")
                        .HasColumnType("int")
                        .HasComment("阅读数");

                    b.Property<int?>("RecommendNum")
                        .HasColumnType("int")
                        .HasComment("推荐数");

                    b.Property<DateTime?>("ReleaseTime")
                        .HasColumnType("datetime2")
                        .HasComment("发布时间");

                    b.Property<string>("SubContent")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("文章简介");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("标题");

                    b.HasKey("Id");

                    b.ToTable("Cnblogs");
                });

            modelBuilder.Entity("WeChat.Domain.CodeDeaultblogs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("AnalyzingType")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CollectionNum")
                        .HasColumnType("int");

                    b.Property<int?>("CommentNum")
                        .HasColumnType("int");

                    b.Property<string>("ContentUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("文章完整地址Url");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsDel")
                        .HasColumnType("bit");

                    b.Property<int?>("LikeNum")
                        .HasColumnType("int");

                    b.Property<int?>("ReadNum")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReleaseTime")
                        .HasColumnType("datetime2")
                        .HasComment("发布时间");

                    b.Property<string>("SubContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("标题");

                    b.HasKey("Id");

                    b.ToTable("CodeDeaultblogs");
                });

            modelBuilder.Entity("WeChat.Domain.Csdnblogs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("AnalyzingType")
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .HasMaxLength(520)
                        .HasColumnType("nvarchar(520)")
                        .HasComment("作者");

                    b.Property<string>("AuthorManUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("作者主页地址");

                    b.Property<int?>("CommentNum")
                        .HasColumnType("int")
                        .HasComment("评论数");

                    b.Property<string>("ContentUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("文章完整地址Url");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedAt")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("创建");

                    b.Property<int?>("DiggNum")
                        .HasColumnType("int")
                        .HasComment("点赞数");

                    b.Property<string>("Img")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("主图");

                    b.Property<bool?>("IsDel")
                        .HasColumnType("bit");

                    b.Property<string>("ProductType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReadNum")
                        .HasColumnType("int")
                        .HasComment("阅读数");

                    b.Property<string>("SubContent")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("文章简介");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("标题");

                    b.HasKey("Id");

                    b.ToTable("Csdnblogs");
                });

            modelBuilder.Entity("WeChat.Domain.ItHomeblogs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("AnalyzingType")
                        .HasColumnType("int");

                    b.Property<string>("ContentUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("文章完整地址Url");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Img")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("主图");

                    b.Property<bool?>("IsDel")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ReleaseTime")
                        .HasColumnType("datetime2")
                        .HasComment("发布时间");

                    b.Property<string>("SubContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tags")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("标签");

                    b.Property<string>("TagsUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("标签地址");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("标题");

                    b.HasKey("Id");

                    b.ToTable("ItHomeblogs");
                });

            modelBuilder.Entity("WeChat.Domain.JueJinblogs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("AnalyzingType")
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .HasMaxLength(520)
                        .HasColumnType("nvarchar(520)")
                        .HasComment("作者");

                    b.Property<string>("AuthorManUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("作者主页地址");

                    b.Property<int?>("CommentNum")
                        .HasColumnType("int")
                        .HasComment("评论数");

                    b.Property<string>("ContentUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("文章完整地址Url");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GiveLikeNum")
                        .HasColumnType("int")
                        .HasComment("点赞数");

                    b.Property<double?>("HotIndex")
                        .HasColumnType("float")
                        .HasComment("热门系数");

                    b.Property<string>("Img")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("主图");

                    b.Property<bool?>("IsDel")
                        .HasColumnType("bit");

                    b.Property<int?>("ReadNum")
                        .HasColumnType("int")
                        .HasComment("阅读数");

                    b.Property<DateTime?>("ReleaseTime")
                        .HasColumnType("datetime2")
                        .HasComment("发布时间");

                    b.Property<string>("SubContent")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("文章简介");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("标题");

                    b.HasKey("Id");

                    b.ToTable("JueJinblogs");
                });

            modelBuilder.Entity("WeChat.Domain.Log", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Exception")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LogDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LogLevel")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("日志等级");

                    b.Property<string>("LogType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("日志类型");

                    b.Property<string>("Logger")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MachineIp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MachineName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NetRequestMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NetRequestUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("操作人");

                    b.HasKey("Id");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("WeChat.Domain.OsChinablogs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("AnalyzingType")
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .HasMaxLength(520)
                        .HasColumnType("nvarchar(520)")
                        .HasComment("作者");

                    b.Property<string>("AuthorManUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("作者主页地址");

                    b.Property<int?>("CommentNum")
                        .HasColumnType("int")
                        .HasComment("评论数");

                    b.Property<string>("ContentUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("文章完整地址Url");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Img")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("主图");

                    b.Property<bool?>("IsDel")
                        .HasColumnType("bit");

                    b.Property<int?>("LikeNum")
                        .HasColumnType("int")
                        .HasComment("喜欢数");

                    b.Property<int?>("ReadNum")
                        .HasColumnType("int")
                        .HasComment("阅读数");

                    b.Property<string>("ReleaseTimeStr")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("时间");

                    b.Property<string>("SubContent")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("文章简介");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("标题");

                    b.HasKey("Id");

                    b.ToTable("OsChinablogs");
                });

            modelBuilder.Entity("WeChat.Domain.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasComment("说明");

                    b.Property<DateTime?>("EditTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("EditUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDel")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("WeChat.Domain.Segmentfaultblogs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("AnalyzingType")
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .HasMaxLength(520)
                        .HasColumnType("nvarchar(520)")
                        .HasComment("作者");

                    b.Property<string>("AuthorManUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("作者主页地址");

                    b.Property<int?>("CommentNum")
                        .HasColumnType("int")
                        .HasComment("评论数");

                    b.Property<string>("ContentUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("文章完整地址Url");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DiggNum")
                        .HasColumnType("int")
                        .HasComment("点赞数");

                    b.Property<string>("Img")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("主图");

                    b.Property<bool?>("IsDel")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ReleaseTime")
                        .HasColumnType("datetime2")
                        .HasComment("发布时间");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("标题");

                    b.HasKey("Id");

                    b.ToTable("Segmentfaultblogs");
                });

            modelBuilder.Entity("WeChat.Domain.Token", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Access_Token")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Token");

                    b.Property<double?>("Expires_In")
                        .HasColumnType("float")
                        .HasComment("多少秒后失效");

                    b.Property<DateTime?>("OperationTime")
                        .HasColumnType("datetime2")
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
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserAndRoleMap");
                });

            modelBuilder.Entity("WeChat.Domain.UserInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AvatarUrl")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasComment("头像Url地址");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("EditTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("EditUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDel")
                        .HasColumnType("bit");

                    b.Property<string>("LoginName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NickName")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("PassWrod")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("UserInfo");
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
