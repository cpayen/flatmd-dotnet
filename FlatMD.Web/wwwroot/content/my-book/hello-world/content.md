# Hello World

It is a post...  

<div>
![Image alt text](/my-book/hello-world/medias/sample-1.jpg "Image title")
</div>

<pre>
<code class="go">
func handleHomeRequest(c *gin.Context) {
    books := data.GetBooks()

    c.HTML(http.StatusOK, "home", gin.H{
        "PageTitle":       "Welcome",
        "PageDescription": "Welcome to gomd",
        "Books":           books,
    })
}
</code>
</pre>

<pre>
<code class="csharp">
public async Task<Book> CreateAsync(CreateBookCommand cmd)
{
    if(!cmd.IsValid)
    {
        throw new InvalidCommandException(nameof(CreateBookCommand), cmd);
    }

    var book = new Book
    {
        Title = cmd.Title,
        Slug = await GetUniqueSlugAsync(cmd.Slug),
        Description = cmd.Description,
        ReadAccess = cmd.ReadAccess,
        WriteAccess = cmd.WriteAccess,
        Owner = await _auth.GetCurrentUserEntityAsync(),
        CreatedAt = DateTime.Now
    };

    _unitOfWork.BookRepository.Create(book);
    await _unitOfWork.SaveAsync();
    
    return book;
}
</code>
</pre>