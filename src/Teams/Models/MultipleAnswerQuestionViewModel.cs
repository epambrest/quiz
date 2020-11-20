using Teams.Domain;

namespace Teams.Models
{
    public class MultipleAnswerQuestionViewModel
    {
        public MultipleAnswerQuestion SourceQuestion { get; set; }
        public int[] ChosenOptions { get; set; }
    }
}
