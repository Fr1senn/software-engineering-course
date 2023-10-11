using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftwareEngineering.Migrations
{
    /// <inheritdoc />
    public partial class order_book_id_on_delete_set_null : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "order_book_id_fkey",
                table: "order");

            migrationBuilder.AddForeignKey(
                name: "order_book_id_fkey",
                table: "order",
                column: "book_id",
                principalTable: "book",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "order_book_id_fkey",
                table: "order");

            migrationBuilder.AddForeignKey(
                name: "order_book_id_fkey",
                table: "order",
                column: "book_id",
                principalTable: "book",
                principalColumn: "id");
        }
    }
}
