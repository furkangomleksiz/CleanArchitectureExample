// File: ToDoApp.API/Controllers/ToDoItemController.cs
using MediatR;
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
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new ToDoItemQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateToDoItemCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(Get), new { id = result }, null);
    }
}
