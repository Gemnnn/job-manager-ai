using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Country
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public ICollection<Province> Provinces { get; set; } = new List<Province>();
    }

}
