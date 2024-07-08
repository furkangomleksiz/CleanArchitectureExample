using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Domain.Entities
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public bool IsDone { get; set; }
        // Foreign key property
        public int UserId { get; set; }
        // Navigation property
        public User User { get; set; }
    }
}