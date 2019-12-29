using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bandymas.Entities
{
    public class BookInfo
    {
        public BookInfo(int ibin, string title, BookType type)
        {
            IBIN = ibin;
            Title = title;
            Type = type;
        }

        public int IBIN { get; set; }

        public string Title { get; set; }

        public BookType Type { get; set; } 
    }
}
