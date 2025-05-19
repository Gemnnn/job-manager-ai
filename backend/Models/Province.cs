using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Province
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public int CountryId { get; set; }
        public Country Country { get; set; } = null!;

        public ICollection<City> Cities { get; set; } = new List<City>();
    }

}
