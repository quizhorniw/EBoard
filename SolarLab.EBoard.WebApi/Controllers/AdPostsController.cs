using MediatR;
using Microsoft.AspNetCore.Mvc;
using SolarLab.EBoard.Application.AdPosts.Archive;
using SolarLab.EBoard.Application.AdPosts.Create;
using SolarLab.EBoard.Application.AdPosts.GetAll;
using SolarLab.EBoard.Application.AdPosts.GetById;
using SolarLab.EBoard.Application.AdPosts.Update;
using SolarLab.EBoard.Domain.AdPosts;

namespace SolarLab.EBoard.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdPostsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AdPostsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AdPost>>> GetAll(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllAdPostsQuery(), cancellationToken);
        return Ok(result);
    }
    
    [HttpGet("{adPostId:guid}")]
    public async Task<ActionResult<IEnumerable<AdPost>>> GetById(Guid adPostId, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAdPostByIdQuery(adPostId), cancellationToken);
        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateAdPostCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { adPostId = result }, result);
    }

    [HttpPut("{adPostId:guid}")]
    public async Task<ActionResult> Update(Guid adPostId, UpdateAdPostCommand command, CancellationToken cancellationToken)
    {
        if (adPostId != command.AdPostId)
            return BadRequest("Id mismatch");
        
        await _mediator.Send(command, cancellationToken);
        return NoContent();
    }

    // TODO: Retrieve UserId from JWT
    [HttpDelete("{adPostId:guid}")]
    public async Task<ActionResult> Archive(Guid adPostId, Guid userId, CancellationToken cancellationToken)
    {
        await _mediator.Send(new ArchiveAdPostCommand(adPostId, userId), cancellationToken);
        return NoContent();
    }
}