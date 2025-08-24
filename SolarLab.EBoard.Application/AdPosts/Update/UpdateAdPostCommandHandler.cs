using MediatR;
using SolarLab.EBoard.Application.Abstractions.Authentication;
using SolarLab.EBoard.Domain.Interfaces;

namespace SolarLab.EBoard.Application.AdPosts.Update;

public sealed class UpdateAdPostCommandHandler : IRequestHandler<UpdateAdPostCommand>
{
    private readonly IAdPostsRepository _adPostsRepository;
    private readonly IUserContext _userContext;

    public UpdateAdPostCommandHandler(IAdPostsRepository adPostsRepository, IUserContext userContext)
    {
        _adPostsRepository = adPostsRepository;
        _userContext = userContext;
    }

    public async Task Handle(UpdateAdPostCommand request, CancellationToken cancellationToken)
    {
        
        var adPost = await _adPostsRepository.GetByIdAsync(request.AdPostId, cancellationToken);
        if (adPost == null)
        {
            throw new KeyNotFoundException("Ad post not found");
        }

        if (_userContext.UserId != adPost.UserId)
        {
            throw new UnauthorizedAccessException("No permission to update this ad post");
        }
        
        adPost.UpdateDetails(request.Title, request.Description, request.Price);
        
        await _adPostsRepository.UpdateAsync(adPost, cancellationToken);
    }
}