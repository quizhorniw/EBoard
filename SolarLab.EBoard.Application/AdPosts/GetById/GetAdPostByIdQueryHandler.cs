using MediatR;
using SolarLab.EBoard.Domain.AdPosts;
using SolarLab.EBoard.Domain.Interfaces;

namespace SolarLab.EBoard.Application.AdPosts.GetById;

public sealed class GetAdPostByIdQueryHandler : IRequestHandler<GetAdPostByIdQuery, AdPost?>
{
    private readonly IAdPostsRepository _adPostsRepository;

    public GetAdPostByIdQueryHandler(IAdPostsRepository adPostsRepository)
    {
        _adPostsRepository = adPostsRepository;
    }

    public async Task<AdPost?> Handle(GetAdPostByIdQuery request, CancellationToken cancellationToken)
    {
        return await _adPostsRepository.GetByIdAsync(request.AdPostId, cancellationToken);
    }
}