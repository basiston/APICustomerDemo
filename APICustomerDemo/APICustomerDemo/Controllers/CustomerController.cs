using System;
using System.Linq;
using APICustomerDemo.Models;
using APICustomerDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace APICustomerDemo.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly IKundeService _kundeservice;

        public CustomerController(IKundeService kundeservice)
        {
            _kundeservice = kundeservice;
        }

        // GET api/Customer
        [HttpGet]
        public IActionResult Get()
        {
            var kundelist = _kundeservice.GetKundeList()
                .Where(x => x.ValidFromDttm > new DateTime(2010, 12, 31) && x.KundeAns != null);
            return Ok(kundelist);
        }

        // GET api/Customer/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // Put api/Customer
        [HttpPut]
        public void Post(Kunde kunde)
        {
        }
    }
}