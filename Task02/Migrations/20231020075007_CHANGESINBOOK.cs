using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task02.Migrations
{
    /// <inheritdoc />
    public partial class CHANGESINBOOK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorsAuthor_Id",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorsAuthor_Id",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AuthorsAuthor_Id",
                table: "Books");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorsAuthor_Id",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorsAuthor_Id",
                table: "Books",
                column: "AuthorsAuthor_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorsAuthor_Id",
                table: "Books",
                column: "AuthorsAuthor_Id",
                principalTable: "Authors",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
