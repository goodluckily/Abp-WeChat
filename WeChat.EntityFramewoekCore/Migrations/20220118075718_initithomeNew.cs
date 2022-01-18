using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeChat.EntityFramewoekCore.Migrations
{
    public partial class initithomeNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserAndRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3a017e48-08d9-8d2c-bdb1-d37337bc97f0"), new Guid("3a017e48-08d8-0710-3d2b-ac20063814d1") });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3a017e48-08d9-8d2c-bdb1-d37337bc97f0"));

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: new Guid("3a017e48-08d8-0710-3d2b-ac20063814d1"));

            migrationBuilder.AddColumn<string>(
                name: "SubContent",
                table: "ItHomeblogs",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreateTime", "CreateUserId", "Description", "EditTime", "EditUserId", "IsActive", "IsDel", "Name" },
                values: new object[] { new Guid("3a017e5d-8955-6dc2-060c-c46dffa6277d"), new DateTime(2022, 1, 18, 15, 57, 17, 526, DateTimeKind.Local).AddTicks(29), new Guid("3a017e5d-8955-aa43-8a4e-5a73b83b547b"), "最高权限管理者", null, null, true, false, "管理者" });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "AvatarUrl", "CreateTime", "CreateUserId", "EditTime", "EditUserId", "Email", "IsActive", "IsDel", "LoginName", "NickName", "PassWrod", "Phone" },
                values: new object[] { new Guid("3a017e5d-8955-aa43-8a4e-5a73b83b547b"), null, new DateTime(2022, 1, 18, 15, 57, 17, 525, DateTimeKind.Local).AddTicks(7170), null, null, null, null, true, true, "admin", "管理员", "123456", null });

            migrationBuilder.InsertData(
                table: "UserAndRoleMap",
                columns: new[] { "RoleId", "UserId", "CreateTime", "CreateUserId" },
                values: new object[] { new Guid("3a017e5d-8955-6dc2-060c-c46dffa6277d"), new Guid("3a017e5d-8955-aa43-8a4e-5a73b83b547b"), new DateTime(2022, 1, 18, 15, 57, 17, 526, DateTimeKind.Local).AddTicks(1233), new Guid("3a017e5d-8955-aa43-8a4e-5a73b83b547b") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserAndRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3a017e5d-8955-6dc2-060c-c46dffa6277d"), new Guid("3a017e5d-8955-aa43-8a4e-5a73b83b547b") });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3a017e5d-8955-6dc2-060c-c46dffa6277d"));

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: new Guid("3a017e5d-8955-aa43-8a4e-5a73b83b547b"));

            migrationBuilder.DropColumn(
                name: "SubContent",
                table: "ItHomeblogs");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreateTime", "CreateUserId", "Description", "EditTime", "EditUserId", "IsActive", "IsDel", "Name" },
                values: new object[] { new Guid("3a017e48-08d9-8d2c-bdb1-d37337bc97f0"), new DateTime(2022, 1, 18, 15, 33, 48, 377, DateTimeKind.Local).AddTicks(5589), new Guid("3a017e48-08d8-0710-3d2b-ac20063814d1"), "最高权限管理者", null, null, true, false, "管理者" });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "AvatarUrl", "CreateTime", "CreateUserId", "EditTime", "EditUserId", "Email", "IsActive", "IsDel", "LoginName", "NickName", "PassWrod", "Phone" },
                values: new object[] { new Guid("3a017e48-08d8-0710-3d2b-ac20063814d1"), null, new DateTime(2022, 1, 18, 15, 33, 48, 377, DateTimeKind.Local).AddTicks(2944), null, null, null, null, true, true, "admin", "管理员", "123456", null });

            migrationBuilder.InsertData(
                table: "UserAndRoleMap",
                columns: new[] { "RoleId", "UserId", "CreateTime", "CreateUserId" },
                values: new object[] { new Guid("3a017e48-08d9-8d2c-bdb1-d37337bc97f0"), new Guid("3a017e48-08d8-0710-3d2b-ac20063814d1"), new DateTime(2022, 1, 18, 15, 33, 48, 377, DateTimeKind.Local).AddTicks(6638), new Guid("3a017e48-08d8-0710-3d2b-ac20063814d1") });
        }
    }
}
