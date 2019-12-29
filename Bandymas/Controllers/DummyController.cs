using Bandymas.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bandymas.Controllers
{
    public class DummyController:Controller
    {
        private BooksInfoContext ctx;
        public DummyController(BooksInfoContext _ctx)
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
