using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bandymas.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bandymas.Pages.BooksList
{
    public class ListModel : PageModel
    {
        private BooksInfoContext _booksInfoContext;
        public IEnumerable<Books> BooksOnScreen { get; set; }
        public ListModel(BooksInfoContext booksInfoContext)
        {
            _booksInfoContext = booksInfoContext;
        }
        public void OnGet()
        {
            BooksOnScreen = _booksInfoContext.BooksList.ToList();
        }
    }
}
