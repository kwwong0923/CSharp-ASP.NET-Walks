using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class InMemoryRegionRepository
    {
        public async Task<List<Region>> GetAllAsync()
        {
            return new List<Region>()
            {
                new Region(Guid.NewGuid(), "SAM", "Sameer's Region"),
                new Region(Guid.NewGuid(), "KAI", "Kai's Region"),
            };
                
        }
    }
}
