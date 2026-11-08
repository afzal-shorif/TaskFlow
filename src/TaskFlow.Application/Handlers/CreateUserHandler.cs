using MediatR;
using TaskFlow.Infrastructure;
using TaskFlow.Application.Commands;
using TaskFlow.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace TaskFlow.Application.Handlers;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
	private readonly AppDbContext _db;
	private readonly IPasswordHasher<UserEntity> _passwordHasher;

	public CreateUserCommandHandler(AppDbContext db, IPasswordHasher<UserEntity> passwordHasher)
	{
		_db = db;
		_passwordHasher = passwordHasher;
	}

	public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
	{

		var user = new UserEntity
		{
			Id = Guid.Empty,
			Name = request.Name,
			Email = request.Email,
			Password = "",
			CreatedAt = DateTimeOffset.UtcNow,
		};

		var hashedPassword = _passwordHasher.HashPassword(user, request.Password);
		user.Password = hashedPassword;

		await _db.AddAsync(user);
		await _db.SaveChangesAsync();

		return user.Id;
	}
}
