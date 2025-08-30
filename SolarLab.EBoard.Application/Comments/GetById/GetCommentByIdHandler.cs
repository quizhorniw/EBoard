using MapsterMapper;
using MediatR;
using SolarLab.EBoard.Domain.Interfaces;

namespace SolarLab.EBoard.Application.Comments.GetById;

public sealed class GetCommentByIdHandler : IRequestHandler<GetCommentByIdQuery, CommentDto?>
{
    private readonly ICommentsRepository _commentsRepository;
    private readonly IMapper _mapper;

    public GetCommentByIdHandler(ICommentsRepository commentsRepository, IMapper mapper)
    {
        _commentsRepository = commentsRepository;
        _mapper = mapper;
    }

    public async Task<CommentDto?> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _commentsRepository.GetByIdAsync(request.Id, cancellationToken);
        return result is not null ? _mapper.Map<CommentDto>(result) : null;
    }
}