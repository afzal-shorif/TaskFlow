using MediatR;
using TaskFlow.Model;

public record GetUserForLoginQuery(
    string Email
) : IRequest<UserDto>;
