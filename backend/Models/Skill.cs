using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Skill
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public ICollection<RequiredSkill> RequiredSkills { get; set; } = new List<RequiredSkill>();
    }
}
