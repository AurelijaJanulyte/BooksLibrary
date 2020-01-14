using Bandymas.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bandymas.Controllers
{
    public class DummyController:Controller
    {
        private Models.BooksInfoContext ctx;
        public DummyController(Models.BooksInfoContext _ctx)
        {
            ctx = _ctx;  
        }

        [HttpGet]
        [Route("books/testdatabase")]
        public IActionResult TestDataBase() 
        {
            return Ok();
        }
    }
}
