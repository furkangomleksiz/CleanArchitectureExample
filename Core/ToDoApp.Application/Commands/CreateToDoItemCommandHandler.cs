// File: Core/ToDoApp.Application/Commands/CreateToDoItemCommandHandler.cs
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoApp.Application.Commands;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Interfaces;

namespace ToDoApp.Application.Commands
{
    public class CreateToDoItemCommandHandler : IRequestHandler<CreateToDoItemCommand, int>
    {
        private readonly IToDoRepository _toDoRepository;

        public CreateToDoItemCommandHandler(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public Task<int> Handle(CreateToDoItemCommand request, CancellationToken cancellationToken)
        {
            var item = new ToDoItem
            {
                Description = request.Description
            };
            return _toDoRepository.CreateAsync(item);
        }
    }
}
