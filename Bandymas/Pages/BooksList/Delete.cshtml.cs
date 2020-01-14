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
    public class DeleteModel : PageModel
    {
        public Books Book { get; set; }
        private BooksInfoContext _booksInfoContext;
        public DeleteModel(BooksInfoContext booksInfoContext)
        {
            _booksInfoContext = booksInfoContext;
        }
        public IActionResult OnGet(int bookId)
        {
            Book = _booksInfoContext.BooksList.Single(b => b.Id==bookId);
            if (Book == null) 
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int bookId) 
        {
            var book = _booksInfoContext.BooksList.Single(b => b.Id == bookId);

            if (book != null)
            {
                _booksInfoContext.Remove(book);
                _booksInfoContext.SaveChanges();
            }
            else 
            {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"{book.Title} deleted";
            return RedirectToPage("./List");
        }
    }
}