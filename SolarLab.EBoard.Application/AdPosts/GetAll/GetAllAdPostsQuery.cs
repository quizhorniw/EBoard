using MediatR;
using SolarLab.EBoard.Domain.AdPosts;

namespace SolarLab.EBoard.Application.AdPosts.GetAll;

public sealed record GetAllAdPostsQuery : IRequest<IEnumerable<AdPost>>;