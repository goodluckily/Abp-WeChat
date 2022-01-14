using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeChat.EntityFramewoekCore.Migrations
{
    public partial class initmsi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserAndRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3a0165ac-8ad8-66e3-7a92-e358859496f3"), new Guid("3a0165ac-8ad7-c984-1cef-e02d6d2cfe66") });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3a0165ac-8ad8-66e3-7a92-e358859496f3"));

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: new Guid("3a0165ac-8ad7-c984-1cef-e02d6d2cfe66"));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreateTime", "CreateUserId", "Description", "EditTime", "EditUserId", "IsActive", "IsDel", "Name" },
                values: new object[] { new Guid("3a016b75-d584-c148-3187-f2ef0229cc01"), new DateTime(2022, 1, 14, 23, 51, 2, 788, DateTimeKind.Local).AddTicks(8303), new Guid("3a016b75-d584-da89-1bbf-c95980f1687e"), "最高权限管理者", null, null, true, false, "管理者" });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "AvatarUrl", "CreateTime", "CreateUserId", "EditTime", "EditUserId", "Email", "IsActive", "IsDel", "LoginName", "NickName", "PassWrod", "Phone" },
                values: new object[] { new Guid("3a016b75-d584-da89-1bbf-c95980f1687e"), null, new DateTime(2022, 1, 14, 23, 51, 2, 788, DateTimeKind.Local).AddTicks(5848), null, null, null, null, true, true, "admin", "管理员", "123456", null });

            migrationBuilder.InsertData(
                table: "UserAndRoleMap",
                columns: new[] { "RoleId", "UserId", "CreateTime", "CreateUserId" },
                values: new object[] { new Guid("3a016b75-d584-c148-3187-f2ef0229cc01"), new Guid("3a016b75-d584-da89-1bbf-c95980f1687e"), new DateTime(2022, 1, 14, 23, 51, 2, 788, DateTimeKind.Local).AddTicks(9282), new Guid("3a016b75-d584-da89-1bbf-c95980f1687e") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserAndRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3a016b75-d584-c148-3187-f2ef0229cc01"), new Guid("3a016b75-d584-da89-1bbf-c95980f1687e") });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3a016b75-d584-c148-3187-f2ef0229cc01"));

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: new Guid("3a016b75-d584-da89-1bbf-c95980f1687e"));

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
        }
    }
}
