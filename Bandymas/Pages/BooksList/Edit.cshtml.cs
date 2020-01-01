using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bandymas.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bandymas.Pages.BooksList
{
    public class EditModel : PageModel
    {
        private BooksInfoContext _infoContext;
        public Books Book { get; set; }
        public EditModel(BooksInfoContext infoContext)
        {
            _infoContext = infoContext;
        }
        public IActionResult OnGet(int bookId)
        {
            Book = _infoContext.BooksList.Single(b=>b.Id==bookId);
            if (Book == null) 
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }
    }
}