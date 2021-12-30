using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeChat.Host.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OperationTime",
                table: "Token",
                type: "datetime2",
                maxLength: 20,
                nullable: true,
                comment: "操作时间",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 20,
                oldComment: "操作时间");

            migrationBuilder.AlterColumn<double>(
                name: "Expires_In",
                table: "Token",
                type: "float",
                maxLength: 20,
                nullable: true,
                comment: "多少秒后失效",
                oldClrType: typeof(double),
                oldType: "float",
                oldMaxLength: 20,
                oldComment: "多少秒后失效");

            migrationBuilder.AlterColumn<string>(
                name: "Access_Token",
                table: "Token",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "Token",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "Token");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OperationTime",
                table: "Token",
                type: "datetime2",
                maxLength: 20,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "操作时间",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 20,
                oldNullable: true,
                oldComment: "操作时间");

            migrationBuilder.AlterColumn<double>(
                name: "Expires_In",
                table: "Token",
                type: "float",
                maxLength: 20,
                nullable: false,
                defaultValue: 0.0,
                comment: "多少秒后失效",
                oldClrType: typeof(double),
                oldType: "float",
                oldMaxLength: 20,
                oldNullable: true,
                oldComment: "多少秒后失效");

            migrationBuilder.AlterColumn<string>(
                name: "Access_Token",
                table: "Token",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                comment: "Token",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldComment: "Token");
        }
    }
}
