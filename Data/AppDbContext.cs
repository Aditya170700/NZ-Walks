using System;
using Microsoft.EntityFrameworkCore;
using NZ_Walks.Models.Domain;

namespace NZ_Walks.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Region> Regions { get; set; }
		public DbSet<WalkDifficulty> WalkDifficultys { get; set; }
		public DbSet<Walk> Walks { get; set; }
    }
}

