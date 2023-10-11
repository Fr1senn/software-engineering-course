using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SoftwareEngineering.Migrations
{
    /// <inheritdoc />
    public partial class initial_migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "author",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("author_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "book",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    publication_date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("book_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "reader",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    birth_date = table.Column<DateOnly>(type: "date", nullable: false),
                    education = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("reader_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "books_authors",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    book_id = table.Column<int>(type: "integer", nullable: true),
                    author_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("books_authors_pkey", x => x.id);
                    table.ForeignKey(
                        name: "books_authors_author_id_fkey",
                        column: x => x.author_id,
                        principalTable: "author",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "books_authors_book_id_fkey",
                        column: x => x.book_id,
                        principalTable: "book",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_date = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "CURRENT_DATE"),
                    refund_date = table.Column<DateOnly>(type: "date", nullable: true),
                    reader_id = table.Column<int>(type: "integer", nullable: true),
                    book_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("order_pkey", x => x.id);
                    table.ForeignKey(
                        name: "order_book_id_fkey",
                        column: x => x.book_id,
                        principalTable: "book",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "order_reader_id_fkey",
                        column: x => x.reader_id,
                        principalTable: "reader",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_authors_author_id",
                table: "books_authors",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_books_authors_book_id",
                table: "books_authors",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_book_id",
                table: "order",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_reader_id",
                table: "order",
                column: "reader_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books_authors");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "author");

            migrationBuilder.DropTable(
                name: "book");

            migrationBuilder.DropTable(
                name: "reader");
        }
    }
}
