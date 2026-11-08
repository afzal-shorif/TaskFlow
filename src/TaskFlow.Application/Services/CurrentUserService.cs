using Microsoft.AspNetCore.Http;
using TaskFlow.Model;

namespace TaskFlow.Application.Service;

public class CurrentUserService : ICurrentUserService
{
	private readonly IHttpContextAccessor _httpContextAccessor;

	public CurrentUserService(IHttpContextAccessor httpContextAccessor)
	{
		_httpContextAccessor = httpContextAccessor;
	}


	public UserDto User
	{
		get
		{
			var claimPrincipal = _httpContextAccessor.HttpContext.User;

			var userDto = new UserDto();
			userDto.Id = Guid.Parse(claimPrincipal.FindFirst(c => c.Type == "ID").Value);
			userDto.Email = claimPrincipal.FindFirst(c => c.Type == "Email").Value;
			userDto.Name = claimPrincipal.FindFirst(c => c.Type == "Name").Value;

			return userDto;
		}
	}
}
