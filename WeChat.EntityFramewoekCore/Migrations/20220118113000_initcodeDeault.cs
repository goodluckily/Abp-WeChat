using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeChat.EntityFramewoekCore.Migrations
{
    public partial class initcodeDeault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserAndRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3a017e5d-8955-6dc2-060c-c46dffa6277d"), new Guid("3a017e5d-8955-aa43-8a4e-5a73b83b547b") });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3a017e5d-8955-6dc2-060c-c46dffa6277d"));

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: new Guid("3a017e5d-8955-aa43-8a4e-5a73b83b547b"));

            migrationBuilder.AlterColumn<string>(
                name: "Tags",
                table: "ItHomeblogs",
                type: "longtext",
                nullable: true,
                comment: "标签",
                oldClrType: typeof(string),
                oldType: "varchar(520)",
                oldMaxLength: 520,
                oldNullable: true,
                oldComment: "标签")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CodeDeaultblogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "longtext", nullable: true, comment: "标题")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContentUrl = table.Column<string>(type: "longtext", nullable: true, comment: "文章完整地址Url")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SubContent = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Category = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReleaseTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "发布时间"),
                    ReadNum = table.Column<int>(type: "int", nullable: true),
                    CommentNum = table.Column<int>(type: "int", nullable: true),
                    LikeNum = table.Column<int>(type: "int", nullable: true),
                    CollectionNum = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_CodeDeaultblogs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreateTime", "CreateUserId", "Description", "EditTime", "EditUserId", "IsActive", "IsDel", "Name" },
                values: new object[] { new Guid("3a017f20-45cb-e458-36e5-36684656d8d9"), new DateTime(2022, 1, 18, 19, 29, 59, 756, DateTimeKind.Local).AddTicks(654), new Guid("3a017f20-45cb-d18e-5b22-29bb4ebfc5ce"), "最高权限管理者", null, null, true, false, "管理者" });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "AvatarUrl", "CreateTime", "CreateUserId", "EditTime", "EditUserId", "Email", "IsActive", "IsDel", "LoginName", "NickName", "PassWrod", "Phone" },
                values: new object[] { new Guid("3a017f20-45cb-d18e-5b22-29bb4ebfc5ce"), null, new DateTime(2022, 1, 18, 19, 29, 59, 755, DateTimeKind.Local).AddTicks(7276), null, null, null, null, true, true, "admin", "管理员", "123456", null });

            migrationBuilder.InsertData(
                table: "UserAndRoleMap",
                columns: new[] { "RoleId", "UserId", "CreateTime", "CreateUserId" },
                values: new object[] { new Guid("3a017f20-45cb-e458-36e5-36684656d8d9"), new Guid("3a017f20-45cb-d18e-5b22-29bb4ebfc5ce"), new DateTime(2022, 1, 18, 19, 29, 59, 756, DateTimeKind.Local).AddTicks(2032), new Guid("3a017f20-45cb-d18e-5b22-29bb4ebfc5ce") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodeDeaultblogs");

            migrationBuilder.DeleteData(
                table: "UserAndRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3a017f20-45cb-e458-36e5-36684656d8d9"), new Guid("3a017f20-45cb-d18e-5b22-29bb4ebfc5ce") });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3a017f20-45cb-e458-36e5-36684656d8d9"));

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: new Guid("3a017f20-45cb-d18e-5b22-29bb4ebfc5ce"));

            migrationBuilder.AlterColumn<string>(
                name: "Tags",
                table: "ItHomeblogs",
                type: "varchar(520)",
                maxLength: 520,
                nullable: true,
                comment: "标签",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true,
                oldComment: "标签")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreateTime", "CreateUserId", "Description", "EditTime", "EditUserId", "IsActive", "IsDel", "Name" },
                values: new object[] { new Guid("3a017e5d-8955-6dc2-060c-c46dffa6277d"), new DateTime(2022, 1, 18, 15, 57, 17, 526, DateTimeKind.Local).AddTicks(29), new Guid("3a017e5d-8955-aa43-8a4e-5a73b83b547b"), "最高权限管理者", null, null, true, false, "管理者" });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "AvatarUrl", "CreateTime", "CreateUserId", "EditTime", "EditUserId", "Email", "IsActive", "IsDel", "LoginName", "NickName", "PassWrod", "Phone" },
                values: new object[] { new Guid("3a017e5d-8955-aa43-8a4e-5a73b83b547b"), null, new DateTime(2022, 1, 18, 15, 57, 17, 525, DateTimeKind.Local).AddTicks(7170), null, null, null, null, true, true, "admin", "管理员", "123456", null });

            migrationBuilder.InsertData(
                table: "UserAndRoleMap",
                columns: new[] { "RoleId", "UserId", "CreateTime", "CreateUserId" },
                values: new object[] { new Guid("3a017e5d-8955-6dc2-060c-c46dffa6277d"), new Guid("3a017e5d-8955-aa43-8a4e-5a73b83b547b"), new DateTime(2022, 1, 18, 15, 57, 17, 526, DateTimeKind.Local).AddTicks(1233), new Guid("3a017e5d-8955-aa43-8a4e-5a73b83b547b") });
        }
    }
}
