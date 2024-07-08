// File: ToDoApp.API/Controllers/ToDoItemController.cs
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
        var usernameClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

        if (usernameClaim != null)
        {
            var username = usernameClaim.Value;
            // Use the username to retrieve ToDo items or perform other operations
            var result = await _mediator.Send(new ToDoItemQuery { Username = username });
            return Ok(result);
        }
        else
        {
            // Handle case where username claim is not found
            return BadRequest("Username claim not found in token.");
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Post([FromBody] CreateToDoItemCommand command)
    {
        // Retrieve the user's claims from the token
        var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "userId");

        if (userIdClaim != null)
        {
            var userId = int.Parse(userIdClaim.Value);
            // Assign userId to the command before sending it to the mediator
            command.UserId = userId;

            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id = result }, null);
        }
        else
        {
            // Handle case where userId claim is not found
            return BadRequest("UserId claim not found in token.");
        }
    }
}
