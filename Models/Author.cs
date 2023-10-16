using System;
using System.Collections.Generic;

namespace SoftwareEngineering.Models;

public partial class Author
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public virtual ICollection<BooksAuthor> BooksAuthors { get; set; } = new List<BooksAuthor>();
}
