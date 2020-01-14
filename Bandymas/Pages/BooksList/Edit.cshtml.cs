using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bandymas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bandymas.Pages.BooksList
{
    public class EditModel : PageModel
    {
        private BooksInfoContext _infoContext;
        private IHtmlHelper _htmlHelper;

        [BindProperty]
        public BookToUpdate Book { get; set; }
        [BindProperty]
        public IEnumerable<SelectListItem> Authors { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; }
        public EditModel(BooksInfoContext infoContext,
                         IHtmlHelper htmlHelper)
        {
            _infoContext = infoContext;
            _htmlHelper = htmlHelper;

            Types = _htmlHelper.GetEnumSelectList<BookType>();
        }

        public IActionResult OnGet(int? bookId)
        {
            Authors = _infoContext.AuthorsList.ToList()
                   .Select(a => new SelectListItem { Value = a.Id.ToString(), Text = $"{a.FirstName} {a.LastName}" });

            if (bookId.HasValue)
            {
                var book = _infoContext.BooksList.SingleOrDefault(b => b.Id == bookId.Value);
                Book = new BookToUpdate { IBIN = book.IBIN, Title = book.Title, Type = book.Type, AuthorId=book.AuthorInfoId};
            }
            else
            {
                Book = new BookToUpdate();
            }

            if (Book == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(int? bookId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            TempData["Message"] = "Book was saved";

            if (bookId.HasValue)
            {
                var book = _infoContext.BooksList.Include(a=>a.AuthorInfo).Single(b => b.Id == bookId);
                book.IBIN = Book.IBIN.Value;
                book.Title = Book.Title;
                book.Type = Book.Type.Value;
                book.AuthorInfoId = Book.AuthorId;
                _infoContext.SaveChanges();

                return RedirectToPage("./Detail", new { bookId });

            }
            else
            {
                var newBook = new Books(Book.IBIN.Value, Book.Title, Book.Type.Value,Book.AuthorId);
                _infoContext.Add(newBook);
                _infoContext.SaveChanges();

                return RedirectToPage("./Detail", new { bookId = newBook.Id });
            }
        }
    }
}