using NZWalks.API.Models.Domain;

namespace NZWalks.API.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public String? WalkImageUrl { get; set; }
        public Guid DifficultyId { get; set; }

        public Guid RegionId { get; set; }

        // Navigation Properties
        public Difficulty Difficulty { get; set; }
        public Region Region { get; set; }
    }
}
