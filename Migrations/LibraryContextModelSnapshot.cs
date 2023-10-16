﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SoftwareEngineering.Models;

#nullable disable

namespace SoftwareEngineering.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SoftwareEngineering.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("full_name");

                    b.HasKey("Id")
                        .HasName("author_pkey");

                    b.ToTable("author", (string)null);
                });

            modelBuilder.Entity("SoftwareEngineering.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("PublicationDate")
                        .HasColumnType("date")
                        .HasColumnName("publication_date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("book_pkey");

                    b.ToTable("book", (string)null);
                });

            modelBuilder.Entity("SoftwareEngineering.Models.BooksAuthor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AuthorId")
                        .HasColumnType("integer")
                        .HasColumnName("author_id");

                    b.Property<int?>("BookId")
                        .HasColumnType("integer")
                        .HasColumnName("book_id");

                    b.HasKey("Id")
                        .HasName("books_authors_pkey");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId");

                    b.ToTable("books_authors", (string)null);
                });

            modelBuilder.Entity("SoftwareEngineering.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("BookId")
                        .HasColumnType("integer")
                        .HasColumnName("book_id");

                    b.Property<DateOnly>("OrderDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("order_date")
                        .HasDefaultValueSql("CURRENT_DATE");

                    b.Property<int?>("ReaderId")
                        .HasColumnType("integer")
                        .HasColumnName("reader_id");

                    b.Property<DateOnly?>("RefundDate")
                        .HasColumnType("date")
                        .HasColumnName("refund_date");

                    b.HasKey("Id")
                        .HasName("order_pkey");

                    b.HasIndex("BookId");

                    b.HasIndex("ReaderId");

                    b.ToTable("order", (string)null);
                });

            modelBuilder.Entity("SoftwareEngineering.Models.Reader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date")
                        .HasColumnName("birth_date");

                    b.Property<string>("Education")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("education");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("full_name");

                    b.HasKey("Id")
                        .HasName("reader_pkey");

                    b.ToTable("reader", (string)null);
                });

            modelBuilder.Entity("SoftwareEngineering.Models.BooksAuthor", b =>
                {
                    b.HasOne("SoftwareEngineering.Models.Author", "Author")
                        .WithMany("BooksAuthors")
                        .HasForeignKey("AuthorId")
                        .HasConstraintName("books_authors_author_id_fkey");

                    b.HasOne("SoftwareEngineering.Models.Book", "Book")
                        .WithMany("BooksAuthors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("books_authors_book_id_fkey");

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("SoftwareEngineering.Models.Order", b =>
                {
                    b.HasOne("SoftwareEngineering.Models.Book", "Book")
                        .WithMany("Orders")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("order_book_id_fkey");

                    b.HasOne("SoftwareEngineering.Models.Reader", "Reader")
                        .WithMany("Orders")
                        .HasForeignKey("ReaderId")
                        .HasConstraintName("order_reader_id_fkey");

                    b.Navigation("Book");

                    b.Navigation("Reader");
                });

            modelBuilder.Entity("SoftwareEngineering.Models.Author", b =>
                {
                    b.Navigation("BooksAuthors");
                });

            modelBuilder.Entity("SoftwareEngineering.Models.Book", b =>
                {
                    b.Navigation("BooksAuthors");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("SoftwareEngineering.Models.Reader", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
