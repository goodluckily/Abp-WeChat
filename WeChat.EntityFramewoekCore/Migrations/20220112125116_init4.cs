using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeChat.EntityFramewoekCore.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserAndRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("85148845-e680-3951-6d49-3a01606cb2ca"), new Guid("298ecbe0-2002-9bd5-5778-3a01606cb2c9") });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("85148845-e680-3951-6d49-3a01606cb2ca"));

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: new Guid("298ecbe0-2002-9bd5-5778-3a01606cb2c9"));

            migrationBuilder.DropColumn(
                name: "ReleaseTimeStr",
                table: "JueJinblogs");

            migrationBuilder.AlterColumn<int>(
                name: "ReadNum",
                table: "JueJinblogs",
                type: "int",
                nullable: true,
                comment: "阅读数",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "HotIndex",
                table: "JueJinblogs",
                type: "float",
                nullable: true,
                comment: "热门系数",
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseTime",
                table: "JueJinblogs",
                type: "datetime2",
                nullable: true,
                comment: "发布时间");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreateTime", "CreateUserId", "Description", "EditTime", "EditUserId", "IsActive", "IsDel", "Name" },
                values: new object[] { new Guid("4ffee807-f945-08d9-10e7-3a016084846b"), new DateTime(2022, 1, 12, 20, 51, 15, 692, DateTimeKind.Local).AddTicks(1829), new Guid("10a668b8-118f-a4f0-9952-3a016084846b"), "最高权限管理者", null, null, true, false, "管理者" });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "AvatarUrl", "CreateTime", "CreateUserId", "EditTime", "EditUserId", "Email", "IsActive", "IsDel", "LoginName", "NickName", "PassWrod", "Phone" },
                values: new object[] { new Guid("10a668b8-118f-a4f0-9952-3a016084846b"), null, new DateTime(2022, 1, 12, 20, 51, 15, 691, DateTimeKind.Local).AddTicks(7675), null, null, null, null, true, true, "admin", "管理员", "123456", null });

            migrationBuilder.InsertData(
                table: "UserAndRoleMap",
                columns: new[] { "RoleId", "UserId", "CreateTime", "CreateUserId" },
                values: new object[] { new Guid("4ffee807-f945-08d9-10e7-3a016084846b"), new Guid("10a668b8-118f-a4f0-9952-3a016084846b"), new DateTime(2022, 1, 12, 20, 51, 15, 692, DateTimeKind.Local).AddTicks(3463), new Guid("10a668b8-118f-a4f0-9952-3a016084846b") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserAndRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4ffee807-f945-08d9-10e7-3a016084846b"), new Guid("10a668b8-118f-a4f0-9952-3a016084846b") });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("4ffee807-f945-08d9-10e7-3a016084846b"));

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: new Guid("10a668b8-118f-a4f0-9952-3a016084846b"));

            migrationBuilder.DropColumn(
                name: "ReleaseTime",
                table: "JueJinblogs");

            migrationBuilder.AlterColumn<int>(
                name: "ReadNum",
                table: "JueJinblogs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "阅读数");

            migrationBuilder.AlterColumn<double>(
                name: "HotIndex",
                table: "JueJinblogs",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true,
                oldComment: "热门系数");

            migrationBuilder.AddColumn<string>(
                name: "ReleaseTimeStr",
                table: "JueJinblogs",
                type: "nvarchar(max)",
                nullable: true,
                comment: "发布时间 string");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreateTime", "CreateUserId", "Description", "EditTime", "EditUserId", "IsActive", "IsDel", "Name" },
                values: new object[] { new Guid("85148845-e680-3951-6d49-3a01606cb2ca"), new DateTime(2022, 1, 12, 20, 25, 14, 698, DateTimeKind.Local).AddTicks(5763), new Guid("298ecbe0-2002-9bd5-5778-3a01606cb2c9"), "最高权限管理者", null, null, true, false, "管理者" });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "AvatarUrl", "CreateTime", "CreateUserId", "EditTime", "EditUserId", "Email", "IsActive", "IsDel", "LoginName", "NickName", "PassWrod", "Phone" },
                values: new object[] { new Guid("298ecbe0-2002-9bd5-5778-3a01606cb2c9"), null, new DateTime(2022, 1, 12, 20, 25, 14, 698, DateTimeKind.Local).AddTicks(2563), null, null, null, null, true, true, "admin", "管理员", "123456", null });

            migrationBuilder.InsertData(
                table: "UserAndRoleMap",
                columns: new[] { "RoleId", "UserId", "CreateTime", "CreateUserId" },
                values: new object[] { new Guid("85148845-e680-3951-6d49-3a01606cb2ca"), new Guid("298ecbe0-2002-9bd5-5778-3a01606cb2c9"), new DateTime(2022, 1, 12, 20, 25, 14, 698, DateTimeKind.Local).AddTicks(7013), new Guid("298ecbe0-2002-9bd5-5778-3a01606cb2c9") });
        }
    }
}
