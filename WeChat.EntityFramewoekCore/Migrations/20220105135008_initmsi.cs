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
                keyValues: new object[] { new Guid("58b01bc6-b884-94e8-1692-3a013baf0c62"), new Guid("cb242ecc-19cf-b3d1-b9cc-3a013baf0c62") });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("58b01bc6-b884-94e8-1692-3a013baf0c62"));

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: new Guid("cb242ecc-19cf-b3d1-b9cc-3a013baf0c62"));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Active", "CreateTime", "CreateUserId", "Description", "EditTime", "EditUserId", "IsDel", "Name" },
                values: new object[] { new Guid("e5671a0a-984c-414f-b119-3a013cade57d"), true, new DateTime(2022, 1, 5, 21, 50, 7, 741, DateTimeKind.Local).AddTicks(2469), new Guid("8cdcc7fc-9e4c-d876-27b7-3a013cade57c"), "最高权限管理者", null, null, false, "管理者" });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "AvatarUrl", "CreateTime", "CreateUserId", "EditTime", "EditUserId", "Email", "IsActive", "IsDel", "LoginName", "NickName", "PassWrod", "Phone" },
                values: new object[] { new Guid("8cdcc7fc-9e4c-d876-27b7-3a013cade57c"), null, new DateTime(2022, 1, 5, 21, 50, 7, 740, DateTimeKind.Local).AddTicks(9588), null, null, null, null, true, true, "admin", "管理员", "123456", null });

            migrationBuilder.InsertData(
                table: "UserAndRoleMap",
                columns: new[] { "RoleId", "UserId", "CreateTime", "CreateUserId" },
                values: new object[] { new Guid("e5671a0a-984c-414f-b119-3a013cade57d"), new Guid("8cdcc7fc-9e4c-d876-27b7-3a013cade57c"), new DateTime(2022, 1, 5, 21, 50, 7, 741, DateTimeKind.Local).AddTicks(4230), new Guid("8cdcc7fc-9e4c-d876-27b7-3a013cade57c") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserAndRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e5671a0a-984c-414f-b119-3a013cade57d"), new Guid("8cdcc7fc-9e4c-d876-27b7-3a013cade57c") });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("e5671a0a-984c-414f-b119-3a013cade57d"));

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: new Guid("8cdcc7fc-9e4c-d876-27b7-3a013cade57c"));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Active", "CreateTime", "CreateUserId", "Description", "EditTime", "EditUserId", "IsDel", "Name" },
                values: new object[] { new Guid("58b01bc6-b884-94e8-1692-3a013baf0c62"), true, new DateTime(2022, 1, 5, 17, 11, 46, 18, DateTimeKind.Local).AddTicks(8922), new Guid("cb242ecc-19cf-b3d1-b9cc-3a013baf0c62"), "最高权限管理者", null, null, false, "管理者" });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "AvatarUrl", "CreateTime", "CreateUserId", "EditTime", "EditUserId", "Email", "IsActive", "IsDel", "LoginName", "NickName", "PassWrod", "Phone" },
                values: new object[] { new Guid("cb242ecc-19cf-b3d1-b9cc-3a013baf0c62"), null, new DateTime(2022, 1, 5, 17, 11, 46, 18, DateTimeKind.Local).AddTicks(4955), null, null, null, null, true, true, "admin", "管理员", "123456", null });

            migrationBuilder.InsertData(
                table: "UserAndRoleMap",
                columns: new[] { "RoleId", "UserId", "CreateTime", "CreateUserId" },
                values: new object[] { new Guid("58b01bc6-b884-94e8-1692-3a013baf0c62"), new Guid("cb242ecc-19cf-b3d1-b9cc-3a013baf0c62"), new DateTime(2022, 1, 5, 17, 11, 46, 19, DateTimeKind.Local).AddTicks(1408), new Guid("cb242ecc-19cf-b3d1-b9cc-3a013baf0c62") });
        }
    }
}
