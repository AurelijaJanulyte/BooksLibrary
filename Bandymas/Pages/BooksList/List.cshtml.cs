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
    public class ListModel : PageModel
    {
        private BooksInfoContext _booksInfoContext;
        public IEnumerable<Books> BooksOnScreen { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchedTerm { get; set; }
        public ListModel(BooksInfoContext booksInfoContext)
        {
            _booksInfoContext = booksInfoContext;
        }
        public void OnGet(string SearchedTerm)
        {
            if (string.IsNullOrWhiteSpace(SearchedTerm))
            {
                BooksOnScreen = _booksInfoContext.BooksList.Include(a=>a.AuthorInfo).ToList();
            }
            else
            {
                BooksOnScreen = _booksInfoContext.BooksList
                    .Include(b => b.AuthorInfo)
                    .Where(b => b.IBIN.ToString().Contains(SearchedTerm, StringComparison.InvariantCultureIgnoreCase) ||
                           b.Title.Contains(SearchedTerm, StringComparison.InvariantCultureIgnoreCase) ||
                           b.Type.ToString().Contains(SearchedTerm, StringComparison.InvariantCultureIgnoreCase) ||
                           b.AuthorInfo.FirstName.Contains(SearchedTerm, StringComparison.InvariantCultureIgnoreCase)||
                           b.AuthorInfo.LastName.Contains(SearchedTerm,StringComparison.InvariantCultureIgnoreCase))
                    .ToList();

            }
        }
    }
}
