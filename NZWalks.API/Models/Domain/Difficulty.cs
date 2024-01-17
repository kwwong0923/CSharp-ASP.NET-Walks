namespace NZWalks.API.Models.Domain
{
    public class Difficulty
    {
        public Guid Id { get; set; }
        public String Name { get; set; }

        public Difficulty() { }

        public Difficulty(String name)
        {
            this.Name = name;
        }
        public Difficulty(Guid id, String name)
        {
            this.Id = id;
            this.Name = name;
        }

    }
}
