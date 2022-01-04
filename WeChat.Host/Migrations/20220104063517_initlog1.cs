using Microsoft.EntityFrameworkCore.Migrations;

namespace WeChat.Host.Migrations
{
    public partial class initlog1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NetUserAuthtype",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "NetUserIdentity",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "NetUserIsauthenticated",
                table: "Log");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NetUserAuthtype",
                table: "Log",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NetUserIdentity",
                table: "Log",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NetUserIsauthenticated",
                table: "Log",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
