using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolarLab.EBoard.Application.Users.GetById;
using SolarLab.EBoard.Application.Users.Login;
using SolarLab.EBoard.Application.Users.Register;
using SolarLab.EBoard.Domain.Users;

namespace SolarLab.EBoard.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{userId:guid}")]
    [Authorize]
    public async Task<ActionResult<User?>> GetById(Guid userId, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetUserByIdQuery(userId), cancellationToken);
        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost("[action]")]
    [AllowAnonymous]
    public async Task<ActionResult<Guid>> Register(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { userId = result }, result);
    }

    [HttpPost("[action]")]
    [AllowAnonymous]
    public async Task<ActionResult<string?>> Login(LoginUserCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}