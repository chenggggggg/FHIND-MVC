using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FHIND_MVC.Models
{
    public class LoginViewModel    
    {
        [Key]        

        [Required(ErrorMessage = "This field is required.")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required.")]
        public string Wachtwoord { get; set; }
    }
}
