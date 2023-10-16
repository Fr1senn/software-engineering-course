using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftwareEngineering.Migrations
{
    /// <inheritdoc />
    public partial class books_author_book_id_delete_cascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "books_authors_book_id_fkey",
                table: "books_authors");

            migrationBuilder.AddForeignKey(
                name: "books_authors_book_id_fkey",
                table: "books_authors",
                column: "book_id",
                principalTable: "book",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "books_authors_book_id_fkey",
                table: "books_authors");

            migrationBuilder.AddForeignKey(
                name: "books_authors_book_id_fkey",
                table: "books_authors",
                column: "book_id",
                principalTable: "book",
                principalColumn: "id");
        }
    }
}
