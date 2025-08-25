using MediatR;

namespace SolarLab.EBoard.Application.AdPosts.Delete;

public sealed record DeleteAdPostCommand(Guid Id) : IRequest;