using Microsoft.AspNetCore.Mvc;
using MediatR;
using TaskFlow.Model;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Registr([FromBody] CreateAccountDto create)
    {
        var userId = _mediator.Send(new CreateUserCommand(create.Name, create.Email, create.Password));

        if (userId == null)
        {
            return BadRequest();
        }

        return Created(userId);
    }

    [HttpPost("login")]
    public async Task Login([FromBody] LoginDto login)
    {

    }
}
