using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bandymas.Models
{
    public class SignIn
    {
        [Required(ErrorMessage ="Have to supplay username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Have to supplay password")]
        public string Password { get; set; }
    }
}
