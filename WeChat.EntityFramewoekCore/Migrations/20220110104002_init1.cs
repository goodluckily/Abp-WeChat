using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeChat.EntityFramewoekCore.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserAndRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9ad08a4d-b1c0-699e-f5e1-3a0155bdf4ac"), new Guid("12949c9f-b090-266f-7415-3a0155bdf4aa") });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("9ad08a4d-b1c0-699e-f5e1-3a0155bdf4ac"));

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: new Guid("12949c9f-b090-266f-7415-3a0155bdf4aa"));

            migrationBuilder.CreateTable(
                name: "Netcnblogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecommendNum = table.Column<int>(type: "int", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorManUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CommentNum = table.Column<int>(type: "int", nullable: true),
                    ReadNum = table.Column<int>(type: "int", nullable: true),
                    AnalyzingType = table.Column<int>(type: "int", nullable: true),
                    CreateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EditTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDel = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Netcnblogs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreateTime", "CreateUserId", "Description", "EditTime", "EditUserId", "IsActive", "IsDel", "Name" },
                values: new object[] { new Guid("e7a4e4ef-dba3-be9d-a68d-3a0155bfa525"), new DateTime(2022, 1, 10, 18, 40, 1, 317, DateTimeKind.Local).AddTicks(9179), new Guid("75e92c55-211c-e859-eba5-3a0155bfa525"), "最高权限管理者", null, null, true, false, "管理者" });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "AvatarUrl", "CreateTime", "CreateUserId", "EditTime", "EditUserId", "Email", "IsActive", "IsDel", "LoginName", "NickName", "PassWrod", "Phone" },
                values: new object[] { new Guid("75e92c55-211c-e859-eba5-3a0155bfa525"), null, new DateTime(2022, 1, 10, 18, 40, 1, 317, DateTimeKind.Local).AddTicks(6243), null, null, null, null, true, true, "admin", "管理员", "123456", null });

            migrationBuilder.InsertData(
                table: "UserAndRoleMap",
                columns: new[] { "RoleId", "UserId", "CreateTime", "CreateUserId" },
                values: new object[] { new Guid("e7a4e4ef-dba3-be9d-a68d-3a0155bfa525"), new Guid("75e92c55-211c-e859-eba5-3a0155bfa525"), new DateTime(2022, 1, 10, 18, 40, 1, 318, DateTimeKind.Local).AddTicks(470), new Guid("75e92c55-211c-e859-eba5-3a0155bfa525") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Netcnblogs");

            migrationBuilder.DeleteData(
                table: "UserAndRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e7a4e4ef-dba3-be9d-a68d-3a0155bfa525"), new Guid("75e92c55-211c-e859-eba5-3a0155bfa525") });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("e7a4e4ef-dba3-be9d-a68d-3a0155bfa525"));

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: new Guid("75e92c55-211c-e859-eba5-3a0155bfa525"));

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
        }
    }
}
