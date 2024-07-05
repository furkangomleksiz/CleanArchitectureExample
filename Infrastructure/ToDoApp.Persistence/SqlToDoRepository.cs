using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Interfaces;

namespace ToDoApp.Persistence
{
    public class SqlToDoRepository : IToDoRepository
    {
        private readonly ToDoDbContext _context;

        public SqlToDoRepository(ToDoDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(ToDoItem item)
        {
            _context.ToDoItems.Add(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        public async Task<List<ToDoItem>> GetAllAsync()
        {
            return await _context.ToDoItems.ToListAsync();
        }
    }
}