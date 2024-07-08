using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ToDoApp.Domain;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Interfaces;
namespace ToDoApp.Application.Queries
{
    public class ToDoItemQueryHandler : IRequestHandler<ToDoItemQuery, List<ToDoItem>>
    {
        private readonly IToDoRepository _toDoRepository;

        public ToDoItemQueryHandler(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public async Task<List<ToDoItem>> Handle(ToDoItemQuery request, CancellationToken cancellationToken)
        {
            return await _toDoRepository.GetAllAsync(request.UserId);
        }
    }
}