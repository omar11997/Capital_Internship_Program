namespace CapitalInternshipProgram.Model
{
    public class Experience
    {
        public string? CompanyName { get; set; }
        public string? Title { get; set; }

        public string? CompanyLocation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Experience() { }
        public Experience Clone()
        {
            return new Experience
            {
                CompanyLocation = this.CompanyLocation,
                CompanyName = this.CompanyName,
                Title = this.Title,
                StartDate = this.StartDate,
                EndDate = this.EndDate,
            };
        }
    }
}
