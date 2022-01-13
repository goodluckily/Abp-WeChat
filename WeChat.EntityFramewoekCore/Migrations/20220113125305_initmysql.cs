﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeChat.EntityFramewoekCore.Migrations
{
    public partial class initmysql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "JueJinblogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "longtext", nullable: true, comment: "标题")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Img = table.Column<string>(type: "longtext", nullable: true, comment: "主图")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SubContent = table.Column<string>(type: "longtext", nullable: true, comment: "文章简介")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContentUrl = table.Column<string>(type: "longtext", nullable: true, comment: "文章完整地址Url")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Author = table.Column<string>(type: "varchar(520)", maxLength: 520, nullable: true, comment: "作者")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuthorManUrl = table.Column<string>(type: "longtext", nullable: true, comment: "作者主页地址")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReleaseTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "发布时间"),
                    CommentNum = table.Column<int>(type: "int", nullable: true, comment: "评论数"),
                    GiveLikeNum = table.Column<int>(type: "int", nullable: true, comment: "点赞数"),
                    ReadNum = table.Column<int>(type: "int", nullable: true, comment: "阅读数"),
                    HotIndex = table.Column<double>(type: "double", nullable: true, comment: "热门系数"),
                    AnalyzingType = table.Column<int>(type: "int", nullable: true),
                    CreateUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EditUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    EditTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsDel = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JueJinblogs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "操作人", collation: "ascii_general_ci"),
                    LogLevel = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "日志等级")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LogType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "日志类型")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Logger = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Message = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MachineName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MachineIp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NetRequestMethod = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NetRequestUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Exception = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LogDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Netcnblogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "longtext", nullable: true, comment: "标题")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Img = table.Column<string>(type: "longtext", nullable: true, comment: "主图")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SubContent = table.Column<string>(type: "longtext", nullable: true, comment: "文章简介")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContentUrl = table.Column<string>(type: "longtext", nullable: true, comment: "文章完整地址Url")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RecommendNum = table.Column<int>(type: "int", nullable: true, comment: "推荐数"),
                    Author = table.Column<string>(type: "varchar(520)", maxLength: 520, nullable: true, comment: "作者")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuthorManUrl = table.Column<string>(type: "longtext", nullable: true, comment: "作者主页地址")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReleaseTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "发布时间"),
                    CommentNum = table.Column<int>(type: "int", nullable: true, comment: "评论数"),
                    ReadNum = table.Column<int>(type: "int", nullable: true, comment: "阅读数"),
                    AnalyzingType = table.Column<int>(type: "int", nullable: true),
                    CreateUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EditUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    EditTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsDel = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Netcnblogs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true, comment: "说明")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EditUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    EditTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsDel = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Token",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WeiChatType = table.Column<int>(type: "int", nullable: false),
                    TokenType = table.Column<int>(type: "int", nullable: false),
                    Access_Token = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true, comment: "Token")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expires_In = table.Column<double>(type: "double", nullable: true, comment: "多少秒后失效"),
                    OperationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "操作时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Token", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    LoginName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PassWrod = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NickName = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AvatarUrl = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true, comment: "头像Url地址")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EditUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    EditTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsDel = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserAndRoleMap",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreateUserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAndRoleMap", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserAndRoleMap_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAndRoleMap_UserInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreateTime", "CreateUserId", "Description", "EditTime", "EditUserId", "IsActive", "IsDel", "Name" },
                values: new object[] { new Guid("3a0165ac-8ad8-66e3-7a92-e358859496f3"), new DateTime(2022, 1, 13, 20, 53, 4, 856, DateTimeKind.Local).AddTicks(4137), new Guid("3a0165ac-8ad7-c984-1cef-e02d6d2cfe66"), "最高权限管理者", null, null, true, false, "管理者" });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "AvatarUrl", "CreateTime", "CreateUserId", "EditTime", "EditUserId", "Email", "IsActive", "IsDel", "LoginName", "NickName", "PassWrod", "Phone" },
                values: new object[] { new Guid("3a0165ac-8ad7-c984-1cef-e02d6d2cfe66"), null, new DateTime(2022, 1, 13, 20, 53, 4, 856, DateTimeKind.Local).AddTicks(1665), null, null, null, null, true, true, "admin", "管理员", "123456", null });

            migrationBuilder.InsertData(
                table: "UserAndRoleMap",
                columns: new[] { "RoleId", "UserId", "CreateTime", "CreateUserId" },
                values: new object[] { new Guid("3a0165ac-8ad8-66e3-7a92-e358859496f3"), new Guid("3a0165ac-8ad7-c984-1cef-e02d6d2cfe66"), new DateTime(2022, 1, 13, 20, 53, 4, 856, DateTimeKind.Local).AddTicks(5137), new Guid("3a0165ac-8ad7-c984-1cef-e02d6d2cfe66") });

            migrationBuilder.CreateIndex(
                name: "IX_UserAndRoleMap_RoleId",
                table: "UserAndRoleMap",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JueJinblogs");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "Netcnblogs");

            migrationBuilder.DropTable(
                name: "Token");

            migrationBuilder.DropTable(
                name: "UserAndRoleMap");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "UserInfo");
        }
    }
}
