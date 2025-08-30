using MapsterMapper;
using MediatR;
using SolarLab.EBoard.Application.Comments.Create;

namespace SolarLab.EBoard.WebApi.Endpoints.Comments;

internal sealed class Create : IEndpoint
{
    internal sealed record Request(Guid AdPostId, string Text);
    
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/comments",
            async (Request request, IMediator mediator, IMapper mapper, CancellationToken cancellationToken) =>
            {
                var command = mapper.Map<CreateCommentCommand>(request);
                var result = await mediator.Send(command, cancellationToken);
                return Results.CreatedAtRoute(GetById.EndpointName, new { Id = result }, result);
            })
            .RequireAuthorization();
    }
}