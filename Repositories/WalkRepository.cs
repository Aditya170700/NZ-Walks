using System;
using Microsoft.EntityFrameworkCore;
using NZ_Walks.Data;
using NZ_Walks.Models.Domain;

namespace NZ_Walks.Repositories
{
	public class WalkRepository : IWalkRepository
	{
        private readonly AppDbContext _appDbContext;

        public WalkRepository(AppDbContext appDbContext)
		{
            _appDbContext = appDbContext;
        }

        public async Task<Walk> AddAsync(Walk walk)
        {
            walk.Id = Guid.NewGuid();

            await _appDbContext.AddAsync(walk);
            await _appDbContext.SaveChangesAsync();

            return walk;
        }

        public async Task<Walk> DeleteByIdAsync(Walk walk)
        {
            _appDbContext.Walks.Remove(walk);
            await _appDbContext.SaveChangesAsync();

            return walk;


        }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await _appDbContext.Walks
                .Include(w => w.Region)
                .Include(w => w.WalkDifficulty)
                .ToListAsync();
        }

        public async Task<Walk> GetByIdAsync(Guid Id)
        {
            return await _appDbContext.Walks
                .Include(w => w.Region)
                .Include(w => w.WalkDifficulty)
                .FirstOrDefaultAsync(w => w.Id == Id);
        }

        public async Task<Walk> UpdateAsync(Walk walk, Walk updateWalkRequest)
        {
            walk.Name = updateWalkRequest.Name;
            walk.Length = updateWalkRequest.Length;
            walk.RegionId = updateWalkRequest.RegionId;
            walk.WalkDifficultyId = updateWalkRequest.WalkDifficultyId;

            await _appDbContext.SaveChangesAsync();

            return walk;
        }
    }
}

