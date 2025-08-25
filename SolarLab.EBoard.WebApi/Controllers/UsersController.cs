using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolarLab.EBoard.Application.Users.GetById;
using SolarLab.EBoard.Application.Users.Login;
using SolarLab.EBoard.Application.Users.Register;
using SolarLab.EBoard.WebApi.Users;

namespace SolarLab.EBoard.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public UsersController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("{id:guid}")]
    [Authorize]
    public async Task<ActionResult<UserResponse?>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetUserByIdQuery(id), cancellationToken);
        if (result is null)
        {
            return NotFound();
        }
        var response = _mapper.Map<UserResponse>(result);
        return Ok(response);
    }

    [HttpPost("[action]")]
    [AllowAnonymous]
    public async Task<ActionResult<Guid>> Register(RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<RegisterUserCommand>(request); 
        var result = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { userId = result }, result);
    }

    [HttpPost("[action]")]
    [AllowAnonymous]
    public async Task<ActionResult<string?>> Login(LoginUserRequest request, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<LoginUserCommand>(request);
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}