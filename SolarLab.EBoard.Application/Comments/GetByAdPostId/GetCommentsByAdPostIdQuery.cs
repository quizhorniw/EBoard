using MediatR;

namespace SolarLab.EBoard.Application.Comments.GetByAdPostId;

public sealed record GetCommentsByAdPostIdQuery(Guid AdPostId) : IRequest<IEnumerable<CommentDto>>;