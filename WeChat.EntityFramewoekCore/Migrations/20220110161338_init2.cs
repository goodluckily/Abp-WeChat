using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeChat.EntityFramewoekCore.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserAndRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8c30a80d-d9af-79f6-9c1c-3a0156ed21ab"), new Guid("2cc6a543-1366-7b68-af40-3a0156ed21aa") });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("8c30a80d-d9af-79f6-9c1c-3a0156ed21ab"));

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: new Guid("2cc6a543-1366-7b68-af40-3a0156ed21aa"));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreateTime", "CreateUserId", "Description", "EditTime", "EditUserId", "IsActive", "IsDel", "Name" },
                values: new object[] { new Guid("a6584a96-cccb-8640-c519-3a0156f111d4"), new DateTime(2022, 1, 11, 0, 13, 37, 620, DateTimeKind.Local).AddTicks(8361), new Guid("df261f49-69a9-7187-3c94-3a0156f111d4"), "最高权限管理者", null, null, true, false, "管理者" });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "AvatarUrl", "CreateTime", "CreateUserId", "EditTime", "EditUserId", "Email", "IsActive", "IsDel", "LoginName", "NickName", "PassWrod", "Phone" },
                values: new object[] { new Guid("df261f49-69a9-7187-3c94-3a0156f111d4"), null, new DateTime(2022, 1, 11, 0, 13, 37, 620, DateTimeKind.Local).AddTicks(5905), null, null, null, null, true, true, "admin", "管理员", "123456", null });

            migrationBuilder.InsertData(
                table: "UserAndRoleMap",
                columns: new[] { "RoleId", "UserId", "CreateTime", "CreateUserId" },
                values: new object[] { new Guid("a6584a96-cccb-8640-c519-3a0156f111d4"), new Guid("df261f49-69a9-7187-3c94-3a0156f111d4"), new DateTime(2022, 1, 11, 0, 13, 37, 620, DateTimeKind.Local).AddTicks(9443), new Guid("df261f49-69a9-7187-3c94-3a0156f111d4") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserAndRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a6584a96-cccb-8640-c519-3a0156f111d4"), new Guid("df261f49-69a9-7187-3c94-3a0156f111d4") });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a6584a96-cccb-8640-c519-3a0156f111d4"));

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: new Guid("df261f49-69a9-7187-3c94-3a0156f111d4"));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreateTime", "CreateUserId", "Description", "EditTime", "EditUserId", "IsActive", "IsDel", "Name" },
                values: new object[] { new Guid("8c30a80d-d9af-79f6-9c1c-3a0156ed21ab"), new DateTime(2022, 1, 11, 0, 9, 19, 531, DateTimeKind.Local).AddTicks(3689), new Guid("2cc6a543-1366-7b68-af40-3a0156ed21aa"), "最高权限管理者", null, null, true, false, "管理者" });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "AvatarUrl", "CreateTime", "CreateUserId", "EditTime", "EditUserId", "Email", "IsActive", "IsDel", "LoginName", "NickName", "PassWrod", "Phone" },
                values: new object[] { new Guid("2cc6a543-1366-7b68-af40-3a0156ed21aa"), null, new DateTime(2022, 1, 11, 0, 9, 19, 531, DateTimeKind.Local).AddTicks(1165), null, null, null, null, true, true, "admin", "管理员", "123456", null });

            migrationBuilder.InsertData(
                table: "UserAndRoleMap",
                columns: new[] { "RoleId", "UserId", "CreateTime", "CreateUserId" },
                values: new object[] { new Guid("8c30a80d-d9af-79f6-9c1c-3a0156ed21ab"), new Guid("2cc6a543-1366-7b68-af40-3a0156ed21aa"), new DateTime(2022, 1, 11, 0, 9, 19, 531, DateTimeKind.Local).AddTicks(4699), new Guid("2cc6a543-1366-7b68-af40-3a0156ed21aa") });
        }
    }
}
