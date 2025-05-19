namespace backend.Models
{
    public class Location
    {
        public int Id { get; set; }

        public int CityId { get; set; }
        public City City { get; set; } = null!;

        public ICollection<Job> Jobs { get; set; } = new List<Job>();
    }

}
