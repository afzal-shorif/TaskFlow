using MediatR;
using TaskFlow.Model;
using TaskFlow.Domain.Entities;
using TaskFlow.Application.Commands;
using TaskFlow.Infrastructure;
using Microsoft.AspNetCore.Identity;

public class MatchUserCredCommandHandler : IRequestHandler<MatchUserCredCommand, UserDto>
{
	private readonly AppDbContext _db;
	private readonly IPasswordHasher<UserEntity> _passwordHasher;

	public MatchUserCredCommandHandler(AppDbContext db, IPasswordHasher<UserEntity> passwordHasher)
	{
		_db = db;
		_passwordHasher = passwordHasher;
	}

	public async Task<UserDto> Handle(MatchUserCredCommand request, CancellationToken cancellationToken)
	{

		var user = _db.Users.FirstOrDefault(u => u.Email == request.Email);

		if (user == null)
		{
			return null;
		}

		var pwVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.Password, request.Password);

		if (pwVerificationResult == PasswordVerificationResult.Failed)
		{
			return null;
		}

		var userDto = new UserDto()
		{
			Id = user.Id,
			Email = user.Email,
			Name = user.Name
		};

		return userDto;
	}
}
