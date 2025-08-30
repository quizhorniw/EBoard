using MediatR;

namespace SolarLab.EBoard.Application.Comments.Delete;

public sealed record DeleteCommentCommand(Guid Id) : IRequest;