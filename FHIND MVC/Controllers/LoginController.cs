using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FHIND_MVC.Models;
using ClassLibraryFHIND.Data;

namespace FHIND_MVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]

        public ActionResult Authorize(LoginViewModel Model)
        {
            DatabaseConnection database = new DatabaseConnection();

            if (Model.Email.Length > 0 && Model.Wachtwoord.Length > 0)
            {
                int UserID = database.GetUserID(Model.Email, Model.Wachtwoord);

                if (UserID != -1)
                {
                    //Redirect("");
                    Console.WriteLine("Userid found!");
                }
            }            
            //Redirect if authorized...
            return View();
        }
    }
}