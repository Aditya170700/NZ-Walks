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

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _appDbContext.Regions.ToListAsync();
        }
    }
}

