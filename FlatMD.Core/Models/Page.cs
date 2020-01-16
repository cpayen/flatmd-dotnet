using System;

namespace FlatMD.Core.Models
{
    public class Page
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public Book Book { get; set; } 
    }
}