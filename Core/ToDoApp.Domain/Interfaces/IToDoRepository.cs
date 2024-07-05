using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Domain;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Domain.Interfaces
{
    public interface IToDoRepository
    {
        Task<List<ToDoItem>> GetAllAsync();
        Task<int> CreateAsync(ToDoItem item);
        // Other methods as needed
    }
}