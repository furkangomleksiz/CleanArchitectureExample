// File: ToDoApp.Persistence/InMemoryToDoRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Interfaces;

public class InMemoryToDoRepository : IToDoRepository
{
    private static readonly List<ToDoItem> _items = new List<ToDoItem>();

    public Task<int> CreateAsync(ToDoItem item)
    {
        _items.Add(item);
        item.Id = _items.Count; // Assign a simple incrementing ID
        return Task.FromResult(item.Id);
    }

    public Task<List<ToDoItem>> GetAllAsync()
    {
        return Task.FromResult(_items);
    }
}