using Microsoft.EntityFrameworkCore;
using Walks.API.Data;
using Walks.API.Models.Domain;

namespace Walks.API.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly WalksDbContext dbContext;

        public SQLRegionRepository(WalksDbContext dbConext)
        {
            this.dbContext = dbConext;
            
        }
        public async Task<Region> createAsync(Region region)
        {
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> deleteAsync(Guid id)
        {
            var existinRegion = await dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
            if(existinRegion == null)
            {
                return null;
            }
            
            dbContext.Regions.Remove(existinRegion);
            await dbContext.SaveChangesAsync();

            return null;
            }

        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Region?> updateAsync(Guid id, Region region)
        {
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
            if (existingRegion == null) {
                return null;
            }
            
            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.RegionImageUrl = region.RegionImageUrl;
            
            await dbContext.SaveChangesAsync();
            return existingRegion;
        }
    }
}
