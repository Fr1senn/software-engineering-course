﻿using SoftwareEngineering.Models;

namespace SoftwareEngineering.Interfaces
{
    public interface IBookRepository
    {
        public Task<IEnumerable<BookDTO>> GetBooksAsync();
    }
}
