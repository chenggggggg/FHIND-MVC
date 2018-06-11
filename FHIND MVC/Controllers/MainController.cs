using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClassLibraryFHIND.Data;
using ClassLibraryFHIND.Entities;

namespace FHIND_MVC.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            DatabaseConnection database = new DatabaseConnection();

            List<Student> students1 = database.GetAllStudents(); // SELECT * FROM student

            List<Lokaal> lokalen = new List<Lokaal>();
            Lokaal lokaal1 = new Lokaal("2.09", 2, students1);

            List<Student> students2 = database.GetAllStudents();
            Lokaal lokaal2 = new Lokaal("2.10", 2, students2);

            List<Student> students3 = database.GetAllStudents();
            Lokaal lokaal3 = new Lokaal("2.11", 2, students3);

            lokalen.Add(lokaal1);
            lokalen.Add(lokaal2);
            lokalen.Add(lokaal3);

            return View(lokalen);
        }
        
        /*
        public IActionResult Students()
        {
            //database get studentinfo()


            return View();
        }
        */
    }
}