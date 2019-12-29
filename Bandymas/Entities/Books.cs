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
        public Books(int ibin, string title, BookType type)
        {
            IBIN = ibin;
            Title = title;
            Type = type;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IBIN { get; set; }
        public string Title { get; set; }
        public BookType Type { get; set; }
    }

    public enum BookType { Horror, Romance, Adventure }
}
