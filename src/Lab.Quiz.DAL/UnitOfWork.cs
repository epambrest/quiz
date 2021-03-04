using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Lab.Quiz.DAL.Interfaces;

namespace Lab.Quiz.DAL
{
    public sealed class UnitOfWork : IUnitOfWork ,IDisposable
    {
        private readonly ApplicationDbContext _dbContext;
        public IMultipleAnswerQuestionRepository MultipleAnswerQuestionRepository { get; set; }
        public IOpenAnswerQuestionRepository OpenAnswerQuestionRepository { get; set; }
        public IProgramCodeQuestionRepository ProgramCodeQuestionRepository { get; set; }
        public IQuestionRepository QuestionRepository { get; set; }
        public IQueuedProgramRepository QueuedProgramRepository { get; set; }
        public ISingleSelectionQuestionRepository SingleSelectionQuestionRepository { get; set; }
        public ITestRepository TestRepository { get; set; }
        public ITestRunRepository TestRunRepository { get; set; }

        private bool _disposed;

        public UnitOfWork(IMultipleAnswerQuestionRepository multipleAnswerQuestionRepository,
            IOpenAnswerQuestionRepository openAnswerQuestionRepository, 
            IProgramCodeQuestionRepository programCodeQuestionRepository,
            IQuestionRepository questionRepository,
            IQueuedProgramRepository queuedProgramRepository,
            ISingleSelectionQuestionRepository singleSelectionQuestionRepository,
            ITestRepository testRepository,
            ITestRunRepository testRunRepository, ApplicationDbContext dbContext)
        {
            MultipleAnswerQuestionRepository = multipleAnswerQuestionRepository;
            OpenAnswerQuestionRepository = openAnswerQuestionRepository;
            ProgramCodeQuestionRepository = programCodeQuestionRepository;
            QuestionRepository = questionRepository;
            QueuedProgramRepository = queuedProgramRepository;
            SingleSelectionQuestionRepository = singleSelectionQuestionRepository;
            TestRepository = testRepository;
            TestRunRepository = testRunRepository;

            _dbContext = dbContext;
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                _dbContext.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
