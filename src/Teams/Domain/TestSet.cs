using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Composition.Convention;
using System.Linq;
using System.Threading.Tasks;

namespace Teams.Domain
{
    public class TestSet : Entity
    {
        [ForeignKey("TestRunId")] public ICollection<TestRun> TestRuns { get; private set; }
        [ForeignKey("AnsweredQuestionId")] public ICollection<Question> AnsweredQuestions { get; private set; }

        public TestSet(ICollection<TestRun> testRuns)
        {
            TestRuns = testRuns;
        }

        public void QuestionAnswered(Question question)
        {
            AnsweredQuestions.Add(question);
        }
    }
}
