using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace APICustomerDemo.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        


        // GET api/Customer
        [HttpGet]
        public IActionResult Get()
        {
            
            return Ok();

        }
        
    }
}