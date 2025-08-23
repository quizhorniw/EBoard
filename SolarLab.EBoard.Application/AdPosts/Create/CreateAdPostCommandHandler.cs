using MediatR;
using SolarLab.EBoard.Domain.AdPosts;
using SolarLab.EBoard.Domain.Interfaces;

namespace SolarLab.EBoard.Application.AdPosts.Create;

public sealed class CreateAdPostCommandHandler : IRequestHandler<CreateAdPostCommand, Guid>
{
    private readonly IAdPostsRepository _adPostsRepository;

    public CreateAdPostCommandHandler(IAdPostsRepository adPostsRepository)
    {
        _adPostsRepository = adPostsRepository;
    }

    public async Task<Guid> Handle(CreateAdPostCommand request, CancellationToken cancellationToken)
    {
        var adPost = new AdPost(
            request.UserId,
            request.Title,
            request.Description,
            request.Price
            );
        
        await _adPostsRepository.AddAsync(adPost, cancellationToken);
        return adPost.Id;
    }
}