using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FHIND_MVC.Models;

namespace FHIND_MVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]

        public ActionResult Authorize()
        {
            //Authorize user and redirect if authorized...
            return View();
        }
    }
}