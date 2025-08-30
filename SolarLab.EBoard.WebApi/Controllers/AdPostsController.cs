using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolarLab.EBoard.Application.AdPosts.Create;
using SolarLab.EBoard.Application.AdPosts.Delete;
using SolarLab.EBoard.Application.AdPosts.GetAll;
using SolarLab.EBoard.Application.AdPosts.GetById;
using SolarLab.EBoard.Application.AdPosts.Update;
using SolarLab.EBoard.WebApi.AdPosts;

namespace SolarLab.EBoard.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdPostsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AdPostsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<AdPostResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllAdPostsQuery(), cancellationToken);
        var response = result.Select(_mapper.Map<AdPostResponse>);
        return Ok(response);
    }
    
    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    public async Task<ActionResult<AdPostResponse>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAdPostByIdQuery(id), cancellationToken);
        if (result is null)
        {
            return NotFound();
        }
        
        var response = _mapper.Map<AdPostResponse>(result);
        return Ok(response);
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Guid>> Create(CreateAdPostRequest request, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<CreateAdPostCommand>(request);
        var result = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result }, result);
    }

    [HttpPut("{id:guid}")]
    [Authorize]
    public async Task<ActionResult> Update(Guid id, UpdateAdPostRequest request, CancellationToken cancellationToken)
    {
        var command = request.Adapt<UpdateAdPostCommand>() with { Id = id };
        await _mediator.Send(command, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [Authorize]
    public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteAdPostCommand(id), cancellationToken);
        return NoContent();
    }
}