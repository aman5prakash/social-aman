using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backEnd.Migrations
{
    public partial class newsocialdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category_table",
                columns: table => new
                {
                    topic_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    topic_name = table.Column<string>(nullable: true),
                    topic_image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category_table", x => x.topic_id);
                });

            migrationBuilder.CreateTable(
                name: "user_table",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    user_name = table.Column<string>(nullable: true),
                    user_image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_table", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "post_table",
                columns: table => new
                {
                    post_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    topic_id = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    posts = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post_table", x => x.post_id);
                    table.ForeignKey(
                        name: "FK_post_table_category_table_topic_id",
                        column: x => x.topic_id,
                        principalTable: "category_table",
                        principalColumn: "topic_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_post_table_user_table_user_id",
                        column: x => x.user_id,
                        principalTable: "user_table",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comments_table",
                columns: table => new
                {
                    comment_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(nullable: false),
                    post_id = table.Column<int>(nullable: false),
                    comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments_table", x => x.comment_id);
                    table.ForeignKey(
                        name: "FK_comments_table_post_table_post_id",
                        column: x => x.post_id,
                        principalTable: "post_table",
                        principalColumn: "post_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comments_table_user_table_user_id",
                        column: x => x.user_id,
                        principalTable: "user_table",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comments_table_post_id",
                table: "comments_table",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "IX_comments_table_user_id",
                table: "comments_table",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_post_table_topic_id",
                table: "post_table",
                column: "topic_id");

            migrationBuilder.CreateIndex(
                name: "IX_post_table_user_id",
                table: "post_table",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comments_table");

            migrationBuilder.DropTable(
                name: "post_table");

            migrationBuilder.DropTable(
                name: "category_table");

            migrationBuilder.DropTable(
                name: "user_table");
        }
    }
}
