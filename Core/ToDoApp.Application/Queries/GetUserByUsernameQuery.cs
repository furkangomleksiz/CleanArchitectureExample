using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.Queries
{
    public class GetUserByUsernameQuery : IRequest<User>
    {
        public string Username { get; }
        public GetUserByUsernameQuery(string username)
        {
            Username = username;
        }
    }
}