using System;
using NZ_Walks.Models.Domain;

namespace NZ_Walks.Repositories
{
	public interface ITokenHandler
	{
		Task<string> CreateTokenAsync(User user);
	}
}

