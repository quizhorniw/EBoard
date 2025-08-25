using MapsterMapper;
using MediatR;
using SolarLab.EBoard.Domain.AdPosts;
using SolarLab.EBoard.Domain.Interfaces;

namespace SolarLab.EBoard.Application.AdPosts.GetById;

public sealed class GetAdPostByIdQueryHandler : IRequestHandler<GetAdPostByIdQuery, AdPostDto?>
{
    private readonly IAdPostsRepository _adPostsRepository;
    private readonly IMapper _mapper;

    public GetAdPostByIdQueryHandler(IAdPostsRepository adPostsRepository, IMapper mapper)
    {
        _adPostsRepository = adPostsRepository;
        _mapper = mapper;
    }

    public async Task<AdPostDto?> Handle(GetAdPostByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _adPostsRepository.GetByIdAsync(request.Id, cancellationToken);
        return result is not null ? _mapper.Map<AdPost, AdPostDto>(result) : null;
    }
}