using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bandymas.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bandymas.Pages.BooksList
{
    public class DetailModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        BooksInfoContext _infoContext { get; set; }
        public DetailModel(BooksInfoContext infoContext)
        {
            _infoContext = infoContext;
        }
        public Books Book { get; set; }
        public void OnGet(int bookId)
        {
            Book = _infoContext.BooksList.SingleOrDefault(b => b.Id == bookId);
        }
    }
}