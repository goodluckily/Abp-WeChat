using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeChat.EntityFramewoekCore.Migrations
{
    public partial class localhost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreateTime", "CreateUserId", "Description", "EditTime", "EditUserId", "IsActive", "IsDel", "Name" },
                values: new object[] { new Guid("3a02bd7f-a674-2816-1cd0-323ae8b6e9f0"), new DateTime(2022, 3, 21, 15, 13, 25, 109, DateTimeKind.Local).AddTicks(877), new Guid("3a02bd7f-a674-1ee1-8ef9-9de81384a371"), "最高权限管理者", null, null, true, false, "管理者" });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "AvatarUrl", "CreateTime", "CreateUserId", "EditTime", "EditUserId", "Email", "IsActive", "IsDel", "LoginName", "NickName", "PassWrod", "Phone" },
                values: new object[] { new Guid("3a02bd7f-a674-1ee1-8ef9-9de81384a371"), null, new DateTime(2022, 3, 21, 15, 13, 25, 108, DateTimeKind.Local).AddTicks(8107), null, null, null, null, true, true, "admin", "管理员", "123456", null });

            migrationBuilder.InsertData(
                table: "UserAndRoleMap",
                columns: new[] { "RoleId", "UserId", "CreateTime", "CreateUserId" },
                values: new object[] { new Guid("3a02bd7f-a674-2816-1cd0-323ae8b6e9f0"), new Guid("3a02bd7f-a674-1ee1-8ef9-9de81384a371"), new DateTime(2022, 3, 21, 15, 13, 25, 109, DateTimeKind.Local).AddTicks(1996), new Guid("3a02bd7f-a674-1ee1-8ef9-9de81384a371") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserAndRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3a02bd7f-a674-2816-1cd0-323ae8b6e9f0"), new Guid("3a02bd7f-a674-1ee1-8ef9-9de81384a371") });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3a02bd7f-a674-2816-1cd0-323ae8b6e9f0"));

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: new Guid("3a02bd7f-a674-1ee1-8ef9-9de81384a371"));
        }
    }
}
