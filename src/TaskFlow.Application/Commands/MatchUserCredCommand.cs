using TaskFlow.Model;
using MediatR;

namespace TaskFlow.Application.Commands;

public record MatchUserCredCommand(
    string Email,
    string Password
) : IRequest<UserDto>;
