using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeChat.EntityFramewoekCore.Migrations
{
    public partial class initsifou : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserAndRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3a016f34-a23c-37fb-4e07-f845581274a4"), new Guid("3a016f34-a23b-1664-1927-0745ffa47a86") });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3a016f34-a23c-37fb-4e07-f845581274a4"));

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: new Guid("3a016f34-a23b-1664-1927-0745ffa47a86"));

            migrationBuilder.CreateTable(
                name: "Segmentfaultblogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "longtext", nullable: true, comment: "标题")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContentUrl = table.Column<string>(type: "longtext", nullable: true, comment: "文章完整地址Url")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Author = table.Column<string>(type: "varchar(520)", maxLength: 520, nullable: true, comment: "作者")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Img = table.Column<string>(type: "longtext", nullable: true, comment: "主图")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuthorManUrl = table.Column<string>(type: "longtext", nullable: true, comment: "作者主页地址")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReleaseTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "发布时间"),
                    DiggNum = table.Column<int>(type: "int", nullable: true, comment: "点赞数"),
                    CommentNum = table.Column<int>(type: "int", nullable: true, comment: "评论数"),
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
                    table.PrimaryKey("PK_Segmentfaultblogs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreateTime", "CreateUserId", "Description", "EditTime", "EditUserId", "IsActive", "IsDel", "Name" },
                values: new object[] { new Guid("3a016f72-03fa-1eef-c6e8-28a40969059d"), new DateTime(2022, 1, 15, 18, 25, 21, 402, DateTimeKind.Local).AddTicks(9152), new Guid("3a016f72-03fa-69c9-ceb8-36fe03a061b9"), "最高权限管理者", null, null, true, false, "管理者" });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "AvatarUrl", "CreateTime", "CreateUserId", "EditTime", "EditUserId", "Email", "IsActive", "IsDel", "LoginName", "NickName", "PassWrod", "Phone" },
                values: new object[] { new Guid("3a016f72-03fa-69c9-ceb8-36fe03a061b9"), null, new DateTime(2022, 1, 15, 18, 25, 21, 402, DateTimeKind.Local).AddTicks(6635), null, null, null, null, true, true, "admin", "管理员", "123456", null });

            migrationBuilder.InsertData(
                table: "UserAndRoleMap",
                columns: new[] { "RoleId", "UserId", "CreateTime", "CreateUserId" },
                values: new object[] { new Guid("3a016f72-03fa-1eef-c6e8-28a40969059d"), new Guid("3a016f72-03fa-69c9-ceb8-36fe03a061b9"), new DateTime(2022, 1, 15, 18, 25, 21, 403, DateTimeKind.Local).AddTicks(266), new Guid("3a016f72-03fa-69c9-ceb8-36fe03a061b9") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Segmentfaultblogs");

            migrationBuilder.DeleteData(
                table: "UserAndRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3a016f72-03fa-1eef-c6e8-28a40969059d"), new Guid("3a016f72-03fa-69c9-ceb8-36fe03a061b9") });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3a016f72-03fa-1eef-c6e8-28a40969059d"));

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: new Guid("3a016f72-03fa-69c9-ceb8-36fe03a061b9"));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreateTime", "CreateUserId", "Description", "EditTime", "EditUserId", "IsActive", "IsDel", "Name" },
                values: new object[] { new Guid("3a016f34-a23c-37fb-4e07-f845581274a4"), new DateTime(2022, 1, 15, 17, 18, 18, 684, DateTimeKind.Local).AddTicks(8532), new Guid("3a016f34-a23b-1664-1927-0745ffa47a86"), "最高权限管理者", null, null, true, false, "管理者" });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "AvatarUrl", "CreateTime", "CreateUserId", "EditTime", "EditUserId", "Email", "IsActive", "IsDel", "LoginName", "NickName", "PassWrod", "Phone" },
                values: new object[] { new Guid("3a016f34-a23b-1664-1927-0745ffa47a86"), null, new DateTime(2022, 1, 15, 17, 18, 18, 684, DateTimeKind.Local).AddTicks(4244), null, null, null, null, true, true, "admin", "管理员", "123456", null });

            migrationBuilder.InsertData(
                table: "UserAndRoleMap",
                columns: new[] { "RoleId", "UserId", "CreateTime", "CreateUserId" },
                values: new object[] { new Guid("3a016f34-a23c-37fb-4e07-f845581274a4"), new Guid("3a016f34-a23b-1664-1927-0745ffa47a86"), new DateTime(2022, 1, 15, 17, 18, 18, 685, DateTimeKind.Local).AddTicks(283), new Guid("3a016f34-a23b-1664-1927-0745ffa47a86") });
        }
    }
}
