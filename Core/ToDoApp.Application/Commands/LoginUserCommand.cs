using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ToDoApp.Application.Commands
{
    public class LoginUserCommand : IRequest<string>
{
    public string Username { get; set; }
    public string Password { get; set; }
}
}