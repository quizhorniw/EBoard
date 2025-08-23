using MediatR;
using SolarLab.EBoard.Domain.AdPosts;

namespace SolarLab.EBoard.Application.AdPosts.GetById;

public sealed record GetAdPostByIdQuery(Guid AdPostId) : IRequest<AdPost?>;