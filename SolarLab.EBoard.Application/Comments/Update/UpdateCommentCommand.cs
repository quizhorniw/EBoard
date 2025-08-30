using MediatR;

namespace SolarLab.EBoard.Application.Comments.Update;

public sealed record UpdateCommentCommand(Guid Id, string Text) : IRequest;