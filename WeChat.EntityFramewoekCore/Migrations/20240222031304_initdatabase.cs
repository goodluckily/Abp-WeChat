using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeChat.EntityFramewoekCore.Migrations
{
    public partial class initdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cnblogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "标题"),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "主图"),
                    SubContent = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "文章简介"),
                    ContentUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "文章完整地址Url"),
                    RecommendNum = table.Column<int>(type: "int", nullable: true, comment: "推荐数"),
                    Author = table.Column<string>(type: "nvarchar(520)", maxLength: 520, nullable: true, comment: "作者"),
                    AuthorManUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "作者主页地址"),
                    ReleaseTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "发布时间"),
                    CommentNum = table.Column<int>(type: "int", nullable: true, comment: "评论数"),
                    ReadNum = table.Column<int>(type: "int", nullable: true, comment: "阅读数"),
                    AnalyzingType = table.Column<int>(type: "int", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDel = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cnblogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodeDeaultblogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "标题"),
                    ContentUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "文章完整地址Url"),
                    SubContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "发布时间"),
                    ReadNum = table.Column<int>(type: "int", nullable: true),
                    CommentNum = table.Column<int>(type: "int", nullable: true),
                    LikeNum = table.Column<int>(type: "int", nullable: true),
                    CollectionNum = table.Column<int>(type: "int", nullable: true),
                    AnalyzingType = table.Column<int>(type: "int", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDel = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeDeaultblogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Csdnblogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "标题"),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "主图"),
                    SubContent = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "文章简介"),
                    ContentUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "文章完整地址Url"),
                    Author = table.Column<string>(type: "nvarchar(520)", maxLength: 520, nullable: true, comment: "作者"),
                    AuthorManUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "作者主页地址"),
                    CreatedAt = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "创建"),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiggNum = table.Column<int>(type: "int", nullable: true, comment: "点赞数"),
                    CommentNum = table.Column<int>(type: "int", nullable: true, comment: "评论数"),
                    ReadNum = table.Column<int>(type: "int", nullable: true, comment: "阅读数"),
                    AnalyzingType = table.Column<int>(type: "int", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDel = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Csdnblogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CTO51blogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "标题"),
                    SubContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "文章完整地址Url"),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "主图"),
                    KeyWords = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "关键词"),
                    SourceType = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "来源类型"),
                    ReleaseTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "时间"),
                    AnalyzingType = table.Column<int>(type: "int", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDel = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTO51blogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItHomeblogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "标题"),
                    ContentUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "文章完整地址Url"),
                    SubContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "标签"),
                    TagsUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "标签地址"),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "主图"),
                    ReleaseTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "发布时间"),
                    AnalyzingType = table.Column<int>(type: "int", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDel = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItHomeblogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JueJinblogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "标题"),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "主图"),
                    SubContent = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "文章简介"),
                    ContentUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "文章完整地址Url"),
                    Author = table.Column<string>(type: "nvarchar(520)", maxLength: 520, nullable: true, comment: "作者"),
                    AuthorManUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "作者主页地址"),
                    ReleaseTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "发布时间"),
                    CommentNum = table.Column<int>(type: "int", nullable: true, comment: "评论数"),
                    GiveLikeNum = table.Column<int>(type: "int", nullable: true, comment: "点赞数"),
                    ReadNum = table.Column<int>(type: "int", nullable: true, comment: "阅读数"),
                    HotIndex = table.Column<double>(type: "float", nullable: true, comment: "热门系数"),
                    AnalyzingType = table.Column<int>(type: "int", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDel = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JueJinblogs", x => x.Id);
                });

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
                name: "OsChinablogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "标题"),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "主图"),
                    SubContent = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "文章简介"),
                    ContentUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "文章完整地址Url"),
                    Author = table.Column<string>(type: "nvarchar(520)", maxLength: 520, nullable: true, comment: "作者"),
                    AuthorManUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "作者主页地址"),
                    ReleaseTimeStr = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "时间"),
                    CommentNum = table.Column<int>(type: "int", nullable: true, comment: "评论数"),
                    ReadNum = table.Column<int>(type: "int", nullable: true, comment: "阅读数"),
                    LikeNum = table.Column<int>(type: "int", nullable: true, comment: "喜欢数"),
                    AnalyzingType = table.Column<int>(type: "int", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDel = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OsChinablogs", x => x.Id);
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
                name: "Segmentfaultblogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "标题"),
                    ContentUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "文章完整地址Url"),
                    Author = table.Column<string>(type: "nvarchar(520)", maxLength: 520, nullable: true, comment: "作者"),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "主图"),
                    AuthorManUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "作者主页地址"),
                    ReleaseTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "发布时间"),
                    DiggNum = table.Column<int>(type: "int", nullable: true, comment: "点赞数"),
                    CommentNum = table.Column<int>(type: "int", nullable: true, comment: "评论数"),
                    AnalyzingType = table.Column<int>(type: "int", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDel = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segmentfaultblogs", x => x.Id);
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

            migrationBuilder.CreateIndex(
                name: "IX_UserAndRoleMap_RoleId",
                table: "UserAndRoleMap",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cnblogs");

            migrationBuilder.DropTable(
                name: "CodeDeaultblogs");

            migrationBuilder.DropTable(
                name: "Csdnblogs");

            migrationBuilder.DropTable(
                name: "CTO51blogs");

            migrationBuilder.DropTable(
                name: "ItHomeblogs");

            migrationBuilder.DropTable(
                name: "JueJinblogs");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "OsChinablogs");

            migrationBuilder.DropTable(
                name: "Segmentfaultblogs");

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
