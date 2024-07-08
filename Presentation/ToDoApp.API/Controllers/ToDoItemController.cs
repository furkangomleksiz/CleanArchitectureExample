// File: ToDoApp.API/Controllers/ToDoItemController.cs
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoApp.Application.Commands;
using ToDoApp.Application.Queries;

[Route("api/[controller]")]
[ApiController]
public class ToDoItemController : ControllerBase
{
    private readonly IMediator _mediator;

    public ToDoItemController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Get()
    {
        var userId = int.Parse(User.FindFirst("id").Value); // Assuming the user's ID is stored in the token
        var result = await _mediator.Send(new ToDoItemQuery { UserId = userId });
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Post([FromBody] CreateToDoItemCommand command)
    {
        var userId = int.Parse(User.FindFirst("id").Value); // Assuming the user's ID is stored in the token
        command.UserId = userId;
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(Get), new { id = result }, null);
    }
}
