namespace backend.Models
{
    public enum EmploymentType
    {
        FullTime,
        PartTime,
        Contract,
        Internship,
        Freelance,
        Temporary
    }

    public enum WorkArrangementType
    {
        InPerson,
        Remote,
        Hybrid
    }

    public enum JobStatus
    {
        Applied,
        AwaitingResponse,
        PhoneInterview,
        Assessment,
        Offer,
        Rejected
    }

}
