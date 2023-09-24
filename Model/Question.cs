using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CapitalInternshipProgram.Model
{
    public class Question
    {
       public string? QuestionType { get; set; }
        public string? QuestionBody { get; set; }

        public List<string>? Choices { get; set; }

        public Question Clone()
        {
            var question = new Question()
            {
                QuestionType = this.QuestionType,
                QuestionBody = this.QuestionBody,
                Choices = new List<string>()
            };
            foreach (var item in this.Choices)
            {
                question.Choices.Add(item);
            }
            return question;
        }

    }
    //public enum Questiontype
    //{ 
    //    Paragraph,
    //    ShortAnswer,
    //    YesNo,
    //    Dropdown,
    //    MultipleChoice,
    //    Date,
    //    Number, 
    //    FileUpload,
    //}

}
