using NZWalks.API.Models.Domain;
using System.Runtime.InteropServices;

namespace NZWalks.API.Repositories
{
    public interface IRegionRepository
    {
        // GET REQUEST
        Task<List<Region>> GetAllAsync();

        Task<Region> GetByIdAsync(Guid id);

        // POST
        Task<Region> CreateAsync(Region region);

        // Update
        Task<Region?> UpdateAsync(Guid id, Region region);

        // Delete
        Task<Region?> DeleteAsync(Guid id);
    }
}
