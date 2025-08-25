using MediatR;
using SolarLab.EBoard.Application.Abstractions.Authentication;
using SolarLab.EBoard.Domain.Interfaces;

namespace SolarLab.EBoard.Application.AdPosts.Delete;

public sealed class DeleteAdPostCommandHandler : IRequestHandler<DeleteAdPostCommand>
{
    private readonly IAdPostsRepository _adPostsRepository;
    private readonly IUserContext _userContext;
    
    public DeleteAdPostCommandHandler(IAdPostsRepository adPostsRepository, IUserContext userContext)
    {
        _adPostsRepository = adPostsRepository;
        _userContext = userContext;
    }

    public async Task Handle(DeleteAdPostCommand request, CancellationToken cancellationToken)
    {
        var adPost = await _adPostsRepository.GetByIdAsync(request.Id, cancellationToken);
        if (adPost is null) return;
        
        if (!_userContext.IsInRole("Admin") && _userContext.UserId != adPost.UserId)
        {
            throw new UnauthorizedAccessException("No permission to delete this ad post");
        }
        
        await _adPostsRepository.DeleteAsync(request.Id, cancellationToken);
    }
}