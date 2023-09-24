using System.ComponentModel.DataAnnotations;
using CapitalInternshipProgram.DTO;
using Newtonsoft.Json;

namespace CapitalInternshipProgram.Model
{
    public class MyProgram
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Program Title is required.")]
        public string? Title { get; set; }

        public string? Summary { get; set; }
        [Required(ErrorMessage = "Program Description is required.")]
        public string? Description { get; set; }

        public string? RequiredSkills { get; set; }

        public string? Benefits { get; set; }

        public string? ApplicationCriteria { get; set; }
        [Required(ErrorMessage = "Program Type is required.")]
        public string? ProgramType { get; set; }    

        public DateTime? ProgramStart { get; set; }
        [Required(ErrorMessage = "Application Date is required.")]
        public DateTime? ApplicationOpen { get; set;}
        [Required(ErrorMessage = "Application Close Date is required.")]
        public DateTime? ApplicationClose { get; set; }

        public string? ProgramDuration { get; set; }
        [Required(ErrorMessage = "Program Location is required.")]
        public string? ProgramLocation { get; set; }

        public bool FullyRemotly { get; set; }
        public string? ProgramQulification { get; set; }

        public int MaxNumberOfApplication { get; set; }
        public MyProgram()
        {

        }
        public MyProgram(ProgramToAddDTO newprogram)
        {
            this.Id = Guid.NewGuid();
            this.Title = newprogram.Title;
            this.Summary = newprogram.Summary;
            this.Description = newprogram.Description;
            this.RequiredSkills = newprogram.RequiredSkills;
            this.Benefits=newprogram.Benefits;  
            this.ApplicationCriteria = newprogram.ApplicationCriteria;
            this.ProgramType = newprogram.ProgramType;
            this.ProgramStart = newprogram.ProgramStart;    
            this.ApplicationOpen= newprogram.ApplicationOpen;   
            this.ApplicationClose = newprogram.ApplicationClose;
            this.ProgramDuration = newprogram.ProgramDuration;  
            this.ProgramLocation = newprogram.ProgramLocation;  
            this.FullyRemotly = newprogram.FullyRemotly;
            this.ProgramQulification= newprogram.ProgramQulification;   
            this.MaxNumberOfApplication= newprogram.MaxNumberOfApplication; 
        }

    }
}
