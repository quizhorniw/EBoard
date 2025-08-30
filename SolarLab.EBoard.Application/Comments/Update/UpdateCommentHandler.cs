using MapsterMapper;
using MediatR;
using SolarLab.EBoard.Application.Abstractions.Authentication;
using SolarLab.EBoard.Domain.Interfaces;

namespace SolarLab.EBoard.Application.Comments.Update;

public sealed class UpdateCommentHandler : IRequestHandler<UpdateCommentCommand>
{
    private readonly ICommentsRepository _commentsRepository;
    private readonly IUserContext _userContext;
    private readonly IMapper _mapper;

    public UpdateCommentHandler(ICommentsRepository commentsRepository, IUserContext userContext, IMapper mapper)
    {
        _commentsRepository = commentsRepository;
        _userContext = userContext;
        _mapper = mapper;
    }

    public async Task Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _commentsRepository.GetByIdAsync(request.Id, cancellationToken);
        if (comment is null)
        {
            throw new KeyNotFoundException("Comment not found");
        }

        if (!_userContext.IsInRole("Admin") && _userContext.UserId != comment.UserId)
        {
            throw new UnauthorizedAccessException("No permission to update this comment");
        }
        
        comment.ChangeText(request.Text);
        await _commentsRepository.UpdateTextAsync(comment, cancellationToken);
    }
}