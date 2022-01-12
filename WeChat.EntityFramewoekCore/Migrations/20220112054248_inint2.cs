using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeChat.EntityFramewoekCore.Migrations
{
    public partial class inint2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserAndRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b4dc44d6-d2f8-02a2-29d8-3a015be224fa"), new Guid("a3141077-4b48-e8bd-cf1b-3a015be224f9") });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b4dc44d6-d2f8-02a2-29d8-3a015be224fa"));

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: new Guid("a3141077-4b48-e8bd-cf1b-3a015be224f9"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreateTime", "CreateUserId", "Description", "EditTime", "EditUserId", "IsActive", "IsDel", "Name" },
                values: new object[] { new Guid("b4dc44d6-d2f8-02a2-29d8-3a015be224fa"), new DateTime(2022, 1, 11, 23, 15, 25, 562, DateTimeKind.Local).AddTicks(3808), new Guid("a3141077-4b48-e8bd-cf1b-3a015be224f9"), "最高权限管理者", null, null, true, false, "管理者" });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "AvatarUrl", "CreateTime", "CreateUserId", "EditTime", "EditUserId", "Email", "IsActive", "IsDel", "LoginName", "NickName", "PassWrod", "Phone" },
                values: new object[] { new Guid("a3141077-4b48-e8bd-cf1b-3a015be224f9"), null, new DateTime(2022, 1, 11, 23, 15, 25, 562, DateTimeKind.Local).AddTicks(1318), null, null, null, null, true, true, "admin", "管理员", "123456", null });

            migrationBuilder.InsertData(
                table: "UserAndRoleMap",
                columns: new[] { "RoleId", "UserId", "CreateTime", "CreateUserId" },
                values: new object[] { new Guid("b4dc44d6-d2f8-02a2-29d8-3a015be224fa"), new Guid("a3141077-4b48-e8bd-cf1b-3a015be224f9"), new DateTime(2022, 1, 11, 23, 15, 25, 562, DateTimeKind.Local).AddTicks(4860), new Guid("a3141077-4b48-e8bd-cf1b-3a015be224f9") });
        }
    }
}
