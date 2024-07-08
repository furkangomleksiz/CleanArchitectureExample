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

        public async Task<int> Handle(CreateToDoItemCommand request, CancellationToken cancellationToken)
        {
            var newItem = new ToDoItem
            {
                Description = request.Description,
                IsDone = request.IsDone
            };

            return await _toDoRepository.CreateAsync(request.UserId, newItem);
        }
    }
}
