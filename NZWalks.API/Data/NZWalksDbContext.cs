using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext: DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            
        }

        // DB sets
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        // Seeding
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Difficulties
            // Create values
            List<Difficulty> difficulties = new List<Difficulty>()
            {
                new Difficulty(Guid.Parse("0aea6672-cbb4-4b28-bea6-e9669f8d539b"), "Easy"),
                new Difficulty(Guid.Parse("27700281-e191-4224-83f6-f6f43b214ec8"), "Medium"),
                new Difficulty(Guid.Parse("3b296bbb-77a3-4e78-b5ec-83949ee8cc35"), "Hard"),
            };

            // Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Sene data for Regions
            List<Region> regions = new List<Region>()
            {
                new Region(Guid.Parse("99993186-f760-41a1-ac29-420c4ca655e6"),"AKL", "Auckland", 
                "@https://images.pexels.com/photos/19575680/pexels-photo-19575680/free-photo-of-mount-victoria-in-auckland-seen-from-the-harbour-in-new-zealand.jpeg"),
                new Region(Guid.Parse("04b3ca23-cf37-41e3-a084-4576e4e1f7ea"), "NTL", "Norhtland"),
                new Region(Guid.Parse("c84fd593-6643-48cc-9f08-9a5a558d86b6"), "BOP", "Bay of Plenty"),
                new Region(Guid.Parse("2750e89c-b283-4340-89a5-18748a068b31"), "WGN", "Wellington",
                @"https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"),
                new Region
                {
                    Id = Guid.Parse("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("f077a22e-4248-4bf6-b564-c7cf4e250263"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = null
                },
            };

            modelBuilder.Entity<Region>().HasData(regions);


        }
    }
}
