﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Volo.Abp.EntityFrameworkCore;
using WeChat.EntityFramewoekCore;

namespace WeChat.EntityFramewoekCore.Migrations
{
    [DbContext(typeof(WeChatDbContext))]
    [Migration("20220110161708_init3")]
    partial class init3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("_Abp_DatabaseProvider", EfCoreDatabaseProvider.SqlServer)
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WeChat.Domain.WeChat.Log", b =>
                {
                    b.Property<Guid>("Id")
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

            modelBuilder.Entity("WeChat.Domain.WeChat.Netcnblogs", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("AnalyzingType")
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AuthorManUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CommentNum")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("EditTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("EditUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDel")
                        .HasColumnType("bit");

                    b.Property<int?>("ReadNum")
                        .HasColumnType("int");

                    b.Property<int?>("RecommendNum")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReleaseTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("标题");

                    b.HasKey("Id");

                    b.ToTable("Netcnblogs");
                });

            modelBuilder.Entity("WeChat.Domain.WeChat.Role", b =>
                {
                    b.Property<Guid>("Id")
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("97eff0cb-892a-d839-92ed-3a0156f447db"),
                            CreateTime = new DateTime(2022, 1, 11, 0, 17, 8, 59, DateTimeKind.Local).AddTicks(9126),
                            CreateUserId = new Guid("79bcfd9a-9135-e863-e585-3a0156f447db"),
                            Description = "最高权限管理者",
                            IsActive = true,
                            IsDel = false,
                            Name = "管理者"
                        });
                });

            modelBuilder.Entity("WeChat.Domain.WeChat.Token", b =>
                {
                    b.Property<Guid>("Id")
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

            modelBuilder.Entity("WeChat.Domain.WeChat.UserAndRoleMap", b =>
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

                    b.HasData(
                        new
                        {
                            UserId = new Guid("79bcfd9a-9135-e863-e585-3a0156f447db"),
                            RoleId = new Guid("97eff0cb-892a-d839-92ed-3a0156f447db"),
                            CreateTime = new DateTime(2022, 1, 11, 0, 17, 8, 60, DateTimeKind.Local).AddTicks(106),
                            CreateUserId = new Guid("79bcfd9a-9135-e863-e585-3a0156f447db")
                        });
                });

            modelBuilder.Entity("WeChat.Domain.WeChat.UserInfo", b =>
                {
                    b.Property<Guid>("Id")
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("79bcfd9a-9135-e863-e585-3a0156f447db"),
                            CreateTime = new DateTime(2022, 1, 11, 0, 17, 8, 59, DateTimeKind.Local).AddTicks(6709),
                            IsActive = true,
                            IsDel = true,
                            LoginName = "admin",
                            NickName = "管理员",
                            PassWrod = "123456"
                        });
                });

            modelBuilder.Entity("WeChat.Domain.WeChat.UserAndRoleMap", b =>
                {
                    b.HasOne("WeChat.Domain.WeChat.Role", "Role")
                        .WithMany("UserAndRoleMaps")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WeChat.Domain.WeChat.UserInfo", "UserInfo")
                        .WithMany("UserAndRoleMaps")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("WeChat.Domain.WeChat.Role", b =>
                {
                    b.Navigation("UserAndRoleMaps");
                });

            modelBuilder.Entity("WeChat.Domain.WeChat.UserInfo", b =>
                {
                    b.Navigation("UserAndRoleMaps");
                });
#pragma warning restore 612, 618
        }
    }
}