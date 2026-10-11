using MediatR;
using TaskFlow.Infrastructure;
using TaskFlow.Application.Commands;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Handlers;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly AppDbContext _db;

    public CreateUserCommandHandler(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new UserEntity
        {
            Id = Guid.Empty,
            Name = request.Name,
            Email = request.Email,
            Password = request.Password, // TODO: We will hash later
            CreatedAt = DateTimeOffset.UtcNow,
        };

        await _db.AddAsync(user);
        await _db.SaveChangesAsync();

        return user.Id;
    }
}
