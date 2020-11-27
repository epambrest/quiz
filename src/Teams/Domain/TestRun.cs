using System.ComponentModel.DataAnnotations.Schema;

namespace Teams.Domain
{
    public class TestRun : Entity
    {
        [ForeignKey("Question")]
        public Question SampleQuestion { get; set; }
        [ForeignKey("Answers")]
        public Answers SampleAnswers { get; set; }
        [ForeignKey("User ID")] public ApplicationUser TestedUser { get; set; }

        public TestRun(Question question, Answers answers, ApplicationUser user)
        {
            SampleQuestion = question;
            SampleAnswers = answers;
            TestedUser = user;
        }

        public bool IsCorrect { get; private set; }
        public int Attempts { get; private set; }

        public void VerifyAnswer(Answers sampleAnswers)
        {
            SampleAnswers = sampleAnswers;
            IsCorrect = SampleAnswers.Equals(SampleQuestion.CorrectAnswers);
            Attempts++;
        }
    }
}
