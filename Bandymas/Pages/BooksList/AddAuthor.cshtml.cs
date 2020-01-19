using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bandymas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bandymas.Pages.BooksList
{
    public class AddAuthorModel : PageModel
    {
        private BooksInfoContext _booksInfo;
        [BindProperty]
        public Author Author { get; set; }

        public AddAuthorModel(BooksInfoContext booksInfo)
        {
            _booksInfo = booksInfo;
        }
        public async Task<IActionResult> OnGet(int? authorId)
        {
            if (authorId.HasValue)
            {
                var author = await _booksInfo.AuthorsList.SingleOrDefaultAsync(a => a.Id == authorId.Value);
                Author = new Author { FirstName = author.FirstName, LastName = author.LastName };
            }
            else 
            {
                Author = new Author();
            }

            if (Author == null) 
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public async Task<IActionResult> OnPost(int? authorId) 
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            TempData["Message"] = "Author was saved";

            if (!authorId.HasValue)
            {
                var newAuthor = new AuthorInfo(Author.FirstName,Author.LastName);
                _booksInfo.Add(newAuthor);
                await _booksInfo.SaveChangesAsync();
            }
            return RedirectToPage("./AuthorsList");
        }
    }
}