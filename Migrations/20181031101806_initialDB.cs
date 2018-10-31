using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backEnd.Migrations
{
    public partial class initialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TopicT",
                columns: table => new
                {
                    topic_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    topic_name = table.Column<string>(nullable: true),
                    topic_image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicT", x => x.topic_id);
                });

            migrationBuilder.CreateTable(
                name: "UserT",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    user_name = table.Column<string>(nullable: true),
                    user_image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserT", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "PostT",
                columns: table => new
                {
                    post_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    posts = table.Column<string>(nullable: true),
                    TopicForeignKey = table.Column<int>(nullable: false),
                    UserForeignKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostT", x => x.post_id);
                    table.ForeignKey(
                        name: "FK_PostT_TopicT_TopicForeignKey",
                        column: x => x.TopicForeignKey,
                        principalTable: "TopicT",
                        principalColumn: "topic_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostT_UserT_UserForeignKey",
                        column: x => x.UserForeignKey,
                        principalTable: "UserT",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommentT",
                columns: table => new
                {
                    comment_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    comment = table.Column<string>(nullable: true),
                    PostForeignKey = table.Column<int>(nullable: false),
                    UsercomForeignKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentT", x => x.comment_id);
                    table.ForeignKey(
                        name: "FK_CommentT_PostT_PostForeignKey",
                        column: x => x.PostForeignKey,
                        principalTable: "PostT",
                        principalColumn: "post_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentT_UserT_UsercomForeignKey",
                        column: x => x.UsercomForeignKey,
                        principalTable: "UserT",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentT_PostForeignKey",
                table: "CommentT",
                column: "PostForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_CommentT_UsercomForeignKey",
                table: "CommentT",
                column: "UsercomForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_PostT_TopicForeignKey",
                table: "PostT",
                column: "TopicForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_PostT_UserForeignKey",
                table: "PostT",
                column: "UserForeignKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentT");

            migrationBuilder.DropTable(
                name: "PostT");

            migrationBuilder.DropTable(
                name: "TopicT");

            migrationBuilder.DropTable(
                name: "UserT");
        }
    }
}
