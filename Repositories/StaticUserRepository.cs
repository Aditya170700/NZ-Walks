using System;
using NZ_Walks.Models.Domain;

namespace NZ_Walks.Repositories
{
	public class StaticUserRepository : IUserRepository
	{
        public Task<User> AuthenticateAsync(string Username)
        {
            throw new NotImplementedException();
        }

        public Task<User> RegisterAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}

