using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bandymas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        public void OnGet(string SearchedTerm )
        {
            if (string.IsNullOrWhiteSpace(SearchedTerm))
            {
                Authors = _infoContext.AuthorsList.ToList();
            }
            else 
            {
                Authors = _infoContext.AuthorsList
                    .Where(a => a.FirstName.Contains(SearchedTerm, StringComparison.InvariantCultureIgnoreCase) ||
                           a.LastName.Contains(SearchedTerm, StringComparison.InvariantCultureIgnoreCase))
                    .ToList();
            }
        }
    }
}