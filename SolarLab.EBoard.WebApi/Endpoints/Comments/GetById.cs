using MediatR;
using SolarLab.EBoard.Application.Comments.GetById;

namespace SolarLab.EBoard.WebApi.Endpoints.Comments;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/comments/{id:guid}", async (Guid id, IMediator mediator, CancellationToken cancellationToken) =>
        {
            var result = await mediator.Send(new GetCommentByIdQuery(id), cancellationToken);
            return result is not null ? Results.Ok(result) : Results.NotFound();
        })
            .AllowAnonymous();
    }
}