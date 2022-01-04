using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeChat.Host.Migrations
{
    public partial class initusermaptto3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAndRoleMap_Role_RoleId",
                table: "UserAndRoleMap");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAndRoleMap_UserInfo_UserId",
                table: "UserAndRoleMap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAndRoleMap",
                table: "UserAndRoleMap");

            migrationBuilder.DeleteData(
                table: "UserAndRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("06cef685-e87c-4121-890c-89c6bae7b5bf"), new Guid("8e4fe282-a026-4181-b5a7-566780103908") });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("06cef685-e87c-4121-890c-89c6bae7b5bf"));

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: new Guid("8e4fe282-a026-4181-b5a7-566780103908"));

            migrationBuilder.RenameTable(
                name: "UserAndRoleMap",
                newName: "userAndRoleMaps");

            migrationBuilder.RenameIndex(
                name: "IX_UserAndRoleMap_RoleId",
                table: "userAndRoleMaps",
                newName: "IX_userAndRoleMaps_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userAndRoleMaps",
                table: "userAndRoleMaps",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Active", "CreateTime", "CreateUserId", "Description", "EditTime", "EditUserId", "IsDel", "Name" },
                values: new object[] { new Guid("ede49525-ba2c-46a5-ae4c-07f38dd66f3a"), true, new DateTime(2022, 1, 4, 23, 48, 5, 945, DateTimeKind.Local).AddTicks(443), new Guid("cb36b856-f100-4743-aac0-0c0fd6f931cd"), "最高权限管理者", null, null, false, "管理者" });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "AvatarUrl", "CreateTime", "CreateUserId", "EditTime", "EditUserId", "Email", "IsActive", "IsDel", "LoginName", "NickName", "PassWrod", "Phone" },
                values: new object[] { new Guid("cb36b856-f100-4743-aac0-0c0fd6f931cd"), null, new DateTime(2022, 1, 4, 23, 48, 5, 944, DateTimeKind.Local).AddTicks(7938), null, null, null, null, true, true, "admin", "管理员", "123456", null });

            migrationBuilder.InsertData(
                table: "userAndRoleMaps",
                columns: new[] { "RoleId", "UserId", "CreateTime", "CreateUserId" },
                values: new object[] { new Guid("ede49525-ba2c-46a5-ae4c-07f38dd66f3a"), new Guid("cb36b856-f100-4743-aac0-0c0fd6f931cd"), new DateTime(2022, 1, 4, 23, 48, 5, 945, DateTimeKind.Local).AddTicks(2185), new Guid("cb36b856-f100-4743-aac0-0c0fd6f931cd") });

            migrationBuilder.AddForeignKey(
                name: "FK_userAndRoleMaps_Role_RoleId",
                table: "userAndRoleMaps",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userAndRoleMaps_UserInfo_UserId",
                table: "userAndRoleMaps",
                column: "UserId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userAndRoleMaps_Role_RoleId",
                table: "userAndRoleMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_userAndRoleMaps_UserInfo_UserId",
                table: "userAndRoleMaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userAndRoleMaps",
                table: "userAndRoleMaps");

            migrationBuilder.DeleteData(
                table: "userAndRoleMaps",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ede49525-ba2c-46a5-ae4c-07f38dd66f3a"), new Guid("cb36b856-f100-4743-aac0-0c0fd6f931cd") });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("ede49525-ba2c-46a5-ae4c-07f38dd66f3a"));

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: new Guid("cb36b856-f100-4743-aac0-0c0fd6f931cd"));

            migrationBuilder.RenameTable(
                name: "userAndRoleMaps",
                newName: "UserAndRoleMap");

            migrationBuilder.RenameIndex(
                name: "IX_userAndRoleMaps_RoleId",
                table: "UserAndRoleMap",
                newName: "IX_UserAndRoleMap_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAndRoleMap",
                table: "UserAndRoleMap",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Active", "CreateTime", "CreateUserId", "Description", "EditTime", "EditUserId", "IsDel", "Name" },
                values: new object[] { new Guid("06cef685-e87c-4121-890c-89c6bae7b5bf"), true, new DateTime(2022, 1, 4, 22, 42, 27, 399, DateTimeKind.Local).AddTicks(6942), new Guid("8e4fe282-a026-4181-b5a7-566780103908"), "最高权限管理者", null, null, false, "管理者" });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "AvatarUrl", "CreateTime", "CreateUserId", "EditTime", "EditUserId", "Email", "IsActive", "IsDel", "LoginName", "NickName", "PassWrod", "Phone" },
                values: new object[] { new Guid("8e4fe282-a026-4181-b5a7-566780103908"), null, new DateTime(2022, 1, 4, 22, 42, 27, 399, DateTimeKind.Local).AddTicks(4564), null, null, null, null, true, true, "admin", "管理员", "123456", null });

            migrationBuilder.InsertData(
                table: "UserAndRoleMap",
                columns: new[] { "RoleId", "UserId", "CreateTime", "CreateUserId" },
                values: new object[] { new Guid("06cef685-e87c-4121-890c-89c6bae7b5bf"), new Guid("8e4fe282-a026-4181-b5a7-566780103908"), new DateTime(2022, 1, 4, 22, 42, 27, 399, DateTimeKind.Local).AddTicks(8603), new Guid("8e4fe282-a026-4181-b5a7-566780103908") });

            migrationBuilder.AddForeignKey(
                name: "FK_UserAndRoleMap_Role_RoleId",
                table: "UserAndRoleMap",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAndRoleMap_UserInfo_UserId",
                table: "UserAndRoleMap",
                column: "UserId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
