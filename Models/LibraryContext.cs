using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SoftwareEngineering.Models;

public partial class LibraryContext : DbContext
{
    private readonly IConfiguration? _configuration;

    public LibraryContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
    {
    }

    public LibraryContext(DbContextOptions<LibraryContext> options, IConfiguration configuration) :
        base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BooksAuthor> BooksAuthors { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Reader> Readers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseNpgsql(_configuration?.GetConnectionString("dbConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("author_pkey");

            entity.ToTable("author");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FullName)
                .HasMaxLength(150)
                .HasColumnName("full_name");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("book_pkey");

            entity.ToTable("book");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PublicationDate).HasColumnName("publication_date");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
        });

        modelBuilder.Entity<BooksAuthor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("books_authors_pkey");

            entity.ToTable("books_authors");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.BookId).HasColumnName("book_id");

            entity.HasOne(d => d.Author).WithMany(p => p.BooksAuthors)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("books_authors_author_id_fkey");

            entity.HasOne(d => d.Book).WithMany(p => p.BooksAuthors)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("books_authors_book_id_fkey");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("order_pkey");

            entity.ToTable("order");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("order_date");
            entity.Property(e => e.ReaderId).HasColumnName("reader_id");
            entity.Property(e => e.RefundDate).HasColumnName("refund_date");

            entity.HasOne(d => d.Book).WithMany(p => p.Orders)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("order_book_id_fkey");

            entity.HasOne(d => d.Reader).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ReaderId)
                .HasConstraintName("order_reader_id_fkey");
        });

        modelBuilder.Entity<Reader>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("reader_pkey");

            entity.ToTable("reader");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.Education)
                .HasMaxLength(100)
                .HasColumnName("education");
            entity.Property(e => e.FullName)
                .HasMaxLength(150)
                .HasColumnName("full_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
