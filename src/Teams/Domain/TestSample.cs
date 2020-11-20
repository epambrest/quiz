using System.ComponentModel.DataAnnotations.Schema;

namespace Teams.Domain
{
    public class TestSample : Entity
    {
        [ForeignKey("Question")]
        public Question SampleQuestion { get; set; }
        [ForeignKey("Answers")]
        public Answers SampleAnswers { get; set; }
        public bool IsCorrect { get; private set; }

        public void VerifyAnswer(Answers sampleAnswers)
        {
            SampleAnswers = sampleAnswers;
            IsCorrect = SampleAnswers.Equals(SampleQuestion.CorrectAnswers);
        }
    }
}
