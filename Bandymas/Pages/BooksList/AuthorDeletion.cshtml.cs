using Bandymas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Bandymas.Pages.BooksList
{
    public class AuthorDeletionModel : PageModel
    {
        public AuthorInfo Author { get; set; }

        public Books Book { get; set; }

        private BooksInfoContext _infoContext;

        public AuthorDeletionModel(BooksInfoContext infoContext)
        {
            _infoContext = infoContext;
        }

        public async Task<IActionResult> OnGet(int authorId) 
        {
            Author = await _infoContext.AuthorsList.SingleAsync(a => a.Id == authorId);

            if (Book != null)
            {
                return RedirectToPage("./AuthorDetails");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(int authorId)
        {
            Author = await _infoContext.AuthorsList.SingleAsync(a=>a.Id==authorId);
            var book = await _infoContext.BooksList.AnyAsync(b=>b.AuthorInfoId==authorId);

            if (book == false)
            {
                _infoContext.Remove(Author);
                await _infoContext.SaveChangesAsync();
            }
            else 
            {
                TempData["Message"] = $"{Author.Id} can't be deleted";

                return RedirectToPage("./AuthorDetails");
            }

            TempData["Message"] = $"{Author.FirstName} + {Author.LastName} was deleted";
            return RedirectToPage("./AuthorsList");
        }
    }
}