using System.Threading.Tasks;

namespace Lab.Quiz.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IMultipleAnswerQuestionRepository MultipleAnswerQuestionRepository { get; set; }
        IOpenAnswerQuestionRepository OpenAnswerQuestionRepository { get; set; }
        IProgramCodeQuestionRepository ProgramCodeQuestionRepository { get; set; }
        IQuestionRepository QuestionRepository { get; set; }
        IQueuedProgramRepository QueuedProgramRepository { get; set; }
        ISingleSelectionQuestionRepository SingleSelectionQuestionRepository { get; set; }
        ITestRepository TestRepository { get; set; }
        ITestRunRepository TestRunRepository { get; set; }

        Task SaveAsync();
    }
}
