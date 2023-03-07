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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<RoleUser>()
				.HasOne(x => x.Role)
				.WithMany(y => y.RoleUsers)
				.HasForeignKey(x => x.RoleId);
            modelBuilder.Entity<RoleUser>()
                .HasOne(x => x.User)
                .WithMany(y => y.RoleUsers)
                .HasForeignKey(x => x.UserId);
        }

		public DbSet<Region> Regions { get; set; }
		public DbSet<WalkDifficulty> WalkDifficultys { get; set; }
		public DbSet<Walk> Walks { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<RoleUser> RoleUsers { get; set; }
    }
}

