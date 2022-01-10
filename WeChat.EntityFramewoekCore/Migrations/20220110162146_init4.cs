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
                keyValues: new object[] { new Guid("97eff0cb-892a-d839-92ed-3a0156f447db"), new Guid("79bcfd9a-9135-e863-e585-3a0156f447db") });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("97eff0cb-892a-d839-92ed-3a0156f447db"));

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: new Guid("79bcfd9a-9135-e863-e585-3a0156f447db"));

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Netcnblogs",
                newName: "SubContent");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreateTime", "CreateUserId", "Description", "EditTime", "EditUserId", "IsActive", "IsDel", "Name" },
                values: new object[] { new Guid("5faa5830-4e13-7be0-d51f-3a0156f88710"), new DateTime(2022, 1, 11, 0, 21, 46, 385, DateTimeKind.Local).AddTicks(755), new Guid("31e0f7bc-d09a-f371-9f7f-3a0156f88710"), "最高权限管理者", null, null, true, false, "管理者" });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "AvatarUrl", "CreateTime", "CreateUserId", "EditTime", "EditUserId", "Email", "IsActive", "IsDel", "LoginName", "NickName", "PassWrod", "Phone" },
                values: new object[] { new Guid("31e0f7bc-d09a-f371-9f7f-3a0156f88710"), null, new DateTime(2022, 1, 11, 0, 21, 46, 384, DateTimeKind.Local).AddTicks(8384), null, null, null, null, true, true, "admin", "管理员", "123456", null });

            migrationBuilder.InsertData(
                table: "UserAndRoleMap",
                columns: new[] { "RoleId", "UserId", "CreateTime", "CreateUserId" },
                values: new object[] { new Guid("5faa5830-4e13-7be0-d51f-3a0156f88710"), new Guid("31e0f7bc-d09a-f371-9f7f-3a0156f88710"), new DateTime(2022, 1, 11, 0, 21, 46, 385, DateTimeKind.Local).AddTicks(1743), new Guid("31e0f7bc-d09a-f371-9f7f-3a0156f88710") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserAndRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5faa5830-4e13-7be0-d51f-3a0156f88710"), new Guid("31e0f7bc-d09a-f371-9f7f-3a0156f88710") });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("5faa5830-4e13-7be0-d51f-3a0156f88710"));

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: new Guid("31e0f7bc-d09a-f371-9f7f-3a0156f88710"));

            migrationBuilder.RenameColumn(
                name: "SubContent",
                table: "Netcnblogs",
                newName: "Content");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreateTime", "CreateUserId", "Description", "EditTime", "EditUserId", "IsActive", "IsDel", "Name" },
                values: new object[] { new Guid("97eff0cb-892a-d839-92ed-3a0156f447db"), new DateTime(2022, 1, 11, 0, 17, 8, 59, DateTimeKind.Local).AddTicks(9126), new Guid("79bcfd9a-9135-e863-e585-3a0156f447db"), "最高权限管理者", null, null, true, false, "管理者" });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "AvatarUrl", "CreateTime", "CreateUserId", "EditTime", "EditUserId", "Email", "IsActive", "IsDel", "LoginName", "NickName", "PassWrod", "Phone" },
                values: new object[] { new Guid("79bcfd9a-9135-e863-e585-3a0156f447db"), null, new DateTime(2022, 1, 11, 0, 17, 8, 59, DateTimeKind.Local).AddTicks(6709), null, null, null, null, true, true, "admin", "管理员", "123456", null });

            migrationBuilder.InsertData(
                table: "UserAndRoleMap",
                columns: new[] { "RoleId", "UserId", "CreateTime", "CreateUserId" },
                values: new object[] { new Guid("97eff0cb-892a-d839-92ed-3a0156f447db"), new Guid("79bcfd9a-9135-e863-e585-3a0156f447db"), new DateTime(2022, 1, 11, 0, 17, 8, 60, DateTimeKind.Local).AddTicks(106), new Guid("79bcfd9a-9135-e863-e585-3a0156f447db") });
        }
    }
}
