using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Interfaces;

namespace ToDoApp.Persistence.Repositories
{
    public class SqlToDoRepository : IToDoRepository
    {
        private readonly ToDoDbContext _context;

        public SqlToDoRepository(ToDoDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(int userId, ToDoItem item)
        {
            var user = await _context.Users.Include(u => u.ToDoItems).FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            user.ToDoItems.Add(item);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<ToDoItem>> GetAllAsync(int userId)
        {
            var user = await _context.Users.Include(u => u.ToDoItems).FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            return user.ToDoItems.ToList();
        }
    }
}