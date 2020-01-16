using System;
using System.Collections.Generic;

namespace FlatMD.Core.Models
{
    public class Book
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public IEnumerable<Page> Pages { get; set; } 
    }
}