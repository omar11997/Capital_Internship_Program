namespace CapitalInternshipProgram.Model
{
    public class PersonalInfo
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Nationality { get; set; }
        public string? CurrentResidence { get; set; }

        public string? IdNumber { get; set; }

        public DateTime BirthDay { get; set; }

        public string? Gender { get; set; }

        public List<Question>? Questions { get; set; }

        public PersonalInfo Clone()
        {
            var clone = new PersonalInfo()
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
                Phone = this.Phone,
                Nationality = this.Nationality,
                CurrentResidence = this.CurrentResidence,
                IdNumber = this.IdNumber,
                BirthDay = this.BirthDay,
                Gender = this.Gender,
                Questions = new List<Question>()
            };
            foreach (var item in this.Questions)
            {
                clone.Questions.Add(item.Clone());
            }
            return clone;

        }

    }
}
