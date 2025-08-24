using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolarLab.EBoard.Application.AdPosts.Create;
using SolarLab.EBoard.Application.AdPosts.Delete;
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
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<AdPost>>> GetAll(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllAdPostsQuery(), cancellationToken);
        return Ok(result);
    }
    
    [HttpGet("{adPostId:guid}")]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<AdPost>>> GetById(Guid adPostId, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAdPostByIdQuery(adPostId), cancellationToken);
        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Guid>> Create(CreateAdPostCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { adPostId = result }, result);
    }

    [HttpPut("{adPostId:guid}")]
    [Authorize]
    public async Task<ActionResult> Update(Guid adPostId, UpdateAdPostCommand command, CancellationToken cancellationToken)
    {
        if (adPostId != command.AdPostId)
            return BadRequest("Id mismatch");
        
        await _mediator.Send(command, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{adPostId:guid}")]
    [Authorize]
    public async Task<ActionResult> Delete(Guid adPostId, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteAdPostCommand(adPostId), cancellationToken);
        return NoContent();
    }
}