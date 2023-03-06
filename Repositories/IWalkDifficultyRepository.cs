using System;
using NZ_Walks.Models.Domain;

namespace NZ_Walks.Repositories
{
	public interface IWalkDifficultyRepository
	{
		Task<IEnumerable<WalkDifficulty>> GetAllAsync();
		Task<WalkDifficulty> GetByIdAsync(Guid Id);
		Task<WalkDifficulty> AddAsync(WalkDifficulty walkDifficulty);
		Task<WalkDifficulty> UpdateAsync(WalkDifficulty walkDifficulty, WalkDifficulty updateWalkDifficultyRequest);
		Task<WalkDifficulty> DeleteAsync(WalkDifficulty walkDifficulty);
	}
}

