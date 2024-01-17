namespace NZWalks.API.Models.DTO
{
    public class RegionDto
    {
        public Guid Id { get; set; }
        public String Code { get; set; }
        public String Name { get; set; }
        public String? RegionImageUrl { get; set; }

        public RegionDto()
        { 
        
        }

        public RegionDto(Guid id, String Code, String Name)
        {
            this.Id = id;
            this.Code = Code;
            this.Name = Name;
        }

        public RegionDto(Guid id, String Code, String Name, String RegionImageUrl): this(id, Code, Name) 
        {
            this.RegionImageUrl = RegionImageUrl;
        }

    }
}
