using Microsoft.EntityFrameworkCore;
using Walks.API.Models.Domain;

namespace Walks.API.Data
{
    public class WalksDbContext: DbContext
    {
        public WalksDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)    
        {
        }
        public DbSet<Difficulty> Difficuties { get; set; }
        public DbSet <Region> Regions { get; set; }
        public DbSet <Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /*
             * Seed data for Difficulty
             * Easy Medium, Hard
            */
            var difficulty = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("3767c8ab-dbe7-4790-a8c7-898f8e04f988"),
                    Name = "Easy"
                },
                  new Difficulty()
                {
                    Id = Guid.Parse("2e39cca1-41f5-449b-a95b-17ffdfacae64"),
                    Name = "Mediam"
                },
                    new Difficulty()
                {
                    Id = Guid.Parse("da192823-7fe1-4a8c-bd47-b3aa6a8214ea"),
                    Name = "Hard"
                },
            };

            // seed data into DB:
            modelBuilder.Entity<Difficulty>().HasData(difficulty);

            var regions = new List<Region>()
            {
                new Region
                    {
                        Id = Guid.Parse("ee7ecbba-c423-4272-946c-444b1073a1a0"),
                        Code = "N",
                        Name = "North",
                        RegionImageUrl = "https://dummyimage.com/600x400/000/fff"
                    },
                new Region
                    {
                        Id = Guid.Parse("093dd075-bbe3-43d9-ac27-b0668c8b81c8"),
                        Code = "W",
                        Name = "West",
                        RegionImageUrl = "https://dummyimage.com/600x400/000/fff"
                    },
                new Region
                    {
                        Id = Guid.Parse("0eb161a0-47b4-4d3f-8f83-8565cb7d1d78"),
                        Code = "E",
                        Name = "East",
                        RegionImageUrl = "https://dummyimage.com/600x400/000/fff"
                    },
                new Region
                    {
                        Id = Guid.Parse("6548231d-41ca-47a6-80b5-f7ab46fe175c"),
                        Code = "S",
                        Name = "South",
                        RegionImageUrl = "https://dummyimage.com/600x400/000/fff"
                    },
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
