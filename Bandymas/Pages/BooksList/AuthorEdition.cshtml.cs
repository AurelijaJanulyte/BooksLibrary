using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bandymas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bandymas.Pages.BooksList
{
    public class AuthorEditionModel : PageModel
    {
        private BooksInfoContext _infoContext;
        
        [BindProperty]
        public Author Author { get; set; }
        public AuthorEditionModel(BooksInfoContext infoContext)
        {
            _infoContext = infoContext;
        }
        public IActionResult OnGet(int authorId)
        {
            var author = _infoContext.AuthorsList.SingleOrDefault(a => a.Id == authorId);
            Author = new Author{FirstName=author.FirstName, LastName=author.LastName};

            return Page();
        }

        public IActionResult OnPost(int authorId) 
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            TempData["Message"] = "Author was saved";
            var author = _infoContext.AuthorsList.Single(a=>a.Id==authorId);
            author.FirstName = Author.FirstName;
            author.LastName = Author.LastName;
            _infoContext.SaveChanges();

            return RedirectToPage("./AuthorDetails");
        }
    }
}