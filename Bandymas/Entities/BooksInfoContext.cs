using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bandymas.Entities
{
    public class BooksInfoContext:DbContext
    {
        public BooksInfoContext(DbContextOptions<BooksInfoContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Books> BooksList { get; set; }
        public DbSet<AuthorInfo> AuthorsList { get; set; }
    }
}
