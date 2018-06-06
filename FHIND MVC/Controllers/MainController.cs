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

            List<Student> students = database.GetAllStudents(); // SELECT * FROM student

            return View(students);
        }
    }
}