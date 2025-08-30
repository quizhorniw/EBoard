using MediatR;
using SolarLab.EBoard.Application.Abstractions.Authentication;
using SolarLab.EBoard.Domain.AdPosts;
using SolarLab.EBoard.Domain.Interfaces;

namespace SolarLab.EBoard.Application.AdPosts.Create;

public sealed class CreateAdPostCommandHandler : IRequestHandler<CreateAdPostCommand, Guid>
{
    private readonly IAdPostsRepository _adPostsRepository;
    private readonly IUserContext _userContext;

    public CreateAdPostCommandHandler(IAdPostsRepository adPostsRepository, IUserContext userContext)
    {
        _adPostsRepository = adPostsRepository;
        _userContext = userContext;
    }

    public async Task<Guid> Handle(CreateAdPostCommand request, CancellationToken cancellationToken)
    {
        var adPost = new AdPost(
            _userContext.UserId,
            request.Title,
            request.Description,
            request.CategoryId,
            request.Price
            );
        adPost.SetUserId(_userContext.UserId);
        
        await _adPostsRepository.AddAsync(adPost, cancellationToken);
        return adPost.Id;
    }
}