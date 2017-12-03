using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace APICustomerDemo.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly IKundeRepository _kundeRepository;

        public CustomerController(IKundeRepository kundeRepository)
        {
            _kundeRepository = kundeRepository;
        }

        // GET api/Customer
        [HttpGet]
        public IActionResult Get()
        {
            var kundelist = _kundeRepository.GetKundeList()
                .Where(x => x.ValidFromDttm > new DateTime(2010, 12, 31) && x.KundeAns != null);
            return Ok(kundelist);
        }

        // Put api/Customer
        [HttpPut]
        public IActionResult Put(string kundeId, string bankSamtykke)
        {
            var kunde = _kundeRepository.GetKundeList().SingleOrDefault(x => x.KundeNrAnomymisert == kundeId);
            if (kunde == null)
                return BadRequest();
            kunde.SamtykkeBank = bankSamtykke;
            return Ok(kunde);
        }
    }
}