using System;
using Microsoft.EntityFrameworkCore;
using NZ_Walks.Data;
using NZ_Walks.Models.Domain;

namespace NZ_Walks.Repositories
{
	public class UserRepository : IUserRepository
	{
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
		{
            _appDbContext = appDbContext;
        }

        public async Task<User> AuthenticateAsync(string Username, string Password)
        {
            var user = await _appDbContext.Users
                .Include(u => u.RoleUsers)
                .ThenInclude(ru => ru.Role)
                .FirstOrDefaultAsync(x => x.Username.ToLower() == Username.ToLower() && x.Password == Password);

            if (user == null)
            {
                throw new Exception("Username or password is incorrect");
            }

            if (user.RoleUsers.Count > 0)
            {
                user.Roles = new List<string>();
                user.RoleUsers.ForEach((ru) =>
                {
                    user.Roles.Add(ru.Role.Name);
                });
            }

            user.Password = null;
            return user;
        }
    }
}

