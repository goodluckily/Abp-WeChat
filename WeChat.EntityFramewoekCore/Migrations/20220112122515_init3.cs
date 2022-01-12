using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeChat.EntityFramewoekCore.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserAndRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("08c2445c-dc5b-1bc3-4b93-3a015efc3e55"), new Guid("2c5d52e4-d3c8-ac30-e91a-3a015efc3e54") });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("08c2445c-dc5b-1bc3-4b93-3a015efc3e55"));

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: new Guid("2c5d52e4-d3c8-ac30-e91a-3a015efc3e54"));

            migrationBuilder.AddColumn<double>(
                name: "HotIndex",
                table: "JueJinblogs",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReadNum",
                table: "JueJinblogs",
                type: "int",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "HotIndex",
                table: "JueJinblogs");

            migrationBuilder.DropColumn(
                name: "ReadNum",
                table: "JueJinblogs");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreateTime", "CreateUserId", "Description", "EditTime", "EditUserId", "IsActive", "IsDel", "Name" },
                values: new object[] { new Guid("08c2445c-dc5b-1bc3-4b93-3a015efc3e55"), new DateTime(2022, 1, 12, 13, 42, 47, 637, DateTimeKind.Local).AddTicks(2994), new Guid("2c5d52e4-d3c8-ac30-e91a-3a015efc3e54"), "最高权限管理者", null, null, true, false, "管理者" });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "AvatarUrl", "CreateTime", "CreateUserId", "EditTime", "EditUserId", "Email", "IsActive", "IsDel", "LoginName", "NickName", "PassWrod", "Phone" },
                values: new object[] { new Guid("2c5d52e4-d3c8-ac30-e91a-3a015efc3e54"), null, new DateTime(2022, 1, 12, 13, 42, 47, 637, DateTimeKind.Local).AddTicks(267), null, null, null, null, true, true, "admin", "管理员", "123456", null });

            migrationBuilder.InsertData(
                table: "UserAndRoleMap",
                columns: new[] { "RoleId", "UserId", "CreateTime", "CreateUserId" },
                values: new object[] { new Guid("08c2445c-dc5b-1bc3-4b93-3a015efc3e55"), new Guid("2c5d52e4-d3c8-ac30-e91a-3a015efc3e54"), new DateTime(2022, 1, 12, 13, 42, 47, 637, DateTimeKind.Local).AddTicks(4017), new Guid("2c5d52e4-d3c8-ac30-e91a-3a015efc3e54") });
        }
    }
}
