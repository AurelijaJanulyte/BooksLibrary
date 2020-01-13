using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bandymas.Entities
{
    public class AuthorInfo
    {
        private AuthorInfo()
        {

        }
        public AuthorInfo(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
