using System;
namespace NZ_Walks.Models.Dto.Auth
{
	public class RegisterResponse
	{
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

