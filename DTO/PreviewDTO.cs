using System.ComponentModel.DataAnnotations;
using CapitalInternshipProgram.Model;

namespace CapitalInternshipProgram.DTO
{
    public class PreviewDTO
    {
        public string? Tilte { get; set; }
        public string? Summary { get; set; }

        public string? Description { get; set; }
        public string? Benefits { get; set; }

        public string? ApplicationCriteria { get; set; }
        public string? CoverImage { get; set; }

        public string? ProgramLocation { get; set; }
        public DateTime? ApplicationOpen { get; set; }
        
        public DateTime? ApplicationClose { get; set; }

        public string? ProgramDuration { get; set; }
        public DateTime? ProgramStart { get; set; }

        public PreviewDTO(MyProgram program, AppTemp appTemp) 
        {
            CopyCommonProps(program);
            this.CoverImage = appTemp.CoverImage;
        }
        public PreviewDTO(MyProgram program) 
        {
            CopyCommonProps(program);
        }
        private void CopyCommonProps(MyProgram program)
        {
            this.Tilte = program.Title;
            this.Summary = program.Summary;
            this.Description = program.Description;
            this.ApplicationCriteria = program.ApplicationCriteria;
            this.Benefits = program.Benefits;
            this.ApplicationOpen = program.ApplicationOpen;
            this.ApplicationClose = program.ApplicationClose;
            this.ProgramDuration = program.ProgramDuration;
            this.ProgramStart = program.ProgramStart;
        }

    }
}
