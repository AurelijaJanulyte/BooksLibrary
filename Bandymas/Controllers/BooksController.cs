using Bandymas.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Bandymas.Controllers
{
    [Route("books")]
    public class BooksController : Controller
    {
        private readonly BooksInfoContext _context;

        public BooksController(BooksInfoContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public IActionResult GetBooks()
        {
            var booksList = _context.BooksList.Include(a=>a.AuthorInfo).ToList();
            return Ok(booksList);
        }

        [HttpGet("{ibin}")]
        public IActionResult GetBook(int ibin)
        {
            var findBook = _context.BooksList.SingleOrDefault(b => b.IBIN == ibin);

            if (findBook == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(findBook);
            }
        }

        [HttpPost()]
        public IActionResult CreateBook([FromBody] BookToCreate newBook)
        {
            if (ModelState.IsValid)
            {
                _context.BooksList.Add(new Books(newBook.IBIN.Value, newBook.Title, newBook.Type.Value,newBook.AuthorId));
                _context.SaveChanges();
                return Ok();
            }
            else
                return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] BookToUpdate correctedBook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var oldBook = _context.BooksList.SingleOrDefault(b => b.Id == id);

            if (oldBook == null)
            {
                return NotFound();
            }

            oldBook.Title = correctedBook.Title;
            oldBook.IBIN = correctedBook.IBIN.Value;
            oldBook.Type = correctedBook.Type.Value;
            oldBook.AuthorInfoId = correctedBook.AuthorId;
            _context.SaveChanges();
            return Ok();

        }

        [HttpDelete("{ibin}")]
        public IActionResult DeleteBook(int ibin)
        {
            var oldBook = _context.BooksList.SingleOrDefault(b => b.IBIN == ibin);
            if (oldBook != null)
            {
                _context.BooksList.Remove(oldBook);
                _context.SaveChanges();
            }

            return NoContent();
        }

    }
}
