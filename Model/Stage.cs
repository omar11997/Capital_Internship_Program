namespace CapitalInternshipProgram.Model
{
    public class Stage
    {

        public string? StageName { get; set; }

        public string? StageType { get; set;}

        public bool ShowStage { get; set; }

        public Stage Clone()
        {
            return new Stage
            {
                StageName = this.StageName,
                StageType = this.StageType,
                ShowStage = this.ShowStage
            };
        }
    }
    //public enum StageType {
    //    Shortlisting,
    //    VideoInterview,
    //    Placement
    //}

}
