using Mapster;
using MapsterMapper;
using MediatR;
using SolarLab.EBoard.Application.Abstractions.Authentication;
using SolarLab.EBoard.Domain.AdPosts;
using SolarLab.EBoard.Domain.Interfaces;

namespace SolarLab.EBoard.Application.AdPosts.Create;

public sealed class CreateAdPostCommandHandler : IRequestHandler<CreateAdPostCommand, Guid>
{
    private readonly IAdPostsRepository _adPostsRepository;
    private readonly IUserContext _userContext;
    private readonly IMapper _mapper;

    public CreateAdPostCommandHandler(IAdPostsRepository adPostsRepository, IUserContext userContext, IMapper mapper)
    {
        _adPostsRepository = adPostsRepository;
        _userContext = userContext;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateAdPostCommand request, CancellationToken cancellationToken)
    {
        var adPost = _mapper.Map<AdPost>(request);
        adPost.SetUserId(_userContext.UserId);
        
        await _adPostsRepository.AddAsync(adPost, cancellationToken);
        return adPost.Id;
    }
}