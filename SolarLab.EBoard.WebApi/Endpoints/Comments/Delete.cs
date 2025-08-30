using MediatR;
using SolarLab.EBoard.Application.Comments.Delete;

namespace SolarLab.EBoard.WebApi.Endpoints.Comments;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("/comments/{id:guid}", 
            async (Guid id, IMediator mediator, CancellationToken cancellationToken) => 
            {
                await mediator.Send(new DeleteCommentCommand(id), cancellationToken);
                return Results.NoContent();
            })
            .RequireAuthorization();
    }
}