using System;
using System.Collections.Generic;
using System.Text;
using ClassLibraryFHIND.Data;

namespace ClassLibraryFHIND.Entities
{
    public class Lokaal
    {
        public string LokaalNummer { get; set; }

        public int Verdieping { get; set; }

        public List<Student> aanwezigeStudenten { get; set; }

        public Lokaal(string lokaalnummer, int verdieping, List<Student> AlleStudenten)
        {
            DatabaseConnection db = new DatabaseConnection();

            LokaalNummer = lokaalnummer;
            Verdieping = verdieping;
            aanwezigeStudenten = db.getStudentsOfCurrentTime(AlleStudenten, lokaalnummer);
        }
    }
}
