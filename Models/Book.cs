using System;
using System.Collections.Generic;

namespace SoftwareEngineering.Models;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public DateOnly PublicationDate { get; set; }

    public virtual ICollection<BooksAuthor> BooksAuthors { get; set; } = new List<BooksAuthor>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
