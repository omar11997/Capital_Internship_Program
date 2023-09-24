namespace CapitalInternshipProgram.Model
{
    public class Profile
    {
        public List<Education>? Educations { get; set; }

        public List<Experience>? Experiences { get; set; }

        public string? Resume { get; set; }

        public List<Question>? Questions { get; set; }   

        public Profile Clone()
        {
            var profile = new Profile()
            {
                Resume = this.Resume,
                Educations = new List<Education>(),
                Experiences = new List<Experience>(),
                Questions = new List<Question>()
            };
            foreach (var item in this.Educations)
            {
                profile.Educations.Add(item.Clone());
            };
            foreach (var item in this.Experiences)
            {
                profile.Experiences.Add(item.Clone());
            };
            foreach (var item in this.Questions)
            {
                profile.Questions.Add(item.Clone());
            };
            return profile;
        }
    }
}
