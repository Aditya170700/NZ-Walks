﻿using System;
namespace NZ_Walks.Models.Dto.Auth
{
	public class RegisterRequest
	{
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

