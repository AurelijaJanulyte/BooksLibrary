using Bandymas.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bandymas.Entities
{
    public class Books
    {
        private Books()
        {
        }

        public Books(int ibin, string title, BookType type,int authorId)
        {
            AuthorInfoId = authorId;
            IBIN = ibin;
            Title = title;
            Type = type;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int IBIN { get; set; }
        [Required]
        public string Title { get; set; }
        public BookType Type { get; set; }
        public int AuthorInfoId { get; set; }
        public AuthorInfo AuthorInfo { get; set; }
    }

    public enum BookType { None,Horror, Romance, Adventure }
}
