using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Domain;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Domain.Interfaces
{
    public interface IToDoRepository
    {
        Task<int> CreateAsync(int userId, ToDoItem item);
        Task<List<ToDoItem>> GetAllAsync(string username);
        // Other methods as needed
    }
}