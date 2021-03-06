using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FHIND_MVC.Services;
using FHIND_MVC.Models;

namespace FHIND_MVC.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoItemService _todoItemService;

        public async Task<IActionResult> Index()
        {
            var items = await _todoItemService.GetIncompleteItemsAsync();

            var model = new TodoViewModel()
            {
                Items = items
            };

            return View(model);
        }

        public TodoController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

    }
}