using System;
using Microsoft.EntityFrameworkCore;
using NZ_Walks.Data;
using NZ_Walks.Models.Domain;

namespace NZ_Walks.Repositories
{
	public class WalkDifficultyRepository : IWalkDifficultyRepository
	{
        private readonly AppDbContext _appDbContext;

        public WalkDifficultyRepository(AppDbContext appDbContext)
		{
            _appDbContext = appDbContext;
        }

        async Task<WalkDifficulty> IWalkDifficultyRepository.AddAsync(WalkDifficulty walkDifficulty)
        {
            walkDifficulty.Id = Guid.NewGuid();
            await _appDbContext.AddAsync(walkDifficulty);
            await _appDbContext.SaveChangesAsync();

            return walkDifficulty;
        }

        async Task<WalkDifficulty> IWalkDifficultyRepository.DeleteAsync(WalkDifficulty walkDifficulty)
        {
            _appDbContext.WalkDifficultys.Remove(walkDifficulty);
            await _appDbContext.SaveChangesAsync();

            return walkDifficulty;
        }

        async Task<IEnumerable<WalkDifficulty>> IWalkDifficultyRepository.GetAllAsync()
        {
            return await _appDbContext.WalkDifficultys.ToListAsync();
        }

        async Task<WalkDifficulty> IWalkDifficultyRepository.GetByIdAsync(Guid Id)
        {
            return await _appDbContext.WalkDifficultys.FirstOrDefaultAsync(w => w.Id == Id);
        }

        async Task<WalkDifficulty> IWalkDifficultyRepository.UpdateAsync(WalkDifficulty walkDifficulty, WalkDifficulty updateWalkDifficultyRequest)
        {
            walkDifficulty.Name = updateWalkDifficultyRequest.Name;
            await _appDbContext.SaveChangesAsync();

            return walkDifficulty;
        }
    }
}

