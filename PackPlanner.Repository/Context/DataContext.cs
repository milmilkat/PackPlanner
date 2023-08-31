using Microsoft.EntityFrameworkCore;
using PackPlanner.Models.Entities;

namespace PackPlanner.Repository.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Item> Items => Set<Item>();
        public DbSet<Pack> Packs => Set<Pack>();

        public DataContext(): base() 
        {
            this.Seed();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "PackPlannerDb");
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pack>().HasData(
                new Pack
                {
                    Id = 1
                });

            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Id = 1,
                    Length = 1,
                    Quantity = 1,
                    Weight = 1,
                    //Pack = Packs.First(p => p.Id == 1)
                });
        }
    }
}
