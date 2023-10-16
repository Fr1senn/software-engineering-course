﻿using System;
using System.Collections.Generic;

namespace SoftwareEngineering.Models;

public partial class BooksAuthor
{
    public int Id { get; set; }

    public int? BookId { get; set; }

    public int? AuthorId { get; set; }

    public virtual Author? Author { get; set; }

    public virtual Book? Book { get; set; }
}
