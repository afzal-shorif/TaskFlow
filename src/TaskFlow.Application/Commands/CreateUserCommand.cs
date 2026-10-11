using MediatR;

namespace TaskFlow.Application.Commands;

public record CreateUserCommand(
    string Name,
    string Email,
    string Password
) : IRequest<Guid>;
