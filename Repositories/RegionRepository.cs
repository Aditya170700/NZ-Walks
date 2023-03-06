using System;
using Microsoft.EntityFrameworkCore;
using NZ_Walks.Data;
using NZ_Walks.Models.Domain;

namespace NZ_Walks.Repositories
{
	public class RegionRepository : IRegionRepository
	{
        private readonly AppDbContext _appDbContext;

        public RegionRepository(AppDbContext appDbContext)
		{
            _appDbContext = appDbContext;
        }

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();

            await _appDbContext.AddAsync(region);
            await _appDbContext.SaveChangesAsync();

            return region;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _appDbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetByIdAsync(Guid Id)
        {
            return await _appDbContext.Regions.FirstOrDefaultAsync(r => r.Id == Id);
        }

        public async Task<Region> DeleteAsync(Region region)
        {
            _appDbContext.Regions.Remove(region);
            await _appDbContext.SaveChangesAsync();

            return region;
        }

        public async Task<Region> UpdateAsync(Region region, Region updateRegionRequest)
        {
            region.Code = updateRegionRequest.Code;
            region.Name = updateRegionRequest.Name;
            region.Area = updateRegionRequest.Area;
            region.Lat = updateRegionRequest.Lat;
            region.Long = updateRegionRequest.Long;
            region.Population = updateRegionRequest.Population;

            await _appDbContext.SaveChangesAsync();

            return region;
        }
    }
}

