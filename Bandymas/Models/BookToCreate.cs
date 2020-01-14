using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bandymas.Models
{
    public class BookToCreate
    {
        public int Id { get; set; }
        [Required]
        public int? IBIN { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public BookType? Type { get; set; }
        [Required]
        public int AuthorId { get; set; }
    }
}
