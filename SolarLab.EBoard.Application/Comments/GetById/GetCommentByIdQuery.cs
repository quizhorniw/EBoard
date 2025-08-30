using MediatR;

namespace SolarLab.EBoard.Application.Comments.GetById;

public sealed record GetCommentByIdQuery(Guid Id) : IRequest<CommentDto?>;