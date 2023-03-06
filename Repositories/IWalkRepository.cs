using System;
using NZ_Walks.Models.Domain;

namespace NZ_Walks.Repositories
{
	public interface IWalkRepository
	{
		Task<IEnumerable<Walk>> GetAllAsync();
		Task<Walk> GetByIdAsync(Guid Id);
		Task<Walk> AddAsync(Walk walk);
		Task<Walk> UpdateAsync(Walk walk, Walk updateWalkRequest);
		Task<Walk> DeleteByIdAsync(Walk walk);
	}
}

