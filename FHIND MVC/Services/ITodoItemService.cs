using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FHIND_MVC.Models;

namespace FHIND_MVC.Services
{
    public interface ITodoItemService
    {
        Task<TodoItem[]> GetIncompleteItemsAsync();
    }
}