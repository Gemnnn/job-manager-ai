﻿namespace backend.Models
{
    public class RequiredSkill
    {
        public int JobId { get; set; }
        public Job Job { get; set; } = null!;

        public int SkillId { get; set; }
        public Skill Skill { get; set; } = null!;
    }
}
