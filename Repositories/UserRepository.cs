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

        public async Task<User> AuthenticateAsync(string Username)
        {
            var user = await _appDbContext.Users
                .Include(u => u.RoleUsers)
                .ThenInclude(ru => ru.Role)
                .FirstOrDefaultAsync(x => x.Username == Username);

            if (user.RoleUsers.Count > 0)
            {
                user.Roles = new List<string>();
                user.RoleUsers.ForEach((ru) =>
                {
                    user.Roles.Add(ru.Role.Name);
                });
            }

            return user;
        }

        public async Task<User> RegisterAsync(User user)
        {
            user.Id = Guid.NewGuid();

            _appDbContext.AddAsync(user);
            await _appDbContext.SaveChangesAsync();

            return user;
        }
    }
}

