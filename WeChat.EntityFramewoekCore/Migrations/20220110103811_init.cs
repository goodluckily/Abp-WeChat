using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeChat.EntityFramewoekCore.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "操作人"),
                    LogLevel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "日志等级"),
                    LogType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "日志类型"),
                    Logger = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MachineName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MachineIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NetRequestMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NetRequestUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Exception = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true, comment: "说明"),
                    CreateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EditTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDel = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PassWrod = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    AvatarUrl = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true, comment: "头像Url地址"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EditTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDel = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAndRoleMap",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAndRoleMap", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserAndRoleMap_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAndRoleMap_UserInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreateTime", "CreateUserId", "Description", "EditTime", "EditUserId", "IsActive", "IsDel", "Name" },
                values: new object[] { new Guid("9ad08a4d-b1c0-699e-f5e1-3a0155bdf4ac"), new DateTime(2022, 1, 10, 18, 38, 10, 604, DateTimeKind.Local).AddTicks(3270), new Guid("12949c9f-b090-266f-7415-3a0155bdf4aa"), "最高权限管理者", null, null, true, false, "管理者" });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "AvatarUrl", "CreateTime", "CreateUserId", "EditTime", "EditUserId", "Email", "IsActive", "IsDel", "LoginName", "NickName", "PassWrod", "Phone" },
                values: new object[] { new Guid("12949c9f-b090-266f-7415-3a0155bdf4aa"), null, new DateTime(2022, 1, 10, 18, 38, 10, 603, DateTimeKind.Local).AddTicks(2196), null, null, null, null, true, true, "admin", "管理员", "123456", null });

            migrationBuilder.InsertData(
                table: "UserAndRoleMap",
                columns: new[] { "RoleId", "UserId", "CreateTime", "CreateUserId" },
                values: new object[] { new Guid("9ad08a4d-b1c0-699e-f5e1-3a0155bdf4ac"), new Guid("12949c9f-b090-266f-7415-3a0155bdf4aa"), new DateTime(2022, 1, 10, 18, 38, 10, 604, DateTimeKind.Local).AddTicks(4704), new Guid("12949c9f-b090-266f-7415-3a0155bdf4aa") });

            migrationBuilder.CreateIndex(
                name: "IX_UserAndRoleMap_RoleId",
                table: "UserAndRoleMap",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "Token");

            migrationBuilder.DropTable(
                name: "UserAndRoleMap");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "UserInfo");
        }
    }
}
