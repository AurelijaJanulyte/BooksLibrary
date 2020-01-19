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
    public class DetailModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        BooksInfoContext _infoContext { get; set; }
        public Books Book { get; set; }

        public DetailModel(BooksInfoContext infoContext)
        {
            _infoContext = infoContext;
        }

        public async Task OnGet(int bookId)
        {
            Book = await _infoContext.BooksList
                .Include(a=>a.AuthorInfo)
                .SingleOrDefaultAsync(b => b.Id == bookId);
        }
    }
}