namespace NZWalks.API.Models.Domain
{
    public class Region
    {
        public Guid Id { get; set; }
        public String Code { get; set; }
        public String Name { get; set; }
        public String? RegionImageUrl { get; set; }

        public Region() { }

        public Region(Guid Id, String Code, String Name)
        {
            this.Id = Id;
            this.Code = Code;
            this.Name = Name;
        }

        public Region(Guid Id, String Code, String Name, String regionImageUrl): this(Id, Code,Name)
        {
            this.RegionImageUrl = regionImageUrl;
        }
    }
}
