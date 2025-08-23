using MediatR;
using SolarLab.EBoard.Domain.Interfaces;

namespace SolarLab.EBoard.Application.AdPosts.Delete;

public sealed class DeleteAdPostCommandHandler : IRequestHandler<DeleteAdPostCommand>
{
    private readonly IAdPostsRepository _adPostsRepository;

    public DeleteAdPostCommandHandler(IAdPostsRepository adPostsRepository)
    {
        _adPostsRepository = adPostsRepository;
    }

    public async Task Handle(DeleteAdPostCommand request, CancellationToken cancellationToken)
    {
        await _adPostsRepository.DeleteAsync(request.AdPostId, cancellationToken);
    }
}