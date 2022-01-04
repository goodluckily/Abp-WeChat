using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeChat.Host.Migrations
{
    public partial class initusermaptto1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDel",
                table: "UserInfo",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "UserInfo",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDel",
                table: "Role",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<Guid>(
                name: "EditUserId",
                table: "Role",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreateUserId",
                table: "Role",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Role",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Role",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<bool>(
                name: "IsDel",
                table: "UserInfo",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "UserInfo",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDel",
                table: "Role",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EditUserId",
                table: "Role",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreateUserId",
                table: "Role",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Role",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Role",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }
    }
}
