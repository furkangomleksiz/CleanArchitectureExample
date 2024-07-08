using MediatR;
using System.Collections.Generic;
using ToDoApp.Domain;
using ToDoApp.Domain.Entities; // Make sure to adjust the namespace if needed

public class ToDoItemQuery : IRequest<List<ToDoItem>>
{
    public int UserId { get; set; }
}