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
        private Entities.BooksInfoContext ctx;
        public DummyController(Entities.BooksInfoContext _ctx)
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
