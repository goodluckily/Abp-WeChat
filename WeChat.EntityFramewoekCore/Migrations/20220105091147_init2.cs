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
                keyValues: new object[] { new Guid("3b06ea55-9997-a7b4-effa-3a013b7ee4c6"), new Guid("8db61cfc-c0f7-fcc9-7b83-3a013b7ee4c5") });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3b06ea55-9997-a7b4-effa-3a013b7ee4c6"));

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: new Guid("8db61cfc-c0f7-fcc9-7b83-3a013b7ee4c5"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("3b06ea55-9997-a7b4-effa-3a013b7ee4c6"), true, new DateTime(2022, 1, 5, 16, 19, 10, 154, DateTimeKind.Local).AddTicks(3504), new Guid("8db61cfc-c0f7-fcc9-7b83-3a013b7ee4c5"), "最高权限管理者", null, null, false, "管理者" });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "AvatarUrl", "CreateTime", "CreateUserId", "EditTime", "EditUserId", "Email", "IsActive", "IsDel", "LoginName", "NickName", "PassWrod", "Phone" },
                values: new object[] { new Guid("8db61cfc-c0f7-fcc9-7b83-3a013b7ee4c5"), null, new DateTime(2022, 1, 5, 16, 19, 10, 150, DateTimeKind.Local).AddTicks(6479), null, null, null, null, true, true, "admin", "管理员", "123456", null });

            migrationBuilder.InsertData(
                table: "UserAndRoleMap",
                columns: new[] { "RoleId", "UserId", "CreateTime", "CreateUserId" },
                values: new object[] { new Guid("3b06ea55-9997-a7b4-effa-3a013b7ee4c6"), new Guid("8db61cfc-c0f7-fcc9-7b83-3a013b7ee4c5"), new DateTime(2022, 1, 5, 16, 19, 10, 154, DateTimeKind.Local).AddTicks(6244), new Guid("8db61cfc-c0f7-fcc9-7b83-3a013b7ee4c5") });
        }
    }
}
