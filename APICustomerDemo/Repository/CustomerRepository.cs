using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ExcelDataReader;
using Repository.Models;

namespace Repository
{
    public class CustomerRepository : ICustomerRepository
    {

        /// <summary>
        /// File path of excel sheet, change this with file path of location.
        /// </summary>
        private const string Filepath =
                @"C:\\Users\\basiston\\Source\\Repos\\APICustomerDemo\\APICustomerDemo\\APICustomerDemo\\Content\\DAT-3447_Anonymisert_kundetabell_historisert_RS161212_v1.xls";

        public List<Kunde> GetCustomerList()
        {
            
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (var fs = File.Open(Filepath, FileMode.Open, FileAccess.Read))
            {
                var reader = ExcelReaderFactory.CreateReader(fs);
                var kundelist = new List<Kunde>();

                var i = 0;
                while (reader.Read())
                {
                    i++;
                    if (i == 1) continue;
                    kundelist.Add(new Kunde
                    {
                        KundeNrAnomymisert = Convert.ToString(reader.GetValue(0)),
                        ValidFromDttm = Convert.ToDateTime(reader.GetValue(1)),
                        PostNr = Convert.ToString(reader.GetValue(2)),
                        PostSted = Convert.ToString(reader.GetValue(3)),
                        KundeAns = Convert.ToString(reader.GetValue(4)),
                        BankId = Convert.ToInt32(reader.GetValue(5)),
                        SamtykkeForsikring = Convert.ToString(reader.GetValue(6)),
                        SamtykkeBank = Convert.ToString(reader.GetValue(7))
                    });
                }

                return kundelist;
            }
        }

        public List<Kunde> GetCustomersListWithCriteria()
        {
            return GetCustomerList().Where(x => x.ValidFromDttm > new DateTime(2010,12,31) && x.KundeAns != null).ToList();
        }

        public Kunde GetCustomerById(string customerId)
        {
            return GetCustomerList().SingleOrDefault(x => x.KundeNrAnomymisert == customerId);
        }

        public Kunde UpdateCustomer(string customerId, string bankAgreement)
        {
            var customer = GetCustomerById(customerId);
            if (customer == null)
                return null;
            customer.SamtykkeBank = bankAgreement;
            return customer;
        }
    }
}
