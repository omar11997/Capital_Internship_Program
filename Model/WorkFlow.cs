using CapitalInternshipProgram.DTO;
using Newtonsoft.Json;

namespace CapitalInternshipProgram.Model
{
    public class WorkFlow
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        public Guid ProgramId { get; set; }

        public List<Stage> Stages { get; set; } = new List<Stage>();
        public WorkFlow() { }

        public WorkFlow(WorkFlowToAddDTO workFlowToAddDTO) 
        {
            this.Stages = workFlowToAddDTO.Clone();
        }
    }
}
