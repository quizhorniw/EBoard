using MapsterMapper;
using MediatR;
using SolarLab.EBoard.Domain.Interfaces;

namespace SolarLab.EBoard.Application.Comments.GetByAdPostId;

public class GetCommentsByAdPostIdHandler : IRequestHandler<GetCommentsByAdPostIdQuery, IEnumerable<CommentDto>>
{
    private readonly ICommentsRepository _commentsRepository;
    private readonly IMapper _mapper;

    public GetCommentsByAdPostIdHandler(ICommentsRepository commentsRepository, IMapper mapper)
    {
        _commentsRepository = commentsRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CommentDto>> Handle(GetCommentsByAdPostIdQuery request, CancellationToken cancellationToken)
    {
        var comments = await _commentsRepository.GetByAdPostIdAsync(request.AdPostId, cancellationToken);
        return comments.Select(_mapper.Map<CommentDto>);
    }
}