namespace CapitalInternshipProgram.Model
{
    public class Education
    {
        public string? SchoolName { get; set; }
        public string? Degree { get; set; }

        public string? CourseName { get; set; }
        public string? StudyLocation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Education() { }
        public Education Clone()
        {
            return new Education
            {
                SchoolName = this.SchoolName,
                Degree = this.Degree,
                CourseName = this.CourseName,
                StudyLocation = this.StudyLocation,
                StartDate = this.StartDate,
                EndDate = this.EndDate,
            };
        }


    }
}
