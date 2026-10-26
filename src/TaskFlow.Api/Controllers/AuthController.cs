using Microsoft.AspNetCore.Mvc;
using MediatR;
using TaskFlow.Model;
using TaskFlow.Application.Commands;
using TaskFlow.Application.Queries;

using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;


[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IConfiguration _config;

    public AuthController(IMediator mediator, IConfiguration config)
    {
        _mediator = mediator;
        _config = config;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Registr([FromBody] CreateAccountDto create)
    {
        var userId = await _mediator.Send(new CreateUserCommand(create.Name, create.Email, create.Password));

        if (userId == null)
        {
            return BadRequest();
        }

        return Created();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto login)
    {
        var user = await _mediator.Send(new MatchUserCredCommand(login.Email, login.Password));

        if (user == null)
        {
            return NotFound();
        }

        var claims = new[]{
            new Claim("Name", user.Name),
            new Claim("Email", user.Email),
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config["jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(_config["Jwt:DurationInMinutes"])),
            signingCredentials: creds
        );

        return Ok(new JwtSecurityTokenHandler().WriteToken(token));
    }
}
