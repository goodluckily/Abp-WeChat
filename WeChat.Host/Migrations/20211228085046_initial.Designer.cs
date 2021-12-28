﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Volo.Abp.EntityFrameworkCore;
using WeChat.Host.EntityFrameworkCore;

namespace WeChat.Host.Migrations
{
    [DbContext(typeof(WeChatSecondDbContext))]
    [Migration("20211228085046_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("_Abp_DatabaseProvider", EfCoreDatabaseProvider.MySql)
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("WeChat.Domain.WeChat.TokenLapse", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("Access_Token")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasComment("Token");

                    b.Property<int>("Expires_In")
                        .HasMaxLength(20)
                        .HasColumnType("int")
                        .HasComment("多少秒后失效");

                    b.Property<DateTime>("OperationTime")
                        .HasMaxLength(20)
                        .HasColumnType("datetime(6)")
                        .HasComment("操作时间");

                    b.HasKey("Id");

                    b.ToTable("TokenLapse");
                });
#pragma warning restore 612, 618
        }
    }
}
