using MediatR;
using SolarLab.EBoard.Domain.Interfaces;

namespace SolarLab.EBoard.Application.AdPosts.Update;

public sealed class UpdateAdPostCommandHandler : IRequestHandler<UpdateAdPostCommand>
{
    private readonly IAdPostsRepository _adPostsRepository;

    public UpdateAdPostCommandHandler(IAdPostsRepository adPostsRepository)
    {
        _adPostsRepository = adPostsRepository;
    }

    public async Task Handle(UpdateAdPostCommand request, CancellationToken cancellationToken)
    {
        var adPost = await _adPostsRepository.GetByIdAsync(request.AdPostId, cancellationToken);
        if (adPost == null)
        {
            throw new KeyNotFoundException("Ad post not found");
        }
        
        adPost.UpdateDetails(request.Title, request.Description, request.Price);
        
        await _adPostsRepository.UpdateAsync(adPost, cancellationToken);
    }
}