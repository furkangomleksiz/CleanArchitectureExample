using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ToDoApp.Application.Commands
{

    public class CreateToDoItemCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }

}