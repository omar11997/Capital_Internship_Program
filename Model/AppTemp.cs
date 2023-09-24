using CapitalInternshipProgram.DTO;
using Newtonsoft.Json;

namespace CapitalInternshipProgram.Model
{
    public class AppTemp
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        public Guid ProgrameId { get; set; }

        public string? CoverImage { get; set; }
        
        
        public PersonalInfo? PersonalInfo { get; set; }
        
        public Profile? Profile { get; set; }
        public AppTemp() { }
        public AppTemp(AppTempToAddDto appTempToAddDto) 
        {
            this.CoverImage = appTempToAddDto.CoverImage;
            this.PersonalInfo = appTempToAddDto.PersonalInfo.Clone();
            this.Profile = appTempToAddDto.Profile.Clone();
        }
    }
}
