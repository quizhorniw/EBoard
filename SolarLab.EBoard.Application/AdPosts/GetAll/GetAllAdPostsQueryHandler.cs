using MapsterMapper;
using MediatR;
using SolarLab.EBoard.Domain.Interfaces;

namespace SolarLab.EBoard.Application.AdPosts.GetAll;

public sealed class GetAllAdPostsQueryHandler : IRequestHandler<GetAllAdPostsQuery, IEnumerable<AdPostDto>>
{
    private readonly IAdPostsRepository _adPostsRepository;
    private readonly IMapper _mapper;

    public GetAllAdPostsQueryHandler(IAdPostsRepository adPostsRepository, IMapper mapper)
    {
        _adPostsRepository = adPostsRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AdPostDto>> Handle(GetAllAdPostsQuery request, CancellationToken cancellationToken)
    {
        var result = await _adPostsRepository.GetAllAsync(cancellationToken);
        return result.Select(_mapper.Map<AdPostDto>);
    }
}