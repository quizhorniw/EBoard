using MediatR;
using SolarLab.EBoard.Domain.Interfaces;

namespace SolarLab.EBoard.Application.AdPosts.Archive;

public sealed class ArchiveAdPostCommandHandler : IRequestHandler<ArchiveAdPostCommand>
{
    private readonly IAdPostsRepository _adPostsRepository;

    public ArchiveAdPostCommandHandler(IAdPostsRepository adPostsRepository)
    {
        _adPostsRepository = adPostsRepository;
    }

    public async Task Handle(ArchiveAdPostCommand request, CancellationToken cancellationToken)
    {
        var adPost = await _adPostsRepository.GetByIdAsync(request.AdPostId, cancellationToken);
        if (adPost == null)
        {
            throw new KeyNotFoundException("Ad post not found");
        }
        
        adPost.Archive(request.UserId);
        
        await _adPostsRepository.UpdateAsync(adPost, cancellationToken);
    }
}