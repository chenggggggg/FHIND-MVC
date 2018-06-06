using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryFHIND.Entities
{
    public class Student
    {
        public int StudentID { get; set; }

        public string Email { get; set; }

        public string Wachtwoord { get; set; }

        public string Voornaam { get; set; }

        public string Achternaam { get; set; }

        public string Tussenvoegsel { get; set; }

        public int Studentnummer { get; set; }

        public int Leerjaar { get; set; }

        public string Specialiteiten { get; set; }

        public int ProfielID { get; set; }

        public int SpecialisatieID { get; set; }

        public Student(int id, string email, string wachtwoord, string voornaam, string achternaam, int studentnummer, int leerjaar)
        {

        }
        
    }
}

