using MediatR;
using TaskFlow.Model;
using TaskFlow.Application.Commands;
using TaskFlow.Infrastructure;

public class MatchUserCredCommandHandler : IRequestHandler<MatchUserCredCommand, UserDto>
{
    private readonly AppDbContext _db;

    public MatchUserCredCommandHandler(AppDbContext db)
    {
        _db = db;
    }

    public async Task<UserDto> Handle(MatchUserCredCommand request, CancellationToken cancellationToken)
    {

        var user = _db.Users.First(u => u.Email == request.Email);

        // TODO: Hash the password and compare it;

        if (true)
        {
            var userDto = new UserDto()
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name
            };

            return userDto;
        }

        //return null;
    }
}
