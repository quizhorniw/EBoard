using MediatR;

namespace SolarLab.EBoard.Application.Comments.Create;

public sealed record CreateCommentCommand(Guid AdPostId, string Text) : IRequest<Guid>;