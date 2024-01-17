namespace NZWalks.API.Models.DTO
{
    public class AddWalkRequestDto
    {
        public String Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public String? WalkImageUrl { get; set; }
        public Guid RegionId { get; set; }
        public Guid DifficultId { get; set; }
    }
}
