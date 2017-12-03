using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface ICustomerRepository
    {
        List<Kunde> GetCustomerList();
        IEnumerable<Kunde> GetCustomersListWithCriteria();
        Kunde GetCustomerById(string customerId);
    }
}
