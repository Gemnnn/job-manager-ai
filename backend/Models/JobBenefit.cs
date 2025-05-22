namespace backend.Models
{
    public class JobBenefit
    {
        public int JobId { get; set; }
        public Job Job { get; set; } = null!;

        public int BenefitId { get; set; }
        public Benefit Benefit { get; set; } = null!;
    }
}
