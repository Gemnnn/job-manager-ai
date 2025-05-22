namespace backend.Models
{
    public class Industry
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Job> Jobs { get; set; } = new List<Job>();
    }
}
