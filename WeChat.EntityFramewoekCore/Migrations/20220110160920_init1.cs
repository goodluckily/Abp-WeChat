using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeChat.EntityFramewoekCore.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserAndRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("29403342-2366-8911-12c6-3a0156e7bb02"), new Guid("a7cc7553-f685-7d44-7da0-3a0156e7bb02") });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("29403342-2366-8911-12c6-3a0156e7bb02"));

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: new Guid("a7cc7553-f685-7d44-7da0-3a0156e7bb02"));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Netcnblogs",
                type: "nvarchar(max)",
                nullable: true,
                comment: "标题",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Netcnblogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "标题");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreateTime", "CreateUserId", "Description", "EditTime", "EditUserId", "IsActive", "IsDel", "Name" },
                values: new object[] { new Guid("29403342-2366-8911-12c6-3a0156e7bb02"), new DateTime(2022, 1, 11, 0, 3, 25, 570, DateTimeKind.Local).AddTicks(7852), new Guid("a7cc7553-f685-7d44-7da0-3a0156e7bb02"), "最高权限管理者", null, null, true, false, "管理者" });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "AvatarUrl", "CreateTime", "CreateUserId", "EditTime", "EditUserId", "Email", "IsActive", "IsDel", "LoginName", "NickName", "PassWrod", "Phone" },
                values: new object[] { new Guid("a7cc7553-f685-7d44-7da0-3a0156e7bb02"), null, new DateTime(2022, 1, 11, 0, 3, 25, 570, DateTimeKind.Local).AddTicks(5435), null, null, null, null, true, true, "admin", "管理员", "123456", null });

            migrationBuilder.InsertData(
                table: "UserAndRoleMap",
                columns: new[] { "RoleId", "UserId", "CreateTime", "CreateUserId" },
                values: new object[] { new Guid("29403342-2366-8911-12c6-3a0156e7bb02"), new Guid("a7cc7553-f685-7d44-7da0-3a0156e7bb02"), new DateTime(2022, 1, 11, 0, 3, 25, 570, DateTimeKind.Local).AddTicks(9021), new Guid("a7cc7553-f685-7d44-7da0-3a0156e7bb02") });
        }
    }
}
