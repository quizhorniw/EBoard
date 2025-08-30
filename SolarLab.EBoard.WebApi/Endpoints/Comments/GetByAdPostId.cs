using MediatR;
using Microsoft.AspNetCore.Mvc;
using SolarLab.EBoard.Application.Comments.GetByAdPostId;

namespace SolarLab.EBoard.WebApi.Endpoints.Comments;

internal sealed class GetByAdPostId : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/comments",
            async ([FromQuery(Name = "postId")] Guid adPostId, IMediator mediator, CancellationToken cancellationToken) => { 
                var result = await mediator.Send(new GetCommentsByAdPostIdQuery(adPostId), cancellationToken); 
                return Results.Ok(result); 
            })
            .AllowAnonymous();
    }
}