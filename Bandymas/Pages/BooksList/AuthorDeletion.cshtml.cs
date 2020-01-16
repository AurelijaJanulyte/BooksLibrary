using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bandymas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bandymas.Pages.BooksList
{
    public class AuthorDeletionModel : PageModel
    {
        public AuthorInfo Author { get; set; }
        public Books Book { get; set; }

        private BooksInfoContext _infoContext;

        public AuthorDeletionModel(BooksInfoContext infoContext)
        {
            _infoContext = infoContext;
        }

        public IActionResult OnGet(int authorId) 
        {
            Author = _infoContext.AuthorsList.Single(a => a.Id == authorId);

            if (Book != null)
            {
                return RedirectToPage("./AuthorDetails");
            }
            return Page();
        }
        public IActionResult OnPost (int authorId)
        {
            Author = _infoContext.AuthorsList.Single(a=>a.Id==authorId);
            var book = _infoContext.BooksList.Any(b=>b.AuthorInfoId==authorId);

            if (book == false)
            {
                _infoContext.Remove(Author);
                _infoContext.SaveChanges();
            }

            else 
            {
                TempData["Message"] = $"{Author.Id} can't be deleted";

                return RedirectToPage("./AuthorDetails");
            }
            TempData["Message"] = $"{Author.FirstName} + {Author.LastName} was deleted";
            return RedirectToPage("./AuthorsList");
        }
    }
}