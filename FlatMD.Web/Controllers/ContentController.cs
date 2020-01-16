using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FlatMD.Web.Models;
using FlatMD.Core.Services;

namespace FlatMD.Web.Controllers
{
    [Authorize]
    [Route("content")]
    public class ContentController : Controller
    {
        private readonly ILogger<ContentController> _logger;
        private readonly Books _books;

        public ContentController(ILogger<ContentController> logger, Books books)
        {
            _logger = logger;
            _books = books;
        }

        [Route("/")]
        public IActionResult Index()
        {
            var books = _books.GetBooks();
            return View();
        }

        [Route("{bookSlug}")]
        public IActionResult Book(string bookSlug)
        {
            var book = _books.GetBook(bookSlug);
            return View();
        }

        [Route("{bookSlug}/{pageSlug}")]
        public IActionResult Page(string bookSlug, string pageSlug)
        {
            return View();
        }
    }
}
