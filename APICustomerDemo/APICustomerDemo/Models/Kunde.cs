using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICustomerDemo.Models
{
    public class Kunde
    {
        public string KundeNrAnomymisert { get; set; }
        public DateTime? ValidFromDttm { get; set; }
        public string PostNr { get; set; }
        public string PostSted { get; set; }
        public string KundeAns { get; set; }
        public int? BankId { get; set; }
        public string SamtykkeForsikring { get; set; }
        public string SamtykkeBank { get; set; }
    }
}
