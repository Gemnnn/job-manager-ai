using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class City
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public int ProvinceId { get; set; }
        public Province Province { get; set; } = null!;

        public ICollection<Location> Locations { get; set; } = new List<Location>();
    }

}
