using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolarLab.EBoard.Application.Categories.Create;
using SolarLab.EBoard.Application.Categories.Delete;
using SolarLab.EBoard.Application.Categories.GetAll;
using SolarLab.EBoard.Application.Categories.GetById;
using SolarLab.EBoard.Application.Categories.Update;
using SolarLab.EBoard.WebApi.Categories;

namespace SolarLab.EBoard.WebApi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CategoriesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<CategoryResponse>>> GetCategories(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllCategoriesQuery(), cancellationToken);
        var response = result.Select(_mapper.Map<CategoryResponse>);
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    public async Task<ActionResult<CategoryResponse?>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetCategoryByIdQuery(id), cancellationToken);
        if (result is null)
        {
            return NotFound();
        }
        
        var response = _mapper.Map<CategoryResponse>(result);
        return Ok(response);
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> Create(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<CreateCategoryCommand>(request);
        var result = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result }, result);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> Update(Guid id, UpdateCategoryRequest request, 
        CancellationToken cancellationToken)
    {
        var command = request.Adapt<UpdateCategoryCommand>() with { Id = id };
        await _mediator.Send(command, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteCategoryCommand(id), cancellationToken);
        return NoContent();
    }
}