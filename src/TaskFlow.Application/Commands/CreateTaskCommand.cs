using MediatR;

namespace TaskFlow.Application.Commands;

public record CreateTaskCommand(
    string Title,
    string? Description
) : IRequest<Guid>;
