using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FHIND_MVC.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            //something.
            return View();
        }
    }
}