using System;
using LibSis.Domain.Core.Models;

namespace LibSis.Domain.Models
{
    public class Book : Entity
    {
        public Book(Guid id, string name, string author)
        {
            Id = id;
            Name = name;
            Author = author;
        }

        // Empty constructor for EF
        protected Book() { }

        public string Name { get; private set; }

        public string Author { get; private set; }
    }
}