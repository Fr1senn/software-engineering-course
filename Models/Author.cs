using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SoftwareEngineering.Models;

public partial class Author
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<BooksAuthor> BooksAuthors { get; set; } = new List<BooksAuthor>();
}
