using System;
using System.Collections.Generic;
using System.Threading;
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
            //Add request to a queue and serve the webrequest as First in first out way
            RequestQueue.Queue.Enqueue(Guid.NewGuid());
            var kundelist = new List<Kunde>();

            var s = RequestQueue.Queue;
            //run a foreach and serve as FIFO way
            foreach (var queuenr in RequestQueue.Queue)
            {
                kundelist = _customerRepository.GetCustomersListWithCriteria();
                Thread.Sleep(10000);
                var exitqueuenr = queuenr;
                //Delete the Queue nr after response is served. 
                RequestQueue.Queue.TryDequeue(out exitqueuenr);
            }
            return kundelist;
        }

        [HttpGet("{kundeId}", Name = "GetById")]
        public IActionResult GetById(string kundeId)
        {
            var kunde = _customerRepository.GetCustomerById(kundeId);
            if (kunde == null)
                return NotFound();
            return Ok(kunde);
        }


        // Put api/Customer
        [HttpPut]
        public IActionResult Put(string kundeId, string bankSamtykke)
        {
            var kunde = _customerRepository.UpdateCustomer(kundeId, bankSamtykke);
            if (kunde == null)
                return NotFound();
            //TO:DO update the customer record in reality
            //for now i am returning just the object back
            return Ok(kunde);
        }
    }
}