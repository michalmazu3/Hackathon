using Hackathon.Garbage.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Garbage.Dal.DbContexts
{
    public class FloraDbContext : DbContext
    {
        // Add-Migration -Name "" -Project "Hackathon.Garbage.Dal" -StartupProject "Hackathon.Garbage.Api"
        // Update-Database -Project "Hackathon.Garbage.Dal" -StartUpProject "Hackathon.Garbage.Api"
        // Remove-Migration -Project "Hackathon.Garbage.Dal" -StartupProject "Hackathon.Garbage.Api
        public FloraDbContext(DbContextOptions<FloraDbContext> options)
               : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FieldEntity>().
                HasMany(x => x.Cordinates).
                WithOne(x => x.Field);
        }

        public DbSet<CordinatesEntity> Cordinates { get; set; }
        public DbSet<FieldEntity> Fields { get; set; }
        public DbSet<ExecutiveEntity> Executives { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<RatingEntity> Ratings { get; set; }

    }
}
