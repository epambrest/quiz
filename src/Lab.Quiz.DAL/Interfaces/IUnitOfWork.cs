using Lab.Quiz.DAL.Entities;
using System.Threading.Tasks;

namespace Lab.Quiz.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Question> QuestionsRepository{ get; }
        IRepository<Answer> AnswersRepository { get; }
        IRepository<OpenAnswerQuestion> OpenAnswerQuestionsRepository { get; }
        IRepository<SingleSelectionQuestion> SingleSelectionQuestionsRepository { get; }
        IRepository<MultipleAnswerQuestion> MultipleAnswerQuestionsRepository { get; }
        IRepository<ProgramCodeQuestion> ProgramCodeQuestionsRepository { get; }
        IRepository<TestQuestion> TestQuestionsRepository { get; }
        IRepository<QuizCardDALModel> QuizCardRepository { get; }
        IRepository<TestRun> TestRunsRepository { get; }
        IRepository<QueuedProgram> QueuedProgramsRepository { get; }
        Task SaveAsync();
    }
}
