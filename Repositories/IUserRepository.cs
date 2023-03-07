using System;
using NZ_Walks.Models.Domain;

namespace NZ_Walks.Repositories
{
	public interface IUserRepository
	{
		Task<User> AuthenticateAsync(string Username);
		Task<User> RegisterAsync(User user);
    }
}

