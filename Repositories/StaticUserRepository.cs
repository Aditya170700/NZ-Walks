using System;
using NZ_Walks.Models.Domain;

namespace NZ_Walks.Repositories
{
	public class StaticUserRepository : IUserRepository
	{
        private List<User> Users = new List<User>()
        {
            //new User()
            //{
            //    FirstName = "Read Only",
            //    LastName = "User",
            //    Email = "readonlyuser@gmail.com",
            //    Id = Guid.NewGuid(),
            //    Username = "readonlyuser@gmail.com",
            //    Password = "Readonly@user",
            //    Roles = new List<string> { "reader" },
            //},
            //new User()
            //{
            //    FirstName = "Read Write",
            //    LastName = "User",
            //    Email = "readwriteuser@gmail.com",
            //    Id = Guid.NewGuid(),
            //    Username = "readwriteuser@gmail.com",
            //    Password = "Readwrite@user",
            //    Roles = new List<string> { "reader", "writer" },
            //},
        };

        public async Task<User> AuthenticateAsync(string Username, string Password)
        {
            return Users.Find(x => x.Username.Equals(Username, StringComparison.InvariantCultureIgnoreCase) &&
                x.Password == Password);
        }
    }
}

