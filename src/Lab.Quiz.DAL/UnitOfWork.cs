using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Lab.Quiz.DAL.Entities;
using Lab.Quiz.DAL.Interfaces;
using Lab.Quiz.DAL.Repositories;

namespace Lab.Quiz.DAL
{
    public sealed class UnitOfWork : IUnitOfWork ,IDisposable
    {
        private readonly ApplicationDbContext _dbContext;
        private Repository<Question> _QuestionsRepository;
        private Repository<Answer> _AnswersRepository;
        private Repository<OpenAnswerQuestion> _OpenAnswerQuestionsRepository;
        private Repository<SingleSelectionQuestion> _SingleSelectionQuestionsRepository;
        private Repository<MultipleAnswerQuestion> _MultipleAnswerQuestionsRepository;
        private Repository<ProgramCodeQuestion> _ProgramCodeQuestionsRepository;
        private Repository<TestQuestion> _TestQuestionsRepository;
        private Repository<Test> _TestsRepository;
        private Repository<TestRun> _TestRunsRepository;
        private Repository<QueuedProgram> _QueuedProgramsRepository;

        private bool _disposed;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<Question> QuestionsRepository => _QuestionsRepository ??= new Repository<Question>(_dbContext);
        public IRepository<Answer> AnswersRepository => _AnswersRepository ??= new Repository<Answer>(_dbContext);
        public IRepository<OpenAnswerQuestion> OpenAnswerQuestionsRepository => _OpenAnswerQuestionsRepository ??= new Repository<OpenAnswerQuestion>(_dbContext);
        public IRepository<SingleSelectionQuestion> SingleSelectionQuestionsRepository => _SingleSelectionQuestionsRepository ??= new Repository<SingleSelectionQuestion>(_dbContext);
        public IRepository<MultipleAnswerQuestion> MultipleAnswerQuestionsRepository => _MultipleAnswerQuestionsRepository ??= new Repository<MultipleAnswerQuestion>(_dbContext);
        public IRepository<ProgramCodeQuestion> ProgramCodeQuestionsRepository => _ProgramCodeQuestionsRepository ??= new Repository<ProgramCodeQuestion>(_dbContext);
        public IRepository<TestQuestion> TestQuestionsRepository => _TestQuestionsRepository ??= new Repository<TestQuestion>(_dbContext);
        public IRepository<Test> TestsRepository => _TestsRepository ??= new Repository<Test>(_dbContext);
        public IRepository<TestRun> TestRunsRepository => _TestRunsRepository ??= new Repository<TestRun>(_dbContext);
        public IRepository<QueuedProgram> QueuedProgramsRepository => _QueuedProgramsRepository ??= new Repository<QueuedProgram>(_dbContext);

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
