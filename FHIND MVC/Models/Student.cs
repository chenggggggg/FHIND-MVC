using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FHIND_MVC.Models
{
    public class Student    
    {
        [Key]
        
        public int StudentID { get; set; }

        public string Voornaam { get; set; }

        public string Achternaam { get; set; }
        
        public string Tussenvoegsel { get; set; }

        public int Studentnummer { get; set; }
        
        public int Leerjaar { get; set; }
        
        public string Specialiteiten { get; set; }
        
        public int ProfielID { get; set; }
        
        public int SpecialisatieID { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        ///[RegularExpression()]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required.")]
        public string Wachtwoord { get; set; }
    }
}
