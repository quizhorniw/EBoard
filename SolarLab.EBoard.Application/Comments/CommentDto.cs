namespace SolarLab.EBoard.Application.Comments;

public sealed record CommentDto(Guid Id, Guid AdPostId, Guid UserId, string Text);