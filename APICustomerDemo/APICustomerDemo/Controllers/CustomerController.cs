using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace APICustomerDemo.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        // GET api/Customer
        [HttpGet]
        public IActionResult Get()
        {
            var kundelist = _customerRepository.GetCustomersListWithCriteria();
            return Ok(kundelist);

        }


        // Put api/Customer
        [HttpPut]
        public IActionResult Put(string kundeId, string bankSamtykke)
        {
            var kunde = _customerRepository.GetCustomerById(kundeId);
            if (kunde == null)
                return BadRequest();
            kunde.SamtykkeBank = bankSamtykke;
            //TO:DO update the customer record
            return Ok(kunde);
        }
    }
}