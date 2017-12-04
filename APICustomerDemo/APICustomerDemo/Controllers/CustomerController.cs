using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Models;

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
        public IEnumerable<Kunde> Get()
        {
           return  _customerRepository.GetCustomersListWithCriteria();
          
        }

        [HttpGet("{kundeId}", Name = "GetById")]
        public IActionResult GetById(string kundeId)
        {
            var kunde = _customerRepository.GetCustomerById(kundeId);
            if (kunde == null)
                return NotFound();
            else
                return Ok(kunde);

        }


        // Put api/Customer
        [HttpPut]
        public IActionResult Put(string kundeId, string bankSamtykke)
        {
            var kunde = _customerRepository.UpdateCustomer(kundeId,bankSamtykke);
            if (kunde == null)
                return NotFound();
            //TO:DO update the customer record in reality
            //for now i am returning just the object back
            return Ok(kunde);
        }
    }
}