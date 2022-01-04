using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeChat.Host.Migrations
{
    public partial class initlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true, comment: "操作人"),
                    LogLevel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "日志等级"),
                    LogType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "日志类型"),
                    Logger = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MachineName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MachineIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NetRequestMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NetRequestUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NetUserIsauthenticated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NetUserAuthtype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NetUserIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Exception = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Token",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WeiChatType = table.Column<int>(type: "int", nullable: false),
                    TokenType = table.Column<int>(type: "int", nullable: false),
                    Access_Token = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "Token"),
                    Expires_In = table.Column<double>(type: "float", nullable: true, comment: "多少秒后失效"),
                    OperationTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "操作时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Token", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "Token");
        }
    }
}
