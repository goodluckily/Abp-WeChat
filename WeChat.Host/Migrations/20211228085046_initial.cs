using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeChat.Host.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TokenLapse",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Access_Token = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, comment: "Token")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expires_In = table.Column<int>(type: "int", maxLength: 20, nullable: false, comment: "多少秒后失效"),
                    OperationTime = table.Column<DateTime>(type: "datetime(6)", maxLength: 20, nullable: false, comment: "操作时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenLapse", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TokenLapse");
        }
    }
}
