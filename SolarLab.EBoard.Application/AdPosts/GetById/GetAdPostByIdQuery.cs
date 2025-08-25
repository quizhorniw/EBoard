using MediatR;

namespace SolarLab.EBoard.Application.AdPosts.GetById;

public sealed record GetAdPostByIdQuery(Guid Id) : IRequest<AdPostDto?>;