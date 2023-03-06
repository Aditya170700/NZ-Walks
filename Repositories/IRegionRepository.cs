using System;
using NZ_Walks.Models.Domain;

namespace NZ_Walks.Repositories
{
	public interface IRegionRepository
	{
		Task<IEnumerable<Region>> GetAllAsync();
		Task<Region> GetByIdAsync(Guid Id);
		Task<Region> AddAsync(Region region);
		Task<Region> DeleteAsync(Region region);
		Task<Region> UpdateAsync(Region region, Region updateRegionRequest);
	}
}

