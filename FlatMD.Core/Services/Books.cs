using System.Linq;
using System.IO;
using System.Collections.Generic;
using FlatMD.Core.Models;
using Newtonsoft.Json;

namespace FlatMD.Core.Services
{
    public class Books
    {
        public IEnumerable<Book> GetBooks()
        {
            var books = new List<Book>();
            var dirs = Directory.GetDirectories(@"C:\Users\camil\dotnet\flatmd-dotnet-web\FlatMD.Web\wwwroot\content");
            foreach (var dir in dirs)
            {
                var json = File.ReadAllText(Path.Combine(dir, "data.json")); // TODO: check errors
                var book = JsonConvert.DeserializeObject<Book>(json);
                book.Slug = dir;
                books.Add(book);
            }

            return books;
        }
        
        public Book GetBook(string slug)
        {
            var bookPath = Path.Combine(@"C:\Users\camil\dotnet\flatmd-dotnet-web\FlatMD.Web\wwwroot\content", slug);
            var bookJson = File.ReadAllText(Path.Combine(bookPath, "data.json"));
            var book = JsonConvert.DeserializeObject<Book>(bookJson);

            var pages = new List<Page>();
            book.Pages = pages;
            book.Slug = slug;

            var pageDirs = Directory.GetDirectories(bookPath);
            foreach (var pageDir in pageDirs)
            {
                var pageJson = File.ReadAllText(Path.Combine(pageDir, "data.json"));
                var page = JsonConvert.DeserializeObject<Page>(pageJson);
                page.Slug = $"{book.Slug}/{pageDir.Split(Path.DirectorySeparatorChar).Last()}";
                pages.Add(page);
            }

            return book;
        }
    }
}