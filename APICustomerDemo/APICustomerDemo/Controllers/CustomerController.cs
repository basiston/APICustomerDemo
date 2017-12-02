using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        // GET api/values
        [HttpGet]
        public IEnumerable<Kunde> Get()
        {
            return _kundeservice.GetKundeList().Where(x=>x.ValidFromDttm > new DateTime(2010,12,31) && x.KundeAns!=null);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
