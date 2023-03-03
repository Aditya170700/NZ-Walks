using System;
using NZ_Walks.Models.Domain;

namespace NZ_Walks.Repositories
{
	public interface IRegionRepository
	{
		Task<IEnumerable<Region>> GetAllAsync();
	}
}

