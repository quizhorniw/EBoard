using MediatR;

namespace SolarLab.EBoard.Application.AdPosts.GetAll;

public sealed record GetAllAdPostsQuery : IRequest<IEnumerable<AdPostDto>>;