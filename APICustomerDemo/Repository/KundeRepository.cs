using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ExcelDataReader;

namespace Repository
{
    public class KundeRepository : IKundeRepository
    {
        private const string Filepath =
            @"C:\\Users\\Basiston\\Desktop\\DAT-3447_Anonymisert_kundetabell_historisert_RS161212_v1.xls";
        public List<Kunde> GetKundeList()
        {
            var fs = File.Open(Filepath, FileMode.Open, FileAccess.Read);
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
}
