﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Volo.Abp.EntityFrameworkCore;
using WeChat.Host.EntityFrameworkCore;

namespace WeChat.Host.Migrations
{
    [DbContext(typeof(WeChatSecondDbContext))]
    [Migration("20220104134449_initusermap")]
    partial class initusermap
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("_Abp_DatabaseProvider", EfCoreDatabaseProvider.SqlServer)
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
#pragma warning restore 612, 618
        }
    }
}
