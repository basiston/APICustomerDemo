using System;
using System.Collections.Generic;
using System.Text;
using Repository.Models;

namespace Repository
{
    public interface ICustomerRepository
    {
        List<Kunde> GetCustomerList();
        List<Kunde> GetCustomersListWithCriteria();
        Kunde GetCustomerById(string customerId);
        Kunde UpdateCustomer(string customerId, string bankAgreement);
    }
}
