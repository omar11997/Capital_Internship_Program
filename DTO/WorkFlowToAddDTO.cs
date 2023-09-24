using CapitalInternshipProgram.Model;

namespace CapitalInternshipProgram.DTO
{
    public class WorkFlowToAddDTO
    {
        public List<Stage> Stages { get; set; } = new List<Stage>();

        public List<Stage> Clone()
        {
            var workFlow = new List<Stage>();
            foreach (var item in this.Stages)
            {
                workFlow.Add(item.Clone());
            }
            return workFlow;
        }
    }
}
