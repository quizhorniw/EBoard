using MediatR;
using SolarLab.EBoard.Domain.AdPosts;
using SolarLab.EBoard.Domain.Interfaces;

namespace SolarLab.EBoard.Application.AdPosts.GetAll;

public sealed class GetAllAdPostsQueryHandler : IRequestHandler<GetAllAdPostsQuery, IEnumerable<AdPost>>
{
    private readonly IAdPostsRepository _adPostsRepository;

    public GetAllAdPostsQueryHandler(IAdPostsRepository adPostsRepository)
    {
        _adPostsRepository = adPostsRepository;
    }

    public async Task<IEnumerable<AdPost>> Handle(GetAllAdPostsQuery request, CancellationToken cancellationToken)
    {
        return await _adPostsRepository.GetAllAsync(cancellationToken);
    }
}