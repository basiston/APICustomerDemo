using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICustomerDemo.Models;

namespace APICustomerDemo.Services
{
    public interface IKundeService
    {
        List<Kunde> GetKundeList();
    }
}
