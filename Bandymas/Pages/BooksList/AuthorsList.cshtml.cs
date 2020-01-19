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
    public class AuthorListModel : PageModel
    {
        private BooksInfoContext _infoContext;
        public IEnumerable<AuthorInfo> Authors { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchedTerm { get; set; }

        public AuthorListModel(BooksInfoContext infoContext)
        {
            _infoContext = infoContext;
        }

        public async Task OnGet(string SearchedTerm )
        {
            if (string.IsNullOrWhiteSpace(SearchedTerm))
            {
                Authors = await _infoContext.AuthorsList.ToListAsync();
            }
            else 
            {
                Authors = await _infoContext.AuthorsList
                    .Where(a => a.FirstName.Contains(SearchedTerm, StringComparison.InvariantCultureIgnoreCase) ||
                           a.LastName.Contains(SearchedTerm, StringComparison.InvariantCultureIgnoreCase))
                    .ToListAsync();
            }
        }
    }
}