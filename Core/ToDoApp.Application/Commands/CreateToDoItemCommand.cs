using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ToDoApp.Application.Commands
{

    public class CreateToDoItemCommand : IRequest<int>
    {
        public required string Description { get; set; }
    }

}