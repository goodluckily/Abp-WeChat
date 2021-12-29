using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeChat.Host.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TokenLapse",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Access_Token = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Token"),
                    Expires_In = table.Column<int>(type: "int", maxLength: 20, nullable: false, comment: "多少秒后失效"),
                    OperationTime = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false, comment: "操作时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenLapse", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TokenLapse");
        }
    }
}
