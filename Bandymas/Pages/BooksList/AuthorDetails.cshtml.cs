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
    public class AuthorDetailsModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        BooksInfoContext _infoContext { get; set; }
        public AuthorInfo Author { get; set; }

        public AuthorDetailsModel(BooksInfoContext infoContext)
        {
            _infoContext = infoContext;
        }
        public async Task OnGet(int authorId)
        {
            Author = await _infoContext.AuthorsList.SingleOrDefaultAsync(a=>a.Id==authorId);
        }
    }
}