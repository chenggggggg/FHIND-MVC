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

        public IActionResult Main()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(LoginViewModel model)
        {
            DatabaseConnection database = new DatabaseConnection();

            if (model.Email != null && model.Wachtwoord != null)
            {
                int UserID = database.GetUserID(model.Email, model.Wachtwoord);

                if (UserID != -1)
                {

                    return RedirectToAction("Index", "Main");
                }
                else
                {
                    model.IncorrectUser = "Email or password is incorrect.";
                    return View("Index", model);
                }
            }

            return View("Index");
        }
    }
}