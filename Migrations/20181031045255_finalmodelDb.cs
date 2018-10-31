using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backEnd.Migrations
{
    public partial class finalmodelDb : Migration
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
                    posts = table.Column<string>(nullable: true),
                    CategoryForeignKey = table.Column<int>(nullable: false),
                    UserForeignKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post_table", x => x.post_id);
                    table.ForeignKey(
                        name: "FK_post_table_category_table_CategoryForeignKey",
                        column: x => x.CategoryForeignKey,
                        principalTable: "category_table",
                        principalColumn: "topic_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_post_table_user_table_UserForeignKey",
                        column: x => x.UserForeignKey,
                        principalTable: "user_table",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "comments_table",
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
                    table.PrimaryKey("PK_comments_table", x => x.comment_id);
                    table.ForeignKey(
                        name: "FK_comments_table_post_table_PostForeignKey",
                        column: x => x.PostForeignKey,
                        principalTable: "post_table",
                        principalColumn: "post_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comments_table_user_table_UsercomForeignKey",
                        column: x => x.UsercomForeignKey,
                        principalTable: "user_table",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comments_table_PostForeignKey",
                table: "comments_table",
                column: "PostForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_comments_table_UsercomForeignKey",
                table: "comments_table",
                column: "UsercomForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_post_table_CategoryForeignKey",
                table: "post_table",
                column: "CategoryForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_post_table_UserForeignKey",
                table: "post_table",
                column: "UserForeignKey");
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
