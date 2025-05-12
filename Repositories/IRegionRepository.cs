using Walks.API.Models.Domain;

namespace Walks.API.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
        Task<Region?> GetByIdAsync(Guid id);
        Task<Region> createAsync(Region region);
        Task<Region?> updateAsync(Guid id, Region region);
        Task<Region?> deleteAsync(Guid id);
    }
}
